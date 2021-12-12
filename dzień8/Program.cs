var text = args[0];
var a = text.ToLower().Where(Char.IsLetter);
var b = a.Reverse();

if (a.SequenceEqual(b))
  Console.WriteLine($"\"{text}\" jest palindromem!");
else
  Console.WriteLine($"\"{text}\" nie jest palindromem!");



