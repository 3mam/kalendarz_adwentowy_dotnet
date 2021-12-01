
var getRest = (int val) => (
    rest100: val/100,
    rest25:  val%100/25,
    rest10:  val%100%25/10,
    rest5:   val%100%25%10/5,
    rest1:   val%100%25%10%5
);


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

