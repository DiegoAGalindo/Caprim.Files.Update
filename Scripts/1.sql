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

/*
-- Insertar datos de ejemplo en la tabla BinanceP2P
INSERT INTO BinanceP2P 
(OrderNumber, OrderType, AssetType, FiatType, TotalPrice, Price, Quantity, MakerFee, Couterparty, Status, CreatedTime)
VALUES
('P2P123456789', 'Buy', 'USDT', 'COP', 1000000.00, 4000.00, 250.00, 2.50, 'trader1', 'Completed', '2024-01-15 10:30:00'),
('P2P123456790', 'Sell', 'BTC', 'COP', 2000000.00, 4100.00, 0.05, 3.00, 'trader2', 'Completed', '2024-01-15 11:45:00'),
('P2P123456791', 'Buy', 'ETH', 'COP', 1500000.00, 4050.00, 0.37, 2.75, 'trader3', 'Completed', '2024-01-15 13:20:00'),
('P2P123456792', 'Sell', 'USDT', 'COP', 800000.00, 3980.00, 201.00, 2.00, 'trader4', 'Completed', '2024-01-15 14:15:00'),
('P2P123456793', 'Buy', 'BTC', 'COP', 2500000.00, 4150.00, 0.06, 3.50, 'trader5', 'Completed', '2024-01-15 15:30:00'),
('P2P123456794', 'Sell', 'ETH', 'COP', 1200000.00, 4020.00, 0.30, 2.25, 'trader6', 'Completed', '2024-01-15 16:45:00'),
('P2P123456795', 'Buy', 'USDT', 'COP', 950000.00, 3990.00, 238.00, 2.15, 'trader7', 'Completed', '2024-01-15 17:20:00'),
('P2P123456796', 'Sell', 'BTC', 'COP', 1800000.00, 4080.00, 0.044, 2.80, 'trader8', 'Completed', '2024-01-15 18:10:00'),
('P2P123456797', 'Buy', 'ETH', 'COP', 1600000.00, 4060.00, 0.39, 2.60, 'trader9', 'Completed', '2024-01-15 19:25:00'),
('P2P123456798', 'Sell', 'USDT', 'COP', 1100000.00, 4010.00, 274.00, 2.30, 'trader10', 'Completed', '2024-01-15 20:00:00');
*?