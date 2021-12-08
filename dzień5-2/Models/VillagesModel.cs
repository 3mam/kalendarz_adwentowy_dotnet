namespace mvc.Models;
public record Village(string Name, int People);
public class VillagesModel
{
  static readonly List<Village> _villages = new List<Village>();
  static readonly VillagesModel _instance = new VillagesModel();
  VillagesModel()
  {
    _villages.Add(new Village(Name: "Biały Sad", People: 20));
    _villages.Add(new Village(Name: "Podgaje", People: 25));
    _villages.Add(new Village(Name: "Zalipie", People: 40));
    _villages.Add(new Village(Name: "Poróg", People: 10));
    _villages.Add(new Village(Name: "Jawornik", People: 30));
  }

  public static List<Village> List() => _villages;
  public static Village Village(int id) => _villages[id];

  public static Village Remove(int id)
  {
    var village = _villages[id];
    _villages.Remove(village);
    return village;
  }

  public static void Replace(int id, Village village) => _villages[id] = village;

  public static void Add(Village village) => _villages.Add(village);

}
