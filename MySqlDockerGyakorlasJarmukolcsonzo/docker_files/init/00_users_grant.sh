#!/bin/bash
set -euo pipefail

# --- Beállítások / fallback-ek ---
# Alap DB név: MYSQL_ADD_DB (compose), ha nincs, akkor MYSQL_DATABASE
DEFAULT_DB="${MYSQL_ADD_DB:-${MYSQL_DATABASE:-}}"

# DB lista: ha MYSQL_DATABASES nincs megadva, akkor csak a DEFAULT_DB
if [ -n "${MYSQL_DATABASES:-}" ]; then
  DB_LIST="${MYSQL_DATABASES}"
else
  if [ -z "${DEFAULT_DB}" ]; then
    echo "ENV ERROR: neither MYSQL_DATABASES nor (MYSQL_ADD_DB / MYSQL_DATABASE) is set" >&2
    exit 1
  fi
  DB_LIST="${DEFAULT_DB}"
fi

# --- Várakozás, amíg a szerver ténylegesen elérhető ---
# 1) várunk a socketre (gyorsabb, mint a TCP)
for i in {1..60}; do
  [ -S /var/run/mysqld/mysqld.sock ] && break
  sleep 1
done

# 2) pingeljük a szervert a socketen
until mysqladmin --protocol=socket --socket=/var/run/mysqld/mysqld.sock \
  -uroot -p"${MYSQL_ROOT_PASSWORD}" ping --silent; do
  sleep 1
done

# --- Felhasználó létrehozása (ha nincs), majd DB-k létrehozása és jogok ---
# Karakterkészlet és kolláció MySQL 8.4-hez
CHARSET="utf8mb4"
COLLATE="utf8mb4_0900_ai_ci"

# User létrehozása (ha már létezik, nem hiba)
mysql --protocol=socket --socket=/var/run/mysqld/mysqld.sock \
  -uroot -p"${MYSQL_ROOT_PASSWORD}" <<EOSQL
CREATE USER IF NOT EXISTS '${MYSQL_USER}'@'%' IDENTIFIED BY '${MYSQL_PASSWORD}';
EOSQL

# Minden DB-t létrehozunk és jogot adunk rá
for db in ${DB_LIST}; do
  mysql --protocol=socket --socket=/var/run/mysqld/mysqld.sock \
    -uroot -p"${MYSQL_ROOT_PASSWORD}" <<EOSQL
CREATE DATABASE IF NOT EXISTS \`${db}\`
  CHARACTER SET ${CHARSET} COLLATE ${COLLATE};
GRANT ALL PRIVILEGES ON \`${db}\`.* TO '${MYSQL_USER}'@'%';
EOSQL
done

# Végül biztos, ami biztos
mysql --protocol=socket --socket=/var/run/mysqld/mysqld.sock \
  -uroot -p"${MYSQL_ROOT_PASSWORD}" -e "FLUSH PRIVILEGES;"

echo ">> Created/ensured databases: ${DB_LIST}"
echo ">> Granted ALL on each to user '${MYSQL_USER}'@'%'"
