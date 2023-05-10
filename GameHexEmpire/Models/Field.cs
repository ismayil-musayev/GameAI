namespace GameAI.GameHexEmpire.Models;

public class Field
{
    public Type Type { get; set; }

    public int Fx { get; set; }

    public int Fy { get; set; }

    public int LandId { get; set; }

    public bool Tl { get; set; }

    public List<Field> Neighbours { get; set; } = new List<Field>(6);

    public Army Army { get; set; }

    public int Party { get; set; }

    public int Capital { get; set; }

    public bool NTown { get; set; }

    public string TownName { get; set; }

    public int[] Profitability { get; set; } = new[] { 0, 0, 0, 0 };

    public double TmpProf { get; set; }

    public bool[] NCapital { get; set; } = new[] { false, false, false, false };

    public bool WaitForSupport { get; set; }
}

public enum Type
{
    Water = 0,
    Land = 1,
    Port = 2,
    Town = 3,
    Capital = 4
}
