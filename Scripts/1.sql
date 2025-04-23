/*Este script genera la estructura de toda la base de datos.*/

-- Crear la tabla BinanceP2P si no existe
CREATE TABLE BinanceP2P (
  `OrderNumber` VARCHAR(50) NOT NULL,
  `OrderType` VARCHAR(50),
  `AssetType` VARCHAR(50),
  `FiatType` VARCHAR(50),
  `TotalPrice` DECIMAL(15,2),  -- Actualizado para permitir valores mayores
  `Price` DECIMAL(15,2),
  `Quantity` DECIMAL(15,2),
  `MakerFee` DECIMAL(15,2),  
  `Couterparty` VARCHAR(50),
  `Status` VARCHAR(50),
  `CreatedTime` DATETIME,
  PRIMARY KEY (`OrderNumber`)
) ENGINE=InnoDB;

ALTER TABLE BinanceP2P ADD INDEX idx_order_number (OrderNumber);
ALTER TABLE BinanceP2P ADD INDEX idx_created_time (CreatedTime);

CREATE TABLE BinanceSpotHistory (
`DateUtc` DATETIME,
`OrderNo` VARCHAR(50) NOT NULL,
`Pair`  VARCHAR(50),
`BaseAsset`  VARCHAR(50),
`QuoteAsset`  VARCHAR(50),
`Type`  VARCHAR(50),
`OrderPrice` DECIMAL(15,7),
`OrderAmount` DECIMAL(15,7),
`AvgTradingPrice` DECIMAL(15,7),
`Filled` DECIMAL(15,7),
`Total` DECIMAL(15,7),
`Status`  VARCHAR(50),
  PRIMARY KEY (`OrderNo`)
) ENGINE=InnoDB;


ALTER TABLE BinanceSpotHistory ADD INDEX idx_order_number (`OrderNo`);
ALTER TABLE BinanceSpotHistory ADD INDEX idx_created_time (`DateUtc`);



-- Crear la tabla ClienteExterno
CREATE TABLE ClienteExterno (
    Id INT AUTO_INCREMENT PRIMARY KEY, -- Clave primaria auto-incremental
    Nombre VARCHAR(255) NOT NULL,      -- Nombre del cliente
    Identificacion VARCHAR(255) UNIQUE -- Identificación única del cliente
);

-- Crear la tabla PagoExternoDetalle
CREATE TABLE PagoExternoDetalle (
    Id INT AUTO_INCREMENT PRIMARY KEY, -- Clave primaria auto-incremental
    Date DATE NOT NULL,                -- Fecha del detalle del pago
    Valor DECIMAL(18, 2) NOT NULL      -- Valor del detalle del pago
);

-- Crear la tabla PagoExterno
CREATE TABLE PagoExterno (
    Id INT AUTO_INCREMENT PRIMARY KEY,     -- Clave primaria auto-incremental
    Date DATE NOT NULL,                    -- Fecha del pago
    IdCliente INT NOT NULL,                -- Clave foránea a ClienteExterno
    USDT DECIMAL(18, 8) NOT NULL,          -- Monto en USDT
    Tasa DECIMAL(18, 8) NOT NULL,          -- Tasa de cambio
    TotalCop DECIMAL(18, 2) NOT NULL,      -- Total en COP
    FOREIGN KEY (IdCliente) REFERENCES ClienteExterno(Id) -- Definición de clave foránea
);

-- Crear la tabla PagoExternoDistribucion
CREATE TABLE PagoExternoDistribucion (
    ID INT AUTO_INCREMENT PRIMARY KEY,         -- Clave primaria auto-incremental
    IdPagoExternoDetalle INT NOT NULL,         -- Clave foránea a PagoExternoDetalle
    IdPagoExterno INT NOT NULL,                -- Clave foránea a PagoExterno
    Valor DECIMAL(18, 2) NOT NULL,             -- Valor distribuido
    FOREIGN KEY (IdPagoExternoDetalle) REFERENCES PagoExternoDetalle(Id), -- Definición de clave foránea
    FOREIGN KEY (IdPagoExterno) REFERENCES PagoExterno(Id)             -- Definición de clave foránea
);

-- Opcional: Puedes añadir índices para mejorar el rendimiento en las claves foráneas
CREATE INDEX idx_PagoExterno_IdCliente ON PagoExterno(IdCliente);
CREATE INDEX idx_PagoExternoDistribucion_IdPagoExternoDetalle ON PagoExternoDistribucion(IdPagoExternoDetalle);
CREATE INDEX idx_PagoExternoDistribucion_IdPagoExterno ON PagoExternoDistribucion(IdPagoExterno);