var getNumber = () =>
{
  Console.WriteLine("\rPodaj numer aby uzyskać informacje o dziecku:");
  var key = Console.ReadLine() ?? default!;
  try
  {
    return Int32.Parse(key);
  }
  catch (System.FormatException)
  {
    return -1;
  }
};

var selectItem = (Items[] items) =>
{
  while (true)
  {
    var index = getNumber();
    if (index <= 0 || index >= items.Length)
      Console.WriteLine("\rPod podaną liczbą nie ma dziecka");
    else
      return (item: items[index - 1], index: index);
  }
};

var optionsSelect = () =>
{
  Console.WriteLine(@$"
{$"\x1b[1mz\x1b[0m"} zapisz 
{$"\x1b[1mspacja\x1b[0m"} kontynuuj 
{$"\x1b[1mdowolny klawisz\x1b[0m"} zakończ
");
  switch (Console.ReadKey().Key)
  {
    case ConsoleKey.Z: return Options.Save;
    case ConsoleKey.Spacebar: return Options.Continue;
    default: return Options.Quit;
  }
};

var csv = File.ReadAllText("lista_prezentów.csv");
var items = csv.Split('\n')
.Where((v, i) => v != "" && i > 0)
.Select(v => v.Split(','))
.Select(v => new Items(
  FirstName: v[0],
  LastName: v[1],
  Age: Int32.Parse(v[2]),
  Gift: v[3]
))
.ToArray();

Console.Write($@"
{'\t'} Witaj Mikołaju!
Obecnie na liście jest {$"\x1b[1m{items.Length}\x1b[0m"} dzieci.
");

while (true)
{
  var (item, index) = selectItem(items);
  Console.Write(item.ToString());
options:
  switch (optionsSelect())
  {
    case Options.Quit:
      Console.WriteLine("\rDo widzenia");
      return;
    case Options.Continue: continue;
    case Options.Save:
      var name = $"{index}.txt";
      File.WriteAllText(name, item.ToString());
      Console.WriteLine($"\rZapisano w {name}");
      goto options;
  }
}