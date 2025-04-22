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