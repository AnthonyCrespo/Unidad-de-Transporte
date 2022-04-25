create schema inspeccion_ambulancia;
create table inspeccion_ambulancia.datos_generales(
    no_reporte integer NOT NULL,
    coordinacion_zonal integer not null,
    conductor_entrega varchar not null,
    conductor_recibe varchar not null,
    provincia varchar not null,
    unidad_operativa varchar not null,
    ambulancia varchar not null,
    base_operativa varchar,
    hora time not null,
    fecha date not null
);

create table inspeccion_ambulancia.preguntas (
    no_reporte integer not null,
    no_pregunta integer not null,
    estado boolean NOT NULL,
    observacion varchar
);

create table inspeccion_ambulancia.limpieza() inherits(inspeccion_ambulancia.preguntas);
create table inspeccion_ambulancia.cabina_interior() inherits(inspeccion_ambulancia.preguntas);
create table inspeccion_ambulancia.documentos() inherits(inspeccion_ambulancia.preguntas);
create table inspeccion_ambulancia.cabina_exterior() inherits(inspeccion_ambulancia.preguntas);


create table inspeccion_ambulancia.danos(
    no_reporte integer not null,
    id_descripcion int not null,
    descripcion varchar
);


create table inspeccion_ambulancia.otros_datos(
    no_reporte integer not null,
    combustible int not null,
    temperatura varchar not null,
    kilometraje int not null,
    observaciones_generales varchar
);



-------------------------------------------------------------
---------------- Constraints -------------------------------
------------------------------------------------------------

-- Primary key
alter table inspeccion_ambulancia.datos_generales add constraint pkey_no_reporte primary key (no_reporte); 


-- Foreign Key
alter table inspeccion_ambulancia.preguntas add constraint fkey_no_reporte foreign key(no_reporte) references  inspeccion_ambulancia.datos_generales(no_reporte);
alter table inspeccion_ambulancia.limpieza add constraint fkey_no_reporte foreign key(no_reporte) references  inspeccion_ambulancia.datos_generales(no_reporte);
alter table inspeccion_ambulancia.cabina_interior add constraint fkey_no_reporte foreign key(no_reporte) references  inspeccion_ambulancia.datos_generales(no_reporte);
alter table inspeccion_ambulancia.documentos add constraint fkey_no_reporte foreign key(no_reporte) references  inspeccion_ambulancia.datos_generales(no_reporte);
alter table inspeccion_ambulancia.cabina_exterior add constraint fkey_no_reporte foreign key(no_reporte) references  inspeccion_ambulancia.datos_generales(no_reporte);
alter table inspeccion_ambulancia.danos add constraint fkey_no_reporte foreign key(no_reporte) references  inspeccion_ambulancia.datos_generales(no_reporte);
alter table inspeccion_ambulancia.otros_datos add constraint fkey_no_reporte foreign key(no_reporte) references  inspeccion_ambulancia.datos_generales(no_reporte);


create table inspeccion_ambulancia.provincias (
nombre varchar);

insert into inspeccion_ambulancia.provincias values
('Azuay'),
('Bolivar'),
('Cañar'),
('Carchi'),
('Chimborazo'),
('Cotopaxi'),
('El Oro'),
('Esmeraldas'),
('Galápagos'),
('Guayas'),
('Imbabura'),
('Loja'),
('Los Ríos'),
('Manabí'),
('Morona Santiago'),
('Napo'),
('Sucumbíos'),
('Pastaza'),
('Pinchincha'),
('Santa Elena'),
('Santo Domingo'),
('Francisco De Orellana'),
('Tungurahua'),
('Zamora Chinchipe');