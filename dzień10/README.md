# Dzień 10

## Treść zadania
Czy w Twojej rodzinie też jest tradycja losowania jednej osoby, której się kupuje jeden prezent niespodziankę?
U mnie nie :P, ale słyszałem, że w wielu domach to częsta praktyka. Działą to tak, że mamy koszyk z kawałkami papieru, na którym wypisane są imiona wszystkich osób z rodziny.
Koszyk z kawałkami papieru jest tak bardzo XX wieczny... dlatego napisz metodę, która przyjmie imiona wszystkich osób w rodzinie i wylosuje odpowiednie pary. Jednak jest kilka założeń. Osoby z tego samego domu nie mogą być dla siebie parą, żadna osoba nie może być parą dla siebie, 2 osoby nie mogą być parą dla siebie nawzajem.
### Przykład
Jacek, Marta (1 dom). Anna, Waldemar, Mariusz (2 dom), Maciek, Ola (3 dom).
### Możliwe pary:
```
Jacek -> Mariusz
Marta -> Maciek
Anna -> Jacek
Waldemar -> Ola
Maciek -> Anna
Ola -> Waldemar
```

## Uruchomienie
> dotnet run

## Przykład 
> dotnet run

```
Jacek -> Waldemar
Marta -> Maciek
Anna -> Ola
Waldemar -> Marta
Mariusz -> Jacek
Maciek -> Mariusz
Ola -> Anna
```

## Wyjaśnienie
Nie jestem zadowolony z kodu. Ponieważ nie byłem wstanie wymyślić zadowalającego mnie rozwiązania.
Działa i jest wstanie generować za każdym razem inne pary. 

Choć potrafi dojść do takiej sytuacji że ostatnie osoby nie mogą znaleźć wolnej party. Dlatego jest zliczana ilość przebiegów pętli i w razie czego zacznie od nowa.
Ale gdyby lista była ręcznie zmieniana to można doprowadzić do takiej sytuacji że program nie byłby w stanie zakończyć działania przez niemożliwość znalezienia par.