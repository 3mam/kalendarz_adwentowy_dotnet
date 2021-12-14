class DrawPlayer
{
  List<int> _ignore = new();
  Random _random = new();
  int _last;
  int _max;

  public static DrawPlayer Max(int max) => new DrawPlayer()
  {
    _max = max
  };
  public int Next()
  {
    while (true)
    {
      var number = _random.Next(_max);
      if (!_ignore.Contains(number))
      {
        _last = number;
        return number;
      }
    }
  }
  public void Ignore() => _ignore.Add(_last);
}