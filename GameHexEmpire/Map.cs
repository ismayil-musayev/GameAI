using GameAI.GameHexEmpire.Models;

namespace GameAI.GameHexEmpire;

public class Map
{
    readonly List<string> towns;
    readonly int mapNumber;
    int rnd_seed;
    //readonly Dictionary<string, dynamic> images;

    public Map(int mapNumber/*, Dictionary<string, dynamic> images*/)
    {
        towns = GenerateAllTowns();
        this.mapNumber = mapNumber < 0 ? new Random().Next(0, 999999) : mapNumber;

        SetSeed(this.mapNumber);

        //this.images = images;
    }

    public void SetSeed(int seed)
    {
        rnd_seed = seed;
    }

    public static List<string> GenerateAllTowns()
    {
        return new() {
          "Abu Dhabi", "Abuja", "Accra", "Addis Ababa", "Algiers", "Amman", "Amsterdam", "Ankara", "Antananarivo", "Apia", "Ashgabat", "Asmara", "Astana", "Asunción", "Athens",
              "Baghdad", "Baku", "Bamako", "Bangkok", "Bangui", "Banjul", "Basseterre", "Beijing", "Beirut", "Belgrade", "Belmopan", "Berlin", "Bern", "Bishkek", "Bissau", "Bogotá",
              "Brasília", "Bratislava", "Brazzaville", "Bridgetown", "Brussels", "Bucharest", "Budapest", "Buenos Aires", "Bujumbura", "Cairo", "Canberra",
              "Cape Town", "Caracas", "Castries", "Chisinau", "Conakry", "Copenhagen", "Cotonou",
              "Dakar", "Damascus", "Dhaka", "Dili", "Djibouti", "Dodoma", "Doha", "Dublin", "Dushanbe", "Delhi",
              "Freetown", "Funafuti", "Gabarone", "Georgetown", "Guatemala City", "Hague", "Hanoi", "Harare", "Havana", "Helsinki", "Honiara", "Hong Kong",
              "Islamabad", "Jakarta", "Jerusalem", "Kabul", "Kampala", "Kathmandu", "Khartoum", "Kyiv", "Kigali", "Kingston", "Kingstown", "Kinshasa", "Kuala Lumpur", "Kuwait City",
              "La Paz", "Liberville", "Lilongwe", "Lima", "Lisbon", "Ljubljana", "Lobamba", "Lomé", "London", "Luanda", "Lusaka", "Luxembourg",
              "Madrid", "Majuro", "Malé", "Managua", "Manama", "Manila", "Maputo", "Maseru", "Mbabane", "Melekeok", "Mexico City", "Minsk", "Mogadishu", "Monaco", "Monrovia", "Montevideo", "Moroni", "Moscow", "Muscat",
              "Nairobi", "Nassau", "Naypyidaw", "N'Djamena", "New Delhi", "Niamey", "Nicosia", "Nouakchott", "Nuku'alofa", "Nuuk",
              "Oslo", "Ottawa", "Ouagadougou", "Palikir", "Panama City", "Paramaribo", "Paris", "Phnom Penh", "Podgorica", "Prague", "Praia", "Pretoria", "Pyongyang",
              "Quito", "Rabat", "Ramallah", "Reykjavík", "Riga", "Riyadh", "Rome", "Roseau",
              "San José", "San Marino", "San Salvador", "Sanaá", "Santiago", "Santo Domingo", "Sao Tomé", "Sarajevo", "Seoul", "Singapore", "Skopje", "Sofia", "South Tarawa", "St. George's", "St. John's", "Stockholm", "Sucre", "Suva",
              "Taipei", "Tallinn", "Tashkent", "Tbilisi", "Tegucigalpa", "Teheran", "Thimphu", "Tirana", "Tokyo", "Tripoli", "Tunis", "Ulaanbaatar",
              "Vaduz", "Valletta", "Victoria", "Vienna", "Vientiane", "Vilnius", "Warsaw", "Washington", "Wellington", "Windhoek", "Yamoussoukro", "Yaoundé", "Yerevan", "Zagreb", "Zielona Góra",
              "Poznań", "Wrocław", "Gdańsk", "Szczecin", "Łódź", "Białystok", "Toruń", "St. Petersburg", "Turku", "Örebro", "Chengdu",
              "Wuppertal", "Frankfurt", "Düsseldorf", "Essen", "Duisburg", "Magdeburg", "Bonn", "Brno", "Tours", "Bordeaux", "Nice", "Lyon", "Stara Zagora", "Milan", "Bologna", "Sydney", "Venice", "New York",
              "Barcelona", "Zaragoza", "Valencia", "Seville", "Graz", "Munich", "Birmingham", "Naples", "Cologne", "Turin", "Marseille", "Leeds", "Kraków", "Palermo", "Genoa",
              "Stuttgart", "Dortmund", "Rotterdam", "Glasgow", "Málaga", "Bremen", "Sheffield", "Antwerp", "Plovdiv", "Thessaloniki", "Kaunas", "Lublin", "Varna", "Ostrava", "Iaşi", "Katowice",
              "Cluj-Napoca", "Timişoara", "Constanţa", "Pskov", "Vitebsk", "Arkhangelsk", "Novosibirsk", "Samara", "Omsk", "Chelyabinsk", "Ufa", "Volgograd", "Perm", "Kharkiv", "Odessa", "Donetsk", "Dnipropetrovsk",
              "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "Dallas", "Detroit", "Indianapolis", "San Francisco", "Atlanta", "Austin", "Vermont", "Toronto", "Montreal", "Vancouver", "Gdynia", "Edmonton",
        };
    }

    public static Field GetField(int x, int y, Board board)
    {
        return x < 0 || x >= board.Fields.Count ? null
            : y < 0 || y >= board.Fields[x].Count ? null
            : board.Fields[x][y];
    }

    //public static void UpdateField(Field field, Board board)
    //{
    //    if (!field.port)
    //    {
    //        field.port = { };
    //    }

    //    if (!field.town)
    //    {
    //        field.town = { };
    //    }

    //    field.port._visible = false;
    //    field.town._visible = false;
    //    switch (field.Estate)
    //    {
    //        case "port":
    //            field.port._visible = true;
    //            break;
    //        case "town":
    //            field.town._visible = true;
    //            break;
    //        default:
    //            break;
    //    }

    //    function pNormal(icon)
    //    {
    //        icon._width = 35;
    //        icon._height = 35;
    //        icon._x = 0;
    //        icon._y = 0;
    //    }

    //    function pSmall(icon)
    //    {
    //        icon._width = 20;
    //        icon._height = 20;
    //        icon._x = 0;
    //        icon._y = 0;
    //    }

    //    function pSide(icon)
    //    {
    //        icon._width = 20;
    //        icon._height = 20;
    //        icon._x = 18;
    //        icon._y = -4;
    //    }

    //    if (field.army)
    //    {
    //        pSide(field.town);
    //        pSide(field.port);
    //    }
    //    else if (field.capital < 0)
    //    {
    //        pSmall(field.town);
    //        pNormal(field.port);
    //    }
    //    else
    //    {
    //        pNormal(field.town);
    //        pNormal(field.port);
    //    }

    //    var x = field.fx;
    //    var y = field.fy;
    //    if (field.party >= 0 && !board["pb" + field.party]["f" + x + "x" + y])
    //    {
    //        board["pb" + field.party]["f" + x + "x" + y] = { }
    //        var brd = board["pb" + field.party]["f" + x + "x" + y];
    //        var px = x * (board.hw_fw / 4 * 3) + board.hw_fw / 2;
    //        var py;
    //        if (x % 2 == 0)
    //        {
    //            py = y * board.hw_fh + board.hw_fh / 2;
    //        }
    //        else
    //        {
    //            py = y * board.hw_fh + board.hw_fh;
    //        }
    //        brd._x = px;
    //        brd._y = py;
    //    }
    //}

    public int Rand(int n)
    {
        rnd_seed = (int)((rnd_seed * (long)9301 + 49297) % 233280);
        return (int)Math.Floor(rnd_seed / 233280.0 * n);
    }

    public List<Field> Shuffle(List<Field> arr)
    {
        var arrayCopy = arr.ToList();
        for (var index = 0; index < arrayCopy.Count; index++)
        {
            var rn = Rand(arrayCopy.Count);
            (arrayCopy[rn], arrayCopy[index]) = (arrayCopy[index], arrayCopy[rn]);
        }
        return arrayCopy;
    }

    public string RandTown()
    {
        var cnr = Rand(towns.Count);
        var cname = towns[cnr];
        towns[cnr] = towns[0];
        towns.RemoveAt(0);
        return cname;
    }

    public void AddTown(/*int x, int y, Board board*/)
    {
        Rand(6);
        Rand(6);
        Rand(2);
        Rand(2);
        Rand(360);

        //var townBgDirtImg = "images/cd_" + Rand(6) + ".png";
        //var townBgGrassImg = this.images["townBgGrass" + (Rand(6) + 1)].img;
        //var flipH = Rand(2);
        //var flipV = Rand(2);
        //var rotateDegrees = Rand(360);

        //var ctx = board.background_2.getContext('2d');
        //var img = townBgGrassImg;
        //var width = img.width;
        //var height = img.height;
        //var field = this.getField(x, y, board);
        //var destX = field._x - (width / 2);
        //var destY = field._y - (height / 2);

        //ctx.translate(destX, destY);
        //this.rotateImageMatrix(ctx, img, rotateDegrees);
        //this.flipImageMatrix(ctx, img, flipH, flipV);
        //ctx.drawImage(img, 0, 0);
        //ctx.resetTransform();

        //let region = new Path2D();
        //region.rect(0, 0, 750, 465);
        //ctx.clip(region);
    }

    public static void FindNeighbours(Field field, Board board)
    {
        field.Neighbours = new(6);
        if (field.Fx % 2 == 0)
        {
            field.Neighbours.Add(GetField(field.Fx + 1, field.Fy, board));
            field.Neighbours.Add(GetField(field.Fx, field.Fy + 1, board));
            field.Neighbours.Add(GetField(field.Fx - 1, field.Fy, board));
            field.Neighbours.Add(GetField(field.Fx - 1, field.Fy - 1, board));
            field.Neighbours.Add(GetField(field.Fx, field.Fy - 1, board));
            field.Neighbours.Add(GetField(field.Fx + 1, field.Fy - 1, board));
        }
        else
        {
            field.Neighbours.Add(GetField(field.Fx + 1, field.Fy + 1, board));
            field.Neighbours.Add(GetField(field.Fx, field.Fy + 1, board));
            field.Neighbours.Add(GetField(field.Fx - 1, field.Fy + 1, board));
            field.Neighbours.Add(GetField(field.Fx - 1, field.Fy, board));
            field.Neighbours.Add(GetField(field.Fx, field.Fy - 1, board));
            field.Neighbours.Add(GetField(field.Fx + 1, field.Fy, board));
        }
    }

    //flipImageMatrix(ctx, image, flipH, flipV)
    //{
    //    const width = image.width;
    //    const height = image.height;

    //    if (flipH > 0 && flipV > 0)
    //    {
    //        ctx.translate(width, height);
    //        ctx.scale(-1, -1);
    //    }
    //    else if (flipH > 0)
    //    {
    //        ctx.translate(width, 0);
    //        ctx.scale(-1, 1);
    //    }
    //    else if (flipV > 0)
    //    {
    //        ctx.translate(0, height);
    //        ctx.scale(1, -1);
    //    }
    //}

    //degreesToRadians(degrees)
    //{
    //    return (Math.PI / 180) * degrees;
    //}

    //rotateImageMatrix(ctx, image, rotateDegrees)
    //{
    //    const width = image.width;
    //    const height = image.height;

    //    ctx.translate(width / 2, height / 2);
    //    ctx.rotate(this.degreesToRadians(rotateDegrees));
    //    ctx.translate(-width / 2, -height / 2);
    //}

    public void CreateBackground(/*Board board*/)
    {
        //board.background_1 = document.createElement('canvas');
        //board.background_1.width = 800;
        //board.background_1.height = 600;
        //board.background_2 = document.createElement('canvas');
        //board.background_2.width = 800;
        //board.background_2.height = 600;

        //var gridImages = new Array(6 * 4);
        for (var x = 0; x < 6; x++)
        {
            for (var y = 0; y < 4; y++)
            {
                //const index = (x * 4) + y;
                //gridImages[index] = {
                //  dirtBg: new Image(),
                //  grassBg: new Image(),
                //  destX: x * 125 - 15,
                //  destY: y * 125 - 15,
                //  horizontalFlip: -1,
                //  verticalFlip: -1,
                //  rotationDegrees: -1,
                //}

                //gridImages[index].dirtBg.src = "images/ld_" + (this.Rand(6) + 1) + ".png";
                //gridImages[index].grassBg = this.images["grassBg" + (this.Rand(6) + 1)].img;
                Rand(6);
                Rand(6);

                //var flipH = this.Rand(2);
                //var flipV = this.Rand(2);
                //var rotateDegrees = this.Rand(4) * 90;
                Rand(2);
                Rand(2);
                Rand(4);


                //const ctx = board.background_2.getContext('2d');
                //var img = gridImages[index].grassBg;
                //var destX = (x * 125) - 15;
                //var destY = (y * 125) - 15;

                //ctx.translate(destX, destY);
                //this.rotateImageMatrix(ctx, img, rotateDegrees);
                //this.flipImageMatrix(ctx, img, flipH, flipV);

                //ctx.drawImage(img, 0, 0);
                //ctx.resetTransform();

                //let region = new Path2D();
                //region.rect(0, 0, 800, 465);
                //ctx.clip(region);
            }
        }
    }

    public void AddField(int x, int y, Board board)
    {
        if (x >= board.Fields.Count)
        {
            board.Fields.Add(new());
        }
        if (y >= board.Fields[x].Count)
        {
            board.Fields[x].Add(new());
        }

        board.Fields[x][y] = new();
        var nfield = board.Fields[x][y];
        nfield.Fx = x;
        nfield.Fy = y;
        if (x == board.HwXmax - 1 && y == board.HwYmax - 1)
        {
            board.HwTopFieldDepth = -1; // TODO: find a better value
        }
        //var px = x * (board.hw_fw / 4 * 3) + board.hw_fw / 2;
        //var py = 0;
        //if (x % 2 == 0)
        //{
        //    py = y * board.hw_fh + board.hw_fh / 2;
        //}
        //else
        //{
        //    py = y * board.hw_fh + board.hw_fh;
        //}
        //nfield._x = px;
        //nfield._y = py;
        nfield.LandId = -1;
        if (x == 1 && y == 1
          || x == board.HwXmax - 2 && y == 1
          || x == board.HwXmax - 2 && y == board.HwYmax - 2
          || x == 1 && y == board.HwYmax - 2)
        {
            nfield.Type = Models.Type.Land;
        }
        else
        {
            var a = Rand(10);
            if (a <= 1)
            { }
            nfield.Type = a <= 1 ? Models.Type.Land : Models.Type.Water;
        }

        if(x == 4 && y == 10)
        { }

        nfield.Party = -1;
        nfield.Capital = -1;
        nfield.NTown = false;
        nfield.Army = null;

        nfield.Profitability = new[] { 0, 0, 0, 0 };
        //nfield.TmpProf = new[] { 0, 0, 0, 0 };
        nfield.NCapital = new[] { false, false, false, false };
    }

    public void GenerateMap(Board board)
    {
        CreateBackground(/*board*/);

        //for (var p = 0; p < board.hw_parties_count; p++)
        //{
        //    if (!board["pb" + p])
        //    {
        //        // Used to color occupied tiles
        //        board["pb" + p] = { };
        //    }
        //}
        //board.background_sea = document.createElement('canvas');
        //board.background_sea.width = 800;
        //board.background_sea.height = 600;

        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                AddField(x, y, board);
            }
        }

        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                FindNeighbours(field, board);
            }
        }

        SetLandFields(board);
        GenerateHwLands(board);
        GeneratePartyCapitals(board);
        GenerateTowns(board);
        board.HwTowns = Shuffle(board.HwTowns);
        GeneratePorts(board);

        DrawWaterAndPorts(board);
        AssignTownNames(board);
    }

    public static void GeneratePartyCapitals(Board board)
    {
        var cp = 0;
        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                if ((x == 1 && y == 1)
                  || (x == board.HwXmax - 2 && y == 1)
                  || (x == board.HwXmax - 2 && y == board.HwYmax - 2)
                  || (x == 1 && y == board.HwYmax - 2))
                {
                    var field = GetField(x, y, board);
                    //field.Type = Models.Type.Town;
                    board.HwTowns.Add(field);
                    field.Type = Models.Type.Capital;
                    field.Capital = cp;
                    board.HwPartiesCapitals.Add(field);
                    AnnexLand(cp, field, board, true);
                    cp++;
                }
            }
        }
    }

    public static void SetLandFields(Board board)
    {
        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                if (field.Type == Models.Type.Water)
                {
                    var land = 0;
                    for (var n = 0; n < 6; n++)
                    {
                        if (field.Neighbours[n] is null)
                        {
                            continue;
                        }
                        if (field.Neighbours[n].Type != Models.Type.Water)
                        {
                            land++;
                        }
                    }
                    if (land >= 1)
                    {
                        GetField(x, y, board).Tl = true;
                    }
                }
            }
        }

        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                if (GetField(x, y, board).Tl)
                {
                    GetField(x, y, board).Type = Models.Type.Land;
                }
            }
        }

        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                if (field.Type == Models.Type.Water)
                {
                    var water = 0;
                    for (var n = 0; n < 6; n++)
                    {
                        if (field.Neighbours[n] is null)
                        {
                            continue;
                        }
                        if (field.Neighbours[n].Type == Models.Type.Water)
                        {
                            water++;
                        }
                    }
                    if (water == 0)
                    {
                        field.Type = Models.Type.Land;
                    }
                }
            }
        }
    }

    public static void GenerateHwLands(Board board)
    {
        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                if (GetField(x, y, board).Type != Models.Type.Water)
                {
                    board.HwLand++;
                }
            }
        }

        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                if (field.Type != Models.Type.Water && field.LandId < 0)
                {
                    var clid = board.HwLands.Count;
                    board.HwLands.Add(new List<Field>());
                    board.HwLands[clid].Add(field);
                    field.LandId = clid;
                    var add_ngb2l = (Field field, int lid) =>
                    {
                        var newf = 0;
                        for (var n = 0; n < 6; n++)
                        {
                            if (field.Neighbours[n] is not null
                                && field.Neighbours[n].Type != Models.Type.Water
                                && field.Neighbours[n].LandId < 0)
                            {
                                board.HwLands[lid].Add(field.Neighbours[n]);
                                field.Neighbours[n].LandId = lid;
                                newf++;
                            }
                        }
                        return newf;
                    };
                    var cc = 0;
                    var cnr = cc;
                    while (cc >= cnr)
                    {
                        cc += add_ngb2l(board.HwLands[clid][cnr], clid);
                        cnr++;
                    }
                }
            }
        }
    }

    public void GenerateTowns(Board board)
    {
        for (var landNum = 0; landNum < board.HwLands.Count; landNum++)
        {
            var townCount = (int)Math.Floor(board.HwLands[landNum].Count / 10.0) + 1;
            for (var townNum = 0; townNum < townCount; townNum++)
            {
                var created = false;
                var attempts = 0;
                while (!created)
                {
                    attempts++;
                    if (attempts > 10)
                    {
                        created = true;
                    }
                    var nt = Rand(board.HwLands[landNum].Count);
                    if (board.HwLands[landNum][nt].Type == Models.Type.Land
                        || board.HwLands[landNum][nt].Type == Models.Type.Water)
                    {
                        var ok = true;
                        for (var n = 0; n < 6; n++)
                        {
                            var field = board.HwLands[landNum][nt];
                            if (field.Neighbours[n] is null)
                            {
                                continue;
                            }
                            if (field.Neighbours[n].Type != Models.Type.Land)
                            {
                                ok = false;
                            }
                        }
                        if (ok)
                        {
                            board.HwLands[landNum][nt].Type = Models.Type.Town;
                            board.HwTowns.Add(board.HwLands[landNum][nt]);
                            created = true;
                        }
                    }
                }
            }
        }
    }

    public static void GeneratePorts(Board board)
    {
        var portNum = 0;
        var pn = 0;
        for (var town = 0; town < board.HwTowns.Count - 1; town++)
        {
            var path = PathFinder.FindPath(board.HwTowns[town], board.HwTowns[town + 1], new[] { Models.Type.Town, Models.Type.Capital }, true);
            if (path == null || path.Count > portNum)
            {
                path = PathFinder.FindPath(board.HwTowns[town], board.HwTowns[town + 1], new[] { Models.Type.Town, Models.Type.Capital }, false);
                pn++;
            }
            for (var pathIndex = 1; pathIndex < path.Count - 1; pathIndex++)
            {
                if (path[pathIndex].Type != Models.Type.Water
                    && path[pathIndex + 1].Type == Models.Type.Water)
                {
                    path[pathIndex].Type = Models.Type.Port;
                    portNum++;
                }
                if (path[pathIndex].Type != Models.Type.Water
                    && path[pathIndex - 1].Type == Models.Type.Water)
                {
                    path[pathIndex].Type = Models.Type.Port;
                    portNum++;
                }
            }
        }
    }

    public void DrawWaterAndPorts(Board board)
    {
        //var portImageNum = new[] { 2, 1, 2, 2, 1, 2 };
        //var flipX = new[] { 1, 0, 0, 0, 0, 1 };
        //var flipY = new[] { 1, 1, 1, 0, 0, 0 };
        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                if (field.Type == Models.Type.Water)
                {
                    Rand(6);
                    Rand(2);
                    Rand(2);
                    Rand(2);

                    //var seaBg = this.images["seaBg" + (this.Rand(6) + 1)].img;
                    //var flipH = this.Rand(2);
                    //var flipV = this.Rand(2);
                    //var rotateDegrees = this.Rand(2) * 180;
                    //const ctx = board.background_sea.getContext('2d');

                    //const img = seaBg;
                    //const width = seaBg.width;
                    //const height = seaBg.height;
                    //const destX = field._x - (width / 2.0);
                    //const destY = field._y - (height / 2.0);
                    //ctx.translate(destX, destY);
                    //this.rotateImageMatrix(ctx, img, rotateDegrees);
                    //this.flipImageMatrix(ctx, img, flipH, flipV);
                    //ctx.drawImage(img, 0, 0);
                    //ctx.resetTransform();
                }
            }
        }
    }

    public void AssignTownNames(Board board)
    {
        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                //UpdateField(GetField(x, y, board), board);
                switch (field.Type)
                {
                    case Models.Type.Capital:
                    case Models.Type.Town:
                    case Models.Type.Port:
                        AddTown(/*x, y, board*/);
                        field.TownName = RandTown();
                        break;
                    default:
                        break;
                        //default:
                        //    var field = this.GetField(x, y, board);
                        //    if (!field.town_sign)
                        //    {
                        //        field.town_sign = { };
                        //    }
                        //    field.town_sign._visible = false;
                }
            }
        }
    }

    public static void UnitsSpawn(int party, Board board)
    {
        var ucount = board.HwPartiesLands[party].Count + board.HwPartiesPorts[party].Count * 5.0;
        ucount = Math.Floor(ucount / board.HwPartiesTowns[party].Count);
        for (var partyIndex = 0; partyIndex < board.HwPartiesCount; partyIndex++)
        {
            if (board.HwPartiesCapitals[partyIndex].Party == party)
            {
                var morale = board.HwPartiesMorale[party];
                if (board.HwPartiesCapitals[partyIndex].Army is not null)
                {
                    morale = board.HwPartiesCapitals[partyIndex].Army.Morale;
                }
                JoinUnits(5, morale, party, board, null, board.HwPartiesCapitals[partyIndex]);
            }
        }
        for (var townIndex = 0; townIndex < board.HwPartiesTowns[party].Count; townIndex++)
        {
            var morale = board.HwPartiesMorale[party];
            if (board.HwPartiesTowns[party][townIndex].Army is not null)
            {
                morale = board.HwPartiesTowns[party][townIndex].Army.Morale;
            }
            JoinUnits(5 + (int)ucount, morale, party, board, null, board.HwPartiesTowns[party][townIndex]);
        }
    }

    public static void JoinUnits(int count, int morale, int party, Board board, Army army, Field field)
    {
        army ??= field?.Army;
        field ??= army?.Field;
        if (army is null)
        {
            UpdateArmy(count, morale, party, board, army, field);
        }
        else
        {
            var m = (int)Math.Floor((double)(army.Count * army.Morale + count * morale) / (army.Count + count));
            UpdateArmy(army.Count + count, m, party, board, army, field);
        }
    }

    public static void UpdateArmy(int count, int morale, int party, Board board, Army army, Field field)
    {
        army ??= field?.Army;
        field ??= army?.Field;

        if (board is null)
        {
            throw new Exception("Board is undefined");
        }

        if (army is null)
        {
            if (count <= 0)
            {
                return;
            }

            board.HwLAid++;
            var alevel = -1; // TODO: find better value
            var aname = "army" + board.HwLAid;
            board.Armies[aname] = new();
            board.HwaTL = alevel;
            board.Armies[aname].Field = field;
            board.Armies[aname].Party = party;
            board.Armies[aname].RemoveTime = -1;
            board.Armies[aname].Exploding = null;
            board.Armies[aname].Remove = false;
            board.Armies[aname].Waiting = null;
            board.Armies[aname].IsWaiting = false;
            field.Army = board.Armies[aname];
            army = field.Army;
            // Need to add to avoid undefined
            army.Moved = false;
        }
        else if (count <= 0)
        {
            DeleteArmy(army);
            return;
        }
        army.Count = count >= 100 ? 99 : count;
        if (morale < 0)
        {
            morale = 0;
        }
        army.Morale = morale >= army.Count ? army.Count : morale;
        army.Party = party;
    }

    public static void CalcAIHelpers(Board board)
    {
        for (var partyIndex = 0; partyIndex < board.HwPartiesCount; partyIndex++)
        {
            for (var x = 0; x < board.HwXmax; x++)
            {
                for (var y = 0; y < board.HwYmax; y++)
                {
                    var field = GetField(x, y, board);
                    var path = PathFinder.FindPath(field, board.HwPartiesCapitals[partyIndex], Array.Empty<Models.Type>(), true);
                    if (path is null)
                    {
                        Console.Error.WriteLine("Path is undefined for (" + x + "," + y + ")");
                        continue;
                    }
                    field.Profitability[partyIndex] = -path.Count;
                    var neighbours = PathFinder.GetFurtherNeighbours(field);
                    neighbours.Add(field);
                    for (var n = 0; n < neighbours.Count; n++)
                    {
                        if (neighbours[n] is null)
                        {
                            continue;
                        }
                        if (neighbours[n].Capital == partyIndex)
                        {
                            field.NCapital[partyIndex] = true;
                        }
                        if (neighbours[n].Type == Models.Type.Town
                            || neighbours[n].Type == Models.Type.Capital)
                        {
                            field.NTown = true;
                        }
                    }
                }
            }
        }
    }

    public static void CleanupTurn(Board board)
    {
        var partyArmies = board.HwPartiesArmies[board.TurnParty];
        for (var armyIndex = 0; armyIndex < partyArmies.Count; armyIndex++)
        {
            if (partyArmies[armyIndex].Moved)
            {
                partyArmies[armyIndex].Moved = false;
            }
            else
            {
                partyArmies[armyIndex].Morale--;
            }
        }
    }

    public static void UpdateBoard(Board board)
    {
        ListArmies(board);
        for (var p = 0; p < board.HwPartiesCount; p++)
        {
            CheckPartyState(p, board);
        }
        board.HwPartiesTowns = new() { new List<Field>(), new List<Field>(), new List<Field>(), new List<Field>() };
        board.HwPartiesPorts = new() { new List<Field>(), new List<Field>(), new List<Field>(), new List<Field>() };
        board.HwPartiesLands = new() { new List<Field>(), new List<Field>(), new List<Field>(), new List<Field>() };
        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                var party = field.Party;
                //UpdateField(field, board);

                var targetParty = GetFieldParty(field);
                if (targetParty >= 0 && board.HwPartiesStatus[targetParty] == 0)
                {
                    if (field.Party >= 0 && board.HwPartiesCapitals[field.Party] is not null)
                    {
                        field.Party = board.HwPartiesCapitals[field.Party].Party;
                        if (field.Army is not null)
                        {
                            SetExplosion(field.Army, field.Army, null);
                        }
                    }
                }
                if (party >= 0)
                {
                    if (field.Type == Models.Type.Town
                        || field.Type == Models.Type.Capital)
                    {
                        board.HwPartiesTowns[party].Add(field);
                    }
                    else if (field.Type == Models.Type.Port)
                    {
                        board.HwPartiesPorts[party].Add(field);
                    }
                    else
                    {
                        board.HwPartiesLands[party].Add(field);
                    }
                }
            }
        }
        for (var partyIndex = 0; partyIndex < board.HwPartiesCount; partyIndex++)
        {
            var morale = 0.0;
            if (board.HwPartiesArmies[partyIndex].Count > 0)
            {
                for (var armyIndex = 0; armyIndex < board.HwPartiesArmies[partyIndex].Count; armyIndex++)
                {
                    if (board.HwPartiesArmies[partyIndex][armyIndex].Morale < (int)Math.Floor(board.HwPartiesTotalCount[partyIndex] / 50.0))
                    {
                        board.HwPartiesArmies[partyIndex][armyIndex].Morale = (int)Math.Floor(board.HwPartiesTotalCount[partyIndex] / 50.0);
                        // Morale can't be greater than the number of units
                        if (board.HwPartiesArmies[partyIndex][armyIndex].Morale > board.HwPartiesArmies[partyIndex][armyIndex].Count)
                        {
                            board.HwPartiesArmies[partyIndex][armyIndex].Morale = board.HwPartiesArmies[partyIndex][armyIndex].Count;
                        }
                    }
                    morale += board.HwPartiesArmies[partyIndex][armyIndex].Morale;
                }
                morale /= board.HwPartiesArmies[partyIndex].Count;
            }
            else
            {
                morale = 10;
            }
            board.HwPartiesMorale[partyIndex] = (int)Math.Floor(morale);
        }
        //var humanTotalPower = board.hw_parties_morale[board.human] + board.hw_parties_total_count[board.human];
        int? humanTotalPower = null;
        var humanCondition = 1;
        for (var partyIndex = 0; partyIndex < board.HwPartiesCount; partyIndex++)
        {
            if (partyIndex != board.Human && board.HwPartiesStatus[partyIndex] != 0)
            {
                if (humanTotalPower < 0.3 * (board.HwPartiesMorale[partyIndex] + board.HwPartiesTotalCount[partyIndex]))
                {
                    humanCondition = 3;
                }
                else if (humanCondition < 3
                  && humanTotalPower < 0.6 * (board.HwPartiesMorale[partyIndex] + board.HwPartiesTotalCount[partyIndex]))
                {
                    humanCondition = 2;
                }
                else if (board.Human >= 0
                    && board.HwPartiesProvincesCp[board.Human] is not null
                    && board.HwPartiesProvincesCp[board.Human].Count >= 2
                    && humanTotalPower > 2 * (board.HwPartiesMorale[partyIndex] + board.HwPartiesTotalCount[partyIndex]))
                {
                    humanCondition = 0;
                }
            }
        }
        board.HumanCondition = humanCondition;
    }

    public static int GetFieldParty(Field field)
    {
        if (field.Army is not null)
        {
            return field.Army.Party;
        }
        return field.Party;
    }

    public static void ListArmies(Board board)
    {
        for (var p = 0; p < board.HwPartiesCount; p++)
        {
            board.HwPartiesArmies[p] = new();
            board.HwPartiesTotalCount[p] = 0;
            board.HwPartiesTotalPower[p] = 0;
        }
        for (var x = 0; x < board.HwXmax; x++)
        {
            for (var y = 0; y < board.HwYmax; y++)
            {
                var field = GetField(x, y, board);
                if (field.Army is not null && field.Army.RemoveTime < 0)
                {
                    var armyParty = field.Army.Party;
                    board.HwPartiesArmies[armyParty].Add(field.Army);
                    board.HwPartiesTotalCount[armyParty] += field.Army.Count;
                    board.HwPartiesTotalPower[armyParty] += field.Army.Count + field.Army.Morale;
                }
            }
        }
    }

    public static void CheckPartyState(int party, Board board)
    {
        if (board.HwInit)
        {
            board.HwPartiesStatus[party] = -1;
            return;
        }
        var otherCapitals = new List<Field>();
        board.HwPartiesProvincesCp[party] = null;
        for (var p = 0; p < board.HwPartiesCount; p++)
        {
            if (board.HwPartiesCapitals[p].Party == party
              && p != party
              && board.HwPartiesArmies[p].Count == 0
            )
            {
                otherCapitals.Add(board.HwPartiesCapitals[p]);
            }
        }
        if (board.HwPartiesCapitals[party].Party != party)
        {
            // Original party no longer controls capital
            board.HwPartiesStatus[party] = 0;
        }
        else if (otherCapitals.Count > 0)
        {
            // Controls own capital and other capitals
            board.HwPartiesStatus[party] = 1 + otherCapitals.Count;
            board.HwPartiesProvincesCp[party] = otherCapitals;
        }
        else
        {
            // Only controls own capital
            board.HwPartiesStatus[party] = 1;
        }
    }

    public static bool IsVictory(Board board)
    {
        for (var p = 0; p < board.HwPartiesCount; p++)
        {
            if (board.HwPartiesProvincesCp[p] is not null &&
              board.HwPartiesProvincesCp[p].Count == board.HwPartiesCount - 1)
            {
                return true;
            }
        }
        return false;
    }

    public static void AnnexLand(int party, Field field, Board board, bool startup)
    {
        int[] moraleEarned(int party, Field field)
        {
            if (field.Type == Models.Type.Capital)
            {
                if (board.Human == party
                  && board.HwPartiesProvincesCp[party] is not null
                  && board.HwPartiesProvincesCp[party].Count >= 2)
                {
                    UpdateBoard(board);
                    board.Win = true;
                }
                if (field.Capital == field.Party)
                {
                    if (board.Human == party)
                    {
                        board.Subject = field;
                        board.News = "province_conquered";
                    }
                    return new[] { 50, 30 };
                }
                if (board.Human == party)
                {
                    board.Subject = field;
                    board.News = "town_captured";
                }
                return new[] { 30, 20 };
            }
            if (field.Type == Models.Type.Town)
            {
                if (/*board.human == party && */ (board.Subject is null || board.Subject.Type != Models.Type.Capital))
                {
                    board.Subject = field;
                    if (field.Party >= 0)
                    {
                        board.News = "town_captured";
                    }
                    else
                    {
                        board.News = "town_annexed";
                    }
                }
                return new[] { 10, 10 };
            }
            if (field.Type == Models.Type.Port)
            {
                if (/*board.human == party &&*/ (board.Subject is null
                    || (board.Subject.Type != Models.Type.Town && board.Subject.Type != Models.Type.Capital)))
                {
                    board.Subject = field;
                    if (field.Party >= 0)
                    {
                        board.News = "town_captured";
                    }
                    else
                    {
                        board.News = "town_annexed";
                    }
                }
                return new[] { 5, 5 };
            }
            if (field.Type == Models.Type.Land)
            {
                return new[] { 1, 0 };
            }
            return new[] { 0, 0 };
        }

        int moraleLost(int party, Field field)
        {
            if (field.Capital == party)
            {
                if (board.Human == party)
                {
                    UpdateBoard(board);
                    board.Win = false;
                }
            }
            else
            {
                if (field.Type == Models.Type.Capital)
                {
                    if (board.Human == party)
                    {
                        board.Subject = field;
                        board.News = "town_lost";
                    }
                    return -30;
                }
                if (field.Type == Models.Type.Town)
                {
                    if (board.Human == party && (board.Subject is null
                        || board.Subject.Capital < 0))
                    {
                        board.Subject = field;
                        board.News = "town_lost";
                    }
                    return -10;
                }
                if (field.Type == Models.Type.Port)
                {
                    if (board.Human == party && (board.Subject is null
                        || (board.Subject.Type != Models.Type.Town && board.Subject.Type != Models.Type.Capital)))
                    {
                        board.Subject = field;
                        board.News = "town_lost";
                    }
                    return -5;
                }
            }
            return 0;
        }

        if (field.Army is null && !startup)
        {
            return;
        }
        if (field.Type != Models.Type.Water)
        {
            if (field.Party >= 0 && field.Party != party)
            {
                AddMoraleForAll(moraleLost(field.Party, field), field.Party, board);
                if (field.Capital >= 0
                  && field.Capital == field.Party
                  && board.HwPartiesProvincesCp[field.Party] is not null
                  && board.HwPartiesProvincesCp[field.Party].Count != 0)
                {
                    // If you conquer another party that has control of capitals other than their own, liberate those capitals
                    for (var capitalIndex = 0; capitalIndex < board.HwPartiesProvincesCp[field.Party].Count; capitalIndex++)
                    {
                        if (board.HwPartiesProvincesCp[field.Party][capitalIndex].Army is not null)
                        {
                            SetExplosion(board.HwPartiesProvincesCp[field.Party][capitalIndex].Army, board.HwPartiesProvincesCp[field.Party][capitalIndex].Army, null);
                            board.HwPartiesProvincesCp[field.Party][capitalIndex].Army = null;
                        }
                        // Liberate capitals and give original owner new army
                        UpdateArmy(99, 99, board.HwPartiesProvincesCp[field.Party][capitalIndex].Capital, board, null, board.HwPartiesProvincesCp[field.Party][capitalIndex]);
                        AnnexLand(board.HwPartiesProvincesCp[field.Party][capitalIndex].Capital, board.HwPartiesProvincesCp[field.Party][capitalIndex], board, true);
                    }
                }
            }
            if (!startup && field.Party != party)
            {
                AddMoraleForAA(moraleEarned(party, field), field.Army, board);
            }
            field.Party = party;
            for (var n = 0; n < 6; n++)
            {
                if (field.Neighbours[n] is null)
                {
                    continue;
                }
                if (field.Neighbours[n].Type == Models.Type.Land
                  && field.Neighbours[n].Army is null
                  && !(board.HwPeace >= 0
                    && ((field.Neighbours[n].Party == board.HwPeace && party == board.Human)
                    || (party == board.HwPeace && field.Neighbours[n].Party == board.Human)))
                )
                {
                    if (!startup && field.Neighbours[n].Party != party)
                    {
                        AddMoraleForAA(moraleEarned(party, field.Neighbours[n]), field.Army, board);
                    }
                    field.Neighbours[n].Party = party;
                }
            }
        }
    }

    public static void MakeMove(int party, Board board/*, bool init*/)
    {
        var profitability = Bot.CalcArmiesProfitability(party, board);
        profitability = profitability.Order(new ArmyComparer()).ToList();

        if (profitability.Count == 0)
        {
            Console.Error.WriteLine("No possible moves for party ", board.HwPartiesNames[party]);
            return;
        }

        if (!profitability[0].Move.WaitForSupport)
        {
            board.HwPartiesWaitForSupportField[party] = null;
            board.HwPartiesWaitForSupportCount[party] = 0;
            MoveArmy(profitability[0], profitability[0].Move, board);
        }
        else
        {
            if (profitability[0].Move == board.HwPartiesWaitForSupportField[party])
            {
                board.HwPartiesWaitForSupportCount[party] = board.HwPartiesWaitForSupportCount[party] + 1;
            }
            else
            {
                board.HwPartiesWaitForSupportField[party] = profitability[0].Move;
                board.HwPartiesWaitForSupportCount[party] = 0;
            }
            var supportArmies = Bot.SupportArmy(party, profitability[0], profitability[0].Move, board);
            if (supportArmies.Count > 0)
            {
                supportArmies = supportArmies.Order(new ArmyComparer()).ToList();
                MoveArmy(supportArmies[0], supportArmies[0].Move, board);
            }
            else
            {
                MoveArmy(profitability[0], profitability[0].Move, board);
            }
        }
    }

    public static bool MoveArmy(Army army, Field field, Board board)
    {
        var afield = army.Field;

        // Pact was just broken
        if (board.HwPeace >= 0
          && ((field.Party == board.HwPeace && army.Party == board.Human)
          || (army.Party == board.HwPeace && field.Party == board.Human)))
        {
            AddMoraleForAll(30, field.Party, board);
            board.HwPactJustBroken = board.HwPeace;
            board.HwPeace = -1;
        }
        army.Field.Army = null;
        army.Field = field;
        army.Moved = true;
        if (field.Army is not null && field.Party != army.Party)
        {
            // Unit is in contact with enemy party
            if (!Attack(army, field, board))
            {
                UpdateBoard(board);
                return false;
            }
        }
        else if (field.Army is not null && field.Party == army.Party)
        {
            // Unit is joining with other friendly units
            if (field.Army.Count + army.Count <= 99)
            {
                JoinUnits(army.Count, army.Morale, army.Party, board, field.Army, null);
            }
            else
            {
                // Only move enough units to fill other army up to 99 units
                var chng = field.Army.Count + army.Count - 99;
                JoinUnits(99 - field.Army.Count, army.Morale, army.Party, board, field.Army, null);
                JoinUnits(chng, army.Morale, army.Party, board, null, afield);
            }
            SetArmyRemoval(army, field.Army);
            field.Army.Moved = true;
            AnnexLand(army.Party, field, board, false);
            UpdateBoard(board);
            return false;
        }
        field.Army = army;
        AnnexLand(army.Party, field, board, false);
        UpdateBoard(board);
        return true;
    }

    public static bool Attack(Army army1, Field field, Board board)
    {
        var army2 = field.Army;
        if (army2 is null)
        {
            return true;
        }
        var army1_pw = army1.Count + army1.Morale;
        var army2_pw = army2.Count + army2.Morale;
        if (army1_pw > army2_pw)
        {
            AddMoraleForAll(-(int)Math.Floor(army2.Count / 10.0), army2.Party, board);
            army1.Count -= (int)Math.Floor((double)army2_pw / army1_pw * army1.Count);
            army1.Count = army1.Count <= 0 ? 1 : army1.Count;
            army1.Morale = army1.Morale > army1.Count ? army1.Count : army1.Morale;
            SetExplosion(army1, army2, army1);
            return true;
        }
        AddMoraleForAll(-(int)Math.Floor(army1.Count / 10.0), army1.Party, board);
        army2.Count -= (int)Math.Floor((double)army1_pw / army2_pw * army1.Count);
        army2.Count = army2.Count <= 0 ? 1 : army2.Count;
        army2.Morale = army2.Morale > army2.Count ? army2.Count : army2.Morale;
        SetExplosion(army1, army1, army2);
        return false;
    }

    public static void SetArmyRemoval(Army army, Army army_waiting)
    {
        army.Remove = true;
        army.RemoveTime = 24;
        if (army_waiting is not null)
        {
            army.Waiting = army_waiting;
            army_waiting.IsWaiting = true;
        }
    }

    public static void SetExplosion(Army attacking, Army exploding, Army army_waiting)
    {
        exploding ??= attacking;
        attacking.Exploding = exploding;
        exploding.RemoveTime = 36;
        if (army_waiting is not null)
        {
            attacking.Waiting = army_waiting;
            army_waiting.IsWaiting = true;
        }
    }

    public static void DeleteArmy(Army army)
    {
        if (army.Field.Army == army)
        {
            army.Field.Army = null;
        }
    }

    public static void AddMorale(int morale, Army army)
    {
        morale += army.Morale;
        if (morale < 0)
        {
            morale = 0;
        }
        army.Morale = morale >= army.Count ? army.Count : morale;
    }

    public static void AddMoraleForAll(int morale, int party, Board board)
    {
        if (morale == 0)
        {
            return;
        }
        for (var armyIndex = 0; armyIndex < board.HwPartiesArmies[party].Count; armyIndex++)
        {
            AddMorale(morale, board.HwPartiesArmies[party][armyIndex]);
        }
    }

    public static void AddMoraleForAA(int[] morale, Army army, Board board)
    {
        AddMorale(morale[1], army);
        if (morale[0] != 0)
        {
            AddMoraleForAll(morale[0], army.Party, board);
        }
    }

    public static void UpdateArmies(Board board)
    {
        foreach (var (key, value) in board.Armies)
        {
            var army = value;
            if (board.HwPartiesStatus[army.Party] == 0)
            {
                DeleteArmy(army);
                board.Armies.Remove(key);
                continue;
            }

            //if (army._x != army.field._x || army._y != army.field._y)
            //{
            //    army._x = army._x - (army._x - army.field._x) / 2;
            //    army._y = army._y - (army._y - army.field._y) / 2;
            //    if (Math.abs(army._x - army.field._x) <= 1 && Math.abs(army._y - army.field._y) <= 1)
            //    {
            //        army._x = army.field._x;
            //        army._y = army.field._y;
            //    }
            //}
            //else
            {
                if (army.Remove || army.RemoveTime > 0)
                {
                    army.Waiting ??= new();
                    army.Waiting.IsWaiting = false;
                    DeleteArmy(army);
                    board.Armies.Remove(key);
                }
            }
        }
    }

    public static int GetMovePoints(int turnParty, Board board)
    {
        var movePoints = 5;
        var movableArmyCount = Bot.GetMovableArmies(turnParty, board).Count;
        if (movePoints > movableArmyCount)
        {
            movePoints = movableArmyCount;
        }
        return movePoints;
    }

    private class ArmyComparer : IComparer<Army>
    {
        public int Compare(Army a, Army b)
        {
            var armyAProfitability = a.Profitability;
            var armyBProfitability = b.Profitability;
            if (armyAProfitability > armyBProfitability)
            {
                return -1;
            }
            if (armyAProfitability < armyBProfitability)
            {
                return 1;
            }
            var armyATotal = a.Count + a.Morale;
            var armyBTotal = b.Count + b.Morale;
            if (armyATotal > armyBTotal)
            {
                return -1;
            }
            if (armyATotal < armyBTotal)
            {
                return 1;
            }
            return 0;
        }
    }
}
