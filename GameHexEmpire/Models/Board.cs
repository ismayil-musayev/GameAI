namespace GameAI.GameHexEmpire.Models;

public class Board
{
    public bool HwInit { get; set; }
    public int HwXmax { get; set; }
    public int HwYmax { get; set; }
    public int HwFw { get; set; }
    public int HwFh { get; set; }
    public int HwLand { get; set; }
    public int HwTopFieldDepth { get; set; }
    public List<List<Field>> HwLands { get; set; }
    public List<Field> HwTowns { get; set; }
    public List<Field> HwPartiesCapitals { get; set; }
    public int HwPartiesCount { get; set; }
    public List<string> HwPartiesNames { get; set; }
    public List<List<Field>> HwPartiesProvincesCp { get; set; }
    public List<List<Field>> HwPartiesTowns { get; set; }
    public List<List<Field>> HwPartiesPorts { get; set; }
    public List<List<Field>> HwPartiesLands { get; set; }
    public List<int> HwPartiesMorale { get; set; }
    public List<List<Army>> HwPartiesArmies { get; set; }
    public List<int> HwPartiesStatus { get; set; }
    public List<int> HwPartiesTotalCount { get; set; }
    public List<int> HwPartiesTotalPower { get; set; }
    public List<string> HwPartiesControl { get; set; }
    public List<Field> HwPartiesWaitForSupportField { get; set; }
    public List<int> HwPartiesWaitForSupportCount { get; set; }
    public List<bool> HwPartiesSpeechGiven { get; set; }
    public bool HwPactSigned { get; set; }
    public int HwPactJustBroken { get; set; }
    public int HwPeace { get; set; }
    public int HwLAid { get; set; }
    public int HwaTL { get; set; }
    public int LhArea { get; set; }
    public int Human { get; set; }
    public int HumanCondition { get; set; }
    public int Turns { get; set; }
    public int Wait { get; set; }
    public int TurnParty { get; set; }
    public int Difficulty { get; set; }
    public bool Duel { get; set; }
    public List<List<Field>> Fields { get; set; } = new();
    public bool Win { get; set; }
    public Field Subject { get; set; }
    public string News { get; set; }
    public Dictionary<string, Army> Armies { get; set; } = new();
}
