CREATE TABLE BinanceSpotHistory (
`Date(UTC)` DATETIME,
`Order_No` VARCHAR(50) NOT NULL,
`Pair`  VARCHAR(50),
`Base_Asset`  VARCHAR(50),
`Quote_Asset`  VARCHAR(50),
`Type`  VARCHAR(50),
`Order_Price` DECIMAL(15,7),
`Order_Amount` DECIMAL(15,7),
`AvgTrading_Price` DECIMAL(15,7),
`Filled` DECIMAL(15,7),
`Total` DECIMAL(15,7),
`Status`  VARCHAR(50),
  PRIMARY KEY (`Order_No`)
) ENGINE=InnoDB;


ALTER TABLE BinanceSpotHistory ADD INDEX idx_order_number (`Order_No`);
ALTER TABLE BinanceSpotHistory ADD INDEX idx_created_time (`Date(UTC)`);