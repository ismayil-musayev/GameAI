namespace GameAI.GameHexEmpire.Models;

public class Tile
{
    public Field Field { get; set; }

    public Tile Parent { get; set; }

    public double Dc { get; set; }

    public double Tc { get; set; }
}
