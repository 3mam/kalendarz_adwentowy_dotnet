# Dzień 6

## Treść zadania
Dziś kolejne pytanie.
Jaka jest różnica między interfejsem, a klasą abstrakcyjną.


## Odpowiedź
Różnice są takie że interfejsy nie są klasą.
Mimo że można umieszczać implementacje metod. Co mozę kojarzyć się z klasą abstrakcyjną.

Interfejs to typ referencyjny który potrafi wchodzić w interakcje z innymi typami, takimi jak **class**, **record** i **struct**.
Każdy z wymienionych typów jeżeli używa interfejsów, musi mieć zaimplementowane metody i właściwości zgodne z interfejsem. Jednakże może zdarzyć się tak, że kilka użytych interfejsów może mieć zbiór takich samych metod i właściwości.
W takim przypadku **C#** pozwala na definiowanie w typach dla każdego interfejsu osobnej implementacji.
Najlepiej zobrazuje to przykład:
```c#
var a = new Foo();
IFoo1 b = a;
IFoo2 c = a;
a.sayHello();//Witaj z klasy Foo
b.sayHello();//Witaj z klasy Foo przy użyciu interfejsu IFoo1
c.sayHello();//Witaj z klasy Foo przy użyciu interfejsu IFoo2

interface IFoo1
{
  void sayHello();
}

interface IFoo2
{
  void sayHello();
}

class Foo : IFoo1, IFoo2
{
  public void sayHello() => Console.WriteLine("Witaj z klasy Foo");
  void IFoo1.sayHello() => Console.WriteLine("Witaj z klasy Foo przy użyciu interfejsu IFoo1");
  void IFoo2.sayHello() => Console.WriteLine("Witaj z klasy Foo przy użyciu interfejsu IFoo2");
}
```
Trzy implementacje metody o tej samej nazwie ale w zależności od kontekstu inny efekt.

Co się tyczy klasy abstrakcyjnej.
Posiada takie same właściwości co zwykła klasa. Jednakże nie może zostać użyta bezpośrednio. A jedynie po przez klasę która dziedziczy.
Klasa abstrakcyjna jest używana jako fundament pod przyszłe klasy. I oczekuje że klasa która będzie dziedziczyć uzupełni wymagane metody o własne implementacje. Ewentualnie pozwoli zastąpić już istniejące.