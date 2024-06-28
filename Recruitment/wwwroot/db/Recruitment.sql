-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: recruitment
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
-- Table structure for table `employeemaster`
--

DROP TABLE IF EXISTS `employeemaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employeemaster` (
  `emp_id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `lastname` varchar(45) NOT NULL,
  `Image_Path` varchar(255) DEFAULT NULL,
  `gender` varchar(45) NOT NULL,
  `dateofbirth` date NOT NULL,
  `email` varchar(45) NOT NULL,
  `contactno` varchar(15) NOT NULL,
  `designation` varchar(45) NOT NULL,
  `IsActive` tinyint NOT NULL DEFAULT '1',
  `IsDelete` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`emp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employeemaster`
--

LOCK TABLES `employeemaster` WRITE;
/*!40000 ALTER TABLE `employeemaster` DISABLE KEYS */;
INSERT INTO `employeemaster` VALUES (1,'mr.','gdfjghnu','grdju',NULL,'male','2024-05-20','abcd@gmail.com','8050480504','hr',1,1),(2,'miss','vbntf','cbdgr',NULL,'female','2003-02-12','abcd@gmail.com','8050480504','hr',1,1),(3,'miss','vcbdf','dxvfd',NULL,'Female','2024-07-06','efgh@gmail.com','8050480504','hr',1,1),(4,'mr','gngf','cbgffchb',NULL,'Male','2024-07-05','abcd@gmail.com','8050480504','hr',1,1),(5,'mrs','vbfdgv','dg',NULL,'Female','2024-07-05','abcd@gmail.com','1234567890','tyu',1,1),(6,'mr','black','panther','/EmployeeImages/374edf92-8a48-441b-b746-e6f35541191c.jpg','Male','2024-06-21','blackpanther@gmail.com','8050480504','Employee',1,1),(7,'miss','cptain','marvel','/EmployeeImages/9f293596-0258-47d8-91f1-119d6e5e028a.jpg','Female','2024-06-18','marvel@gmail.com','8050480504','HR',1,1),(8,'Mr','Rowan','Atkinson','/EmployeeImages/5b60fb5c-e48f-461d-a1dd-11e8cc0fbeb8.jpg','Male','1955-01-06','rowan@gmail.com','8050480504','CEO',1,1),(9,'Miss','Luna','Valeria','/EmployeeImages/663e4a8c-3e6b-4ef1-b4f1-a43a9f7146b4.jpg','Female','2024-06-20','luna@gmail.com','8050480504','Employee',1,1),(10,'Mr','Rowan','Atkinson','/EmployeeImages/9349311f-fdf5-4636-a20c-73170d602376.jpg','Male','2024-06-24','rowan@gmail.com','8050480504','CEO',1,1),(11,'Mr','abcd','abcd','/EmployeeImages/1da21397-cc2d-4577-9b86-98158fc8b05e.jpg','Male','2020-05-01','abcd@gmail.com','8050480504','hr',1,1),(12,'Mr','Kalix','Jace','/EmployeeImages/7f95ccce-28cb-4765-b049-695a1a58da72.jpg','Male','2024-06-14','kalix@gmail.com','8050480504','Lawyer',1,1),(13,'Miss','Luna','Valeria','/EmployeeImages/09993142-6596-49c5-8708-7062772490fd.jpg','Female','2004-07-15','luna@gmail.com','8050480504','Architect',1,0),(14,'Mr','Rowan','Atkinson','/EmployeeImages/69ef2f69-f733-485d-af5f-b024ecd9ee74.jpg','Male','1998-09-16','rowan@gmail.com','8050480504','CEO',1,0),(15,'Mr','Captain','America','/EmployeeImages/dd3676ae-418a-4867-af50-d639f9c56b9d.jpg','Male','2024-07-04','cap@gmail.com','7050102523','Avengers Leader',1,1),(16,'Mr','sandip','parmar','/EmployeeImages/b0ac453d-5b0d-43d6-b33b-a0ddd328920a.jpg','Male','1997-08-20','sandip66@gmail.com','8050480504','developer',1,1),(17,'Mr','sandip ','parmar','/EmployeeImages/96b2a4d0-f819-4d2b-a879-3a5d34485c2d.png','Male','1995-08-20','fsdf6@gmail.com','81400236565','fdsf',1,0),(18,'Mr','fgvfdgfg','vgfdgdg',NULL,'Female','2024-06-19','vgfd@gmail.com','8050480504','dfvdsgf',0,1),(19,'Mr','fcghd','gfdgdf',NULL,'Female','2024-06-28','fgdhdtfh@gmail.com','7050102523','bgfcgff',0,1),(20,'Miss','gbfcgh','fhbfghbf','/EmployeeImages/fd13e0f7-5cf8-4c1c-a085-d64aa8349fc1.jpg','Male','2024-06-27','fgbfd@gmail.com','8050480504','cfgb',0,1),(21,'Mr','fgdf','gd','/EmployeeImages/d7c21337-58e5-4be1-ad3b-f5da72cec28b.jpg','Male','2024-05-30','gdfg@gmail.com','58888788','fgsdgsd',0,0),(22,'Mr','megh','vfdvdb','/EmployeeImages/aef7c96f-79e9-437d-a6de-fc8efe1153db.jpg','Male','2024-06-21','megh@gmail.com','8050609050','gfhtth',0,0),(23,'Mr','gdfg','fxcgvfd','/EmployeeImages/8b603471-f459-41d9-8b75-146b4250dd83.jpeg','Male','2024-06-11','fvdxg@gmail.com','8050480504','fgdg',0,0),(24,'Mr','ghf','ghfh','/EmployeeImages/9a473173-e69c-4e39-b08f-22dc309c0af9.jpeg','Male','2024-06-13','fgd@gmail.com','7050102523','dsfvdsxf',0,0),(25,'Mr','gdfg','fgbvd','/EmployeeImages/552885e3-d3dd-4662-aabf-e85a7dd2e1e2.jpeg','Male','2024-06-14','fdgbd@gmail.com','8050480504','dfgg',0,0),(26,'Mr','fdgvfdh','fdgg','/EmployeeImages/24adae40-9563-450f-aac3-06fe78f910d2.jpeg','Male','2024-06-07','fdg@gmail.com','8050480504','dfdg',0,0),(27,'Mr','vbghf','ghf','/EmployeeImages/e82e2278-aa40-4f59-a249-8eae6821e100.jpeg','Male','2024-06-26','fgbnf@gmail.com','8050480504','vbhvgh',0,0),(28,'Mr','gvh','gvchbgf','/EmployeeImages/197a1ab7-1663-4fdb-a0a5-78dd3ab7b04a.jpg','Female','2024-06-26','fghfgh@gmail.com','8050480504','fcgc',0,0),(29,'Mr','cfgbf','fgdfdg','/EmployeeImages/0de6db4b-64e4-47b8-bc93-9fcdf03106f6.jpeg','Male','2024-06-13','fcgd@gmail.com','8050480504','hgfhjnh',0,0);
/*!40000 ALTER TABLE `employeemaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `experiencemaster`
--

DROP TABLE IF EXISTS `experiencemaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `experiencemaster` (
  `exp_id` int NOT NULL AUTO_INCREMENT,
  `experience` varchar(50) NOT NULL,
  `IsActive` tinyint NOT NULL DEFAULT '1',
  `IsDelete` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`exp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `experiencemaster`
--

LOCK TABLES `experiencemaster` WRITE;
/*!40000 ALTER TABLE `experiencemaster` DISABLE KEYS */;
INSERT INTO `experiencemaster` VALUES (1,'one year',1,1),(2,'one year',1,1),(3,'one year',1,1),(4,'one year',0,1),(5,'fresher',1,1),(6,'six month',1,1),(7,'one year',1,1),(8,'hgbuy',1,1),(9,'',1,1),(10,'',1,1),(11,'dxfvdsf',1,1),(12,'two year',1,1),(13,'5 Year',0,1),(14,'SIX MONTH',1,0),(15,'FRESHER',1,0),(16,'TWO YEAR',1,0),(17,'THREE YEAR',1,0),(18,'FOUR YEAR',1,0),(19,'seven year',1,1);
/*!40000 ALTER TABLE `experiencemaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `interviews`
--

DROP TABLE IF EXISTS `interviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `interviews` (
  `interview_Id` int NOT NULL,
  `candidateId` int DEFAULT NULL,
  `jobId` int DEFAULT NULL,
  `empId` int DEFAULT NULL,
  `interviewRound` varchar(45) DEFAULT NULL,
  `StartTime` varchar(45) DEFAULT NULL,
  `EndTime` varchar(45) DEFAULT NULL,
  `IsActive` tinyint DEFAULT NULL,
  `IsDelete` tinyint DEFAULT NULL,
  PRIMARY KEY (`interview_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `interviews`
--

LOCK TABLES `interviews` WRITE;
/*!40000 ALTER TABLE `interviews` DISABLE KEYS */;
/*!40000 ALTER TABLE `interviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobmaster`
--

DROP TABLE IF EXISTS `jobmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobmaster` (
  `job_id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `jobposition` varchar(45) DEFAULT NULL,
  `qualification` int NOT NULL,
  `jobtype` varchar(45) DEFAULT NULL,
  `jobdescription` text,
  `vacancies` int NOT NULL,
  `experience` int NOT NULL,
  `validupto` date NOT NULL,
  `createddate` datetime NOT NULL,
  `startsalary` int DEFAULT NULL,
  `endsalary` int DEFAULT NULL,
  `createdby` varchar(45) DEFAULT NULL,
  `IsActive` tinyint DEFAULT '1',
  `IsDelete` tinyint DEFAULT '0',
  PRIMARY KEY (`job_id`),
  KEY `qualificationname_idx` (`qualification`),
  KEY `experiencename_idx` (`experience`),
  CONSTRAINT `experiencename` FOREIGN KEY (`experience`) REFERENCES `experiencemaster` (`exp_id`),
  CONSTRAINT `qualificationname` FOREIGN KEY (`qualification`) REFERENCES `qualificationmaster` (`edu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobmaster`
--

LOCK TABLES `jobmaster` WRITE;
/*!40000 ALTER TABLE `jobmaster` DISABLE KEYS */;
INSERT INTO `jobmaster` VALUES (1,'developer',NULL,8,NULL,'.net',10,4,'2025-05-25','2024-05-18 13:35:51',NULL,NULL,'megha',1,1),(2,'sdgfsrd',NULL,52,NULL,'fesafe',10,8,'2024-10-08','2024-05-18 13:42:42',NULL,NULL,'fcesd',1,1),(3,'xfgvds',NULL,8,NULL,'cxvsd',10,4,'2024-12-05','2024-05-21 12:12:21',NULL,NULL,'bfch',1,1),(4,'tester',NULL,52,NULL,'tester',10,8,'2024-06-08','2024-05-23 15:43:45',NULL,NULL,'tester',1,1),(5,'ca',NULL,40,NULL,'ca',2,8,'2024-06-07','2024-05-23 16:10:50',NULL,NULL,'ca',1,1),(6,'test3',NULL,52,NULL,'test3',23,11,'2024-07-06','2024-05-27 15:14:34',NULL,NULL,NULL,1,1),(7,'test4',NULL,48,NULL,'qsswdccdd',12,11,'2024-07-06','2024-06-03 13:07:18',NULL,NULL,NULL,1,1),(8,'test3',NULL,52,NULL,'fsdfcdesf',12,11,'2024-07-06','2024-06-03 13:08:24',NULL,NULL,NULL,1,1),(9,'test1',NULL,52,NULL,'test1',12,11,'2024-07-05','2024-06-03 13:33:37',NULL,NULL,NULL,1,1),(10,'test',NULL,16,NULL,'test',12,16,'2024-07-04','2024-06-03 16:27:44',NULL,NULL,NULL,1,1),(11,'developer',NULL,48,NULL,'asp.net developer',12,18,'2024-06-13','2024-06-04 16:13:56',NULL,NULL,NULL,1,1),(12,'asp.net',NULL,44,NULL,'asp.net',10,16,'2024-07-02','2024-06-14 17:23:17',NULL,NULL,NULL,1,1),(13,'abcd',NULL,49,NULL,'abcd',12,16,'2024-06-19','2024-06-14 17:26:22',NULL,NULL,NULL,1,1),(14,'abcd',NULL,49,NULL,'abcd',12,17,'2024-06-27','2024-06-14 17:27:57',NULL,NULL,NULL,1,1),(15,'werty',NULL,57,NULL,'fdgvgd',45,15,'2024-07-04','2024-06-14 17:28:17',NULL,NULL,NULL,1,1),(16,'abcd',NULL,48,NULL,'abcdes',23,17,'2024-06-20','2024-06-15 13:04:38',NULL,NULL,NULL,1,1),(17,'cfvgfdg',NULL,44,NULL,'dsfcdsf',45,16,'2024-06-26','2024-06-15 13:04:54',NULL,NULL,NULL,1,1),(18,'fxdgg',NULL,44,NULL,'dfrres',56,16,'2024-07-02','2024-06-15 13:05:18',NULL,NULL,NULL,1,1),(19,'Designer',NULL,44,NULL,'UI / UX Designer',2,17,'2024-06-28','2024-06-20 17:49:25',NULL,NULL,NULL,1,1),(20,'Android Developer',NULL,62,NULL,'test',5,18,'2024-06-22','2024-06-21 16:07:03',NULL,NULL,NULL,1,1),(21,'fgvfcxgvf',NULL,61,NULL,'fgvfdfg',45,15,'2024-06-21','2024-06-25 13:45:28',NULL,NULL,NULL,1,1),(22,'fgbf',NULL,60,NULL,'ghghj',12,15,'2024-07-05','2024-06-25 13:45:50',NULL,NULL,NULL,1,1),(23,'CA',NULL,60,NULL,'CA',2,15,'2024-07-03','2024-06-25 14:46:23',NULL,NULL,NULL,1,1),(24,'xfgvfxg',NULL,62,NULL,'gfhtf',0,18,'2024-06-20','2024-06-26 17:59:00',NULL,NULL,NULL,1,1),(25,'try657y',NULL,60,NULL,'ygjhnyfj',68,18,'2024-07-05','2024-06-26 17:59:30',NULL,NULL,NULL,1,1),(26,'rgfg',NULL,60,NULL,'ftyhftyyh',768,15,'2024-06-29','2024-06-26 18:07:54',NULL,NULL,NULL,1,1),(27,'fgbvd',NULL,60,NULL,'fhtfht',67,18,'2024-06-14','2024-06-27 10:57:17',NULL,NULL,NULL,1,0),(28,'httfy',NULL,60,NULL,'gfhnft',676,16,'2024-06-11','2024-06-27 10:57:30',NULL,NULL,NULL,1,0),(29,'Accountant',NULL,60,NULL,'sadsad',45,15,'2024-07-06','2024-06-27 10:57:54',NULL,NULL,NULL,1,0);
/*!40000 ALTER TABLE `jobmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listofcandidate`
--

DROP TABLE IF EXISTS `listofcandidate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listofcandidate` (
  `candidate_id` int NOT NULL AUTO_INCREMENT,
  `Job_id` int NOT NULL,
  `Title` varchar(45) NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Birthdate` date NOT NULL,
  `Age` int NOT NULL,
  `Contactno` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Gender` varchar(45) NOT NULL,
  `Address` varchar(45) NOT NULL,
  `qualification` int NOT NULL,
  `Experience` int NOT NULL,
  `Candidate_image` varchar(255) NOT NULL,
  `Resume_image` varchar(255) NOT NULL,
  `Result` varchar(45) NOT NULL DEFAULT 'Pendding',
  `IsActive` tinyint NOT NULL DEFAULT '1',
  `IsDelete` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`candidate_id`),
  KEY `job_id_idx` (`Job_id`),
  KEY `experience_idx` (`Experience`),
  KEY `qualification_idx` (`qualification`),
  CONSTRAINT `experience` FOREIGN KEY (`Experience`) REFERENCES `experiencemaster` (`exp_id`),
  CONSTRAINT `job_id` FOREIGN KEY (`Job_id`) REFERENCES `jobmaster` (`job_id`),
  CONSTRAINT `qualification` FOREIGN KEY (`qualification`) REFERENCES `qualificationmaster` (`edu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listofcandidate`
--

LOCK TABLES `listofcandidate` WRITE;
/*!40000 ALTER TABLE `listofcandidate` DISABLE KEYS */;
INSERT INTO `listofcandidate` VALUES (2,13,'mr.','abcd','acbd','abcd','2003-06-09',56,'7080905060','abcd@gmail.com','male','sdsfchj',9,5,'null','null','pendding',1,0),(3,13,'mr.','asdfg','asdfg','asdfg','2003-06-09',23,'8090504070','acdfg@gmail.com','male','asdertyfg',9,4,'null','null','pendding',1,0),(4,13,'mr.','sdsrer','asdsfd','dfgr','2004-05-12',23,'7040508040','asdfg@gmail.com','male','dfvdgtryg',5,8,'null','null','pendding',1,0);
/*!40000 ALTER TABLE `listofcandidate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qualificationmaster`
--

DROP TABLE IF EXISTS `qualificationmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `qualificationmaster` (
  `edu_id` int NOT NULL AUTO_INCREMENT,
  `qualificationname` varchar(45) NOT NULL,
  `IsActive` tinyint DEFAULT '1',
  `IsDelete` tinyint DEFAULT '0',
  PRIMARY KEY (`edu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qualificationmaster`
--

LOCK TABLES `qualificationmaster` WRITE;
/*!40000 ALTER TABLE `qualificationmaster` DISABLE KEYS */;
INSERT INTO `qualificationmaster` VALUES (1,'bfgh',NULL,1),(2,'btech',NULL,1),(3,'testtttt',1,1),(4,'testtttt',1,1),(5,'fafaf',1,1),(6,'gfgfg',1,1),(7,'becom',1,1),(8,'mca',1,1),(9,'mba',1,1),(10,'gvjhngf',1,1),(11,'gbhtrh',1,1),(12,'cgfhd',1,1),(13,'ba5',1,1),(14,'mba',1,1),(15,'Master of Engineering (ME)',1,0),(16,'Doctor of Philosophy (PHD)',1,0),(17,'megha',1,1),(18,'megha',1,1),(19,'megha',1,1),(20,'phd',1,1),(21,'phd',1,1),(22,'phd',1,1),(23,'jahanvi',1,1),(24,'megha',1,1),(25,'megha',1,1),(26,'megha',1,1),(27,'abcd',1,1),(28,'megha',1,1),(29,'phd',1,1),(30,'phd',1,1),(31,'phd',1,1),(32,'phd',1,1),(33,'test',1,1),(34,'test2',1,1),(35,'tedgfg',1,1),(36,'gfgf',1,1),(37,'abcd',1,1),(38,'megha',1,1),(39,'phd',1,1),(40,'test2',1,1),(41,'phd',1,1),(42,'phd',1,1),(43,'abcd',1,1),(44,'Bachelor of Engineering (BE)',1,0),(45,'megha',1,1),(46,'nidhi',1,1),(47,'daksh',1,1),(48,'Bachelor of Arts (BA)',1,0),(49,'Bachelor of Computer Applications (BCA)',1,0),(50,'vbcgfc',1,1),(51,'uyjm',0,1),(52,'be',1,1),(53,'B COM',0,1),(54,'BCOM',1,1),(55,'fxgv',1,1),(56,'Master of Computer Applications (MCA)',1,0),(57,'Bachelor of Technology (B.TECH)',1,0),(58,'Master of Technology (M.TECH)',1,0),(59,'Bachelor of Commerce (B.COM)',1,0),(60,'Master of Commerce (M.COM)',1,0),(61,'Bachelor of Science (BSC)',1,0),(62,'Master of Science (MSC)',1,0);
/*!40000 ALTER TABLE `qualificationmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolemaster`
--

DROP TABLE IF EXISTS `rolemaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rolemaster` (
  `role_id` int NOT NULL AUTO_INCREMENT,
  `rolename` varchar(45) NOT NULL,
  `IsActive` tinyint NOT NULL DEFAULT '1',
  `IsDelete` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolemaster`
--

LOCK TABLES `rolemaster` WRITE;
/*!40000 ALTER TABLE `rolemaster` DISABLE KEYS */;
INSERT INTO `rolemaster` VALUES (1,'user',1,1),(2,'HR',1,1),(3,'HR',1,0),(4,'Employee',1,0),(5,'Admin',1,0),(6,'dfggdg',1,1);
/*!40000 ALTER TABLE `rolemaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usermaster`
--

DROP TABLE IF EXISTS `usermaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usermaster` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `emp_id` int DEFAULT NULL,
  `roleId` int DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(250) DEFAULT NULL,
  `firstName` varchar(45) DEFAULT NULL,
  `lastName` varchar(45) DEFAULT NULL,
  `IsActive` tinyint DEFAULT NULL,
  `IsDelete` tinyint DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  KEY `roleid_idx` (`roleId`),
  KEY `empid_idx` (`emp_id`),
  CONSTRAINT `empid` FOREIGN KEY (`emp_id`) REFERENCES `employeemaster` (`emp_id`),
  CONSTRAINT `roleid` FOREIGN KEY (`roleId`) REFERENCES `rolemaster` (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usermaster`
--

LOCK TABLES `usermaster` WRITE;
/*!40000 ALTER TABLE `usermaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `usermaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'recruitment'
--

--
-- Dumping routines for database 'recruitment'
--
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateExperience` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateExperience`(
    IN id INT,
    IN experienceyear VARCHAR(250),
     IN IsActive TINYINT
)
BEGIN
	 -- Check if qualificationmaster exists
    IF EXISTS (SELECT 1 FROM experiencemaster  WHERE exp_id = id) THEN
        -- Update experiencemaster
        UPDATE experiencemaster 
        SET experience = experienceyear,
        IsActive = IsActive
        WHERE exp_id = id;
        SELECT id AS recid;
    ELSE
        -- Insert new qualificationmaster
        set id=last_insert_id();
        INSERT INTO experiencemaster (experience,IsActive)
        VALUES (experienceyear,IsActive);
		select id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateJob` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateJob`(
    IN p_id INT,
    IN p_Title VARCHAR(50),
    IN p_Jobposition VARCHAR(50),
	IN p_Qualification INT,
	IN p_Jobtype INT,
    IN p_Jobdescription TEXT,
	IN p_Vacancies INT,
    IN p_Experience INT,
    IN p_Validupto DATE,
    IN p_CreatedDate DATE,
	IN p_Startsalary INT,
	IN p_Endsalary INT,
    IN p_Createdby VARCHAR(50),
    IN p_IsActive TINYINT
)
BEGIN
    -- Check if jobmaster exists
    IF EXISTS (SELECT 1 FROM jobmaster WHERE job_id = p_id) THEN
        -- Update jobmaster
        UPDATE jobmaster 
        SET title = p_Title,
			jobposition = p_Jobposition,
			qualification = p_Qualification,
            jobtype = p_Jobtype,
            jobdescription = p_Jobdescription,
			vacancies = p_Vacancies,
            experience = p_Experience,
            validupto = p_Validupto,
            createddate = p_CreatedDate,
			startsalary = p_Startsalary,
            endsalary = p_Endsalary,
			createdby = p_Createdby,
            IsActive = p_IsActive
        WHERE job_id = p_id;
        SELECT p_id AS recid;
    ELSE
        -- Insert new jobmaster
        INSERT INTO jobmaster (title,jobposition,qualification,jobtype,jobdescription,vacancies,experience,validupto,createddate,startsalary,endsalary,createdby,IsActive)
        VALUES (p_Title,p_Jobposition,p_Qualification,p_Jobtype,p_Jobdescription,p_Vacancies,p_Experience,p_Validupto,p_CreatedDate,p_Startsalary,p_Endsalary,p_Createdby,p_IsActive);
        
        -- Retrieve the last inserted ID
        SELECT last_insert_id() AS recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateListofcandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateListofcandidate`(
    IN p_id INT,
    IN p_jobid INT,
    IN p_Title VARCHAR(50),
    IN p_Firstname VARCHAR(50),
    IN p_middlename VARCHAR(50),
    IN p_Lastname VARCHAR(50),
    IN p_Dateofbirth DATE,
    IN p_age INT,
	IN p_Contactno VARCHAR(15),
    IN p_Email VARCHAR(50),
	IN p_Gender VARCHAR(50),
    IN p_address VARCHAR(45),
	IN p_qualification INT,
    IN p_experience INT,
	IN p_Image_Path VARCHAR(255),
	IN p_resume_image VARCHAR(255),
    IN p_result VARCHAR(45),
    IN p_IsActive TINYINT
)
BEGIN
    -- Check if listofcandidate exists
    IF EXISTS (SELECT 1 FROM listofcandidate WHERE candidate_id = p_id) THEN
        -- Update listofcandidate
        UPDATE listofcandidate 
        SET Job_id = p_jobid,
		
            Title = p_Title,
            FirstName = p_Firstname,
            MiddleName = p_middlename,
            LastName = p_Lastname,
            Birthdate = p_Dateofbirth,
            Age = p_age,
			Contactno = p_Contactno,
            Email = p_Email,
			Gender = p_Gender,
			Address = p_address,
			Qualification = p_qualification,
            Experience = p_experience,
         	Candidate_image = p_Image_Path,
            Resume_image = p_resume_image,
            Result = p_result,
            IsActive = p_IsActive
        WHERE candidate_id = p_id;
        SELECT p_id AS recid;
    ELSE
        -- Insert new listofcandidate
        INSERT INTO listofcandidate (
            Job_id, Title, FirstName, MiddleName, LastName,  Birthdate, Age,Contactno, Email,Gender, Address,   Qualification, Experience,  Candidate_image ,  Resume_image, Result, IsActive
        ) VALUES (
            p_jobid,  p_Title, p_Firstname, p_middlename, p_Lastname, p_Dateofbirth, p_age, p_Contactno, p_Email,  p_Gender, p_address,  p_qualification, p_experience, p_Image_Path , p_resume_image , p_result, p_IsActive
        );

        -- Retrieve the last inserted ID
        SELECT last_insert_id() AS recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateQualification` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateQualification`(
	IN id INT,
    IN Qualificationname VARCHAR(50),
    IN IsActive TINYINT
)
BEGIN
	 -- Check if qualificationmaster exists
    IF EXISTS (SELECT 1 FROM qualificationmaster  WHERE edu_id = id) THEN
        -- Update qualificationmaster
        UPDATE qualificationmaster 
        SET qualificationname = Qualificationname,
			IsActive = IsActive
        WHERE edu_id = id;
        SELECT id AS recid;
    ELSE
        -- Insert new qualificationmaster
        set id=last_insert_id();
        INSERT INTO qualificationmaster (Qualificationname,IsActive)
        VALUES (Qualificationname,IsActive);
		select id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertOrUpdateRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertOrUpdateRole`(
	IN id INT,
    IN roleName VARCHAR(50),
    IN IsActive TINYINT
)
BEGIN
		 -- Check if rolemaster exists
    IF EXISTS (SELECT 1 FROM rolemaster  WHERE role_id = id) THEN
        -- Update rolemaster
        UPDATE rolemaster 
        SET rolename = roleName,
			IsActive = IsActive
        WHERE role_id = id;
        SELECT id AS recid;
    ELSE
        -- Insert new qualificationmaster
        set id=last_insert_id();
        INSERT INTO rolemaster (rolename,IsActive)
        VALUES (roleName,IsActive);
		select id as recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsterOrUpdateEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsterOrUpdateEmployee`(
	IN p_id INT,
    IN p_Title VARCHAR(50),
    IN p_Firstname VARCHAR(50),
    IN p_Lastname VARCHAR(50),
    IN p_Gender VARCHAR(50),
    IN p_Dateofbirth date,
    IN p_Email VARCHAR(50),
    IN p_Contactno VARCHAR(15),
    IN p_Designation VARCHAR(50),
	IN p_Image_Path VARCHAR(255),
    IN p_IsActive TINYINT
)
BEGIN
	-- Check if employeemaster exists
    IF EXISTS (SELECT 1 FROM employeemaster WHERE emp_id = p_id) THEN
        -- Update employeemaster
        UPDATE employeemaster 
        SET title = p_Title,
            firstname = p_Firstname,
            lastname = p_Lastname,
            gender = p_Gender,
            dateofbirth = p_Dateofbirth,
            email = p_Email,
            contactno = p_Contactno,
            designation = p_Designation,
            IsActive = p_IsActive
        WHERE emp_id = p_id;
        SELECT p_id AS recid;
    ELSE
        -- Insert new jobmaster
        INSERT INTO employeemaster (title, firstname, lastname, gender, dateofbirth, email, contactno, designation, Image_Path , IsActive)
        VALUES (p_Title, p_Firstname, p_Lastname, p_Gender, p_Dateofbirth, p_Email, p_Contactno, p_Designation , p_Image_Path ,  p_IsActive);
        
        -- Retrieve the last inserted ID
        SELECT last_insert_id() AS recid;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_GetAllEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_GetAllEmployee`()
BEGIN
	Select * From employeemaster where IsDelete=0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_GetAllExperienceList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_GetAllExperienceList`()
BEGIN
	Select * From experiencemaster where IsDelete=0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_GetAllJobList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_GetAllJobList`()
BEGIN
    SELECT 
	
    qua.qualificationname as strqualification,
        job.*, 
          DATE_FORMAT(job.createddate,
                '%d/%m/%Y %h:%i %p') AS strCreateDate,
			DATE_FORMAT(job.validupto,
                '%d/%m/%Y') AS strvalidupto,
        qua.qualificationname,      exp.exp_id as experience,
        exp.experience as strexperience
    FROM 
        jobmaster job 
    INNER JOIN 
        qualificationmaster qua ON job.qualification = qua.edu_id
    INNER JOIN 
        experiencemaster exp ON job.experience = exp.exp_id 
    WHERE 
        job.IsDelete=0 
    ORDER BY 
        1 DESC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_GetAllListofcandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_GetAllListofcandidate`()
BEGIN
  SELECT 
    qua.qualificationname as strqualification,
        candidate.*, 
          DATE_FORMAT(candidate.Birthdate,
                '%d/%m/%Y') AS strBirthdate,
        exp.experience 
    FROM 
        listofcandidate candidate 
    INNER JOIN 
        qualificationmaster qua ON candidate.qualification = qua.edu_id
    INNER JOIN 
        experiencemaster exp ON candidate.Experience = exp.exp_id 
    WHERE 
        candidate.IsDelete=0 
    ORDER BY 
        1 DESC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_GetAllQualificationList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_GetAllQualificationList`()
BEGIN
	 Select * From qualificationmaster where IsDelete=0 order by 1 desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Proc_GetAllRoleList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proc_GetAllRoleList`()
BEGIN
	Select * From rolemaster where IsDelete=0 order by 1 desc;
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveEmployee`(IN p_id INT)
BEGIN
	update employeemaster set  IsDelete=1  where emp_id=p_id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveExperience` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveExperience`(IN id INT)
BEGIN
	update experiencemaster set  IsDelete=1  where exp_id=id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveJob` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveJob`(IN p_id INT)
BEGIN
	update jobmaster set  IsDelete=1  where job_id=p_id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveListofcandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveListofcandidate`(IN p_id INT)
BEGIN
	update listofcandidate set  IsDelete=1  where candidate_id=p_id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveQualification` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveQualification`(IN id INT)
BEGIN
	update qualificationmaster set  IsDelete=1  where edu_id=id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveRole`(IN id INT)
BEGIN
	update rolemaster set  IsDelete=1  where role_id=id ;
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

-- Dump completed on 2024-06-28 15:25:25
