namespace GameAI.GameHexEmpire.Models;

public class Army
{
    public int Party { get; set; }

    public int Count { get; set; }

    public int Morale { get; set; }

    public bool Moved { get; set; }

    public Field Field { get; set; }

    public Field Move { get; set; }

    public double Profitability { get; set; }

    public bool Remove { get; set; }
    public int RemoveTime { get; set; }

    public Army Exploding { get; set; }

    public Army Waiting { get; set; }
    public bool IsWaiting { get; set; }

    public override string ToString()
    {
        return $"Party {Party}; Count: {Count}; Morale {Morale}; Profitability: {Profitability}";
    }
}
