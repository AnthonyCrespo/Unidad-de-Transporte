create schema entrada_salida;

CREATE TYPE clas_vehi AS
ENUM('Ambulancia', 'Camioneta');
CREATE TYPE estad_vehi AS
ENUM ('B','R','M');
create table entrada_salida.vehiculo (
	cod_inst int primary key,
	clase clas_vehi not null,
	num serial not null,
	color varchar not null,
	marca varchar not null,
	placa varchar(8) unique not null,
	tipo varchar not null,
	modelo varchar not null,
	chasis varchar unique not null,
	motor varchar unique not null,
	year smallint not null,
	estado estad_vehi not null,
	kilom int
);
alter table entrada_salida.vehiculo add constraint chk_placa check (placa similar to '[A-Z]{3}[-][0-9]{4}');

insert into entrada_salida.vehiculo values 
(6542196, 'Ambulancia', default, 'BLANCO',      'FORD 350', 'IEI-1216',       'II 4X4', 'FORD E 350 SUPERDUTY CARGO VAN ',  '1FDSS3E15CDA23791', '1FDSS3E15CDA23791', 2012, 'B'),
(6542197, 'Ambulancia', default, 'BLANCO', 'MERCEDES BENZ', 'IEA-1325',   'AMBULANCIA',   '315CDI AC2.1 5P 4X2 TM DIESEL',  'WDB906633DS761517',    '65195531459653', 2013, 'B'),
(6542198, 'Ambulancia', default, 'BLANCO', 'MERCEDES BENZ', 'IEA-1324',   'AMBULANCIA',   '315CDI AC2.1 5P 4X2 TM DIESEL',  'WDB906633DS762654',    '65195531472488', 2013, 'B'),
(6542195,  'Camioneta', default,   'ROJO',     'CHEVROLET', 'IEA-0231', 'DOBLE CABINA',             'LUV C/D 4X2 T/m iny',  '8LBTFR30H20115213',     'C22NE25063097', 2002, 'B'),
(6542193, 'Ambulancia', default, 'BLANCO',           'KIA', 'IEA-0320',   'AMBULANCIA',                          'PREGIO', '8LTOTS73229E002172',          'JT576818', 2008, 'B'),
(6542192,  'Camioneta', default, 'BLANCO',     'CHEVROLET', 'IEA-0391', 'DOBLE CABINA',           'LUV D-MAX C/D 4X2 T/M',  '8LBETF3DX90000552',     'C24SE31028824', 2009, 'B'),
(6542194, 'Ambulancia', default, 'BLANCO',         'MAZDA', 'IEA-1326',   'AMBULANCIA',       'BT-50 CS 4X2 STD TD 2,5FL',  'MM7UNY0W490829846',        'WLTA145654', 2009, 'B');

/* create table entrada_salida.cie10(
	code varchar primary key,
	code_0 varchar,
	code_1 varchar,
	code_2 varchar,
	code_3 varchar,
	code_4 varchar,
	description varchar,
	level int,
	source varchar
); */


CREATE TYPE tip_licen AS
ENUM ('A', 'A1', 'B', 'C', 'C1', 'D', 'D1', 'E', 'E1', 'F', 'G');
create table entrada_salida.conductor(
	cedula varchar(10) primary key,
	nombre varchar not null,
	celular varchar(10) unique not null,
	licencia tip_licen[] not null,
	fech_cad_lic date[] not null,
	puntos_lic NUMERIC(3, 1) not null
);
alter table entrada_salida.conductor add constraint chk_cedula check (cedula similar to '[[0-9]{10}');
alter table entrada_salida.conductor add constraint chk_celular check (celular similar to '[[0-9]{10}');
alter table entrada_salida.conductor add constraint chk_punt check (puntos_lic between 0.0 and 30.0);

insert into entrada_salida.conductor values  
('1001479995',       'RENE ALBUJA', '0986445770',     '{E}',             '{2023-04-03}', 23.5),
('1003023429',         'LUIS MORA', '0997012590',     '{E}',             '{2024-09-09}', 25.5),
('1002642013', 'CHRISTIAN HIDALGO', '0991952600',     '{E}',             '{2022-09-17}', 28.0),
('1002170809',   'ABDON CERVANTES', '0998535837',     '{E}',             '{2026-01-10}', 24.0),
('0401333562',     'MANUEL CADENA', '0998998396', '{E, C1}', '{2022-11-13, 2026-01-28}', 30.0),
('1714312426',   'PATRICIO GAIBOR', '0994538927',    '{C1}',             '{2025-01-21}', 26.0),
('1002567103', 'FRANCISCO VASQUEZ', '0997267097', '{E, C1}', '{2020-11-09, 2024-03-13}', 30.0),
('1002168191',     'PEDRO MORALES', '0967279876', '{E, C1}', '{2023-07-16, 2025-01-21}', 30.0),
('1002365185',        'HUGO ORTIZ', '0986134726',     '{E}',             '{2021-11-29}', 30.0),
('1002038733',     'JUAN PALACIOS', '0959165526', '{E, C1}', '{2024-10-16, 2025-01-21}', 18.0),
('1002533055',      'PABLO RIVERA', '0939997261',     '{E}',             '{2021-06-07}', 28.0),
('1002270187',  'MARCELO VIZCAINO', '0992144632',     '{E}',             '{2022-03-23}', 22.0);

CREATE TYPE tip_sistem AS
ENUM ('MSP', 'RPIS', 'RPC');
create table entrada_salida.destino(
	cod_des serial primary key,
	nombre varchar not null,
	sistema tip_sistem not null,
	ciudad varchar,
	distancia smallint	
);

insert into entrada_salida.destino values
(default,      'HOSPITAL EUGENIO ESPEJO',  'MSP',     'QUITO', 240),
(default,      'MATERNIDAD ISIDRO AYORA',  'MSP',     'QUITO', 270),
(default,          'HOSPITAL BACA ORTIZ',  'MSP',     'QUITO', 241),
(default,         'HOSPITAL DE CALDERON',  'MSP',     'QUITO', 210),
(default,      'HOSPITAL ENRIQUE GARCES',  'MSP',     'QUITO', 270),
(default,                         'HCAM', 'RPIS',     'QUITO', 243),
(default,                         'IESS', 'RPIS',    'IBARRA',   2),
(default,              'CLINICA HARVARD',  'RPC',     'QUITO', 240),
(default,                   'MEDIRECREO',  'RPC',     'QUITO', 257),
(default,              'HOSPITAL INGLES',  'RPC',     'QUITO', 245),
(default,         'RADIOLOGOS ASOCIADOS',  'RPC',     'QUITO', 240),
(default,             'CLINICA COLONIAL',  'RPC',     'QUITO', 247),
(default,                    'INCORAZON',  'RPC',     'QUITO', 247),
(default,        'CLINICA METROPOLITANA',  'RPC',    'IBARRA',   2),
(default,               'CLINICA IBARRA',  'RPC',    'IBARRA',   2),
(default,              'CLINICA MODERNA',  'RPC',    'IBARRA',   2),
(default,    'HOSPITAL BASICO ATUNTAQUI',  'MSP', 'ATUNTAQUI',  26),
(default,           'CLINICA COTOCOLLAO',  'RPC',     'QUITO', 227),
(default, 'HOSPITAL SAN LUIS DE OTAVALO',  'MSP',   'OTAVALO',  51),
(default,     'CENTRO DE SALUD CARANQUI',  'MSP',    'IBARRA',  10);









--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------

-------- TABLA CON DESTINO QUE NO ESTA EN LA BD----
create table entrada_salida.destino_no_bd(
	num_sol int primary key,
	nombre_solicitante varchar not null,
	unidad_m varchar not null,
	ciudad varchar not null
);
------- TABLA DEL SOLICITANTE Y SU CARGO--------
create table entrada_salida.solicitante_cargo(
	num_solicitud int primary key,
	nombre_solicitante varchar not null,
	cargo_solicitante varchar not null
);
-- TABLA CUANDO NO HAY UN DESTINO-----
create table entrada_salida.solicitante_sin_destino(
	numero int primary key,
	solicitante varchar not null,
	destino varchar not null
);

--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------


create table entrada_salida.nacionalidad(
	PAIS_NAC varchar, 
	GENTILICIO_NAC varchar, 
	ISO_NAC varchar(3) primary key
);
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Afganistán','AFGANA','AFG');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Albania','ALBANESA','ALB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Alemania','ALEMANA','DEU');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Andorra','ANDORRANA','AND');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Angola','ANGOLEÑA','AGO');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('AntiguayBarbuda','ANTIGUANA','ATG');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('ArabiaSaudita','SAUDÍ','SAU');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Argelia','ARGELINA','DZA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Argentina','ARGENTINA','ARG');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Armenia','ARMENIA','ARM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Aruba','ARUBEÑA','ABW');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Australia','AUSTRALIANA','AUS');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Austria','AUSTRIACA','AUT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Azerbaiyán','AZERBAIYANA','AZE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Bahamas','BAHAMEÑA','BHS');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Bangladés','BANGLADESÍ','BGD');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Barbados','BARBADENSE','BRB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Baréin','BAREINÍ','BHR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Bélgica','BELGA','BEL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Belice','BELICEÑA','BLZ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Benín','BENINESA','BEN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Bielorrusia','BIELORRUSA','BLR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Birmania','BIRMANA','MMR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Bolivia','BOLIVIANA','BOL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('BosniayHerzegovina','BOSNIA','BIH');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Botsuana','BOTSUANA','BWA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Brasil','BRASILEÑA','BRA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Brunéi','BRUNEANA','BRN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Bulgaria','BÚLGARA','BGR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('BurkinaFaso','BURKINESA','BFA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Burundi','BURUNDESA','BDI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Bután','BUTANESA','BTN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('CaboVerde','CABOVERDIANA','CPV');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Camboya','CAMBOYANA','KHM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Camerún','CAMERUNESA','CMR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Canadá','CANADIENSE','CAN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Catar','CATARÍ','QAT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Chad','CHADIANA','TCD');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Chile','CHILENA','CHL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('China','CHINA','CHN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Chipre','CHIPRIOTA','CYP');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('CiudaddelVaticano','VATICANA','VAT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Colombia','COLOMBIANA','COL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Comoras','COMORENSE','COM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('CoreadelNorte','NORCOREANA','PRK');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('CoreadelSur','SURCOREANA','KOR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('CostadeMarfil','MARFILEÑA','CIV');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('CostaRica','COSTARRICENSE','CRI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Croacia','CROATA','HRV');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Cuba','CUBANA','CUB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Dinamarca','DANESA','DNK');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Dominica','DOMINIQUESA','DMA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Ecuador','ECUATORIANA','ECU');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Egipto','EGIPCIA','EGY');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('ElSalvador','SALVADOREÑA','SLV');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('EmiratosÁrabesUnidos','EMIRATÍ','ARE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Eritrea','ERITREA','ERI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Eslovaquia','ESLOVACA','SVK');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Eslovenia','ESLOVENA','SVN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('España','ESPAÑOLA','ESP');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('EstadosUnidos','ESTADOUNIDENSE','USA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Estonia','ESTONIA','EST');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Etiopía','ETÍOPE','ETH');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Filipinas','FILIPINA','PHL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Finlandia','FINLANDESA','FIN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Fiyi','FIYIANA','FJI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Francia','FRANCESA','FRA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Gabón','GABONESA','GAB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Gambia','GAMBIANA','GMB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Georgia','GEORGIANA','GEO');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Gibraltar','GIBRALTAREÑA','GIB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Ghana','GHANESA','GHA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Granada','GRANADINA','GRD');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Grecia','GRIEGA','GRC');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Groenlandia','GROENLANDESA','GRL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Guatemala','GUATEMALTECA','GTM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Guineaecuatorial','ECUATOGUINEANA','GNQ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Guinea','GUINEANA','GIN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Guinea-Bisáu','GUINEANA','GNB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Guyana','GUYANESA','GUY');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Haití','HAITIANA','HTI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Honduras','HONDUREÑA','HND');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Hungría','HÚNGARA','HUN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('India','HINDÚ','IND');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Indonesia','INDONESIA','IDN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Irak','IRAQUÍ','IRQ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Irán','IRANÍ','IRN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Irlanda','IRLANDESA','IRL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Islandia','ISLANDESA','ISL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('IslasCook','COOKIANA','COK');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('IslasMarshall','MARSHALESA','MHL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('IslasSalomón','SALOMONENSE','SLB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Israel','ISRAELÍ','ISR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Italia','ITALIANA','ITA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Jamaica','JAMAIQUINA','JAM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Japón','JAPONESA','JPN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Jordania','JORDANA','JOR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Kazajistán','KAZAJA','KAZ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Kenia','KENIATA','KEN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Kirguistán','KIRGUISA','KGZ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Kiribati','KIRIBATIANA','KIR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Kuwait','KUWAITÍ','KWT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Laos','LAOSIANA','LAO');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Lesoto','LESOTENSE','LSO');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Letonia','LETÓNA','LVA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Líbano','LIBANESA','LBN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Liberia','LIBERIANA','LBR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Libia','LIBIA','LBY');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Liechtenstein','LIECHTENSTEINIANA','LIE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Lituania','LITUANA','LTU');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Luxemburgo','LUXEMBURGUESA','LUX');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Madagascar','MALGACHE','MDG');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Malasia','MALASIA','MYS');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Malaui','MALAUÍ','MWI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Maldivas','MALDIVA','MDV');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Malí','MALIENSE','MLI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Malta','MALTESA','MLT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Marruecos','MARROQUÍ','MAR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Martinica','MARTINIQUESA','MTQ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Mauricio','MAURICIANA','MUS');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Mauritania','MAURITANA','MRT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('México','MEXICANA','MEX');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Micronesia','MICRONESIA','FSM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Moldavia','MOLDAVA','MDA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Mónaco','MONEGASCA','MCO');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Mongolia','MONGOLA','MNG');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Montenegro','MONTENEGRINA','MNE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Mozambique','MOZAMBIQUEÑA','MOZ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Namibia','NAMIBIA','NAM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Nauru','NAURUANA','NRU');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Nepal','NEPALÍ','NPL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Nicaragua','NICARAGÜENSE','NIC');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Níger','NIGERINA','NER');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Nigeria','NIGERIANA','NGA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Noruega','NORUEGA','NOR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('NuevaZelanda','NEOZELANDESA','NZL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Omán','OMANÍ','OMN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('PaísesBajos','NEERLANDESA','NLD');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Pakistán','PAKISTANÍ','PAK');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Palaos','PALAUANA','PLW');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Palestina','PALESTINA','PSE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Panamá','PANAMEÑA','PAN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('PapúaNuevaGuinea','PAPÚ','PNG');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Paraguay','PARAGUAYA','PRY');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Perú','PERUANA','PER');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Polonia','POLACA','POL');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Portugal','PORTUGUESA','PRT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('PuertoRico','PUERTORRIQUEÑA','PRI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('ReinoUnido','BRITÁNICA','GBR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('RepúblicaCentroafricana','CENTROAFRICANA','CAF');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('RepúblicaCheca','CHECA','CZE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('RepúblicadeMacedonia','MACEDONIA','MKD');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('RepúblicadelCongo','CONGOLEÑA','COG');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('RepúblicaDemocráticadelCongo','CONGOLEÑA','COD');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('RepúblicaDominicana','DOMINICANA','DOM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('RepúblicaSudafricana','SUDAFRICANA','ZAF');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Ruanda','RUANDESA','RWA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Rumanía','RUMANA','ROU');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Rusia','RUSA','RUS');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Samoa','SAMOANA','WSM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SanCristóbalyNieves','CRISTOBALEÑA','KNA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SanMarino','SANMARINENSE','SMR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SanVicenteylasGranadinas','SANVICENTINA','VCT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SantaLucía','SANTALUCENSE','LCA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SantoToméyPríncipe','SANTOTOMENSE','STP');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Senegal','SENEGALESA','SEN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Serbia','SERBIA','SRB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Seychelles','SEYCHELLENSE','SYC');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SierraLeona','SIERRALEONESA','SLE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Singapur','SINGAPURENSE','SGP');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Siria','SIRIA','SYR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Somalia','SOMALÍ','SOM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SriLanka','CEILANESA','LKA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Suazilandia','SUAZI','SWZ');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('SudándelSur','SURSUDANESA','SSD');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Sudán','SUDANESA','SDN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Suecia','SUECA','SWE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Suiza','SUIZA','CHE');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Surinam','SURINAMESA','SUR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Tailandia','TAILANDESA','THA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Tanzania','TANZANA','TZA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Tayikistán','TAYIKA','TJK');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('TimorOriental','TIMORENSE','TLS');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Togo','TOGOLESA','TGO');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Tonga','TONGANA','TON');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('TrinidadyTobago','TRINITENSE','TTO');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Túnez','TUNECINA','TUN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Turkmenistán','TURCOMANA','TKM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Turquía','TURCA','TUR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Tuvalu','TUVALUANA','TUV');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Ucrania','UCRANIANA','UKR');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Uganda','UGANDESA','UGA');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Uruguay','URUGUAYA','URY');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Uzbekistán','UZBEKA','UZB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Vanuatu','VANUATUENSE','VUT');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Venezuela','VENEZOLANA','VEN');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Vietnam','VIETNAMITA','VNM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Yemen','YEMENÍ','YEM');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Yibuti','YIBUTIANA','DJI');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Zambia','ZAMBIANA','ZMB');
INSERT INTO entrada_salida.nacionalidad(PAIS_NAC, GENTILICIO_NAC, ISO_NAC ) VALUES('Zimbabue','ZIMBABUENSE','ZWE');

--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------


create table entrada_salida.orden_mov(
	num int primary key,
	fecha date not null,
	solicitante varchar not null,
	unidad varchar not null,
	motivo varchar not null,

	paciente varchar,
	edad smallint,
	nacionalidad varchar, --fk
	cedula varchar(10),
	cie10 varchar, --fk
	servicio varchar,
	destino integer, --fk

	hora_salida_base time,
	hora_salida_destino time,
	fecha_salida date,
	hora_llegada_destino time,
	hora_llegada_base time,
	fecha_entrada date
);
alter table entrada_salida.orden_mov add constraint fk_nacion  FOREIGN KEY (nacionalidad)  REFERENCES entrada_salida.nacionalidad (ISO_NAC);
--alter table entrada_salida.orden_mov add constraint fk_cie10   FOREIGN KEY (cie10)         REFERENCES entrada_salida.cie10 (code);
alter table entrada_salida.orden_mov add constraint fk_destino FOREIGN KEY (destino)       REFERENCES entrada_salida.destino (cod_des);

CREATE TYPE est_sol AS
ENUM ('APROBADA', 'NEGADA');
create table entrada_salida.info_solicitud (
	num int primary key, --fk
	estado est_sol,
	vehiculo int, --fk
	conductor varchar, --fk
	paramed varchar,
	observ varchar,
	fecha date not null
);
alter table entrada_salida.info_solicitud add constraint fk_vehi_inf FOREIGN KEY (vehiculo)  REFERENCES entrada_salida.vehiculo (cod_inst);
alter table entrada_salida.info_solicitud add constraint fk_cond_inf FOREIGN KEY (conductor) REFERENCES entrada_salida.conductor (cedula);
alter table entrada_salida.info_solicitud add constraint fk_num_inf FOREIGN KEY(num) REFERENCES entrada_salida.orden_mov(num);


CREATE TYPE motivo_salida AS
ENUM ('INSTITUC', 'MECANIC');
create table entrada_salida.autorizacion (
	num int primary key, --fk
	fecha date not null,
	hora_salida time not null,
	hora_entrada time not null,
	km_salida int not null,
	km_entrada int not null,
	vehiculo int not null, --fk
	conductor varchar not null, --fk
	motivo motivo_salida not null,
	solicitante varchar not null,
	asunto varchar
);
alter table entrada_salida.autorizacion add constraint fk_vehi_aut  FOREIGN KEY (vehiculo)  REFERENCES entrada_salida.vehiculo (cod_inst);
alter table entrada_salida.autorizacion add constraint fk_cond_aut  FOREIGN KEY (conductor) REFERENCES entrada_salida.conductor (cedula);
alter table entrada_salida.autorizacion add constraint fk_num_aut   FOREIGN KEY (num)       REFERENCES entrada_salida.orden_mov (num);

