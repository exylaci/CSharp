# Fájlnevek ASCII karakteresre konvertálása

Egy egyszerű command line-os program, amivel a paraméterként megadott útvonal plusz fájl nevéből, vagy az alkönyvtárakban minden fájl és könyvtár bejegyzés nevéből  
  
## kiszedi:  
• a többlet szóközöket,  
• az EXTERNAL_ szöveget.  
## kicseréli:  
• az őŐ és űŰ betűket, ôÔ és ûÛ betűkre  
• az € karaktert, E betűre,  
• az → — " “ ” „ ' ‘ ’ ` * ? karaktereket, - karakterre,  
• a görög ΑΠ(Re) szöveget latin betűs Re szövegre,  
• minden más nem ASCII karaktert, _ jelre.  
  
Ha így azonossá válna két fájl neve, akkor az utóbbi fálj átnevezése előtt egy _ jel után növekvő sorszámot tesz a fájlnév végére, a kiterjesztés elé.  
  
## Használata egy könyvtár és alkönyvtárai minden bejegyzésére:  
• convert2ascii c:\temp\e-mailek  
• convert2ascii "c:\temp\inbox 2023"  
## Használata csak egyetlen fájl nevének módosítása esetén:  
• convert2ascii c:\temp\minta.msg  
• convert2ascii "c:\temp\minta levél.msg"  



