var list = new List<Player>() {
  new Player("Jacek", 1),
  new Player("Marta", 1),
  new Player("Anna", 2),
  new Player("Waldemar", 2),
  new Player("Mariusz", 2),
  new Player("Maciek", 3),
  new Player("Ola", 3),
};

var fitPlayers = (List<Player> list) =>
{
restart:
  var drawPlayer = DrawPlayer.Max(list.Count());
  List<string> parList = new();
  int countLoop = 0;
  foreach (var player in list)
  {
    while (true)
    {
      var number = drawPlayer.Next();
      Player nextPlayer = list[number];
      if (player.House != nextPlayer.House)
      {
        parList.Add($"{player.FirstName} -> {nextPlayer.FirstName}");
        drawPlayer.Ignore();
        break;
      }
      if (countLoop++ > 10)
        goto restart;
    }
  }
  return parList;
};


var playerParList = fitPlayers(list);
foreach (var i in playerParList)
  Console.WriteLine(i);

record Player(string FirstName, int House);
