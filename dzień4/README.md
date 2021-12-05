# Dzień 4

## Treść zadania
Załóżmy że masz plik z danymi ze wszystkich listów wysłanych do mikołaja. Plik zawiera imię i nazwisko dziecka, jego wiek oraz 1 najbardziej wymarzony prezent.
Plik jest w formacie csv.
Napisz aplikację, która odczyta ten plik, pozwoli na zwrócenie dowolnego wiersza i wypisania go na ekranie, oraz zapisanie do nowego pliku.

## Uruchomienie
> dotnet run

## Przykład 
```
         Witaj Mikołaju!
Obecnie na liście jest 100 dzieci.
Podaj numer aby uzyskać informacje o dziecku:
21

Imię: Bolesław 
Nazwisko: Purcelewska 
Wiek: 14 
Prezent: komputer
  
z zapisz 
spacja kontynuuj 
dowolny klawisz zakończ

Zapisano w 21.txt

z zapisz 
spacja kontynuuj 
dowolny klawisz zakończ

Do widzenia
```
## Objaśnienie
Do wygenerowania danych osobowych użyłem Pytona i biblioteki mimesis.
Dzięki czemu mogłem w łatwy sposób stworzyć plik **csv** który zawiera 100 osób.