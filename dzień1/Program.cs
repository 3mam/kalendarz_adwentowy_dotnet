
var getRest = (int val) =>
{
  var val100 = (val / 100) * 100;
  var val10 = Math.Abs(val100 - ((val / 10) * 10));
  var val1 = Math.Abs(val - val100 - val10);
  var rest100 = val100 / 100;
  var rest25 = val10 / 25;
  var rest10 = val10 % 25 / 10;
  var rest5 = val1 / 5;
  var rest1 = val1 % 5;
  return (
    rest100: rest100,
    rest25: rest25,
    rest10: rest10,
    rest5: rest5,
    rest1: rest1
    );
};

var val = Int32.Parse(args[0]);
var rest = getRest(val);
Console.WriteLine($@"
Reszta z {val}
Suma wszystkich monet {rest.rest100+rest.rest25+rest.rest10+rest.rest5+rest.rest1}
100: {rest.rest100}
 25: {rest.rest25}
 10: {rest.rest10}
  5: {rest.rest5}
  1: {rest.rest1}
");

