/* Script en el que vamos a inicializar datos en la base de datos*/

-- Insertar el primer cliente con identificación única
INSERT INTO ClienteExterno (Nombre, Identificacion)
VALUES ('Jhon S R', NULL); -- Reemplaza 'ABC123XYZ' con una identificación única real si es necesario

-- Insertar el segundo cliente con identificación NULL
INSERT INTO ClienteExterno (Nombre, Identificacion)
VALUES ('GGCryptos', NULL);

-- Insertar el tercer cliente con identificación NULL
INSERT INTO ClienteExterno (Nombre, Identificacion)
VALUES ('Jesús Leon', NULL);

-- Opcional: Seleccionar todos los clientes para verificar la inserción
-- SELECT * FROM ClienteExterno;
