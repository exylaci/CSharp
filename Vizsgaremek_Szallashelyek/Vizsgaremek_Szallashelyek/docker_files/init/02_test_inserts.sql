USE `Szallashelyek`;

INSERT INTO Address (ZipCode, City, Street, Housenumber) VALUES
(1051, 'Budapest', 'Fő utca', '1'),
(1052, 'Budapest', 'Kossuth tér', '2/B'),
(2000, 'Szentendre', 'Duna korzó', '3'),
(8600, 'Siófok', 'Petőfi sétány', '10'),
(8600, 'Siófok', 'Aranypart', '15'),
(3300, 'Eger', 'Széchenyi utca', '8'),
(3300, 'Eger', 'Dobó tér', '5'),
(8200, 'Veszprém', 'Vár utca', '4'),
(8200, 'Veszprém', 'Óváros tér', '7'),
(9021, 'Győr', 'Baross utca', '12'),
(9022, 'Győr', 'Király utca', '9'),
(9400, 'Sopron', 'Fő tér', '6'),
(9400, 'Sopron', 'Deák tér', '11'),
(8230, 'Balatonfüred', 'Tagore sétány', '20'),
(8230, 'Balatonfüred', 'Kisfaludy utca', '18'),
(5600, 'Békéscsaba', 'Andrássy út', '14'),
(5600, 'Békéscsaba', 'Jókai utca', '9'),
(7621, 'Pécs', 'Király utca', '3'),
(7622, 'Pécs', 'Széchenyi tér', '1'),
(9700, 'Szombathely', 'Fő tér', '2');

INSERT INTO Accommodation (Id, Name, Profile, AddressId) VALUES
('C0000001', 'Duna Camping', 'Sport', 3),
('C0000002', 'Balaton Camping', 'Sport', 4),
('C0000003', 'Aranypart Camping', 'Sport', 5),
('C0000004', 'Egeri Camping', 'Other', 6),
('C0000005', 'Füredi Camping', 'Sport', 17),
('C0000006', 'Sopron Camping', 'Other', 12),
('C0000007', 'Győri Camping', 'Sport', 10),
('C0000008', 'Pécsi Camping', 'Other', 18),

('H0000001', 'Hotel Panorama', 'Bussines', 1),
('H0000002', 'Hotel Wellness', 'Medical', 2),
('H0000003', 'Balaton Hotel', 'Bussines', 15),
('H0000004', 'Egri Hotel', 'Other', 7),
('H0000005', 'Sopron Hotel', 'Bussines', 13),
('H0000006', 'Győr Hotel', 'Bussines', 11),

('G0000001', 'Vár Vendégház', 'Other', 8),
('G0000002', 'Óváros Vendégház', 'Other', 9),
('G0000003', 'Belvárosi Vendégház', 'Bussines', 16),
('G0000004', 'Pécs Vendégház', 'Medical', 19),
('G0000005', 'Szombathely Vendégház', 'Other', 20),
('G0000006', 'Füred Vendégház', 'Sport', 14);

INSERT INTO Camping (CampingId, AtWaterfront) VALUES
('C0000001', TRUE),
('C0000002', TRUE),
('C0000003', TRUE),
('C0000004', FALSE),
('C0000005', TRUE),
('C0000006', FALSE),
('C0000007', FALSE),
('C0000008', FALSE);

INSERT INTO Building (BuildingId, BasePrice, Stars) VALUES
('H0000001', 35000, 4),
('H0000002', 42000, 5),
('H0000003', 38000, 4),
('H0000004', 30000, 3),
('H0000005', 36000, 4),
('H0000006', 34000, 3),

('G0000001', 18000, 3),
('G0000002', 16000, 2),
('G0000003', 17000, 3),
('G0000004', 15000, 2),
('G0000005', 15500, 2),
('G0000006', 16500, 3);

INSERT INTO Guesthouse (GuesthouseId, HasBreakfast) VALUES
('G0000001', TRUE),
('G0000002', FALSE),
('G0000003', TRUE),
('G0000004', TRUE),
('G0000005', FALSE),
('G0000006', TRUE);

INSERT INTO Hotel (HotelId, HasWellness) VALUES
('H0000001', TRUE),
('H0000002', TRUE),
('H0000003', TRUE),
('H0000004', FALSE),
('H0000005', TRUE),
('H0000006', FALSE);
