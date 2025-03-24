-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.7.13-log


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema test_db
--

CREATE DATABASE IF NOT EXISTS test_db;
USE test_db;

--
-- Definition of table `testtable1`
--

DROP TABLE IF EXISTS `testtable1`;
CREATE TABLE `testtable1` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `middle_name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idx` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `testtable1`
--

/*!40000 ALTER TABLE `testtable1` DISABLE KEYS */;
/*!40000 ALTER TABLE `testtable1` ENABLE KEYS */;


--
-- Definition of table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Gender` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idIndex` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id`,`FirstName`,`LastName`,`Email`,`Gender`) VALUES 
 (1,'Jeff','Dapar','jeffreydapar@gmail.com','Male'),
 (2,'Jeff','Draw','jeffreydapar@gmail.com','Male'),
 (3,'Jeff','Daw','jeffreydapar@gmail.com','Male'),
 (4,'Jeff','Drew','jeffreydapar@gmail.com','Male'),
 (5,'Jeff','Cortel','jeffreydapar@email.com','Male'),
 (6,'Jeff','Aquino','jeffreycortel@gmail.com','Male'),
 (7,'Jeff','Doria','jeffDoria@gmail.com	','Female'),
 (8,'Jeff','Vasquez','jeffreyVasquez@gmail.com','Male'),
 (9,'josh','daw','daw@gmail.com','Male'),
 (11,'Jeff','Austria','Austria@gmail.com','Male');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;


--
-- Definition of procedure `user`
--

DROP PROCEDURE IF EXISTS `user`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `user`(_lastName varchar(55))
BEGIN
	SELECT * FROM users;
END $$

DELIMITER ;



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
