record Items
{
  public string FirstName { get; init; } = default!;
  public string LastName { get; init; } = default!;
  public int Age { get; init; } = default!;
  public string Gift { get; init; } = default!;

  public override string ToString() => @$"
Imię: {FirstName} 
Nazwisko: {LastName} 
Wiek: {Age} 
Prezent: {Gift}
  ";
}