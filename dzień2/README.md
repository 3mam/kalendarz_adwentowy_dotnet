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
> dotnet run -- 6 "Ala ma kota"  

```
Oryginalny tekst:
Ala ma kota
Zaszyfrowany tekst:
Grg sg quzg
Odszyfrowany tekst:
Ala ma kota
```

## Objaśnienie
Na krótkie objaśnienie zasługuje użyty algorytm który dba o to aby podana wartość nie przekraczała zakresu liczb.
Każdy znak ASCII ma przydzieloną liczbę. I tak litery duże są w przedziale od 65 do 90. Zaś małe w przedziale od 97 do 122. Także małe i duże litery mają po 26 znaków.
Aby rozszyfrować zakodowaną wiadomość kluczowe było użycie operatora modulo z **Pytona**.
Ponieważ w **Pytonie** operator działa nieco inaczej w przypadku liczb niepodzielnych. Co w tym przypadku było potrzebne.
