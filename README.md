# ItCentral
Aplikacja sklada sie z dwóch cześci
- A: aplikacja konsolowa, szyfruje wiadomośc o tresci
"ala ma kota " + argument aplikacji+losowy ciag + " " + DateTime.Now.ToLongTimeString();
i umieszcza w bazie, apotem wywołuje web api aby wiadomość odkodować

- B: aplikacka web api, która na podstawie przesłanego klucza, wybiera z bazy zakodowaną wiadomość
i ją odkodowuje



![itcentral1](https://github.com/swdowia1/itCentral/assets/5527467/a9b030f2-3f83-434e-87bd-c54499969cf3)
