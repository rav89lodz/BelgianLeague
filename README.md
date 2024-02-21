## Run Application

1. Create a database and add it to the configuration.
2. Run "update-database" command in Package Manager Console
3. The database will be automatically supplemented with starting data

## Steps

1. Na pocz�tku rozrysowa�em sobie baz� danych i przep�ywy danych
2. Utworzy�em Encje oraz migracje
3. Doda�em kilka Seeder�w �eby mie� dane testowe
4. Doda�em akcje w kontrolerze i stworzy�em serwisy do ich obs�ugi
5. Doda�em repozytoria do obs�ugi zapyta� do DB
6. Utworzy�em widoki i napisa�em do nich JS i CSS

## More info

Skorzysa�em z MySQL poniewa� tak� baz� mam zainstalowan� na komputerze i tak by�o dla mnie najszybciej. Do obs�ugi tego rodzaju DB �ci�gn��em paczk� Pomelo

Zdaj� sobie spraw�, �e niekt�re rzeczy zrobi�em "na sztywno" np. w LeagueService w funkcji getData(), ale zrobi�em tak �eby by�o szybciej napisane. Je�li mia�bym rozbudowa� aplikacj�,
to doda�bym np. drug� lig� albo kolejne sezony i wtedy do tej funckji przekazywa� bym parametry do wczytania odpowiedniej tabeli dla wybranej ligii i sezonu. Mo�na by te� doda� opcje usuwania
konta oraz przypomnienia has�a dla u�ytkownika, ale tego te� nie zrobi�em (na razie). 