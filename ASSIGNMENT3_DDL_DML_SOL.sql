USE TRAINING

-------------------------------------------1. TESTDATA-----------------------------------------
DROP TABLE TESTDATA;
CREATE TABLE TESTDATA(
	TESTNO NUMERIC(3) IDENTITY(1,1) NOT NULL PRIMARY KEY
)

--iNSERTING DATA
SET IDENTITY_INSERT TESTDATA ON --ALLOWING INSERT INTO IDENTITY COLUMN

INSERT INTO TESTDATA(TESTNO) VALUES(1)
INSERT INTO TESTDATA(TESTNO) VALUES(5)
INSERT INTO TESTDATA(TESTNO) VALUES(10)

SET IDENTITY_INSERT TESTDATA OFF --DISABLING INSERT INTO IDENTITY COLUMN

--PROJECTION OF DATA
SELECT * FROM TESTDATA




------------------------------2.	COUNTRY AND STATE TABLE----------------------------------
DROP TABLE STATE
DROP TABLE COUNTRY

CREATE TABLE COUNTRY(
	CON_ID VARCHAR(3) NOT NULL PRIMARY KEY,
	CON_NAME VARCHAR(20) NOT NULL UNIQUE,
	CAPITAL VARCHAR(20) NULL,
	FLAG VARBINARY(MAX) NULL
)

CREATE TABLE STATE(
	STATE_ID VARCHAR(3) NOT NULL PRIMARY KEY,
	STATE_NAME VARCHAR(20) NOT NULL,
	S_CAPITAL VARCHAR(20) NULL,
	CON_ID VARCHAR(3) NULL REFERENCES COUNTRY (CON_ID) ON DELETE CASCADE
)

--INSERTING DATA IN COUNTRY TABLE
--INSERTING IMAGE USING PATH
INSERT INTO COUNTRY VALUES(1, 'INDIA','DELHI',(SELECT * FROM OPENROWSET(BULK N'D:\HDD\PI Techniques\Training\INDIAFLAG.png', SINGLE_BLOB) as T1))
INSERT INTO COUNTRY VALUES(2, 'USA','Washington,D.C',(SELECT * FROM OPENROWSET(BULK N'D:\HDD\PI Techniques\Training\USAFLAG.png', SINGLE_BLOB) as T1))
INSERT INTO COUNTRY VALUES(3, 'CHINA','Beijing',(SELECT * FROM OPENROWSET(BULK N'D:\HDD\PI Techniques\Training\CHINAFLAG.png', SINGLE_BLOB) as T1))

--INSERTING DATA IN STATE TABLE
INSERT INTO STATE VALUES (1,'RAJASTHAN','JAIPUR', 1)
INSERT INTO STATE VALUES (2,'CALIFORNIA','Sacramento', 2)
INSERT INTO STATE VALUES (3,'TEXAS',' Austin', 2)
INSERT INTO STATE VALUES (4,'MAHARASTRA','MUMBAI', 1)

--PROJECTION OF DATA
SELECT * FROM COUNTRY

SELECT * FROM STATE

---------------------------------------3.	CUSTOMER, category and PRODUCT TABLE----------------------------------
DROP TABLE ORDERS
DROP TABLE PRODUCT
DROP TABLE CATEGORY
DROP TABLE CUSTOMER

--CUSTOMER TABLE
CREATE TABLE CUSTOMER(
	CUST_ID NUMERIC(3) NOT NULL PRIMARY KEY,
	CUST_NAME VARCHAR(20) NOT NULL
)

--CATEGORY TABLE
CREATE TABLE CATEGORY(
	CAT_ID NUMERIC(3) NOT NULL PRIMARY KEY,
	CAT_NAME VARCHAR(20) NOT NULL UNIQUE,
	DESCRIPT VARCHAR(20) NULL
)

--PRODUCT TABLE
CREATE TABLE PRODUCT(
	PROD_ID NUMERIC(3) NOT NULL PRIMARY KEY,
	PROD_NAME VARCHAR(20) NOT NULL,
	CAT_ID NUMERIC(3) NULL REFERENCES CATEGORY (CAT_ID) ON DELETE CASCADE,
	PRICE NUMERIC(10,2) NULL CHECK (PRICE>50),
	QUANTITY NUMERIC(3) NULL CHECK(QUANTITY >0)
)

--ORDERS TABLE
CREATE TABLE ORDERS(
	OD_YEAR NUMERIC(3) NOT NULL,
	OD_MONTH VARCHAR(20) NOT NULL,
	OD_ID VARCHAR(20) NOT NULL,
	OD_DATE DATETIME DEFAULT GETDATE(),
	PROD_ID NUMERIC(3) REFERENCES PRODUCT (PROD_ID) ON DELETE CASCADE,
	CUST_ID NUMERIC(3) REFERENCES CUSTOMER (CUST_ID) ON DELETE CASCADE,
	ORD_QRY NUMERIC(3) CHECK(ORD_QRY>0)
)

--Add column �Address � Varchar - 20� in Customer table with validation that customer address 
--can be either Mumbai, Delhi or pune

ALTER TABLE CUSTOMER ADD ADDRESS VARCHAR(20) NULL CHECK (ADDRESS IN ('MUMBAI', 'DELHI','PUNE'))

--Modify size of �OrderYear� column in Orders table as 4 instead of 3
ALTER TABLE ORDERS ALTER COLUMN OD_YEAR NUMERIC(4) NOT NULL

-- Modify column �OrderMonth� in Orders table from Varchar to int data type
ALTER TABLE ORDERS ALTER COLUMN OD_MONTH NUMERIC(2) NOT NULL

-- Drop �Description� column from Category table
ALTER TABLE CATEGORY DROP COLUMN DESCRIPT

--INSERTING OF DATA IN CUSTOMER TABLE
INSERT INTO CUSTOMER VALUES(1,'AJAY','MUMBAI')
INSERT INTO CUSTOMER VALUES(2,'CHIRAG','DELHI')
INSERT INTO CUSTOMER VALUES(3,'AMIT','PUNE')

--INSERTING OF DATA IN CATEGORY TABLE
INSERT INTO CATEGORY VALUES(1,'FOOD')
INSERT INTO CATEGORY VALUES(2,'ELECTRONICS')
INSERT INTO CATEGORY VALUES(3,'STATIONARY')

--INSERTING OF DATA IN PRODUCT TABLE
INSERT INTO PRODUCT VALUES(101, 'TEA',1, 60,100)
INSERT INTO PRODUCT VALUES(102, 'PEN',3, 80,50)
INSERT INTO PRODUCT VALUES(103, 'NOTE BOOK',3, 125,200)
INSERT INTO PRODUCT VALUES(104, 'COFFEE',1, 80,100)
INSERT INTO PRODUCT VALUES(105, 'TV',2, 15000,5)
INSERT INTO PRODUCT VALUES(106, 'WASHING MACHINE',2, 12000,3)

--INSERTING OF DATA IN ORDERS TABLE
INSERT INTO ORDERS(OD_YEAR,OD_MONTH,OD_ID,PROD_ID,CUST_ID,ORD_QRY) VALUES(2010,1,'1', 101,2,10)
INSERT INTO ORDERS(OD_YEAR,OD_MONTH,OD_ID,PROD_ID,CUST_ID,ORD_QRY) VALUES(2010,1,'2', 104,1,2)
INSERT INTO ORDERS(OD_YEAR,OD_MONTH,OD_ID,PROD_ID,CUST_ID,ORD_QRY) VALUES(2010,2,'1', 105,3,1)
INSERT INTO ORDERS VALUES(2010,2,'2',GETDATE(), 101,1,5)
INSERT INTO ORDERS VALUES(2010,2,'3',GETDATE(), 106,2,1)
INSERT INTO ORDERS VALUES(2011,1,'1',GETDATE(), 104,1,2)

--PROJECT OF DATA
SELECT * FROM CUSTOMER 

SELECT * FROM CATEGORY

SELECT * FROM PRODUCT

SELECT * FROM ORDERS
