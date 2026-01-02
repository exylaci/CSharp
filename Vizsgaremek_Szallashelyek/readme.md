# Vizsgaremek – Szálláshelyek  
*László EXNER – 2026*  

A **`vizsgaremek kiírás.pdf`** dokumentumban megadott szálláshely-adatokat kiegészítettem a szálláshely **nevével** is.

---

## Rendezési elv indoklása  
  
A kiírás **8. feladatában** szereplő  
> "azonosító és fajta szerint (a kettő együtt érvényesüljön) rendezés",

az **egyedi azonosító** miatt már önmagában is **egyértelmű sorrendet** eredményez.  
Ezért a **másodlagos, fajta szerinti rendezés** ebben a formában már **nem tud érvényesülni**.

Fordított sorrend esetén:
1. először **fajta szerint**
2. majd **név szerint**

a rendezés valóban láthatóvá válik.

Ennek megfelelően a szálláshelyeket:
- **először a fajtájuk**
- **majd a nevük**

szerint jelenítem meg, 
a **7. pontban megadott szűrési lehetőségek figyelembevételével**.

---

## Docker és adatbázis  
  
A program által használt **MySQL adatbázist** tartalmazó Docker-fájlokat az alábbi könyvtárban helyeztem el:

- **Éles környezet:**
  - `Vizsgaremek_Szallashelyek/docker_files`

- **Tesztkörnyezet:**
  - `Vizsgaremek_Szallashelyek.Test/docker_files`

---

## Futtatáshoz szükséges DLL-ek  
  
Az elkészült **EXE fájl mellé telepíteni kell** a:

- `Vizsgaremek_Szallashelyek.AccommodationProfileDLL.dll`
- `Vizsgaremek_Szallashelyek.ConditionsDLL.dll`

fájlokat is.

---

## Szűrési feltételek bővítése  
  
Más szűrési feltételeket a `Vizsgaremek_Szallashelyek.ConditionsDLL.dll` módosításával lehet beállítani.

Ehhez a szálláshely fajtákat tartalmazó `AccommodationProfile` enum, valamint a szálláshely **attribútumai** a
`Vizsgaremek_Szallashelyek.AccommodationProfileDLL.dll` DLL-ben található **interfészen keresztül** érhetők el.

---

