USE `training`;
CREATE TABLE IF NOT EXISTS students(
    id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(200) NOT NULL,
    email VARCHAR(200) NOT NULL UNIQUE,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

INSERT INTO students (full_name, email)
VALUES  ('Teszt Elek', 'teszt@elek.hu'),
        ('Gipsz Jakab', 'gipsz@jakab.hu');