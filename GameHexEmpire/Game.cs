using GameAI.GameHexEmpire.Models;

namespace GameAI.GameHexEmpire;

public class Game
{
    private int mapNumber;
    private int turns;
    private Board board;
    private Map map;
    //private readonly Dictionary<string, dynamic> _images;
    public int MapNumber => mapNumber;
    public int Turns => turns;
    public Board Board => board;

    public Game()
    {
        //_images = PrepareImages();
    }

    //public static Dictionary<string, dynamic> PrepareImages()
    //{
    //    var images = new Dictionary<string, dynamic>();
    //    for (var i = 1; i <= 6; i++)
    //    {
    //        images["grassBg" + i] = new { img = null, path = "images/l_' + i + '.png", status = "none" };
    //    }

    //    for (var i = 1; i <= 6; i++)
    //    {
    //        images["seaBg" + i] = new { img: null, path = "images/m_' + i + '.png", status = "none" };
    //    }

    //    for (var i = 1; i <= 6; i++)
    //    {
    //        images["townBgGrass" + i] = new { img: null, path = "images/c_' + i + '.png", status = "none" };
    //    }

    //    images["city"] = new { img: null, path = "images/city.png", status = "none" };
    //    images["port"] = new { img: null, path = "images/port.png", status = "none" };
    //    images["capital0"] = new { img: null, path = "images/capital_red.png", status = "none" };
    //    images["capital1"] = new { img: null, path = "images/capital_violet.png", status = "none" };
    //    images["capital2"] = new { img: null, path = "images/capital_blue.png", status = "none" };
    //    images["capital3"] = new { img: null, path = "images/capital_green.png", status = "none" };
    //    return images;
    //}

    public static Board GenerateNewBoard()
    {
        return new Board
        {
            HwInit = false, // false when game starts
            HwXmax = 20,
            HwYmax = 11,
            HwFw = 50,
            HwFh = 40,
            HwTopFieldDepth = 0,
            HwLands = new(),
            HwTowns = new(),
            HwPartiesCapitals = new(),
            HwPartiesCount = 4,
            HwPartiesNames = new() { "Redosia", "Violetnam", "Bluegaria", "Greenland" },
            HwPartiesProvincesCp = new() { new List<Field>(), new List<Field>(), new List<Field>(), new List<Field>() },
            HwPartiesTowns = new() { new List<Field>(), new List<Field>(), new List<Field>(), new List<Field>() },
            HwPartiesPorts = new() { new List<Field>(), new List<Field>(), new List<Field>(), new List<Field>() },
            HwPartiesLands = new() { new List<Field>(), new List<Field>(), new List<Field>(), new List<Field>() },
            HwPartiesMorale = new() { 10, 10, 10, 10 },
            HwPartiesArmies = new() { new(), new(), new(), new() },
            HwPartiesStatus = new() { 1, 1, 1, 1 },
            HwPartiesTotalCount = new() { 0, 0, 0, 0 },
            HwPartiesTotalPower = new() { 0, 0, 0, 0 },
            HwPartiesControl = new() { "computer", "computer", "computer", "computer" },
            HwPartiesWaitForSupportField = new() { null, null, null, null },
            HwPartiesWaitForSupportCount = new() { 0, 0, 0, 0 },
            HwPartiesSpeechGiven = new() { false, false, false, false },
            HwPactJustBroken = -1,
            HwPeace = -1,
            Human = -1, // human player id
            HumanCondition = 1,
            Difficulty = 5,
            Duel = false,
            Fields = new(),
            Armies = new(),
        };
    }

    //loadImage(ref)
    //{
    //    return new Promise(function(resolve) {
    //        ref.img = new Image();
    //        ref.img.onload = _ => { ref.status = 'Image loaded'; resolve(); };
    //        ref.img.onerror = _ => { ref.status = 'Failed to load image'; resolve(); };
    //        ref.img.src = ref.path;
    //    });
    //}

    public void GenerateNewMap(int mapNumber)
    {
        this.mapNumber = mapNumber;

        board = GenerateNewBoard();
        map = new Map(this.mapNumber/*, _images*/);

        //var imagesToLoad = [];
        //for (const [key, value] of Object.entries(this.images)) {
        //    imagesToLoad.push(this.loadImage(this.images[key]))
        //    }

        //var self = this;
        //Promise
        //.all(imagesToLoad)
        //    .then(function() {
        map.GenerateMap(board);
        //const ctx = document.getElementById('map').getContext('2d');
        //ctx.drawImage(self.board.background_2, 0, 0);
        Map.UpdateBoard(board);
        Map.CalcAIHelpers(board);
        InitGame();
        //});
    }

    public void InitGame()
    {
        for (var p = 0; p < board.HwPartiesCount; p++)
        {
            Map.UnitsSpawn(p, board);
            Map.UpdateBoard(board);
        }
        //this.mapRender.drawMap(board, this._images);
        turns = 0;
    }

    public bool IsVictory()
    {
        return Map.IsVictory(board);
    }

    public void RunTurn()
    {
        board.Turns = turns;

        for (var turnParty = 0; turnParty < board.HwPartiesCount; turnParty++)
        {
            RunComputerTurn(/*map, */board, turnParty);
        }
        turns++;
    }

    public static void RunComputerTurn(/*Map map, */Board board, int turnParty)
    {
        board.TurnParty = turnParty;
        board.Duel = IsDuel(board);

        var movePoints = Map.GetMovePoints(turnParty, board);

        Map.CleanupTurn(board);
        Map.UpdateBoard(board);

        if (board.HwPartiesControl[turnParty] == "computer")
        {
            for (var i = 0; i < movePoints; i++)
            {
                Map.MakeMove(turnParty, board/*, false*/);

                Map.UpdateArmies(board);
            }
            Map.UnitsSpawn(turnParty, board);
        }
        //this.mapRender.drawMap(board, this._images);
    }

    public static bool IsDuel(Board board)
    {
        var duel = false;
        var surviving = 0;
        for (var i = 0; i < 4; i++)
        {
            if (board.HwPartiesCapitals[i].Party == i)
            {
                surviving++;
            }
        }
        if (surviving < 3)
        {
            duel = true;
        }
        return duel;
    }
}
