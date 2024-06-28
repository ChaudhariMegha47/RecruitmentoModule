-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: megha1
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `DepartmentId` int NOT NULL AUTO_INCREMENT,
  `DepName` varchar(45) NOT NULL,
  `IsDelete` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`DepartmentId`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'ce',1),(3,'Admin',1),(5,'HR',1),(6,'ity',1),(7,'electical',1),(8,'admin',1),(9,'admin',1),(10,'It',1),(11,'iut',1),(12,'it',1),(13,'it',1),(14,'ce',1),(15,'ce',1),(16,'ec',1),(17,'ce',0),(18,'admin',1),(19,'ec',0),(20,'electrical',0),(21,'ec',0),(22,'ee',1),(23,'ee',1),(24,'it',0),(25,'iot',1),(26,'ai',1),(27,'megha',1),(28,'hr',1),(29,'fghjkkl',1),(30,'finance',1),(31,'Mechanical',1);
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `EmployeeId` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Age` int NOT NULL,
  `Gender` varchar(45) NOT NULL,
  `DepId` int NOT NULL,
  `IsActive` tinyint NOT NULL DEFAULT '1',
  `IsDelete` tinyint NOT NULL DEFAULT '0',
  `Image_Path` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`EmployeeId`),
  KEY `Depid_idx` (`DepId`),
  CONSTRAINT `Depid` FOREIGN KEY (`DepId`) REFERENCES `department` (`DepartmentId`)
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (84,'f','f',21,'Male',1,0,1,''),(86,'esdgfesd','esft',34,'male',6,0,1,''),(87,'gfg','fgfg',1,'Female',1,0,1,'/EmployeeImages/33af75ef-854a-4c2b-b0ee-016c946585df.jpg'),(88,'fcvfd','fdgvfdgv',10,'Male',3,0,1,'/EmployeeImages/52cb31ae-e4d9-4e3c-9f0e-7c2d3aafd876.jpg'),(89,'gfbhgfh','fgbt',10,'Other',1,0,1,'/EmployeeImages/cd523d75-87b2-452d-890e-2a0acdf200e9.jpg'),(90,'fgbvdfbvd','ty5yy',45,'Male',3,0,1,'/EmployeeImages/d73eff65-3f12-4f7f-9f0c-6b7bfaa22ca6.jpg'),(91,'megha','fcgvfd',12000,'Female',3,0,1,'/EmployeeImages/6fb57764-4d28-4478-83bf-cda8959be497.jpg'),(92,'thyty','yht',15,'Female',8,0,1,'/EmployeeImages/96ba3bc3-4dc6-46c5-8015-fbae048217fd.jpg'),(93,'cxvxd','cv x',16,'Female',6,0,1,'/EmployeeImages/55278836-dcb6-41f3-b3ca-ef785795e36a.jpg'),(94,'cvfbfc','cfbgvfc',45,'dxfg',6,0,1,''),(95,'xcvx','cvfc',67,'hg',7,0,1,''),(96,'fvg','fgfv',25,'gvhbgc',6,0,1,''),(97,'megha','cvgfd',17,'Female',17,0,1,'/EmployeeImages/8d9caf7e-c118-46ab-90d9-062af3bb00a5.jpg'),(98,'megha','df',56,'fgh',7,0,1,''),(99,'jahanvi','rtg',56,'gft',6,0,1,''),(100,'megha','gfd',21,'Female',17,0,1,'/EmployeeImages/285a6fb4-9107-41bf-b307-5684de263135.jpg'),(101,'megha','gfd',21,'Female',20,0,1,'/EmployeeImages/ff73e252-14cf-4298-985e-68746fad081c.jpg'),(102,'megha','df',56,'Female',17,0,1,'/EmployeeImages/8503533d-9507-4bd5-aed1-e14c181db028.jpg'),(103,'megha','df',56,'Female',20,0,1,'/EmployeeImages/c10d52ba-16d4-422a-907d-7f945542c017.jpg'),(104,'megha','df',56,'Female',17,0,1,'/EmployeeImages/947028b9-fc18-4fd7-bb5c-08aecb2e12f6.jpg'),(105,'megha','gfd',21,'Male',20,0,1,'/EmployeeImages/c51eeceb-ad3a-40be-a8fd-617bfc69a9bc.jpg'),(106,'hy6u7','ty5yy',18,'Female',17,0,1,'/EmployeeImages/a36cad3b-a562-4f49-9efd-d986cf784ed6.jpg'),(107,'megha','ty5yy',17,'Female',19,0,1,'/EmployeeImages/ae5eaf25-0f3a-42cd-ae09-d6f57705b15f.jpg'),(108,'megha','greg5',18,'Female',20,0,1,'/EmployeeImages/932cfd20-fbc1-45eb-aba8-c1e2b54abb53.jpg'),(109,'hy6u7','h6yty',19,'Female',19,0,1,'/EmployeeImages/8b65b102-935d-4a03-8797-22044a719472.jpg'),(110,'hy6y','u65u6u',26,'Male',21,0,1,'/EmployeeImages/7da9a25c-a6de-4c3f-a403-c3ef67fb895b.jpg'),(111,'megha','u65u6u',16,'Male',19,0,1,'/EmployeeImages/616985e9-6dfd-4366-a5e0-668a71696de8.jpg'),(112,'megha','chaudhari',28,'Female',17,0,1,'/EmployeeImages/7708f0c4-ed10-4284-ae44-a0a3a3492221.jpg'),(113,'jahanvi','modi',20,'Female',24,0,1,'/EmployeeImages/152f693f-d909-41de-8775-7e8f5fba9cf4.jpg'),(114,'megha','chaudhari',28,'Female',21,1,0,'/EmployeeImages/08b9599d-c50a-444d-9f78-d54fd2b50b57.jpg'),(115,'abcd','efgh',20,'Male',17,1,0,'/EmployeeImages/41ab2723-69a2-44bb-8acc-3bac2c6d6b3a.jpg');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'megha1'
--

--
-- Dumping routines for database 'megha1'
--
/*!50003 DROP PROCEDURE IF EXISTS `GetDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDepartment`()
BEGIN
	Select * From department Where IsDelete=0 ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetEmpById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEmpById`()
BEGIN
	Select * From employee Where IsActive=1 and IsDelete=0 ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateDepartment`(
    IN DepId INT,
    IN DepName VARCHAR(50)
)
BEGIN
    -- Check if department exists
    IF EXISTS (SELECT 1 FROM department WHERE DepartmentId = DepId) THEN
        -- Update department
        UPDATE department
        SET DepName = DepName
        WHERE DepartmentId = DepId;
        SELECT DepId AS recid;
    ELSE
        -- Insert new department
        set DepId=last_insert_id();
        INSERT INTO department (DepName)
        VALUES (DepName);
		select DepId as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateEmployee`(
    IN EmpId INT,
    IN FirstName VARCHAR(50),
    IN LastName VARCHAR(50),
    IN DepId INT,
    IN Age VARCHAR(50),
    IN Gender VARCHAR(20),
    IN IsActive TINYINT,
    IN Image_Path VARCHAR(255)
)
BEGIN
    -- Check if the employee exists
    IF EXISTS (SELECT 1 FROM employee WHERE EmployeeId = EmpId) THEN
        -- Update the existing employee
        UPDATE employee
        SET FirstName = FirstName,
            LastName = LastName,
			DepId = DepId, 
            Age = Age,
            Gender = Gender,
            IsActive = IsActive,
            Image_Path = Image_Path
        WHERE EmployeeId = EmpId;
        select EmpId as recid;
    ELSE
    	set EmpId=last_insert_id();
        INSERT INTO employee ( FirstName, LastName, DepId, Age, Gender, IsActive,Image_Path)
        VALUES (FirstName, LastName,DepId, Age, Gender, IsActive,Image_Path);
		select EmpId as recid;
    END IF;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_GetAllDepartmentList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_GetAllDepartmentList`()
BEGIN
    Select * From department where IsDelete<>1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `PROC_GetAllEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `PROC_GetAllEmployee`()
BEGIN
	Select emp.*,dept.DepName From employee emp inner join department dept on emp.Depid = dept.DepartmentId where emp.IsDelete<>1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveDepartment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveDepartment`(IN DepId INT)
BEGIN
	 update department set  IsDelete=1  where DepartmentId=DepId ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveEmployee`(IN EmpId INT)
BEGIN
   update employee set IsActive=0, IsDelete=1  where EmployeeId=EmpId ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-28 15:26:15
