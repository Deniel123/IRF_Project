A beadandó során elkészített program a járvány miatt megnövekedett kórházi zsúfoltsággal járó adminisztrációs nehézségek leküzdésére jött létre. 
Az adatbázist SSMS-ben hoztam létre, benne csak kitalált nevek és adatok szerepelnek. 
A program indításakor betöltődnek a betegek adatai, és a három gomb a fő funkciókkal, amik a következőek:

- Elhunytak listája: Egy új formot nyit meg, amin csak azoknak a nevei szerepelnek, akik elhunytak.
- Törlés: A nyilvántartásból a kijelölt beteg eltávolítása a gombra kattintva
- Exportálás excelbe: Az összes beteg adatát egy formázott Excel munkafüzetbe exportálja.

Ezen kívül a második formon a graph osztályt használva egy gyertya képe rajzolódik ki az elhunytak listája mellett, és itt is lehetőség van a listából törlésre. 
Az adatbázis csak az sqlexpress-ben változtatható, a végleges verziót egy projekthez hozzáadott lokális adatbázisba töltöttem fel.
Az adatbázist a C:\Temp\ mappából nem tudtam elérni, ezért a program készítése során végig az IRF_Project2 könyvtárban volt. 
