# ItCentral
Aplikacja sklada sie z dwóch cześci
-A- aplikacja konsolowa, szyfruje wiadomośc o tresci
"ala ma kota " + argument aplikacji+losowy ciag + " " + DateTime.Now.ToLongTimeString();
i umieszcza w bazie, apotem wywołuje web api aby wiadomość odkodować

-B- aplikacka web api, która na podstawie przesłanego klucza, wybiera z bazy zakodowaną wiadomość
i ją odkodowuje


- wygenerowałem model EF na podstawie przesłanej bazy danych



W szerszym zakresie
- podzielenie na warstwy(oddzielne projekty)
- użycie serwisów i interfejsów
- dodanie projektu z Unit Test(Mock, Nunit)
- użycie web api kontrollerów(aby np w miarę sprawnie wykorzystać AngularJS)


Dodatkowo w ramach wsparcia pracy wykorzystałem
- GitHub(historia zmian w projekcie) https://github.com/swdowia1/adw
![itcentral1](https://github.com/swdowia1/itCentral/assets/5527467/a9b030f2-3f83-434e-87bd-c54499969cf3)
