using GameAI.GameHexEmpire.Models;

namespace GameAI.GameHexEmpire;

public class Bot
{
    public static List<Army> CalcArmiesProfitability(int party, Board board)
    {
        int finalProfitability(Field field, Army army)
        {
            var totalProfitability = -10000000;
            var canTakeCapital = false;
            for (var partyIndex = 0; partyIndex < board.HwPartiesCount; partyIndex++)
            {
                if (partyIndex != party)
                {
                    var profitability = -10000000;
                    // Other party still owns original capital city (party is currently owning party, capital is original owner)
                    if (board.HwPartiesCapitals[partyIndex].Party == board.HwPartiesCapitals[partyIndex].Capital)
                    {
                        profitability = field.Profitability[partyIndex];
                        if (board.HwPartiesControl[partyIndex] == "human")
                        {
                            profitability += board.Difficulty * 2;
                        }
                    }
                    // Don't betray the pact unless there are only 2 powers left, human and other power
                    if (board.HwPeace == party && partyIndex == board.Human && !board.Duel)
                    {
                        profitability -= 500;
                    }
                    // Update total profitability
                    if (totalProfitability < profitability)
                    {
                        totalProfitability = profitability;
                    }
                }
            }
            if (board.HwPeace == party && board.Human == field.Party && !board.Duel)
            {
                totalProfitability -= 500;
            }
            // Taking enemy land
            if (field.Type != Models.Type.Water && field.Party != party)
            {
                // Original enemy capital can be captured
                if (field.Type == Models.Type.Capital
                    && field.Capital == field.Party
                    && army.Count + army.Morale > field.Army.Count + field.Army.Morale)
                {
                    totalProfitability += 1000000;
                    canTakeCapital = true;
                }
                else if (field.Type == Models.Type.Capital)
                {
                    // Can attack enemy capital, but don't have enough forces to take it
                    totalProfitability += 20;
                }
                else if (field.Type == Models.Type.Town)
                {
                    // Enemy town can be taken and units can respawn
                    totalProfitability += 5;
                }
                else if (field.Type == Models.Type.Port)
                {
                    // Enemy port can be taken
                    totalProfitability += 3;
                }
                else if (field.NTown)
                {
                    // Any town
                    totalProfitability += 3;
                }
            }
            // Field has enemy army
            if (field.Army is not null && field.Army.Party != party)
            {
                // Field is neighbour of own capital
                if (field.NCapital[party])
                {
                    totalProfitability += 1000;
                }
                // Opponent computer player with over 1.5 * total power of current party
                // and they are both on left side (0,1) or right side (2,3)
                if (field.Army.Party != board.Human
                    && (field.Party >= 0 && board.HwPartiesTotalPower[field.Party] > 1.5 * board.HwPartiesTotalPower[party])
                    && (field.Army.Count + field.Army.Morale > army.Count + army.Morale)
                    && ((field.Party < 2 && party < 2) || (field.Party > 1 && party > 1)))
                {
                    totalProfitability += 200;
                }
                // On higher difficulty levels, attack computer party less and focus more on human party
                if (board.Difficulty > 5 && field.Army.Party != board.Human)
                {
                    totalProfitability -= 250;
                }
            }

            // Join with own forces
            if (field.Army is not null && field.Army.Party == party)
            {
                // Small chance of joining forces if army is small enough
                if (field.Army.Count > army.Count && field.Army.Count < 70)
                {
                    totalProfitability += 2;
                }
            }

            // Army is stationed in capital, field has no army
            if (army.Field.Capital == party && field.Army is null && board.Turns < 5)
            {
                totalProfitability += 50;
            }
            var neighbour = CalcNeighboursInfo(party, field);
            var enemyNeighbour = CalcEnemyNeighboursPower(party, field);
            var fieldArmyTotal = field.Army is not null ?
                field.Army.Count + field.Army.Morale
                : 0;

            if ((neighbour.Power < enemyNeighbour && neighbour.Power < 300 || (army.Count + army.Morale < fieldArmyTotal) && army.Count < 90)
            && !field.NCapital[party]
                && !canTakeCapital)
            {
                if (board.HwPartiesWaitForSupportField[party] == field)
                {
                    if (board.HwPartiesWaitForSupportCount[party] < 5)
                    {
                        field.WaitForSupport = true;
                    }
                    else
                    {
                        totalProfitability -= 5;
                    }
                }
                else
                {
                    field.WaitForSupport = true;
                }
            }
            return totalProfitability;
        }

        int orderMoves(Field a, Field b)
        {
            // Sort by profitability
            var aValue = a.TmpProf;
            var bValue = b.TmpProf;
            if (aValue > bValue)
            {
                return -1;
            }

            if (aValue < bValue)
            {
                return 1;
            }

            return 0;
        }

        Field findBestMoveVal(Army army)
        {
            var moves = PathFinder.GetPossibleMoves(army.Field, true, false);
            for (var i = 0; i < moves.Count; i++)
            {
                moves[i].WaitForSupport = false;
                moves[i].TmpProf = finalProfitability(moves[i], army);
            }

            moves.Sort(orderMoves);
            return moves[0];
        }

        var movableArmies = GetMovableArmies(party, board);
        for (var armyIndex = 0; armyIndex < movableArmies.Count; armyIndex++)
        {
            var bestMove = findBestMoveVal(movableArmies[armyIndex]);
            if (bestMove is null)
            {
                Console.WriteLine("No move found for army: {0}", movableArmies[armyIndex]);
                continue;
            }

            movableArmies[armyIndex].Move = bestMove;
            movableArmies[armyIndex].Profitability = movableArmies[armyIndex].Move.TmpProf;
            if (movableArmies[armyIndex].Field.Capital == movableArmies[armyIndex].Party && board.Turns > 5)
            {
                movableArmies[armyIndex].Profitability = movableArmies[armyIndex].Profitability - 1000;
            }
        }
        return movableArmies;
    }

    public static NeighboursInfo CalcNeighboursInfo(int party, Field field)
    {
        var power = 0;
        var count = 0;
        var nonEnemyLand = 0;
        var waitForSupport = false;
        var furtherNeighbours = PathFinder.GetFurtherNeighbours(field);
        // TODO: Should this be deleted?
        // field.push.field;
        for (var i = 0; i < furtherNeighbours.Count; i++)
        {
            if (furtherNeighbours[i] is null)
            {
                continue;
            }

            if (furtherNeighbours[i].Army is not null && furtherNeighbours[i].Army.Party == party)
            {
                power += (furtherNeighbours[i].Army.Count + furtherNeighbours[i].Army.Morale);
                count++;
            }

            if (furtherNeighbours[i].Type == field.Type && (furtherNeighbours[i].Party == party || furtherNeighbours[i].Party < 0))
            {
                nonEnemyLand++;
            }

            if (furtherNeighbours[i].WaitForSupport)
            {
                waitForSupport = true;
            }
        }

        return new NeighboursInfo
        {
            Power = power,
            Count = count,
            NonEnemyLand = nonEnemyLand,
            WaitForSupport = waitForSupport
        };
    }

    public static int CalcEnemyNeighboursPower(int party, Field field)
    {
        var furtherNeighbours = PathFinder.GetFurtherNeighbours(field);
        var power = 0;
        // TODO: Should this be deleted?
        // field.push.field;
        for (var i = 0; i < furtherNeighbours.Count; i++)
        {
            if (furtherNeighbours[i] is null)
            {
                continue;
            }

            if (furtherNeighbours[i].Army is not null
                && furtherNeighbours[i].Army.Party != party)
            {
                power += (furtherNeighbours[i].Army.Count + furtherNeighbours[i].Army.Morale);
            }
        }

        return power;
    }

    public static List<Army> SupportArmy(int party, Army army, Field field, Board board)
    {
        int orderMoves(Field a, Field b)
        {
            var aValue = a.TmpProf;
            var bValue = b.TmpProf;

            if (aValue > bValue)
            {
                return -1;
            }

            if (aValue < bValue)
            {
                return 1;
            }

            return 0;
        }

        Field findBestMoveVal(Army army)
        {
            var moves = PathFinder.GetPossibleMoves(army.Field, true, false);
            var supportMoves = new List<Field>();

            for (var i = 0; i < moves.Count; i++)
            {
                if (moves[i] != field && (moves[i].Army is null || moves[i].Army.Party < 0 || moves[i].Army.Party == party))
                {
                    moves[i].TmpProf = -PathFinder.GetDistance(moves[i], field);
                    supportMoves.Add(moves[i]);
                }
            }

            supportMoves.Sort(orderMoves);
            return supportMoves[0];
        }

        var moveableArmies = GetMovableArmies(party, board);
        var supportArmies = new List<Army>();
        for (var armyIndex = 0; armyIndex < moveableArmies.Count; armyIndex++)
        {
            if (moveableArmies[armyIndex] != army && moveableArmies[armyIndex].Field.Capital != party)
            {
                var bestMove = findBestMoveVal(moveableArmies[armyIndex]);
                if (bestMove is null)
                {
                    Console.WriteLine("No move found for army: {0}", moveableArmies[armyIndex]);
                    continue;
                }

                moveableArmies[armyIndex].Move = bestMove;
                moveableArmies[armyIndex].Profitability = moveableArmies[armyIndex].Move.TmpProf;
                if (moveableArmies[armyIndex].Move != field
                    && (moveableArmies[armyIndex].Move.Army is null
                        || moveableArmies[armyIndex].Move.Army.Party < 0
                        || moveableArmies[armyIndex].Move.Army.Party == party)
                )
                {
                    supportArmies.Add(moveableArmies[armyIndex]);
                }
            }
        }
        return supportArmies;
    }

    public static List<Army> GetMovableArmies(int party, Board board)
    {
        var movableArmies = new List<Army>();
        for (var i = 0; i < board.HwPartiesArmies[party].Count; i++)
        {
            if (!board.HwPartiesArmies[party][i].Moved)
            {
                movableArmies.Add(board.HwPartiesArmies[party][i]);
            }
        }

        return movableArmies;
    }

    public class NeighboursInfo
    {
        public int Power { get; set; }
        public int Count { get; set; }
        public int NonEnemyLand { get; set; }
        public bool WaitForSupport { get; set; }
    }
}
