# Dzień 2

## Treść zadania
Napisz program, który zaszyfruje podany tekst za pomocą szyfru Cezara o zadanym przesunięciu.
Zadbaj o zachowanie wielkich i małych liter.
Znaków numerycznych oraz znaków "białych"
nie przesuwaj.
Dla prostoty załóż wykorzystanie języka angielskiego.

## Uruchomienie
> dotnet run -- wartość "tekst"

## Przykład 
> dotnet run -- 6 "ala"

```
Oryginalny tekst:
ala
Zaszyfrowany tekst:
grg
```

## Objaśnienie
Na krótkie objaśnienie zasługuje użyty algorytm który dba o to aby podana wartość nie przekraczała zakresu liczb.
Każdy znak ASCII ma przydzieloną liczbę. I tak litery duże są w przedziale od 65 do 90. Zaś małe w przedziale od 97 do 122. Także małe i duże litery mają po 26 znaków.
