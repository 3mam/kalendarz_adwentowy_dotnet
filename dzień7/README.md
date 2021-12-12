# Dzień 7

## Treść zadania
Dziś kolejne pytanie.

```c#
for (int i = 0; i < n; i++)
  for (int j = i; j < n; j++)
    array[j] += 2;
```
Napisz, jaka jest złożoność obliczeniowa tego fragmentu kodu (według notacji Wielkiego O) i wytłumacz dlaczego.

## Odpowiedź
Niestety mój mózg się podał przy próbuje zgłębienia czym jest notacja Dużego O.   

## Rozwiązanie
Złożoność tego krótkiego fragmentu kodu to O(n^2), ponieważ całość kodu wykona się przechodząc przez n wywołań zewnętrznej pętli, oraz n wywołań wewnętrznej pętli.
Ogólnie notację Wielkiego O stosuje się do obliczania najbardziej pesymistycznego przypadku, w którym znajdziemy poszukiwaną wartość.
Wyróżniamy złożoność czasu  (w jakim czasie zostanie wykonany kod) i miejsca (ile przestrzeni zostanie zaalokowane do wykonania tego kodu).