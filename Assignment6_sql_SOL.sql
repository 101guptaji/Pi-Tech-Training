--------- TEMP DATABASE
/*
	SQL Server comes installed with four system databases by default. They are master, model, msdb, and TempDB.
	TempDB is a database that has many functions within SQL Server, but it is rarely called explicitly.
	Tempdb holds:
	Temporary user objects that are explicitly created. They include global or local temporary tables and indexes, temporary stored procedures, table variables, tables returned in table-valued functions, and cursors.

	Internal objects that the database engine creates. They include:
		Work tables to store intermediate results for spools, cursors, sorts, and temporary large object (LOB) storage.
		Work files for hash join or hash aggregate operations.
		Intermediate sort results for operations such as creating or rebuilding indexes (if SORT_IN_TEMPDB is specified), or certain GROUP BY, ORDER BY, or UNION queries.
	
	Version stores, which are collections of data pages that hold the data rows that support features for row versioning. There are two types: a common version store and an online-index-build version store. The version stores contain:
		Row versions that are generated by data modification transactions in a database that uses READ COMMITTED through row versioning isolation or snapshot isolation transactions.
		Row versions that are generated by data modification transactions for features, such as online index operations, Multiple Active Result Sets (MARS), and AFTER triggers.
	
	Operations within tempdb are minimally logged so that transactions can be rolled back. tempdb is re-created every time SQL Server is started so that the system always starts with a clean copy of the database. Temporary tables and stored procedures are dropped automatically on disconnect, and no connections are active when the system is shut down.

	tempdb never has anything to be saved from one session of SQL Server to another. Backup and restore operations are not allowed on tempdb.
*/
use tempdb
-- Determining the amount of free space in tempdb
SELECT SUM(unallocated_extent_page_count) AS [free pages],
  (SUM(unallocated_extent_page_count)*1.0/128) AS [free space in MB]
FROM sys.dm_db_file_space_usage;

-- Determining the amount of space used by the version store
SELECT SUM(version_store_reserved_page_count) AS [version store pages used],
  (SUM(version_store_reserved_page_count)*1.0/128) AS [version store space in MB]
FROM sys.dm_db_file_space_usage;

-- Determining the amount of space used by internal objects
SELECT SUM(internal_object_reserved_page_count) AS [internal object pages used],
  (SUM(internal_object_reserved_page_count)*1.0/128) AS [internal object space in MB]
FROM sys.dm_db_file_space_usage;

-- Determining the amount of space used by user objects
SELECT SUM(user_object_reserved_page_count) AS [user object pages used],
  (SUM(user_object_reserved_page_count)*1.0/128) AS [user object space in MB]
FROM sys.dm_db_file_space_usage;

--------------------CTE COMMON TABLE EXPRESSION
/*
	A CTE (Common Table Expression) is a temporary result set that you can reference within another SELECT, INSERT, UPDATE, or DELETE statement.  They were introduced in SQL Server version 2005.  They are SQL-compliant and part of the ANSI SQL 99 specification.
	A CTE (Common Table Expression) defines a temporary result set which you can then use in a SELECT statement.
	CTE�s are used within SQL Server to simplify complex joins and subqueries.
	CTE�s are defined within the statement using the WITH operator.There can define one or more common table expression in this fashion.
	there are two types of CTE's
	(1) Recursive CTE�s
	(2) Non-Recursive CTE�s
*/
--Example:
	--	PRINT RECORD OF 3RD HIGHEST SALARY EARNED EMPLOYEE  (DO NOT USE TOP N)
	WITH RANK_SALARY_CTE (EMPNO, EMP_NAME, JOB,MGR,HIREDATE,SAL,COMM,DEPNO,SR)
	AS
		(SELECT *,DENSE_RANK() OVER(ORDER BY SAL DESC)  FROM TRAINING.dbo.EMP)
	SELECT * FROM RANK_SALARY_CTE WHERE SR=3


----------------------------TABLE VARIABLE
/*
	The table variable is a special type of the local variable that helps to store data temporarily, similar to the temp table in SQL Server. In fact, the table variable provides all the properties of the local variable, but the local variables have some limitations, unlike temp or regular tables.
	Table variables are stored in the tempdb database.
	Table structure after the declaration of the table variable can not change or alter.
	CRUD (INSERT, SELECT,UPDATE,DELETE) CAN BE PERFORMED.
*/
--EXAMPLE
	--CREATING TABLE VARIABLE
	DECLARE @TABLE_VARIABLE_EMP TABLE(EMPNAME VARCHAR(20), JOB VARCHAR(10))
	--INSERTION
	INSERT INTO @TABLE_VARIABLE_EMP VALUES('hIMANSHU','DEVELOPER')
	--SELECT
	SELECT * FROM @TABLE_VARIABLE_EMP

--------------------------------------------------------------------------------------------------------------------------
--SP
--COMMA SEPRATED EMP NAME BASED ON DEPTNO
USE TRAINING

ALTER PROC GETEMPNAME (@DNO INT, @EMPLIST VARCHAR(MAX) OUT) 
AS
BEGIN
	DECLARE @EMPNAME VARCHAR(20)
	DECLARE EMP_CURSOR CURSOR FOR SELECT ENAME FROM EMP WHERE DEPTNO=@DNO
	
	OPEN EMP_CURSOR
	FETCH NEXT FROM EMP_CURSOR INTO @EMPNAME
	SET @EMPLIST=@EMPNAME
	WHILE @@FETCH_STATUS=0 
	BEGIN 
	
		--PRINT 'EMPNAME: '+@EMPNAME
		FETCH NEXT FROM EMP_CURSOR INTO @EMPNAME
		IF @@FETCH_STATUS=0 
			SET @EMPLIST=@EMPLIST+','+@EMPNAME
	END
	CLOSE EMP_CURSOR
	DEALLOCATE EMP_CURSOR
END

DECLARE @ELIST VARCHAR(MAX)
EXEC GETEMPNAME 30, @ELIST OUT
PRINT @ELIST

SELECT * FROM EMP WHERE DEPTNO=30


----------------------------------------------------------------------------------------------------------------------
--SP
--CALL PROCEDURE AND PASS COMMA SEPRATED EMPNAME
--INSERT ALL EMP IN A TABLE AS INDEPENDENT RECORD

CREATE TABLE EMPDATA1 (
EMPNO INT IDENTITY PRIMARY KEY,
EMPNAME VARCHAR(20),
DEPTNO INT
)

--DELETE FROM EMPDATA1

CREATE PROC INSERTDATA (@DNO INT, @NAMELIST VARCHAR(50))
AS
BEGIN
    DECLARE @START_INDEX INT, @END_INDEX INT, @CHAR VARCHAR(1)=','
	
    SET @START_INDEX = 1
    IF SUBSTRING(@NAMELIST, LEN(@NAMELIST) - 1, LEN(@NAMELIST)) <> @CHAR
    BEGIN
        SET @NAMELIST = @NAMELIST + @CHAR
    END
 
    WHILE CHARINDEX(@CHAR, @NAMELIST) > 0
    BEGIN
        SET @END_INDEX = CHARINDEX(@CHAR, @NAMELIST)
         
        INSERT INTO EMPDATA1(EMPNAME)
        SELECT SUBSTRING(@NAMELIST, @START_INDEX, @END_INDEX - 1)
        
        SET @NAMELIST = SUBSTRING(@NAMELIST, @END_INDEX + 1, LEN(@NAMELIST))
    END 
END

DECLARE @NAMELIST VARCHAR(50) = 'SMITH,JONES,KING,FORD'

EXEC INSERTDATA 10, @NAMELIST

SELECT * FROM EMPDATA1














---------------------------------------------------------Northwind Queries----------------------------------------------------------
USE Northwind
-------------------------Table: Customers
SELECT * FROM Customers

--1. Display the �Company Name� and �Contact Name� from Customers table
SELECT CompanyName,ContactName FROM Customers

--2. Find the Customers who are staying wither in USA, UK, Germany, France
SELECT * FROM Customers WHERE Country IN ('USA', 'UK','GERMANY','FRANCE') ORDER BY Country

--3. Find the Customers whose �Company Name� starts with G
SELECT * FROM Customers WHERE CompanyName LIKE 'G%'

--4. List all the Customers who are located in Paris
SELECT * FROM Customers WHERE City='PARIS'

--5. List the Customer details whose postal code start with 4
SELECT * FROM Customers WHERE PostalCode LIKE '4%'

--6. List all the Customers who neither stay in Canada nor in Brazil
SELECT * FROM Customers WHERE Country NOT IN ('CANADA','BRAZIL')

--7. Print total number of Customers for each country.
SELECT Country,COUNT(CUSTOMERID)AS "NO OF CUSTOMERS" FROM Customers GROUP BY Country

--8. List Customers detail based on Country and City
SELECT ROW_NUMBER() OVER(PARTITION BY COUNTRY ORDER BY CITY DESC) AS "Customers by Country and City",* FROM Customers

--9. List all the manager from the Customers table
SELECT * FROM Customers WHERE ContactTitle LIKE '%MANAGER'

--10. List all Customers details where �company name� contains aphostophy (�)
SELECT * FROM Customers WHERE CompanyName LIKE '%''%'


--------------------------Table: Products
SELECT * FROM Products

--11. List all the products for CategoryID 4 and UnitsInStock is more then 50
SELECT * FROM Products WHERE CategoryID=4 AND UnitsInStock>50

--12. List ProductName, UnitPrice, UnitsInStock, NetStock (i.e. UnitPrice * UnitsInStock)
SELECT ProductName,UnitPrice,UnitsInStock,(UnitPrice*UnitsInStock) NetStock FROM Products

--13. List Maximum and Minimum UnitPrice
SELECT MAX(UnitPrice) "Maximum UnitPrice",MIN(UnitPrice) "Minimum UnitPrice" FROM Products

--14. Count the number of products whose UnitPrice is more then 50
SELECT COUNT(PRODUCTID) "Number of products" FROM Products WHERE UnitPrice > 50

--15. List product count base on CategoryID. List the data where count is more then 10
SELECT COUNT(PRODUCTID) AS "Product Count",CategoryID FROM Products GROUP  BY CategoryID HAVING COUNT(PRODUCTID) >10

--16. Find all the products where UnitsInStock in less than Reorder Level
SELECT * FROM Products WHERE UnitsInStock < ReorderLevel

--17. List Category wise, Supplier wise product count
SELECT CategoryID,SupplierID,COUNT(PRODUCTID) FROM Products GROUP BY CategoryID,SupplierID

--18. All Products whose UnitsInStock is less than 5 units are entitles for placing order by 50 units for 
--others place the order by 30 units. Display ProductID, ProductName, UnitsInStock, OrderedUnits.
SELECT ProductID, ProductName, UnitsInStock, 
CASE
	WHEN UnitsInStock < 5 THEN UnitsOnOrder+ 50
	WHEN UnitsInStock > 5 THEN UnitsOnOrder+30
END AS OrderedUnits
FROM Products 

--19. List 3 costliest product
SELECT TOP 3 * FROM Products ORDER BY UnitPrice DESC

--20. List all the products whose CategoryID is 1 and SupplierID is either 10 or 12 or CategoryID is 4 
--and SupplierID is either 14 or 15.
SELECT * FROM Products WHERE (CategoryID=1 AND SupplierID IN (10,12)) OR (CategoryID=4 AND SupplierID IN (14,15))


------------------------------------Table: Orders
SELECT * FROM Orders

--21. List all the orders placed in month of February
SELECT * FROM Orders WHERE MONTH(OrderDate)='2'

--22. List year wise order count
SELECT YEAR(OrderDate) "Year",COUNT(OrderID) "ORDERS" FROM Orders GROUP BY YEAR(OrderDate)

--23. List the ShipCountry for which total order placed is more than 100
--Example
--ShipCountry OrderCount
--USA 122
SELECT ShipCountry,COUNT(OrderID) "OrderCount" FROM Orders GROUP BY ShipCountry HAVING COUNT(OrderID)>100

--24. List the data as per the order month (Jan � Dec)
SELECT MONTH(ORDERDATE) "ORDER'S MONTH",* FROM Orders ORDER BY MONTH(ORDERDATE)

--25. List unique country name in ascending order where product is shipped
SELECT DISTINCT ShipCountry FROM Orders ORDER BY ShipCountry ASC

--26. List CustomerID, ShipCity, ShipCountry, ShipRegion from Ordrs table. If ShipRegion is null than 
--display message as �No Region�
SELECT CustomerID, ShipCity, ShipCountry, ISNULL(ShipRegion,'No Region') FROM Orders 

--27. List the detail of first order placed
SELECT TOP 1 * FROM Orders ORDER BY OrderDate

--28. List Customer wise, Year wise (Order date) order placed
--Example
--CustomerID Year OrderCount
--ANATR 1996 1
--BONAP 1997 8 �
SELECT CustomerID,YEAR(OrderDate) Year, COUNT(OrderID)  "OrderCount" FROM Orders GROUP BY CustomerID, YEAR(OrderDate)

--29. List all the orders handled by employeeid 4 for the month of December
SELECT * FROM Orders WHERE EmployeeID=4 AND MONTH(OrderDate)='12'

--30. List employee wise , year wise, month wise ordercount
SELECT EmployeeID,YEAR(OrderDate) YEAR, MONTH(OrderDate) MONTH, COUNT(OrderID) ordercount FROM Orders GROUP BY EmployeeID,YEAR(OrderDate), MONTH(OrderDate)



-----------------------------------Table: [Order Details]
SELECT * FROM "Order Details"

--31. List all the data of [Order Details] table
SELECT * FROM "Order Details"

--32. List ProductID, UnitPrice, Qty and Total. Sort data on Total column with highest value on top
SELECT ProductID, UnitPrice, Quantity, (UnitPrice*Quantity) Total FROM "Order Details" ORDER BY Total DESC

--33. In above query, 
--If Total is more than 10000 display 10% discount on Total cost
--If Total is more than 5000 display 5% discount on Total cost
--If Total is more than 3000 display 2% discount on Total cost
--else Rs. 300 as discount if total is more than 1000
--No discount for Total less than 1000
SELECT ProductID, UnitPrice, Quantity, (UnitPrice*Quantity) Total,
CASE
	WHEN (UnitPrice*Quantity) > 10000 THEN 0.1*(UnitPrice*Quantity)
	WHEN (UnitPrice*Quantity) > 5000 THEN 0.05*(UnitPrice*Quantity)
	WHEN (UnitPrice*Quantity) > 3000 THEN 0.02*(UnitPrice*Quantity)
	WHEN (UnitPrice*Quantity) > 1000 THEN 300
	ELSE NULL
END AS Discount
FROM "Order Details" ORDER BY Total DESC

--34. List Total order placed for each OrderId
SELECT OrderID,COUNT(PRODUCTID) "Total order" FROM "Order Details" GROUP BY OrderID

--35. List minimum cost and maximum cost order value
SELECT MIN(UnitPrice*Quantity-Discount),MAX(UnitPrice*Quantity-Discount) FROM "Order Details"




-------------------------------------------------------JOIN AND SUBQUERY ASSIGNMENT
SELECT * FROM Products
SELECT * FROM Categories
SELECT * FROM Orders
SELECT * FROM Customers 
SELECT * FROM Employees
SELECT * FROM Suppliers
SELECT * FROM "Order Details"

--1 LIST ALL THE PRODUCTS DETAILS WHOSE CATEGORY IS SAME AS 'TOFU'
SELECT * FROM Products WHERE CategoryID IN (SELECT CategoryID FROM Products WHERE ProductName='TOFU')

--2 LIST ALL THE PRODUCTS DETAILS FOR THE CATEGORY 'BEVERAGES'
SELECT * FROM Products WHERE CategoryID IN (SELECT CategoryID FROM Categories WHERE CategoryName='BEVERAGES')

--3 LIST ALL THE ORDERS PLACED BY THE COMPANY NAME "ISLAND TRADING"
SELECT * FROM Orders WHERE CustomerID IN (SELECT CustomerID FROM Customers WHERE CompanyName='ISLAND TRADING')

--4 LIST COMPANY NAME AND NO OF ORDER COUNT PLACED BY EACH COMPANY
SELECT CUST.CompanyName,COUNT(O.ORDERID) "NO OF ORDERS" FROM Orders O JOIN Customers CUST ON O.CustomerID=CUST.CustomerID GROUP BY CUST.CompanyName

--5 LIST ORDERID, CUSTOMER_COMAPNAYNAME FOR ALL THE ORDERS WHICH ARE HANDLE BY THE EMPLOYEES WHOSE TITLE IS "SALES MANAGER"
SELECT ORDERID, C.CompanyName CUSTOMER_COMAPNAYNAME FROM Orders O LEFT JOIN Customers C ON O.CustomerID=C.CustomerID AND C.ContactTitle='SALES MANAGER'


--6 LIST 3RD HIGHEST COSTLIEST PRODUCT
SELECT * FROM (SELECT *,DENSE_RANK() OVER (ORDER BY UNITPRICE DESC) SR FROM Products) AS P WHERE SR=3

--7 FOR THE PRODUCT TABLE DISPLAY PRODUCTNAME AND CATEGORYNAME. ARRANGE AS PER THE CATEGORYNAME
SELECT P.ProductName,C.CategoryName FROM Products P JOIN Categories C ON P.CategoryID=C.CategoryID ORDER  BY C.CategoryName

--8 FOR THE ORDERS TABLE DISPLAY ORDERID CUSTOMER_COMPANYNAME AND EMPLOYEE_FULLNAME
SELECT O.OrderID,C.CompanyName,E.FirstName+' '+E.LastName "EMPLOYEE_FULLNAME" FROM Orders O JOIN Customers C ON O.CustomerID=C.CustomerID JOIN Employees E ON E.EmployeeID=O.EmployeeID

--9 LIST ORDERID, EMPLOYEE_FULLNAME, CUSTOMER_COMPANYNAME, CATEGORYNAME, SUPPLIER_COMPANYNAME, PRODUCTNAME, ORDERDETAIS_UNIRPRICE, ORDERDETAILS_QUANTITY , NETSTOCK
SELECT O.OrderID,E.FirstName+' '+E.LastName "EMPLOYEE_FULLNAME",C.CompanyName, CAT.CategoryName, S.CompanyName,P.ProductName, OD.UnitPrice, OD.Quantity,P.UnitsInStock NETSTOCK FROM Orders O 
	JOIN Customers C ON O.CustomerID=C.CustomerID 
	JOIN Employees E ON E.EmployeeID=O.EmployeeID 
	JOIN "Order Details" OD ON O.OrderID=OD.OrderID
	JOIN Products P ON OD.ProductID=P.ProductID 
	JOIN Categories CAT ON P.CategoryID=CAT.CategoryID
	JOIN Suppliers S ON P.SupplierID=S.SupplierID

--10 LIST ALL THE ORDERS (ORDERID, PRODUCTNAME) PLACED BY THE CUSTOMER IN LONDON
SELECT O.OrderID,P.ProductName FROM Orders O 
	JOIN Customers C ON O.CustomerID=C.CustomerID 
	JOIN "Order Details" OD ON O.OrderID=OD.OrderID
	JOIN Products P ON OD.ProductID=P.ProductID AND C.City='LONDON'
	
--11 FOR THE COSTLIEST PRODUCT DISPLAY PRODUCTNAME, UNITPRICE,CATEGORYNAME, SUPPLIER_CONTACTNAME
SELECT TOP 1 P.ProductName,P.UnitPrice,CAT.CategoryName,S.ContactName FROM "Order Details" OD 
	JOIN Products P ON OD.ProductID=P.ProductID 
	JOIN Categories CAT ON P.CategoryID=CAT.CategoryID
	JOIN Suppliers S ON P.SupplierID=S.SupplierID ORDER BY P.UnitPrice DESC

--12 LIST ALL THE PRODUCTNAME WHOSE ORDER PLACED IN MONTH OF AUGUST
SELECT P.ProductName FROM  Orders O 
	JOIN "Order Details" OD ON O.OrderID=OD.OrderID
	JOIN Products P ON OD.ProductID=P.ProductID AND MONTH(O.ORDERDATE)='8'
	
--13 LIST ORDERID, QUANTITY FOR ALL THE ORDERS. ASSIGNED RANK AS PER THE HIGHEST OT LOWEST QUANTITY. DO NOT MISS ANY NUMBER WHILE ASSIGNING THE RANK
SELECT DENSE_RANK() OVER (ORDER BY QUANTITY DESC) "RANK",ORDERID,Quantity FROM "ORDER DETAILS"

--14 List all the products for the category �Dairy ProductS�
SELECT * FROM Products WHERE CategoryID IN (SELECT CategoryID FROM Categories WHERE CategoryName='DAIRY PRODUCTS')

--15 List all the products which is supplied by the company �Bigfoot Breweries� for the category �Beverages�
SELECT * FROM Products WHERE SupplierID IN (SELECT SupplierID FROM Suppliers WHERE CompanyName='Bigfoot Breweries') 
	AND CategoryID IN (SELECT CategoryID FROM Categories WHERE CategoryName='Beverages')

--16 Print CategoryName , Supplier Comapny name and product count for each category and supplier
SELECT C.CategoryName,S.CompanyName,COUNT(P.PRODUCTID) "Product Count" FROM Products P JOIN Categories C ON P.CategoryID =C.CategoryID JOIN Suppliers S ON P.SupplierID= S.SupplierID GROUP BY C.CategoryName, S.CompanyName

--17 PRINT REGION AND TERRITORYDESCRIPTION NAME IN ASCENDING ORDER
SELECT R.RegionDescription,T.TerritoryDescription FROM Region R JOIN Territories T ON R.RegionID=T.RegionID ORDER BY R.RegionDescription,T.TerritoryDescription ASC

--18 PRINT EMPLOYEES NAME, REGION NAME, CITY AND COUNTRY --(check for the error, no region relationship)
/*SELECT * FROM Employees E JOIN EmployeeTerritories ET ON E.EmployeeID=ET.EmployeeID 
	JOIN Territories T ON ET.TerritoryID=T.TerritoryID
	JOIN Region R ON T.RegionID=R.RegionID*/

SELECT FirstName+' '+LastName "EMPLOYEES NAME",Region,City,Country FROM Employees 

--19 FOR EACH CATEGORIES PRINT CATEGORYNAME AND SUPPLIERS NAME
SELECT DISTINCT C.CategoryName,S.CompanyName "SUPPLIER NAME" FROM Products P JOIN Categories C ON P.CategoryID=C.CategoryID JOIN Suppliers S ON P.SupplierID=S.SupplierID

--20 PRINT EMPLOYEE TITLEOFCOURTESY, EMPLOYEE FIRST + LASTNAME , EMPLOYEE TITLE, MANAGER TITLEOFCURTASY, MANAGER FIRSTNAME + LASTNAME, MANAGER TITLE
SELECT E.TitleOfCourtesy,E.FirstName+' '+E.LastName "EMPLOYEE NAME",E.Title, M.TitleOfCourtesy "MANAGER TITLEOFCURTASY",M.FirstName+' '+M.LastName "MANAGER NAME",M.Title "MANAGER TITLE" FROM Employees E JOIN Employees M ON E.ReportsTo=M.EmployeeID




------------------------------------------NORTHWIND DATABASE � PROGRAMMING ASSIGNMENT
--1. WRITE A PROCEDURE WHICH TAKES CATEGORY NAME AS A PARAMETER AND RETURN ALL PRODUCTS WHICH MATCH WITH THE CATEGORY NAME. IF NAME NOT EXIST PRINT MESSAGE
CREATE PROC PROD_BY_CATEGORY (@CNAME VARCHAR(20)) AS
BEGIN
	
	SELECT * FROM PRODUCTS WHERE CategoryID IN (SELECT CategoryID FROM Categories WHERE CategoryName=@CNAME)
	DECLARE @COUNT INT
	SET @COUNT=@@ROWCOUNT
	IF @COUNT=0
		RAISERROR('CATEGORY NAME DOES NOT EXIST',16,1)
	
END

EXEC PROD_BY_CATEGORY 'DAIRY PRODUCTS'
EXEC PROD_BY_CATEGORY 'DAIRY PRODUCT'

--2. TAKE COUNTRY NAME AS THE PARAMETER AND RETURN ALL CUSTOMERS FROM THAT COUNTRY.
CREATE PROC "CUSTOMER BY COUNTRY" (@CONT_NAME VARCHAR(20)) AS
BEGIN
	SELECT * FROM Customers WHERE Country=@CONT_NAME
	DECLARE @COUNT INT
	SET @COUNT=@@ROWCOUNT
	IF @COUNT=0
		RAISERROR('COUNTRY DOES NOT EXIST',16,1)
END

EXEC "CUSTOMER BY COUNTRY" 'FRANCE'

--3. WRITE INSERT, UPDATE AND DELETE PROCEDURE FOR EMPLOYEES TABLE. IF ANY STATEMENT FAIL RAISE PROPER ERROR MESSAGE
--PARAMETER : 
--EMPLOYEEID LASTNAME FIRSTNAME TITLE TITLEOFCOURTESY BIRTHDATE HIREDATE ADDRESS CITY REGION POSTALCODE COUNTRY
SELECT * FROM Employees

CREATE PROC INSERT_EMPLOYEE (@EMPLOYEEID INT, @LastName nvarchar (20),@FirstName nvarchar (10),@Title nvarchar (30), @TitleOfCourtesy nvarchar (25),@BirthDate datetime,@HireDate datetime,@Address nvarchar (60),@City nvarchar (15),@Region nvarchar (15),@PostalCode nvarchar (10),@Country nvarchar (15) )  AS
BEGIN
	BEGIN TRY
		set identity_insert "Employees" on
		ALTER TABLE "Employees" NOCHECK CONSTRAINT ALL
		INSERT INTO Employees(EMPLOYEEID, LASTNAME, FIRSTNAME, TITLE, TITLEOFCOURTESY, BIRTHDATE, HIREDATE, ADDRESS, CITY, REGION, POSTALCODE, COUNTRY) VALUES (@EMPLOYEEID, @LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country)
		set identity_insert "Employees" OFF
		ALTER TABLE "Employees" CHECK CONSTRAINT ALL
	END TRY
	BEGIN CATCH
		RAISERROR('ERROR IN INSERTION',16,1)
	END CATCH
END

EXEC INSERT_EMPLOYEE 1001,'NANCY','SUMAN','Sales MANAGER','Ms.','12/08/1948','05/01/1992','507 - 20th Ave. E.
Apt. 2A','Seattle','WA','98122','USA'

CREATE PROC UPDATE_EMPLOYEE (@EMPLOYEEID INT, @LastName nvarchar (20),@FirstName nvarchar (10),@Title nvarchar (30), @TitleOfCourtesy nvarchar (25),@BirthDate datetime,@HireDate datetime,@Address nvarchar (60),@City nvarchar (15),@Region nvarchar (15),@PostalCode nvarchar (10),@Country nvarchar (15) )  AS
BEGIN
	ALTER TABLE "Employees" NOCHECK CONSTRAINT ALL
	UPDATE Employees SET
	LASTNAME=@LastName,
	FIRSTNAME=@FirstName,
	TITLE=@Title,
	TITLEOFCOURTESY=@TitleOfCourtesy,
	BIRTHDATE=@BirthDate,
	HIREDATE=@HireDate,
	ADDRESS=@Address,
	CITY=@City,
	REGION=@Region,
	POSTALCODE=@PostalCode,
	COUNTRY=@Country
	WHERE EMPLOYEEID=@EMPLOYEEID
	ALTER TABLE "Employees" CHECK CONSTRAINT ALL
	DECLARE @COUNT INT
	SET @COUNT=@@ROWCOUNT
	IF @COUNT=0
		RAISERROR('INVALID EMPLOYEE ID',16,1)
END

EXEC UPDATE_EMPLOYEE 1001,'GUPTA','HIMANSHU','Sales Representative','Ms.','12/08/1948','05/01/1992','507 - 20th Ave. E.
Apt. 2A','Seattle','WA','98122','USA'


CREATE PROC DELETE_EMPLOYEE (@EMPID INT) AS
BEGIN
	
	DELETE FROM Employees WHERE EmployeeID=@EMPID
	DECLARE @COUNT INT
	SET @COUNT=@@ROWCOUNT
	IF @COUNT=0
		RAISERROR('INVALID EMPLOYEE ID',16,1)
END

EXEC DELETE_EMPLOYEE 1001


--4. TAKE REGIONDESCRIPTION AS A PARAMETER PRINT REGIONDESCRIPTION, TERRITORY DESCRIPTION, AND EMPNAME
CREATE PROC REGION_4 (@REG VARCHAR(255)) AS
BEGIN	
	SELECT R.RegionDescription,T.TerritoryDescription,E.FirstName+' '+E.LastName EMPNAME FROM Region R JOIN Territories T ON R.RegionID=T.RegionID JOIN EmployeeTerritories ET ON ET.TerritoryID=T.TerritoryID JOIN Employees E ON E.EmployeeID=ET.EmployeeID AND R.RegionDescription=@REG
END

EXEC REGION_4 'EASTERN'

--5. TAKE PRODUCTS TABLE WRITE A PROCEDURE WHICH CHECKS UNITSINSTOCK AND UNITSONORDER
--DISPLAY ALL PRODUCTS DETAILS (PRODUCTNAME, UNITPRICE, UNITSINSTOCK, UNITSONORDER, DIFFERENCE ) where UNITSONORDER is more then UNITSINSTOCK
--SELECT ProductName,UnitPrice,UnitsInStock,UnitsOnOrder,UnitsOnOrder-UnitsInStock DIFFERENCE FROM Products WHERE UnitsOnOrder > UnitsInStock

CREATE PROC UNITINSTOCK_GREATER_UNITONORDER AS
BEGIN
	SELECT ProductName,UnitPrice,UnitsInStock,UnitsOnOrder,UnitsOnOrder-UnitsInStock DIFFERENCE FROM Products WHERE UnitsOnOrder > UnitsInStock
END

EXEC UNITINSTOCK_GREATER_UNITONORDER

--6. ORDER DETAILS TABLE TAKE ORDERID AS PARAMETER FOR THE ORDERID PRINT PRODUCTNAME, UNITPRICE, QUANTITY, DISCOUNT, TOTAL (UNITPRICE * QUNATITY), DISCOUNTAMOUNT, FINAL PRICE I.E. TOTAL �DISCOUNT AMOUNT
CREATE PROC "PRODUCT ORDER DETAILS" (@ORDERID INT)
AS
	SELECT ProductName,
		UnitPrice=ROUND(Od.UnitPrice, 2),
		Quantity,
		Discount=CONVERT(int, Discount * 100), 
		TOTAL=OD.UnitPrice * OD.Quantity,
		DISCOUNTAMOUNT=Discount*OD.UnitPrice * OD.Quantity,
		"FINAL Price"=FORMAT(Quantity * (1 - Discount) * Od.UnitPrice, '0.00')
	FROM Products P, [Order Details] Od
	WHERE Od.ProductID = P.ProductID and Od.OrderID = @ORDERID
GO

EXEC "PRODUCT ORDER DETAILS" '10250'

--7. WRITE A PROCEDURE WHICH INSERT IN PRODUCTTABLE
--PARAMETER FOR PROCEDURE PRODUCTNAME, UNITPRICE AND CATEGORYNAME
--CHECK IF CATEGORYNAME EXIST THEN ADD PRODUCTS WITH EXISTING CATEGORYI 
--IF CATEGORYNAME DOES NOT EXIST FIRST INSERT IN CATEGORY TABLE READ CATEGORYID WHICH IS IDENTITY FIELD AND INSERT NEW INSERTED ID IN PRODUCT TABLE AS CATEGORYID

CREATE PROC "INSERT PRODUCT WITH CATEGORY" (@PNAME VARCHAR(255), @UPRICE NUMERIC(10,2), @CNAME VARCHAR(255))
AS
	DECLARE @CID INT;
	SELECT @CID=CategoryID  FROM Categories  WHERE CategoryName=@CNAME
	IF @CID IS NULL
	BEGIN
		INSERT INTO Categories(CategoryName) VALUES (@CNAME)
		SELECT @CID=CategoryID  FROM Categories  WHERE CategoryName=@CNAME
		INSERT INTO Products(PRODUCTNAME,UnitPrice,CATEGORYID) VALUES (@PNAME,@UPRICE,@CID)
	END
	ELSE
		INSERT INTO Products(PRODUCTNAME,UnitPrice,CATEGORYID) VALUES (@PNAME,@UPRICE,@CID)
GO

EXEC "INSERT PRODUCT WITH CATEGORY" 'COFFEE',20.00,'COLDDRINK'

SELECT * FROM Products

--8. ORDERS TABLE TAKE YEAR AS PARAMETER TO PROCEDURE PRINT IN EACH QUARTER HOW MANY ORDERS BOOKED,
--EXAMPLE IN Q-1 100
-- Q-2 150 �.
--IF YEAR NOT EXIST PRINT ERROR MESSAGE
SELECT DATEPART(Q,OrderDate) AS "QUARTER",COUNT(ORDERID) "ORDERS PLACED" FROM Orders WHERE YEAR(OrderDate)='1997' GROUP BY DATEPART(Q,OrderDate)
CREATE PROC "ORDER BY QUARTER" (@YEAR VARCHAR(4)) 
AS
	SELECT DATEPART(Q,OrderDate) AS "QUARTER",COUNT(ORDERID) "ORDERS PLACED" FROM Orders WHERE YEAR(OrderDate)=@YEAR GROUP BY DATEPART(Q,OrderDate)
GO
EXEC "ORDER BY QUARTER" '1997'

--9. TABLE ORDERS AND ORDER DETAILS �OUT PARAMETER TAKE YEAR AND MONTH AS PARAMETER AND RETURN
--TOTAL REVENUE GENERATED SUM(UNITPRICE * QTY � DISCOUNT)
CREATE PROC "TOTAL REVENUE BY MONTH AND YEAR" (@YEAR VARCHAR(4), @MONTH VARCHAR(2), @TOTAL_REVENUE NUMERIC(14,2) OUT)
AS
	SELECT @TOTAL_REVENUE=ROUND(SUM(CONVERT(NUMERIC(14,2), OD.Quantity * (1-OD.Discount) * OD.UnitPrice)), 2) FROM Orders O JOIN [Order Details] OD ON O.OrderID=OD.OrderID AND YEAR(O.ORDERDATE)=@YEAR AND MONTH(O.ORDERDATE)=@MONTH
GO

DECLARE @TOTAL_REVENUE NUMERIC(14,2)
EXEC "TOTAL REVENUE BY MONTH AND YEAR" '1997','5',@TOTAL_REVENUE OUT
PRINT 'TOTAL REVENUE: '+CONVERT(VARCHAR(20),@TOTAL_REVENUE)


--10. FOR EACH EMPLOYEE PRINT EMPLOYEE FULL NAME, BIRTHDATE, HIREDATE, AGE (IN YEARS) AT THE TIME OF HIRING, RETIREMENT DATE. (60 YEARS)
CREATE PROC "EMP RETIREMENT DATE" 
AS
	SELECT FirstName+' '+LastName "EMPLOYEE FULL NAME", BirthDate,HireDate,DATEDIFF(YY,BIRTHDATE,HIREDATE) "AGE(IN YEARS)",DATEADD(YY,60,BIRTHDATE) "RETIREMENT DATE"  FROM Employees
GO

EXEC "EMP RETIREMENT DATE"