# ItCentral
## Aplikacja sklada sie z dwóch cześci
- A: aplikacja konsolowa, szyfruje wiadomośc o tresci
"ala ma kota " + argument aplikacji+losowy ciag + " " + DateTime.Now.ToLongTimeString();
i umieszcza w bazie, apotem wywołuje web api aby wiadomość odkodować

- B: aplikacka web api, która na podstawie przesłanego klucza, wybiera z bazy zakodowaną wiadomość
i ją odkodowuje

## Generowanie bazy
- Przechodzimy do katalogu ItCentral\ItCentral
- Modyfikuje plik połączenie w pliku appsettings.json
- Jeśli nie ma katalogu Migrations to wykonujemy polecenie **dotnet ef migrations add InitialCreate**
- Poleceniem **dotnet ef database update** generujemy baze z tabelami
  
![baza](https://github.com/swdowia1/itCentral/assets/5527467/816a0897-29fc-4ae3-b1fc-b15f239f03ea)

## Uruchomienie aplikacji web api

- W katalogu ItCentral\ItCentral uruchamiamy polecenie **dotnet run**\
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5167
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\dysk_d\projekty\ItCentral\ItCentral

Możemy zweryfikować aplikacje. W onie przeglądarki wpisujemy adres **http://localhost:5167/swagger/index.html**

Uruchomienie aplikacji Konsolowej
- Przechodzimy do katalogu ItCentral\ItCentralConsole\bin\Debug\net8.0
- Modyfikujemy plik appsettings.json. Zmieniamy ConnectionString(ma być taki sam jak w pliku ItCentral\ItCentral\appsettings.json)
- Uruchamiamy aplikacje z opcjami:\
ItCentralConsole.exe o: dane o autorze i kiedy było modyfikowane repozytorium\
ItCentralConsole.exe klient1: co 10 sekund aplikacja wysyła zaszyfrowany tekst do bazy i poobiera odszyfrowany tekst
![itcentral1](https://github.com/swdowia1/itCentral/assets/5527467/a9b030f2-3f83-434e-87bd-c54499969cf3)

## Testowanie(Unit test)
- Przechodzimy do katalogu ItCentral\ItCentralTesty
- Poleceniem **dotnet** test wywołany 2 unit testy aplikacji


