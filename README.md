## Run Application

1. Create a database and add it to the configuration.
2. Run "update-database" command in Package Manager Console
3. The database will be automatically supplemented with starting data

## Steps

1. Na pocz¹tku rozrysowa³em sobie bazê danych i przep³ywy danych
2. Utworzy³em Encje oraz migracje
3. Doda³em kilka Seederów ¿eby mieæ dane testowe
4. Doda³em akcje w kontrolerze i stworzy³em serwisy do ich obs³ugi
5. Doda³em repozytoria do obs³ugi zapytañ do DB
6. Utworzy³em widoki i napisa³em do nich JS i CSS

## More info

Skorzysa³em z MySQL poniewa¿ tak¹ bazê mam zainstalowan¹ na komputerze i tak by³o dla mnie najszybciej. Do obs³ugi tego rodzaju DB œci¹gn¹³em paczkê Pomelo

Zdajê sobie sprawê, ¿e niektóre rzeczy zrobi³em "na sztywno" np. w LeagueService w funkcji getData(), ale zrobi³em tak ¿eby by³o szybciej napisane. Jeœli mia³bym rozbudowaæ aplikacjê,
to doda³bym np. drug¹ ligê albo kolejne sezony i wtedy do tej funckji przekazywa³ bym parametry do wczytania odpowiedniej tabeli dla wybranej ligii i sezonu. Mo¿na by te¿ dodaæ opcje usuwania
konta oraz przypomnienia has³a dla u¿ytkownika, ale tego te¿ nie zrobi³em (na razie). 