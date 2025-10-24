#!/usr/bin/env bash

# Ez a shell script lefuttatja az init vagy a seed könyvtárakban lévő sql parancs fájlokat, ha vannak.
# Mindig #!/usr/bin/env bash -sel kell kezdeni, mert megmondja hogy ezt a fájlt a bin/bash-ből kell futtatni. Azzal, hogy az environment környezetből olvassuk ki a bash helyét, biztosan (platform függetklenül) mindig a jó heélyen fogja keresni.

set -euo pipefail                               # -e : Ha talál hibát, akkor álljon le.
                                                # -u : A nem definiált változót is tekintse hibának és álljon le.
                                                # -o : A pipefail pipeban bármely hibát fogjon meg és álljon le.

echo ">> Waiting a moment just in case..."
sleep 1                                         # Várjon egy kicsit, hogy a hálózat és az sql biztosan készen álljon.

                                                # Időnként átteszik az SQL kommandot másik könyvtárba. Ezért az SQL kommand útvonalát meg kell keresni.
SQLCMD_BIN=""                                   # ebben lesz.
for c in \                                      # c változó szépen sorban felveszi a  felsorolt értékeket.
    "/opt/mssql-tools18/bin/sqlcmd" \
    "/opt/mssql-tools/bin/sqlcmd" \
    "sqlcmd"
do                                              # ciklus mag kezdete
    if command -v "$c" >/dev/null 2>&1; then    # -v "$c" : c változóban megadott parancs elérhető-e
                                                # >/dev/null : std out kimeneti szöveg lenyelése
                                                # 2>&1 : standard error átirányítása a std out-ra, vagyis azt is kikukázza
        SQLCMD_BIN="$(command -v "$c")"         # Ha nyerünk, akkor eltároljuk parancsal együtt az SQL parancs helyét.
        break
    elif [ -x "$c"]; then                       # -x "$c" : Azt is le kell ellenőrizni, hogy ha a pathbanban nem jól szerepel, de mégis végrehajtható-e.
        SQLCMD_BIN="$c"                         # Ha így nyerünk, akkor eltároljuk csak magát az SQL parancs helyét.
        break
    fi                                          # end if
done                                            # end do

if [ -z "${SQLCMD_BIN}"]; then                  # -z : Ha nem találta meg, akkor üres maradt a sztring.
    echo "ERROR: sqlcmd not found please check its path"
    exit 127
fi

echo ">> Using sqlcmd at: ${SQLCMD_BIN}"        # Kiírja, hol találta meg.

shopt -s nullglob                               # Ha a megadott listában csak a *.sql lesz, akkor empty legyen a lista
files=(/seed/*.sql)                             # A seed könyvtárban levő féjlok nevét vegye fel a files nevű listába.

if [ ${#files[@]} -gt 0]; then                  # ha files array elemszáma #files[@] nagyobb mint
    echo ">> Found ${#files[@]} SQL files. Running seed..."
    for f in "${files[@]}"; do
        echo ">> Running $f"                    # f sorban felveszi a list értékeit
        "${SQLCMD_BIN}" -C -S mssql -U sa -P "${SA_PASSWORD}" -i "$f"                  # mssql hoston csinálja
                                                # -C : A szerver kezeli a tanusítványt
                                                # -S : host elérése (Itt a konténerben futo mssql-t kell megadni.)
                                                # -U : felhasználó név (super admin user)
                                                # -P : jelszó
                                                # -i : A futtani kívánt sql parancs file.
    done                                        # ciklus mag vége
    echo ">> Seed completed"
else
    echo ">> No seed files found in /seed"      # Ha nem volt egyetlen .sql fájl sem a seed, vagy init mappában.
fi
