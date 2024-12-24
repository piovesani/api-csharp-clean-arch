-- Inserir registros na tabela Users
INSERT INTO Users (Name, Email, Gender, RG, CPF, MotherName, RegistrationStatus, RegistrationDate) VALUES
('Goku Son', 'goku.ficticio@dbz.com', 'M', '000.000.000', '000.000.000-00', 'Gine Son', 'A', '2021-01-01 00:00:00'),
('Vegeta Saiyan', 'vegeta.ficticio@dbz.com', 'M', '111.111.111', '111.111.111-11', 'Queen Saiyan', 'A', '2021-01-01 00:00:00'),
('Bulma Briefs', 'bulma.ficticio@capsulecorp.com', 'F', '222.222.222', '222.222.222-22', 'Panchy Briefs', 'A', '2021-01-01 00:00:00'),
('Krillin Monk', 'krillin.ficticio@dbz.com', 'M', '333.333.333', '333.333.333-33', 'Unknown', 'A', '2021-01-01 00:00:00'),
('Chi-Chi Son', 'chichi.ficticio@dbz.com', 'F', '444.444.444', '444.444.444-44', 'Ox-King', 'A', '2021-01-01 00:00:00'),
('Piccolo Namek', 'piccolo.ficticio@dbz.com', 'M', '555.555.555', '555.555.555-55', 'Kami Namek', 'A', '2021-01-01 00:00:00'),
('Trunks Briefs', 'trunks.ficticio@dbz.com', 'M', '666.666.666', '666.666.666-66', 'Bulma Briefs', 'A', '2021-01-01 00:00:00'),
('Android 18', 'android18.ficticio@dbz.com', 'F', '777.777.777', '777.777.777-77', 'Dr. Gero', 'A', '2021-01-01 00:00:00'),
('Gohan Son', 'gohan.ficticio@dbz.com', 'M', '888.888.888', '888.888.888-88', 'Chi-Chi Son', 'A', '2021-01-01 00:00:00'),
('Videl Satan', 'videl.ficticio@dbz.com', 'F', '999.999.999', '999.999.999-99', 'Mr. Satan', 'A', '2021-01-01 00:00:00');

-- Inserir registros na tabela Contacts
INSERT INTO Contacts (UserId, Phone, Mobile) VALUES
(1, '(11) 00000-0000', '(11) 00000-0000'),
(2, '(12) 11111-1111', '(12) 11111-1111'),
(3, '(13) 22222-2222', '(13) 22222-2222'),
(4, '(14) 33333-3333', '(14) 33333-3333'),
(5, '(15) 44444-4444', '(15) 44444-4444'),
(6, '(16) 55555-5555', '(16) 55555-5555'),
(7, '(17) 66666-6666', '(17) 66666-6666'),
(8, '(18) 77777-7777', '(18) 77777-7777'),
(9, '(19) 88888-8888', '(19) 88888-8888'),
(10, '(20) 99999-9999', '(20) 99999-9999');

-- Inserir registros na tabela DeliveryAddresses
INSERT INTO DeliveryAddresses (UserId, AddressName, ZIPCode, State, City, District, Address, Number, Complement) VALUES
(1, 'Home', '00000-000', 'SP', 'São Paulo', 'Kame House', 'Rua Nimbus', '1', 'Casa 1'),
(2, 'Home', '11111-111', 'RJ', 'Rio de Janeiro', 'Galaxia Saiyan', 'Rua Vegeta', '2', 'Casa 2'),
(3, 'Work', '22222-222', 'MG', 'Belo Horizonte', 'Corporação Cápsula', 'Rua Bulma', '3', 'Sala 3'),
(4, 'Home', '33333-333', 'BA', 'Salvador', 'Ilha de Roshi', 'Rua Krillin', '4', 'Casa 4'),
(5, 'Home', '44444-444', 'RS', 'Porto Alegre', 'Montanha Paozu', 'Rua Chi-Chi', '5', 'Casa 5'),
(6, 'Work', '55555-555', 'SP', 'Campinas', 'Namekusei', 'Rua Piccolo', '6', 'Casa 6'),
(7, 'Home', '66666-666', 'SC', 'Florianópolis', 'Capsula do Tempo', 'Rua Trunks', '7', 'Sala 7'),
(8, 'Home', '77777-777', 'PE', 'Recife', 'Laboratório Android', 'Rua 18', '8', 'Casa 8'),
(9, 'Home', '88888-888', 'PR', 'Curitiba', 'Monte Paozu', 'Rua Gohan', '9', 'Casa 9'),
(10, 'Home', '99999-999', 'DF', 'Brasília', 'Mansão Satan', 'Rua Videl', '10', 'Apartamento 10');
