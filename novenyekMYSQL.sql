SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `novenyekproba` DEFAULT CHARACTER SET utf8mb4 ;
USE `novenyekproba` ;

-- -----------------------------------------------------
-- Table `novenyekproba`.`__efmigrationshistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `novenyekproba`.`__efmigrationshistory` (
  `MigrationId` VARCHAR(95) NOT NULL,
  `ProductVersion` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`MigrationId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `novenyekproba`.`betegseg`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `novenyekproba`.`betegseg` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Tipus` LONGTEXT NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `novenyekproba`.`elofordulas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `novenyekproba`.`elofordulas` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Honap` LONGTEXT NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `novenyekproba`.`gyujtott`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `novenyekproba`.`gyujtott` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Resz` LONGTEXT NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `novenyekproba`.`felhasznalas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `novenyekproba`.`felhasznalas` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Gyujtott_id` INT(11) NOT NULL,
  `Betegseg_ID` INT(11) NOT NULL,
  `Elo_Id` INT(11) NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `IX_Felhasznalas_Betegseg_ID` (`Betegseg_ID` ASC),
  INDEX `IX_Felhasznalas_Elo_Id` (`Elo_Id` ASC),
  INDEX `IX_Felhasznalas_Gyujtott_id` (`Gyujtott_id` ASC),
  CONSTRAINT `FK_Felhasznalas_Betegseg_Betegseg_ID`
    FOREIGN KEY (`Betegseg_ID`)
    REFERENCES `novenyekproba`.`betegseg` (`ID`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_Felhasznalas_Elofordulas_Elo_Id`
    FOREIGN KEY (`Elo_Id`)
    REFERENCES `novenyekproba`.`elofordulas` (`ID`)
    ON DELETE CASCADE,
  CONSTRAINT `FK_Felhasznalas_Gyujtott_Gyujtott_id`
    FOREIGN KEY (`Gyujtott_id`)
    REFERENCES `novenyekproba`.`gyujtott` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `novenyekproba`.`novenyek`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `novenyekproba`.`novenyek` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Latin` LONGTEXT NULL DEFAULT NULL,
  `Magyar` LONGTEXT NULL DEFAULT NULL,
  `Kep` LONGTEXT NULL DEFAULT NULL,
  `Informacio` LONGTEXT NULL DEFAULT NULL,
  `Felh_Id` INT(11) NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `IX_Novenyek_Felh_Id` (`Felh_Id` ASC),
  CONSTRAINT `FK_Novenyek_Felhasznalas_Felh_Id`
    FOREIGN KEY (`Felh_Id`)
    REFERENCES `novenyekproba`.`felhasznalas` (`ID`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8mb4;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
