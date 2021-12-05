#!/usr/bin/python3

from mimesis import Person
from mimesis.locales import Locale
import csv
import random

person = Person(Locale.PL)
items = [
   'hulajnoga', 'rower', 'konsola do gier', 'lalka', 'pluszowy miś',
   'resoraki', 'piłka', 'skakanka', 'kurs .net', 'klocki',
   'puzzle', 'domek dla lalek', 'samochód zdalnie sterowany', 'komputer',
   'tablet', 'zestaw kredek', 'zegarek', 'zestaw flamastrów', 'dinozaur',
   'pistolet na kulki', 'proca', 'quad', 'skuter', 'psa',
   'deskorolka', 'grę planszową', 'trąbka', 'gitara', 'skrzypce',
   'skarbonkę', 'bierki', 'jednoroszca', 'żółwia', 'teleskop',
   'lornetkę', 'wrotki', 'tamagotchi', 'dron', 'telefon' 
]
with open('lista_prezentów.csv', 'w', newline='') as csvfile:
    fieldnames = ['imię', 'nazwisko', 'wiek', 'prezent']
    writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
    writer.writeheader()
    for _ in range(100):
      writer.writerow({
       'imię': person.first_name(),
       'nazwisko': person.last_name(),
       'wiek': person.age(5,15),
       'prezent': items[random.randint(0,len(items)-1)]
       })