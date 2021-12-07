record Person(string FirstName, string LastName, int Age, string Gift)
{
  public override string ToString() => @$"
Imię: {FirstName} 
Nazwisko: {LastName} 
Wiek: {Age} 
Prezent: {Gift}
  ";
}