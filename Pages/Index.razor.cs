using GameAI.GameHexEmpire;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics;

namespace GameAI.Pages;

public partial class Index
{
    [Inject]
    public IJSRuntime JS { get; set; }

    Components.Map board;

    int map = new Random().Next(0, 999999);
    int Map { get { return map; } set { map = value % 1000000; } }

    readonly Game game = new();
    bool gameRunning = false;

    protected override void OnInitialized()
    {
        Map = 1;
        game.GenerateNewMap(Map);
    }

    void ChangeMap()
    {
        game.GenerateNewMap(Map);
    }

    void RandomMap()
    {
        Map = new Random().Next(0, 999999);
        game.GenerateNewMap(Map);
    }

    void MakeTurn()
    {
        if (game.IsVictory())
        {
            return;
        }

        game.RunTurn();
    }

    async Task StartBattle()
    {
        var sw2 = new Stopwatch();
        sw2.Start();

        long runTime = 0;
        long refreshTime = 0;
        var sw = new Stopwatch();

        if (game.IsVictory())
        {
            game.GenerateNewMap(game.MapNumber);
        }

        Map = game.MapNumber;
        gameRunning = true;

        var maxTurnLimit = 150;

        while (!game.IsVictory() && game.Turns < maxTurnLimit)
        {
            sw.Start();
            game.RunTurn();
            sw.Stop();
            runTime += sw.ElapsedMilliseconds;
            sw.Reset();

            sw.Start();
            board.Refresh();
            sw.Stop();
            refreshTime += sw.ElapsedMilliseconds;
            sw.Reset();

            await Task.Delay(100);
        }

        sw2.Stop();

        Console.WriteLine(runTime + " | " + refreshTime + " | " + sw2.ElapsedMilliseconds);

        gameRunning = false;
    }
}
