# Elektromos rendszer  
  
Az út ötödik éjszakáján egy hatalmas vihar csapott le a hajóra. Kicsit csitult már a vihar és végre sikerült elaludnod, amikor kopogásra riadsz fel. Kapitány az, és a segítségedre van szüksége.  
A hajó elektromos rendszere két hálózatra van felosztva, fontosság szerint. A hajó mind a két villanyszerelője jelenleg az elsődleges rendszeren dolgozik, és a kapitány téged kér, hogy segíts megjavítani a másodlagos rendszert. Az egyik villanyszerelő egy rövid pillantást vetett a problémára, és annyit mondott, hogy biztos benne, hogy csak egyetlen kábel ment tönkre; majd elviharzott a hajó generátora felé.  
A kapitány szabadkozik, hogy sajnos rendes ábrát nem talált a hálózatról, csak egy leltári nyilvántartást a kábelekről, ez a mellékelt `grid.txt`  
A hálózat kapcsolószekrényekből, és azokat összekötő kábelekből áll.  
  
## Input formátum:  
Az input file első sorában egyetlen szám szerepel: `N`, ennyi kábel van összesen.  
Ezek után `N` darab sor következik, amelyek mindegyike három számból áll, szóközzel elválasztva.  
`K`, `A`, `B`  
- `K` a kábel leltári száma,  
- `A` és `B` a kábel által összekötött kapcsolószekrények leltári száma.  
  
1. Hány darab kapcsolószekrény található a hálózatban?  
  
A kapcsolószekrények egy részétől csak egyetlen másik kapcsolószekrényhez visz közvetlen kábel. Ezek a hálózat végpontjai. Az utasok kabinjai mindig pontosan egy ilyen végponthoz kapcsolódnak, és a végpontok mindig legfeljebb egy kabinhoz tartoznak.  
  
2. Hány darab végpont található a hálózatban?  
  
A kapitány egy cédulát ad, rajta négy kapcsolószekrény leltári száma:  
`9526285, 1064470, 5702189, 4341735`  
  
Négy kabinból jelezték az utasok, hogy nincs áram. Elsőre feltételezzük, hogy csak ezek az érintett kabinok (vagyis a végponti kapcsolószekrények közül csak ezek nem kapnak áramot). A generátorhoz csatlakozó kapcsolószekrény száma: `1206792` (Ettől a kapcsolószekrénytől jön az áram.)  
  
3. Ezek alapján melyik kábel lehet a hibás?  
  
Szerencsére a leltárt nagyon részletesen vezetjük. - mondja a kapitány, és a mellette lévő monitorra bök - íme, ide került beépítésre az a kábel. Megkér egy matrózt, hogy nézze meg a kábelt, aki jelenti, hogy a kábelcsatorna végein
kormozódás látható: tényleg ez a hibás kábel.  
-Csak pár kábelünk van raktáron, azokból nem merek elvenni, az elsődleges hálózatunkon még mindig dolgoznak, szükségük lehet ezekre. De ha találnánk a hálózaton egy olyan kábelt, amit gond nélkül kiszedhetünk, akkor arra ki tudnánk cserélni a hibás kábelt.  
-Mit jelent az, hogy gond nélkül kiszedhetjük? - kérdezed - elég annyi, hogy mindenhova jusson áram továbbra is?  
-Szerintem annál tudunk jobbat: azt szeretném, hogy kábelek számát tekintve egyik szoba se kerüljön messzebb a generátortól. Tehát ha pl. egy szobától a legrövidebb út a generátorhoz 4 kábelen át vezetett, akkor az továbbra is 4 kábelen át vezessen (az nem gond, ha másik 4 kábelen át).  
A kapitány feltételeinek több kábel is megfelel.  
  
4. Melyik rendelkezik ezek közül a legkisebb leltáriszámmal?  
