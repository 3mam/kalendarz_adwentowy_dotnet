
var encoding = (int shift, string text) =>
String.Join("",
text.Select(c => (int)c switch
  {
    (>= 65) and (<= 90) => (char)((c + shift - 65) % 26 + 65),
    (>= 97) and (<= 122) => (char)((c + shift - 97) % 26 + 97),
    _ => c,
  }
));

var encodeText = encoding(Int32.Parse(args[0]), args[1]);
Console.Write($@"
Oryginalny tekst:
{args[1]}
Zaszyfrowany tekst:
{encodeText}
");