using GameAI.GameHexEmpire.Models;

namespace GameAI.GameHexEmpire;

public class PathFinder
{
    public static List<Field> FindPath(Field startf,
        Field endf,
        Models.Type[] avoid_estate,
        bool avoid_water = true)
    {
        if (startf is null || endf is null)
        {
            return null;
        }

        if (startf.Type == Models.Type.Water)
        {
            avoid_water = false;
        }

        bool c_Walk(Field a, Field b) => CanWalk(a, b, avoid_estate, avoid_water);

        var tiles = new List<Tile>();
        var path = new List<Tile>();
        var field1 = new Dictionary<string, int>();
        var field2 = new Dictionary<string, int>();
        tiles.Add(new() { Field = startf });
        tiles[^1].Tc = 0;
        var move_cost = new[] { 5, 5, 5, 5, 5, 5 };
        while ((path.Count == 0 || (path.Count > 0 && path[^1].Field != endf)) && tiles.Count > 0)
        {
            var currentTile = tiles[0];
            tiles.RemoveAt(0);
            for (var neighborNum = 0; neighborNum < 6; neighborNum++)
            {
                if (c_Walk(currentTile.Field, currentTile.Field.Neighbours[neighborNum])
                  || currentTile.Field.Neighbours[neighborNum] == endf)
                {
                    var newTile = new Tile
                    {
                        Field = currentTile.Field.Neighbours[neighborNum]
                    };
                    var distance = GetDistance(newTile.Field, endf);
                    newTile.Parent = currentTile;
                    newTile.Dc = move_cost[neighborNum] + distance;
                    newTile.Tc = currentTile.Tc + move_cost[neighborNum];
                    if (!field2.ContainsKey(GetFieldStrO(newTile.Field)))
                    {
                        if (!field1.ContainsKey(GetFieldStrO(newTile.Field)))
                        {
                            field1.Add(GetFieldStrO(newTile.Field), tiles.Count);
                            tiles.Add(newTile);
                        }
                    }
                    else if (path[field2[GetFieldStrO(newTile.Field)]].Tc > newTile.Tc)
                    {
                        path[field2[GetFieldStrO(newTile.Field)]] = newTile;
                    }
                }
            }
            field2[GetFieldStrO(currentTile.Field)] = path.Count;
            path.Add(currentTile);
            if (tiles.Count > 0)
            {
                var tileForSwap = 0;
                for (var tileNum = 1; tileNum < tiles.Count; tileNum++)
                {
                    if (tiles[tileNum].Dc < tiles[tileForSwap].Dc)
                    {
                        tileForSwap = tileNum;
                    }
                }
                (tiles[tileForSwap], tiles[0]) = (tiles[0], tiles[tileForSwap]);
            }
        }

        if (tiles.Count == 0)
        {
            return null;
        }

        var finalPath = new List<Field>();
        var pathIndex = path.Count - 1;
        while (finalPath.Count == 0 || finalPath[^1] != startf)
        {
            finalPath.Add(path[pathIndex].Field);
            if (path[pathIndex]?.Parent is null)
            {
                break;
            }
            pathIndex = field2[GetFieldStrO(path[pathIndex].Parent.Field)];
        }

        finalPath.Reverse();
        return finalPath;
    }

    public static bool CanWalk(Field a, Field b, Models.Type[] avoid_estate, bool avoid_water)
    {
        if (a is null || b is null)
        {
            return false;
        }

        for (var n = 0; n < avoid_estate.Length; n++)
        {
            if (b.Type == avoid_estate[n])
            {
                return false;
            }
        }

        if (!avoid_water)
        {
            return true;
        }

        if (a.Type == Models.Type.Water && b.Type == Models.Type.Water)
        {
            return true;
        }

        if (a.Type != Models.Type.Water && b.Type != Models.Type.Water)
        {
            return true;
        }

        if (a.Type == Models.Type.Water && b.Type != Models.Type.Water)
        {
            return true;
        }

        if (b.Type == Models.Type.Water && a.Type == Models.Type.Port)
        {
            return true;
        }

        return false;
    }

    public static string GetFieldStrO(Field field)
    {
        return "f" + field.Fx + "x" + field.Fy;
    }

    public static double GetDistance(Field a, Field b)
    {
        var acx = a.Fx * 5;
        var bcx = b.Fx * 5;
        int acy, bcy;
        if (a.Fx % 2 == 0)
        {
            acy = a.Fy * 10;
        }
        else
        {
            acy = a.Fy * 10 + 5;
        }
        if (b.Fx % 2 == 0)
        {
            bcy = b.Fy * 10;
        }
        else
        {
            bcy = b.Fy * 10 + 5;
        }
        return Math.Sqrt(Math.Pow(acx - bcx, 2) + Math.Pow(acy - bcy, 2));
    }

    public static List<Field> GetFurtherNeighbours(Field field)
    {
        var additionalNeighbours = new List<Field>();
        if (field.Neighbours.Count > 0 && field.Neighbours[0] != null)
        {
            additionalNeighbours.Add(field.Neighbours[0].Neighbours[0]);
            additionalNeighbours.Add(field.Neighbours[0].Neighbours[1]);
        }
        else
        {
            additionalNeighbours.Add(null);
            additionalNeighbours.Add(null);
        }

        if (field.Neighbours.Count > 1 && field.Neighbours[1] != null)
        {
            additionalNeighbours.Add(field.Neighbours[1].Neighbours[1]);
            additionalNeighbours.Add(field.Neighbours[1].Neighbours[2]);
        }
        else
        {
            additionalNeighbours.Add(null);
            additionalNeighbours.Add(null);
        }

        if (field.Neighbours.Count > 2 && field.Neighbours[2] != null)
        {
            additionalNeighbours.Add(field.Neighbours[2].Neighbours[2]);
        }
        else
        {
            additionalNeighbours.Add(null);
        }

        if (field.Neighbours.Count > 3 && field.Neighbours[3] != null)
        {
            additionalNeighbours.Add(field.Neighbours[3].Neighbours[3]);
            additionalNeighbours.Add(field.Neighbours[3].Neighbours[4]);
        }
        else
        {
            additionalNeighbours.Add(null);
            additionalNeighbours.Add(null);
        }

        if (field.Neighbours.Count > 4 && field.Neighbours[4] != null)
        {
            additionalNeighbours.Add(field.Neighbours[4].Neighbours[4]);
            additionalNeighbours.Add(field.Neighbours[4].Neighbours[5]);
        }
        else
        {
            additionalNeighbours.Add(null);
            additionalNeighbours.Add(null);
        }

        if (field.Neighbours.Count > 5 && field.Neighbours[5] != null)
        {
            additionalNeighbours.Add(field.Neighbours[5].Neighbours[5]);
        }
        else
        {
            additionalNeighbours.Add(null);
        }

        additionalNeighbours.Add(field.Neighbours.Count == 0 || field.Neighbours[0] == null
            ? (field.Neighbours.Count > 5 && field.Neighbours[5] != null
                ? field.Neighbours[5].Neighbours[0]
                : null)
            : field.Neighbours[0].Neighbours[5]);

        additionalNeighbours.Add(field.Neighbours.Count <= 2 || field.Neighbours[2] == null
            ? (field.Neighbours.Count > 3 && field.Neighbours[3] != null
                ? field.Neighbours[3].Neighbours[2]
                : null)
            : field.Neighbours[2].Neighbours[3]);

        return field.Neighbours.Concat(additionalNeighbours).ToList();
    }

    public static List<Field> GetPossibleMoves(Field field, bool no_self, bool check_power)
    {
        bool joinCnd(Field field1, Field field2)
        {
            if (field1 is null)
            {
                return false;
            }

            if (field1 == field2)
            {
                return false;
            }

            if (field1.Army is null)
            {
                return true;
            }

            if (check_power && field1.Army is not null && field2.Army is not null && field1.Army.Party != field2.Army.Party)
            {
                var ap = field1.Army.Count + field1.Army.Morale;
                var bp = field2.Army.Count + field2.Army.Morale;
                if (bp < 0.75 * ap)
                {
                    return false;
                }
            }

            return field1.Army.Party != field2.Army.Party
                || field1.Type != Models.Type.Water
                && field1.Army.Count < 99;
        }

        var reachableFields = new List<Field>();
        if (!no_self)
        {
            reachableFields.Add(field);
        }

        if (field.Type == Models.Type.Port)
        {
            for (var n = 0; n < 6; n++)
            {
                if (joinCnd(field.Neighbours[n], field))
                {
                    reachableFields.Add(field.Neighbours[n]);
                    if (field.Neighbours[n].Type == Models.Type.Water && field.Neighbours[n].Army is null)
                    {
                        for (var n2 = 0; n2 < 6; n2++)
                        {
                            if (field.Neighbours[n].Neighbours.Count <= n2
                                || field.Neighbours[n].Neighbours[n2] is null)
                            {
                                continue;
                            }

                            if (field.Neighbours[n].Neighbours[n2].Type == Models.Type.Water
                              && joinCnd(field.Neighbours[n].Neighbours[n2], field))
                            {
                                reachableFields.Add(field.Neighbours[n].Neighbours[n2]);
                            }
                        }
                    }
                    else if (field.Neighbours[n].Type == Models.Type.Land
                      && field.Neighbours[n].Army is null)
                    {
                        for (var n2 = 0; n2 < 6; n2++)
                        {
                            if (field.Neighbours[n].Neighbours.Count <= n2
                                || field.Neighbours[n].Neighbours[n2] is null)
                            {
                                continue;
                            }

                            if (field.Neighbours[n].Neighbours[n2].Type != Models.Type.Water
                              && joinCnd(field.Neighbours[n].Neighbours[n2], field))
                            {
                                reachableFields.Add(field.Neighbours[n].Neighbours[n2]);
                            }
                        }
                    }
                }
            }
        }
        else if (field.Type == Models.Type.Water)
        {
            for (var n = 0; n < 6; n++)
            {
                if (joinCnd(field.Neighbours[n], field))
                {
                    reachableFields.Add(field.Neighbours[n]);
                    if (field.Neighbours[n].Type == Models.Type.Water && field.Neighbours[n].Army is null)
                    {
                        for (var n2 = 0; n2 < 6; n2++)
                        {
                            if (joinCnd(field.Neighbours[n].Neighbours[n2], field))
                            {
                                reachableFields.Add(field.Neighbours[n].Neighbours[n2]);
                            }
                        }
                    }
                }
            }
        }
        else if (field.Type != Models.Type.Water)
        {
            for (var n = 0; n < 6; n++)
            {
                if (field.Neighbours.Count <= n || field.Neighbours[n] is null)
                {
                    continue;
                }

                if (field.Neighbours[n].Type != Models.Type.Water
                    && joinCnd(field.Neighbours[n], field))
                {
                    reachableFields.Add(field.Neighbours[n]);
                    if (field.Neighbours[n].Type == Models.Type.Land
                        && field.Neighbours[n].Army is null)
                    {
                        for (var n2 = 0; n2 < 6; n2++)
                        {
                            if (field.Neighbours[n].Neighbours.Count <= n2
                                || field.Neighbours[n].Neighbours[n2] is null)
                            {
                                continue;
                            }

                            if (field.Neighbours[n].Neighbours[n2].Type != Models.Type.Water
                                && joinCnd(field.Neighbours[n].Neighbours[n2], field))
                            {
                                reachableFields.Add(field.Neighbours[n].Neighbours[n2]);
                            }
                        }
                    }
                }
            }
        }
        return reachableFields;
    }

    private class Tile
    {
        public Field Field { get; set; }

        public Tile Parent { get; set; }

        public double Dc { get; set; }

        public double Tc { get; set; }
    }
}
