CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Alliances` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AllianceId` bigint NOT NULL,
    `CreatorCorporationId` bigint NOT NULL,
    `CreatorId` bigint NOT NULL,
    `DateFounded` datetime(6) NOT NULL,
    `ExecutorCorporationId` bigint NULL,
    `FactionId` bigint NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Ticker` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Alliances` PRIMARY KEY (`Id`)
);

CREATE TABLE `Corporations` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CorporationId` bigint NOT NULL,
    `AllianceId` bigint NULL,
    `CeoId` bigint NOT NULL,
    `CreatorId` bigint NOT NULL,
    `DateFounded` datetime(6) NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `FactionId` bigint NULL,
    `HomeStationId` bigint NULL,
    `MemberCount` bigint NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Shares` bigint NULL,
    `TaxRate` double NOT NULL,
    `Ticker` longtext CHARACTER SET utf8mb4 NULL,
    `Url` longtext CHARACTER SET utf8mb4 NULL,
    `WarEligible` bit NULL,
    CONSTRAINT `PK_Corporations` PRIMARY KEY (`Id`)
);

CREATE TABLE `Position` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `X` float NOT NULL,
    `Y` float NOT NULL,
    `Z` float NOT NULL,
    CONSTRAINT `PK_Position` PRIMARY KEY (`Id`)
);

CREATE TABLE `Trackers` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `TrackerId` bigint NOT NULL,
    `IsAlliance` bit NOT NULL,
    CONSTRAINT `PK_Trackers` PRIMARY KEY (`Id`)
);

CREATE TABLE `Zkb` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `LocationId` bigint NOT NULL,
    `Hash` longtext CHARACTER SET utf8mb4 NULL,
    `FittedValue` double NOT NULL,
    `TotalValue` double NOT NULL,
    `Points` int NOT NULL,
    `NPC` bit NOT NULL,
    `Solo` bit NOT NULL,
    `Awox` bit NOT NULL,
    `Esi` longtext CHARACTER SET utf8mb4 NULL,
    `Url` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Zkb` PRIMARY KEY (`Id`)
);

CREATE TABLE `Victim` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CharacterId` bigint NOT NULL,
    `AllianceId` bigint NOT NULL,
    `CorporationId` bigint NOT NULL,
    `ShipTypeId` bigint NOT NULL,
    `DamageTaken` bigint NOT NULL,
    `PositionId` bigint NULL,
    CONSTRAINT `PK_Victim` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Victim_Position_PositionId` FOREIGN KEY (`PositionId`) REFERENCES `Position` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Item` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Flag` int NOT NULL,
    `ItemTypeId` int NOT NULL,
    `QuantityDropped` bigint NULL,
    `QuantityDestroyed` bigint NULL,
    `Singleton` int NOT NULL,
    `VictimId` bigint NULL,
    CONSTRAINT `PK_Item` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Item_Victim_VictimId` FOREIGN KEY (`VictimId`) REFERENCES `Victim` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Killmails` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `KillmailId` bigint NOT NULL,
    `KillmailTime` datetime(6) NOT NULL,
    `SolarSystemId` bigint NOT NULL,
    `VictimId` bigint NULL,
    `ZkbId` bigint NULL,
    CONSTRAINT `PK_Killmails` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Killmails_Victim_VictimId` FOREIGN KEY (`VictimId`) REFERENCES `Victim` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Killmails_Zkb_ZkbId` FOREIGN KEY (`ZkbId`) REFERENCES `Zkb` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Attacker` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CharacterId` bigint NOT NULL,
    `AllianceId` bigint NOT NULL,
    `CorporationId` bigint NOT NULL,
    `ShipTypeId` bigint NOT NULL,
    `DamageDone` bigint NOT NULL,
    `FactionId` bigint NOT NULL,
    `FinalBlow` bit NOT NULL,
    `SecurityStatus` float NOT NULL,
    `WeaponTypeID` bigint NOT NULL,
    `KillmailId` bigint NULL,
    CONSTRAINT `PK_Attacker` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Attacker_Killmails_KillmailId` FOREIGN KEY (`KillmailId`) REFERENCES `Killmails` (`Id`) ON DELETE RESTRICT
);

INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (1, 0, 98614694);
INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (2, 1, 99007237);
INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (3, 1, 99003144);
INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (4, 1, 99009583);
INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (5, 1, 99006113);
INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (6, 1, 99006319);
INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (7, 1, 99007192);
INSERT INTO `Trackers` (`Id`, `IsAlliance`, `TrackerId`)
VALUES (8, 1, 99006117);

CREATE INDEX `IX_Attacker_KillmailId` ON `Attacker` (`KillmailId`);

CREATE INDEX `IX_Item_VictimId` ON `Item` (`VictimId`);

CREATE INDEX `IX_Killmails_VictimId` ON `Killmails` (`VictimId`);

CREATE INDEX `IX_Killmails_ZkbId` ON `Killmails` (`ZkbId`);

CREATE INDEX `IX_Victim_PositionId` ON `Victim` (`PositionId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200107210717_InitialCreate', '3.1.0');

