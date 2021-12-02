
var encoding = (int shift, string text) =>
String.Join("",
text.Select(c => (int)c switch
  {
    (>= 65) and (<= 90) => (char)((c + shift - 65) % 26 + 65),
    (>= 97) and (<= 122) => (char)((c + shift - 97) % 26 + 97),
    _ => c,
  }
));

var pyModulo = (int a, int b) => ((a % b) + b) % b;
var decoding = (int shift, string text) =>
String.Join("",
text.Select(c => (int)c switch
  {
    (>= 65) and (<= 90) => (char)(pyModulo(c - shift - 65, 26) + 65),
    (>= 97) and (<= 122) => (char)(pyModulo(c - shift - 97, 26) + 97),
    _ => c,
  }
));

var shift = Int32.Parse(args[0]);
var text = args[1];
var encodeText = encoding(shift, text);
var decodeText = decoding(shift, encodeText);
Console.Write($@"
Oryginalny tekst:
{args[1]}
Zaszyfrowany tekst:
{encodeText}
Odszyfrowany tekst:
{decodeText}
");