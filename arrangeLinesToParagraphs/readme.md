# Sorok újratördelése bekezdésekbe  

Ez a program újra bekezdésekbe rendez olyan pure text fájlt, ahol minden sor végén `CR` `LF` van. (Ilyen például egy `*.pdf` fájlból kimásolt szöveg is.)  
Előbb az OCR során vétett hibákat próbálja meg megtalálni és magától javítani,  
Majd a gyanús pontokon végigvezeti a felhasználót, akinek lehetősége van kézzel javítani, tovább/visszalépni a következő/előző gyanús helyre a `PgDown` és a `PgUp` gombokkal, illetve az `Esc` megnyomásával abbahagyni a kézi ellenőrzést.  
A legvégén pedig az eredeti fájllal azonos könyvtárban, az eredeti fájl nevéhez hozzáfűzött 2-sel `*2.txt` egy új fájlba elmenti az eredményt.  
A feldolgozni kívánt fájl nevét paraméterként kell megadni. Pl:  
`prompt > arrangeLinesToParagraphs.exe "átalakítandó fájl neve.txt"`◄┘
