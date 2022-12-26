DROP DATABASE IF EXISTS Dnsk;
CREATE DATABASE Dnsk
CHARACTER SET = 'utf8mb4'
COLLATE = 'utf8mb4_general_ci';
USE Dnsk;

DROP TABLE IF EXISTS Auths;
CREATE TABLE Auths (
    Id CHAR(22) NOT NULL,
    Email VARCHAR(250) NOT NULL,
    LastAuthedOn DATETIME(3) NOT NULL,
    ActivatedOn DATETIME(3) NOT NULL,
    ActivateCode VARCHAR(250) NULL,
    NewEmail VARCHAR(250) NULL,
    NewEmailCode VARCHAR(250) NULL,
    LoginCodeCreatedOn DATETIME(3) NULL,
    LoginCode VARCHAR(250) NULL,
    Use2FA       BOOLEAN NOT NULL,
    ScryptSalt   VARBINARY(256) NULL,
    ScryptPwd    VARBINARY(256) NULL,
    ScryptN      MEDIUMINT UNSIGNED NULL,
    ScryptR      MEDIUMINT UNSIGNED NULL,
    ScryptP      MEDIUMINT UNSIGNED NULL,
    PRIMARY KEY Id (Id),
    UNIQUE INDEX Email (Email),
    INDEX(ActivatedOn, LastAuthedOn)
);

# cleanup old registrations that have not been activated in a week
SET GLOBAL event_scheduler=ON;
DROP EVENT IF EXISTS authRegistrationCleanup;
DROP EVENT IF EXISTS AuthRegistrationCleanup;
CREATE EVENT AuthRegistrationCleanup
ON SCHEDULE EVERY 24 HOUR
STARTS CURRENT_TIMESTAMP + INTERVAL 1 HOUR
DO DELETE FROM Auths WHERE ActivatedOn=CAST('0001-01-01 00:00:00.000' AS DATETIME(3)) AND LastAuthedOn < DATE_SUB(NOW(), INTERVAL 7 DAY);

DROP USER IF EXISTS 'Dnsk'@'%';
CREATE USER 'Dnsk'@'%' IDENTIFIED BY 'C0-Mm-0n-Dnsk';
GRANT SELECT ON Dnsk.* TO 'Dnsk'@'%';
GRANT INSERT ON Dnsk.* TO 'Dnsk'@'%';
GRANT UPDATE ON Dnsk.* TO 'Dnsk'@'%';
GRANT DELETE ON Dnsk.* TO 'Dnsk'@'%';
GRANT EXECUTE ON Dnsk.* TO 'Dnsk'@'%';