# Szigetvilág  
  
Kapitány előtt az asztalon egy térkép fekszik (a mellékelt archipelago.txt fúé), amin annak a szigetvilágnak a térképe látható aminek délnyugati szélén jár jelenleg a hajó.  
A térkép cellákra van osztva, a cellákban lévő jelek:  
  
♦ ~ : tenger  
♦ 1 - 9 : szárazföld, tengerszint feletti átlagos magasság a cellán belül ( * 100 méter), felfelé kerekítve.  
  
Ezt a szigetvilágot az Ezer Sziget Tengerének hívják. - tűnődik a kapitány - Én sose számoltam meg hány van, de valahogy nem hinném, hogy olyan sok.  
1. Pontosan hány sziget van a térképen?  
  
-Melyik a legszebb sziget? - kérdezed.  
-Az attól függ - válaszol a kapitány -, hogy kit kérdezel. Mindenkinek más. Például ott van az Axióma kapitánya, aki csak azoknál a szigeteknél hajlandó kikötni, amiknek a magasság adait le lehet írni egy palindrom (balról jobbra és jobbról balra olvasva ugyanaz) számként. Szerinte csak azok a szép szigetek.  
  
~~~~~~~~~~~~~~~~~~~~~~~~~  
~11211~33431~13321~12345~  
~~~2~~~4~~~~~1~~~~~~~8~~~  
~~~3~~~532~~~11111~~~8~~~  
~~~1~~~4~~~~~~~~~1~~~9~~~  
~~~1~~~32223~12111~~~4~~~  
~~~~~~~~~~~~~~~~~~~~~~~~~  
  
A fent látható szigetek balról jobbra haladva:  
♦ Az elsőnél hajlandó az Axióma kapitánya kikötni, mert le lehet írni palindromként, például így: 112131211  
♦ A másodiknál sose kötne ki, mert nem lehet palindromként leírni  
♦ A harmadikat le lehet írni palindromként, például: 11213111111312111  
♦ A negyediket nem lehet leírni palindromként  
2. Hány olyan sziget van a szigetvilágban, ahol az Axióma kapitánya hajlandó kikötni?  
  
-Tudod mit szeretek még nagyon ebben a szigetvilágban? - folytatja a kapitány - Az itt élő népek mindig is békében éltek. A törzsek felosztották egymás között a szigeteket, úgy hogy egy törzshöz tartozó szigetek között ne kelljen túl sokat evezniük. Az antropológusok egymás között manhattan-törzseknek hívják őket, mert a távolság mérésre érthetetlen okokból Manhattan távolságot hasznátak.   
A szigetvilág felosztása a törzsek között a mi térképünket használva:  
♦ Minden sziget pontosan egy törzshöz tartozik.  
♦ Ha két sziget közötti legrövidebb vízi út csak élszomszédos négyzetre lépve legfeljebb 10 vizet tartalmazó négyzeten halad át, akkor ugyanahhoz törzshöz tartozik.  
♦ Fenti kettőből is következik: tartozhatnak egy törzshöz olyan szigetek, amik között több mint 10 vizen kéne áthaladni, ha közben vannak szigetek, amiken lehet pihenni.  
Példák:  
Az alábbi 2 sziget ugyanahhoz a törzshöz tartozik, mert a köztük lévő legrövidebb élszomszédos négyzetekre lépő út 8 hosszú. Az egyik lehetséges legrövidebb irt a két sziget között:  
  
~~~~~~~~~~~~~~  
~~1~~~~~~~~~~~  
~~2XXXX~~~~~~~  
~~~~~~XX~~~~~~  
~~~~~~~XX423~~  
~~~~~~~~~~~2~~  
  
Az alábbi térkép 2 törzs között lett volna felosztva. Így:  

![territoriumok_felosztasa_pelda](pelda.png)
  
3. Hány törzs között van felosztva a szigetvilág?  
