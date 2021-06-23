CREATE TABLE DEPT
       (DEPTNO int not null constraint DEPT_deptno_pk1 primary key,
        DNAME VARCHAR(14) CONSTRAINT DEPT_Dname_UNQ UNIQUE,
        LOC VARCHAR(13) )

INSERT INTO DEPT VALUES (10, 'ACCOUNTING', 'NEW YORK');
INSERT INTO DEPT VALUES (20, 'RESEARCH',   'NEW YORK');
INSERT INTO DEPT VALUES (30, 'SALES',      'BOSTON');
INSERT INTO DEPT VALUES (40, 'OPERATIONS', 'BOSTON');


CREATE TABLE EMP
       (EMPNO int NOT NULL CONSTRAINT EMP_EMPNO_PK PRIMARY KEY,
        ENAME VARCHAR(30),
        JOB VARCHAR(9),
        MGR int CONSTRAINT EMP_MGR_SK REFERENCES EMP(EMPNO),
        HIREDATE DATETIME,
        SAL NUmeric(7, 2),
        COMM Numeric(7, 2),
        DEPTNO int CONSTRAINT EMP_DEPTNO_FK REFERENCES DEPT(DEPTNO))

INSERT INTO EMP VALUES
        (7839, 'KING',   'PRESIDENT', NULL, '11/17/1981' , 5000, NULL, null)
INSERT INTO EMP VALUES
        (7566, 'JONES',  'MANAGER',   7839, '04/2/1981',  2975, NULL, 20)
INSERT INTO EMP VALUES
        (7698, 'BLAKE',  'MANAGER',   7839,'05/01/1985',  2975, NULL, 30)
INSERT INTO EMP VALUES
        (7782, 'CLARK',  'MANAGER',   7839, '06/09/1985',  2450, NULL, 10)
INSERT INTO EMP VALUES
        (7999, 'JOHN_MILLER', 'MANAGER',  7839, '01/01/2011' , 4000, NULL, 10)
INSERT INTO EMP VALUES
        (7788, 'SCOTT',  'ANALYST',   7566, '12/09/1982' , 3000, NULL, 20)
INSERT INTO EMP VALUES
        (7902, 'FORD',   'ANALYST',   7566, '12/03/1981' ,  3000, NULL, 20)
INSERT INTO EMP VALUES
        (7499, 'ALLEN',  'SALESMAN',  7698,'02/20/1985', 1600,  300, 30)
INSERT INTO EMP VALUES
        (7521, 'WARD',   'SALESMAN',  7698, '02/22/1981', 1250,  500, 30)
INSERT INTO EMP VALUES
        (7654, 'MARTIN', 'SALESMAN',  7698, '09/28/1991', 1250, 1400, 30)
INSERT INTO EMP VALUES
        (7844, 'TURNER', 'SALESMAN',  7698, '09/08/1985' ,  1500,    0, 30)
INSERT INTO EMP VALUES
        (7900, 'JAMES',  'CLERK',     7698, '12/03/1981' ,   950, NULL, 30)
INSERT INTO EMP VALUES
        (7369, 'SMITH',  'CLERK',     7902, '12/17/1980', 800, NULL, 20)
INSERT INTO EMP VALUES
        (7876, 'ADAMS',  'CLERK',     7788, ' 01/12/2003', 1100, NULL, 20)
INSERT INTO EMP VALUES
        (7934, 'MILLER', 'CLERK',     7782, '01/23/2003' , 1300, NULL, 10)

SELECT * FROM DEPT;
SELECT * FROM EMP;

--pROJECT OF SOME COLUMNS AND ALIAS
SELECT  EMPNO, ENAME AS [EMP_NAME], JOB, SAL AS SALARY FROM EMP

--FILTER -> WHERE CLAUSE


--1	LIST ALL EMPS WHO ARE WORKING IN DEPT 20 AND EARNING MORE THEN 2500
SELECT * FROM EMP WHERE DEPTNO =20 AND SAL > 2500

--2	LIST ALL EMPS WHOSE JOB IS EITHER MANAGER OR CLERK OR ANALYST
SELECT * FROM EMP WHERE JOB IN ('MANAGER','CLERK','ANALYST')

--3	LIST ALL EMPS WHO ARE WORKING AS CLERK IN DPET 10 OR MANAGER FORM DEPT 30
SELECT * FROM EMP WHERE (JOB='CLERK' AND DEPTNO=10) OR (JOB='MANAGER' AND DEPTNO=30)

--4	LIST ALL EMPS WHOSE SALARY IN RANGE OF 3000 TO 5000
SELECT * FROM EMP WHERE SAL BETWEEN 3000 AND 5000

--5	Find the employees whose commission is greater than 50 percent of his salary. 
SELECT * FROM EMP WHERE COMM > 0.5*SAL

--6	LIST ALL EMPS WHOSE COMM IS NOT NULL (means who are earning commission)
SELECT * FROM EMP WHERE COMM IS NOT NULL AND COMM !=0

--LIST ALL EMP WHOSE NAME START WITH 'J'
SELECT * FROM EMP WHERE ENAME LIKE 'J%'

--LIST ALL EMP WHOSE NAME CONTAINS 'A' AT SECOND POSITION
SELECT * FROM EMP WHERE ENAME LIKE '_A%'

--1	LIST ALL EMPS WHOSE NAME ENDS WITH N
SELECT * FROM EMP WHERE ENAME LIKE '%N'

--2	LIST ALL EMP WHOSE NAME CONTAINS I
SELECT * FROM EMP WHERE ENAME LIKE '%I%'

--3	LIST ALL EMP WHOSE NAME START WITH A OR M OR S
SELECT * FROM EMP WHERE ENAME LIKE '[AMS]%'

--4	LIST ALL EMP WHOSE NAME START WITH A...M  (A,B,C,...M)
SELECT * FROM EMP WHERE ENAME LIKE '[A-M]%'

--5	LIST ALL EMP WHOSE NAME DOES NOT START WITH J OR W
SELECT * FROM EMP WHERE ENAME LIKE '[^JM]%'

--6	list all emp whose name contains vowel o or u or e, either at 2 position or at second last position
SELECT * FROM EMP WHERE ENAME LIKE '_[OUE]%' OR ENAME LIKE '%[OUE]_'

--7	LIST ALL EMP WHOSE NAME CONTAINS _   (ANS IS JOHN_MILLER)
SELECT * FROM EMP WHERE ENAME LIKE '%[_]%'

-----------------------------------------SORTING------------------
--LIST ALL EMP AS PER THE JOB
SELECT  * FROM EMP ORDER BY JOB

--LIST ALL EMP AS PER THE HIREDATE, OLDEST EMP FIRST
SELECT  * FROM EMP ORDER BY HIREDATE

--LIST ALL EMP AS PER DEPTNO, WITHIN DEPTNO SORT ON SAL HIGH TO LOW
SELECT * FROM EMP ORDER BY DEPTNO, SAL DESC

--LIST ALL EMP ORDER BY NAME, JOB, SAL, COMM
SELECT * FROM EMP ORDER BY ENAME,JOB,SAL,COMM

--ADD A COLUMN NAME AS NETSAL (SAL+COMM) AND ORDER H TO L
SELECT ENAME, JOB, SAL, COMM, ISNULL(SAL,0)+ ISNULL(COMM,0) AS NETSAL FROM EMP ORDER BY ENAME,JOB, SAL,COMM, NETSAL DESC

--SORT NETSAL(SAL+COMM) WHERE NETSAL>2500
SELECT ENAME, JOB, SAL, COMM, ISNULL(SAL,0)+ ISNULL(COMM,0) AS NETSAL FROM EMP WHERE ISNULL(SAL,0)+ ISNULL(COMM,0) > 2500 ORDER BY NETSAL DESC 

--------------------------------------------AGGREGATE FUNCTION------------------------
--MIN(), MAX(), AVG(), COUNT(), SUM()
SELECT COUNT(EMPNO),MIN(COMM) AS MIN_COMM, MIN(HIREDATE) AS MIN_HIRE,MAX(COMM) AS MAX_COMM, MAX(HIREDATE) AS MAX_HIRE FROM EMP

--AGGREGATE FUNCTION WITH GROUP BY CLAUSE (GROUP LEVEL SUMMERY)

--PRINT DEPT WISE TOTAL SAL
SELECT DEPTNO,SUM(SAL) FROM EMP GROUP BY DEPTNO

--LIST JOBWISE EMP COUNT
SELECT JOB,COUNT(EMPNO) FROM EMP GROUP BY JOB

--FOR EACH DEPT PRINT HIGHEST AND LOWEST SAL
SELECT DEPTNO,MAX(SAL) AS MAX_SAL,MIN(SAL) AS MIN_SAL FROM EMP GROUP BY DEPTNO

--LIST DEPTWISE, JOBWISE EMP COUNT
SELECT DEPTNO, JOB, COUNT(EMPNO) FROM EMP GROUP BY DEPTNO,JOB ORDER BY DEPTNO, JOB

------------------------------------HAVING CLUASE TO FILTER OUT RESULT OF GROUP BY QUERY
--DEPTWISE EMP COUNT AND LIST ONLY DEPT AND COUNT WHERE EMPCOUNT>4
SELECT DEPTNO,COUNT(EMPNO) AS EMP_COUNT FROM EMP GROUP BY DEPTNO HAVING  COUNT(EMPNO)>4 

-------------------------------------DISTINCT (UNIQUE VALUE) TO LIST DIFFERENT -------------
SELECT DISTINCT JOB FROM EMP

-----------------------------------TOP N CLAUSE----------------
--LIST TOP 3 HIGHEST PAID EMPLOYEE
SELECT TOP 3 * FROM EMP ORDER BY SAL DESC


----------------------------------------DATE FUNCTION------------------------
--MM/DD/YYYY
--extract 


SELECT GETDATE(), DATEPART(MM,GETDATE()), DATENAME(MM,GETDATE())

SELECT GETDATE(), DATEPART(DD,GETDATE()) AS "DAY OF MONTH"
SELECT GETDATE(), DATEPART(MM,GETDATE()), DATENAME(MM,GETDATE())
SELECT GETDATE(), DATEPART(YY,GETDATE())AS YEAR
SELECT GETDATE(), DATEPART(YYYY,GETDATE())AS YEAR

SELECT GETDATE(), DATEPART(HH,GETDATE())AS HOUR
SELECT GETDATE(), DATEPART(MI,GETDATE())AS MINUTE
SELECT GETDATE(), DATEPART(SS,GETDATE())AS SECOND

SELECT GETDATE(), DATEPART(DW,GETDATE())AS DAY_OF_WEEK, DATENAME(DW,GETDATE())
SELECT GETDATE(), DATEPART(WW,GETDATE())AS WEEK_OF_YEAR
SELECT GETDATE(), DATEPART(DAYOFYEAR,GETDATE())AS DAY_OF_YEAR
SELECT GETDATE(), DATEPART(Q,GETDATE())AS Q --QUARTER OF YEAR


SELECT DAY(GETDATE()), MONTH(GETDATE()), YEAR(GETDATE())

------------------------------DATEADD /DATEDIFF

SELECT DATEADD(MM,6,GETDATE()) --DATE AFTER 6 MONTH

SELECT DATEADD(DD,15,GETDATE()) --DATE AFTER 15 DAYS

SELECT DATEADD(MM,6,'06/01/2021') --DATE AFTER 6 MONTHS FROM A PARTICULAR DATE

SELECT DATEADD(MM,-5,GETDATE()) --DATE BEFORE 5 MONTHS

SELECT DATEDIFF(DD,'06/01/2021',GETDATE()) --DIFFERENCE BETWEEN 2 DATES IN FORM OF DAYS

SELECT DATEDIFF(MM,'06/01/2021',GETDATE()) ----DIFFERENCE BETWEEN 2 DATES IN FORM OF MONTHS

--CONVERTING DATE FORMAT
SELECT GETDATE(), CONVERT(VARCHAR,GETDATE(),1), CONVERT(VARCHAR,GETDATE(),5), CONVERT(VARCHAR,GETDATE(),100)

--GLOBALIZATION
--FORMAT() FUNCTION

--DATATYPE= DATE(D/d)  NUMBER(N) CURRENCY(C)
SELECT FORMAT ( GETDATE(),'d','en_US') AS 'US ENGLISH RESULT',
	FORMAT ( GETDATE(),'d','en_GB') AS 'GREAT BRITAIN',
	FORMAT ( GETDATE(),'d','de-de') AS 'DUTCH GERMAN RESULT',
	FORMAT ( GETDATE(),'d','ZH-ZH') AS 'CHINESE RESULT',
	FORMAT ( GETDATE(),'d','HI-IN') AS 'HINDI INDIAN RESULT'

SELECT FORMAT ( GETDATE(),'D','en_US') AS 'US ENGLISH RESULT',
	FORMAT ( GETDATE(),'D','en_GB') AS 'GREAT BRITAIN',
	FORMAT ( GETDATE(),'D','de-de') AS 'DUTCH GERMAN RESULT',
	FORMAT ( GETDATE(),'D','ZH-ZH') AS 'CHINESE RESULT',
	FORMAT ( GETDATE(),'D','HI-IN') AS 'HINDI INDIAN RESULT'

SELECT FORMAT(456684944,'N','EN_US') AS 'US', FORMAT(456684944,'N','HI_IN') AS 'INDIA'

SELECT FORMAT(456684944,'C','EN_US') AS 'US', FORMAT(456684944,'C','HI_IN') AS 'INDIA'


----------------------------NUMBER / MATHEMATICAL FUNCTIONS-----------------------
SELECT ABS(-10)
SELECT CEILING(120.5)
SELECT FLOOR(120.5)
SELECT ROUND(1234.566666,2)
SELECT FORMAT(1234.5678,'0.00'), FORMAT(1234.5678,'0')
SELECT ROUND(1267.456,0)
SELECT POWER(5,3)
SELECT PI()


---------------------------------------STRING FUNCTIONS-------------------------------
DECLARE @NAME CHAR(20)
SET @NAME='HIMANSHU'
SELECT DATALENGTH(@NAME) AS MEMORY_BYTES, LEN(@NAME) AS STRING_LENGTH

SELECT LTRIM('		FADU		') + 'TO SQL'

SELECT CONCAT('HIMANSHU ','GUPTA ', 'iiit')

SELECT LEFT('WELCOME',3) 
SELECT RIGHT('WELCOME',3)

SELECT SUBSTRING('WELCOME',2,4) 
SELECT SUBSTRING('WELCOME',4,1) 

SELECT REVERSE('HELLO')

SELECT REPLICATE('HIM',12)

---ASCII OF CHAR
SELECT ASCII('A'), CHAR(65)
SELECT ASCII('Z'), CHAR(90)
SELECT ASCII('a'), CHAR(97)
SELECT ASCII('z'), CHAR(122)

SELECT UPPER('himsisJ'), LOWER('HIMAnshu')



-------------------------CASE OPERATOR ->  CONDITIONAL SEARCH -------------------------

SELECT ENAME,COMM,
CASE 
	WHEN COMM =0 THEN 'EARNING ZERO COMMISSION'
	WHEN COMM IS NULL THEN 'NOT EARNING COMMISSION'
	ELSE 'EARNING COMMISSION'
END AS SUMMERY
FROM EMP
ORDER BY COMM DESC

--IF COMM IS NULL SET TO 0
SELECT ENAME,
CASE 
	WHEN COMM IS NULL THEN '0.00'
	ELSE COMM
END
FROM EMP
ORDER BY COMM DESC


--ROW FUNCTION
--RANK FUNCTION
--DENSE RANK FUNCTION
--PARTITION BY

SELECT ROW_NUMBER() OVER (ORDER BY SAL DESC) AS SRNO,
	Rank() OVER (ORDER BY SAL DESC) AS RANK_SAL,
	DENSE_RANK() OVER (ORDER BY SAL DESC) AS DENSE_RANK_SAL,
	* FROM EMP

SELECT  ROW_NUMBER() OVER(PARTITION BY YEAR(HIREDATE) ORDER BY YEAR(HIREDATE) DESC) AS 'SRNO_YEAR',* FROM EMP 
	

--CREATE INDEX IDX_ENAME ON EMP(ENAME)
--DROP INDEX IDX_ENAME ON EMP 

SELECT * FROM EMP


-------------------------------------ADVANCE QUERY-------------------
----------------SUB QUERY
--LIST ALL EMP WHO ARE WORKING IN SAME DEPT OF MARTIN
SELECT * FROM EMP WHERE DEPTNO=(SELECT DEPTNO FROM EMP WHERE ENAME='MARTIN')

--LIST ALL EMP WHO ARE WORKING IN DEPT OF LOCATION 'BOSTON'
SELECT * FROM EMP WHERE DEPTNO IN (SELECT DEPTNO FROM DEPT WHERE LOC='BOSTON' )


----------------------------------------CLASS ASSIGNMENT------------------------------------
--1		list all emp whose designation is same as BLAKE
SELECT * FROM EMP WHERE JOB=(SELECT JOB FROM EMP WHERE ENAME='BLAKE')


--2		list all emp who are earning more then the average salary of the organization
SELECT * FROM EMP WHERE SAL>(SELECT AVG(SAL) FROM EMP)


--3		list full detail (all column of emp table) of highest paid employee (without using Top n)
SELECT * FROM EMP WHERE SAL IN (SELECT MAX(SAL) FROM EMP)

--4		list all emp whose sal is more then Allen and working
--in same deparment with Scott and 
--hireed in same year of Jones
SELECT * FROM EMP WHERE SAL>(SELECT SAL FROM EMP WHERE ENAME='ALLEN') 
	AND DEPTNO IN (SELECT DEPTNO FROM EMP WHERE ENAME='SCOTT') 
	AND YEAR(HIREDATE) IN (SELECT YEAR(HIREDATE) FROM EMP WHERE ENAME='JONES')


--5		list all emp whose manager is king
SELECT * FROM EMP WHERE MGR IN (SELECT EMPNO FROM EMP WHERE ENAME='KING')

--6		LIST ALL EMP WHOSE MANAGER'S MANGER IS KING
SELECT * FROM EMP WHERE MGR IN (SELECT EMPNO FROM EMP WHERE MGR IN (SELECT EMPNO FROM EMP WHERE ENAME='KING'))

--7		list all emp who are working in research department
SELECT * FROM EMP WHERE DEPTNO IN (SELECT DEPTNO FROM DEPT WHERE DNAME='RESEARCH')

--8		list all emp who are working in NEW YORK
SELECT * FROM EMP WHERE DEPTNO IN (SELECT DEPTNO FROM DEPT WHERE LOC='NEW YORK')

--9		print department name where all emps are earning commission
SELECT DNAME FROM DEPT WHERE DEPTNO IN (SELECT DEPTNO FROM EMP WHERE COMM IS NOT NULL)

--10		LIST ALL EMP WHO ARE WORKING IN BOSTON AND EARNING MORE THEN THE AVERAGE OF DEPT LOCATED IN BOSTON
SELECT * FROM EMP WHERE DEPTNO IN (SELECT DEPTNO FROM DEPT WHERE LOC='BOSTON') AND SAL > (SELECT AVG(SAL) FROM EMP WHERE DEPTNO IN (SELECT DEPTNO FROM DEPT WHERE LOC='BOSTON'))



----------JOINS
--INNER JOIN
SELECT E.ENAME, E.JOB, D.DNAME FROM EMP E JOIN DEPT D ON E.DEPTNO=D.DEPTNO

--LEFT JOIN
SELECT E.ENAME, E.JOB, D.DNAME FROM EMP E LEFT JOIN DEPT D ON E.DEPTNO=D.DEPTNO

--RIGHT JOIN
SELECT E.ENAME, E.JOB, D.DNAME FROM EMP E RIGHT JOIN DEPT D ON E.DEPTNO=D.DEPTNO

--FULL JOIN
SELECT E.ENAME, E.JOB, D.DNAME FROM EMP E FULL JOIN DEPT D ON E.DEPTNO=D.DEPTNO 

--PRINT DEPTNAME AND EMP COUNT FOR EACH DEPT
SELECT D.DNAME,COUNT(E.EMPNO) EMP_COUNT FROM EMP E JOIN DEPT D ON E.DEPTNO=D.DEPTNO GROUP BY D.DNAME

SELECT D.DNAME,COUNT(E.EMPNO) EMP_COUNT FROM EMP E RIGHT JOIN DEPT D ON E.DEPTNO=D.DEPTNO GROUP BY D.DNAME


--LIST PROD_NAME, PRICE AND CAT_NAME
SELECT  P.PROD_NAME, P.PRICE, C.CAT_NAME FROM PRODUCT P JOIN CATEGORY C ON P.CAT_ID=C.CAT_ID

--LIST EMPNAME, JOB, SAL, DEPTNAME, LOC OF LOWEST PAID EMP (DO NOT USE TOP N)
SELECT E.ENAME, E.JOB, E.SAL, D.DNAME, D.LOC FROM EMP E JOIN DEPT D ON D.DEPTNO=E.DEPTNO AND E.SAL IN (SELECT MIN(SAL) FROM EMP)

--SELF JOIN
SELECT E1.ENAME,E1.JOB,E1.SAL,E2.ENAME MGR_NAME FROM EMP E1 LEFT JOIN EMP E2 ON E1.MGR=E2.EMPNO

--LIST ENAME, JOB, SAL, DNAME, MGRNAME, LOC FOR ALL EMP
SELECT E1.ENAME,E1.JOB,E1.SAL,D.DNAME,E2.ENAME MGR_NAME,D.LOC FROM EMP E1 LEFT JOIN EMP E2 ON E1.MGR=E2.EMPNO LEFT JOIN DEPT D ON E1.DEPTNO=D.DEPTNO

SELECT P1.PROGNAME,P2.PROGNAME FROM PROGRAM P1 LEFT JOIN PROGRAM P2 ON P1.OS=P2.PROGID 




-----------------------------PROGRAMMING IN SQL----------------------------

--STORED PROCEDURE

--FUNCTION

--TRIGGER


PRINT('HELLO  '+ CONVERT(VARCHAR,100))
PRINT('HELLO  '+ CAST(100 AS VARCHAR))

PRINT 'TODAY''S DATE: ' + CONVERT(VARCHAR,GETDATE())

--VARIABLES
	--GLOBAL(SYSTEM) -- @@VARNAME
	--LOCAL --@VARNAME

PRINT @@VERSION
PRINT @@LANGUAGE
PRINT @@IDENTITY


--TAKE NAME FROM USER AND GREET
DECLARE @NAME VARCHAR(100)
SELECT @NAME=ENAME FROM EMP WHERE EMPNO=7900
PRINT 'HELLO '+@NAME
GO


-----IF STATEMENT
--CHECK IF A NUMBER IS EVEN OR ODD
DECLARE @SAL NUMERIC(3)
SET @SAL=101
IF @SAL%2 = 0
BEGIN
	PRINT CAST(@SAL AS VARCHAR) +'IS A EVEN SALARY'
END
ELSE
BEGIN
	PRINT CAST(@SAL AS VARCHAR) +'IS AODD SALARY'
END

--TAKE EMPNO AND PRINT EMPNAME, JOB AND SAL
--IF EMP NOT FOUND PRINT MSG EMPNO NOT VALID
DECLARE @EMPNO INT,@NAME VARCHAR(100), @JOB VARCHAR(10), @SAL NUmeric(7, 2)
SET @EMPNO=7900
SELECT @NAME=ENAME, @JOB=JOB, @SAL=SAL FROM EMP WHERE EMPNO=@EMPNO
IF @NAME IS NULL AND @JOB IS NULL AND @SAL IS NULL
BEGIN
	PRINT 'EMPNO NOT VALID'
END
ELSE
BEGIN 
	PRINT 'NAME: '+@NAME+', JOB: '+ @JOB+', SALARY: '+ CAST(@SAL AS VARCHAR)
END

DECLARE @EMPNO INT,@NAME VARCHAR(100), @JOB VARCHAR(10), @SAL NUmeric(7, 2)
SET @EMPNO=7900
IF @EMPNO IN (SELECT EMPNO FROM EMP)
BEGIN
	SELECT @NAME=ENAME, @JOB=JOB, @SAL=SAL FROM EMP WHERE EMPNO=@EMPNO
	PRINT 'NAME: '+@NAME+', JOB: '+ @JOB+', SALARY: '+ CAST(@SAL AS VARCHAR)
END
ELSE
BEGIN
	PRINT 'EMPNO NOT VALID'
END


---------------------WHILE LOOP
DECLARE @NUM INT=1
WHILE @NUM < 5
BEGIN
	PRINT @NUM
	SET @NUM=@NUM+1
END


------------TRY CATCH
SELECT 1/01

BEGIN TRY
	SELECT 1/0
END TRY
BEGIN CATCH
	PRINT 'ERROR'

	--EXECUTE THE ERROR RETRIEVAL STATEMENT
	SELECT
		ERROR_NUMBER() AS ERRORNUMBER,
		ERROR_SEVERITY() AS ErrorSeverity,
		ERROR_STATE() AS ErrorState,
		ERROR_PROCEDURE() AS ErrorProcedure,
		ERROR_LINE() AS ErrorLine,
		ERROR_MESSAGE() AS ErrorMsg
		RAISERROR( 'NUMBER CAN NOT DIVIDE BY ZERO',16,1)
		--RAISERROR( ERROR_MESSAGE(),16,1)
		--THROW 
END CATCH


------------STORED PROCEDURE
	--MAY OR MAY NOT RETURN VALUE.
	--USE FOR DML operations
	--HANDLE ERRORS
	--NEED TO CALL A PROCEDURE WITH EXECUTION
	--FASTER EXEC

--EXAMPLE: CHECK ODD EVEN NUM
--DROP PROCEDURE IF EXIST
DROP PROCEDURE OddEven

--CREATING A NEW PROCEDURE
CREATE PROCEDURE OddEven (@NUM INT) AS
BEGIN
	IF @NUM%2 = 0
	BEGIN
		PRINT CAST(@NUM AS VARCHAR) +' IS A EVEN NUMBER'
	END
	ELSE
	BEGIN
		PRINT CAST(@NUM AS VARCHAR) +' IS A ODD NUMBER'
	END
END

--TO CALL A PROCEDURE
EXEC OddEven 55
EXEC OddEven 100

--WRITE A PROC WHICH DISPAY ALL EMP DATA
CREATE PROC DISPLAY_EMP AS
	SELECT * FROM EMP

EXEC DISPLAY_EMP


--WRITE A PROC WHICH TAKE EMPNO AS A PARA AND PRINT EMP RECORD AS BELOW
--EMPLOYEENAME IS WORKING AS JOB IN DEPT DEPTNO
ALTER PROC DIS_EMP(@NUM INT) AS
BEGIN
	
	DECLARE @NAME VARCHAR(100), @JOB VARCHAR(10), @DEPT NUmeric(3)
	IF @NUM IN (SELECT EMPNO FROM EMP)
	BEGIN
		SELECT @NAME=ENAME, @JOB=JOB, @DEPT=DEPTNO FROM EMP WHERE EMPNO=@NUM
		PRINT +@NAME+' IS WORKING AS '+ @JOB+' IN DEPT '+ CAST(@DEPT AS VARCHAR)
	END
	ELSE
	BEGIN
		PRINT 'EMPNO IS NOT VALID'
	END
END

EXEC DIS_EMP 790

ALTER PROC DIS_EMP2(@NUM INT) AS
BEGIN
	
	DECLARE @NAME VARCHAR(100), @JOB VARCHAR(10), @DEPT NUmeric(3)
	SELECT @NAME=ENAME, @JOB=JOB, @DEPT=DEPTNO FROM EMP WHERE EMPNO=@NUM
	IF @NAME IS NULL AND @JOB IS NULL AND @DEPT IS NULL
	BEGIN
		PRINT 'EMPNO IS NOT VALID'
		
	END
	ELSE
	BEGIN
		PRINT +@NAME+' IS WORKING AS '+ @JOB+' IN DEPT '+ CAST(@DEPT AS VARCHAR)
	END
END

EXEC DIS_EMP2 7900


/*
--TAKE MGRNO AS PARAMETER
--PRINT MESSAGE AS BELOW

TOTAL EMPLOYEE WORKING UNDER _____MGRNAME__________ = 4

IF NOT FOUND PRINT HE IS NOT A MANAGER

*/
ALTER PROC MGR_COUNT(@MGRNO INT) AS
BEGIN
	DECLARE @COUNT INT
	SELECT * FROM EMP WHERE MGR=@MGRNO
	SET @COUNT=@@ROWCOUNT
	IF(@COUNT=0)
	BEGIN
		RAISERROR('HE IS NOT A MANAGER',16,1)
	END
	ELSE
	BEGIN
		DECLARE @MGR_NAME VARCHAR(20)
		SELECT @MGR_NAME=ENAME FROM EMP WHERE EMPNO=@MGRNO
		PRINT 'TOTAL EMPLOYEE WORKING UNDER '+ @MGR_NAME+' = '+CAST(@COUNT AS VARCHAR)
	END
END

EXEC MGR_COUNT 7839

EXEC MGR_COUNT 7900

SELECT * FROM EMP

--METHOD 2 USING CURSOR
CREATE PROC MGR_EMP_COUNT(@MGRNO INT) AS
BEGIN
	DECLARE @COUNT INT, @EMPNAME VARCHAR(20), @EMPCOUNT INT, @MGRNAME VARCHAR(20), @ROWCOUNT INT
	
	SELECT @MGRNAME=ENAME FROM EMP WHERE EMPNO=@MGRNO
	SET @ROWCOUNT=@@ROWCOUNT
	IF(@ROWCOUNT>0)
	BEGIN
		SELECT @EMPCOUNT=COUNT(EMPNO) FROM EMP WHERE MGR=@MGRNO

		IF @EMPCOUNT=0
		BEGIN
			PRINT('NO EMPLOYEE IS REPORTING TO '+@MGRNAME)
		END
		ELSE
		BEGIN
			PRINT 'TOTAL EMPLOYEE WORKING UNDER '+ @MGRNAME+' = '+CAST(@EMPCOUNT AS VARCHAR)
			
			DECLARE MGR_CURSOR CURSOR FOR SELECT E.ENAME FROM EMP E JOIN EMP M 
				ON E.MGR=M.EMPNO AND M.EMPNO=@MGRNO
			OPEN MGR_CURSOR

			FETCH NEXT FROM MGR_CURSOR INTO @EMPNAME

			WHILE @@FETCH_STATUS=0
			BEGIN 
				PRINT 'EMPNAME: '+@EMPNAME
				FETCH NEXT FROM MGR_CURSOR INTO @EMPNAME
			END
			CLOSE MGR_CURSOR
			DEALLOCATE MGR_CURSOR

		END
	END
	ELSE
	BEGIN
		RAISERROR('EMPOYEE NOT FOUND',16,1)
	END
END

EXEC MGR_EMP_COUNT 7839
EXEC MGR_EMP_COUNT 7900
EXEC MGR_EMP_COUNT 7

--PROC WITH IN AND OUT PARAMETER
--IN = INPUT PARAMETER 
--OUT = RETURN VALUE BY PROC IN OUT PARAMETER

--TAKE DEPTNO AS IN PARA AND FOR THAT DEPT RETURN MINSAL, MAXSAL, AND EMCOUNT AS OUT PARA
CREATE PROC OUT_PARA (@DNO INT, @MINSAL NUMERIC(10,2) OUT, @MAXSAL NUMERIC(10,2) OUT, @COUNT INT OUT) AS
BEGIN 
	SELECT @MINSAL=MIN(SAL), @MAXSAL=MAX(SAL), @COUNT=COUNT(EMPNO) FROM EMP WHERE DEPTNO=@DNO
END

DECLARE @MINSAL NUMERIC(10,2), @MAXSAL NUMERIC(10,2), @COUNT INT
EXEC OUT_PARA 10, @MINSAL OUT, @MAXSAL OUT, @COUNT OUT

PRINT 'MINSAL = '+CAST(@MINSAL AS VARCHAR)+CHAR(10) + 'MAXSAL = '+CAST(@MAXSAL AS VARCHAR)+CHAR(13)+ 'EMP COUNT= '+CAST(@COUNT AS VARCHAR)


--TAKE DEPTNAME AS IN PARA AND FOR THAT DEPT RETURN MINSAL, MAXSAL, AND EMCOUNT AS OUT PARA
CREATE PROC OUT_BY_DNAME (@DNAME VARCHAR(20), @MINSAL NUMERIC(10,2) OUT, @MAXSAL NUMERIC(10,2) OUT, @COUNT INT OUT) AS
BEGIN 
	SELECT @MINSAL=MIN(SAL), @MAXSAL=MAX(SAL), @COUNT=COUNT(EMPNO) FROM EMP WHERE DEPTNO IN (SELECT DEPTNO FROM DEPT WHERE DNAME=@DNAME)
END

DECLARE @MINSAL NUMERIC(10,2), @MAXSAL NUMERIC(10,2), @COUNT INT
EXEC OUT_BY_DNAME 'SALES', @MINSAL OUT, @MAXSAL OUT, @COUNT OUT

PRINT 'MINSAL = '+CAST(@MINSAL AS VARCHAR)+CHAR(10) + 'MAXSAL = '+CAST(@MAXSAL AS VARCHAR)+CHAR(13)+ 'EMP COUNT= '+CAST(@COUNT AS VARCHAR)


--PROC WITH DML
--INSERT PROC
--WRITE A PROC WHICH TAKES EMPNO, EMPNAME AND DEPTNO AS A PARAMETER 
--INSERT VALUE IN EMP TABLE
--IF INSERTED SUCESSFULY PASS MESSAGE  OR ERROR MESSAGE IN OUT PARAMETER
ALTER PROC INSERT_PROC(@ENO INT, @ENAME VARCHAR(20), @DNO INT, @MSG VARCHAR(20) OUT) AS 
BEGIN
	BEGIN TRY
		INSERT INTO EMP(EMPNO, ENAME, DEPTNO) VALUES(@ENO, @ENAME, @DNO)
		SET @MSG='INSERT SUCCESSFUL'
	END TRY
	BEGIN CATCH
		SET @MSG='ERROR IN INSERT'
	END CATCH
END
		
DECLARE @MSG VARCHAR(20)
EXEC INSERT_PROC 10,'HIHI',782222, @MSG OUT
PRINT @MSG
EXEC INSERT_PROC 10,'HIHI',10, @MSG OUT
PRINT @MSG


--DELETE PROC
--TAKE EMPNO FROM USER
--IF FOUND DELETE THE RECORD
--IF DELETEDSUCESSFULY PASS MESSAGE  OR ERROR MESSAGE IN OUT PARAMETER
ALTER PROC DELETE_PROC(@ENO INT, @MSG VARCHAR(20) OUT ) AS 
BEGIN
	BEGIN TRY
		DELETE FROM EMP WHERE EMPNO=@ENO
		SET @MSG='DELETE SUCCESSFUL'
	END TRY
	BEGIN CATCH
		SET @MSG='ERROR IN DELETE'
	END CATCH
	
END

DECLARE @MSG VARCHAR(20)
EXEC DELETE_PROC 101010, @MSG OUT
PRINT @MSG
EXEC DELETE_PROC 10, @MSG OUT
PRINT @MSG


--EXTRACTING DATA IN XML FORMAT
--RAW
SELECT * FROM EMP FOR XML RAW
--AUTO 
SELECT * FROM EMP FOR XML AUTO
--PATH
SELECT * FROM EMP FOR XML PATH

--AUTO MODE: 
SELECT * FROM EMP FOR XML AUTO

SELECT * FROM EMP FOR XML PATH('EMPLOYEE'),ROOT('EMPLOYEELIST')


--PERFORM AN XQUERY AGAINST THE XML AND RETURN A VALUE OF SQL TYPE. THIS METHOD --RETURNS A SCALER VALUE
CREATE PROC XML_TO_TABLE @INxml XML AS
BEGIN
	INSERT INTO EMP (EMPNO, ENAME, SAL)
	SELECT 
		RESULTS.EMPLOYEELIST.value('EMPNO[1]','INT') AS EMPNO,
		RESULTS.EMPLOYEELIST.value('EMPNAME[1]','VARCHAR(20)') AS EMPNO,
		RESULTS.EMPLOYEELIST.value('SALARY[1]','NUMERIC(10,2)') AS EMPNO
			FROM @INxml.nodes('EMPLOYEELIST/EMPLOYEE') RESULTS(EMPLOYEELIST)

	SELECT * FROM EMP
END

DECLARE @FileXML XML = '
 <EMPLOYEELIST>
   <EMPLOYEE>
     <EMPNO>1</EMPNO>	 
     <EMPNAME>BHAVANA</EMPNAME>     
     <SALARY>4000</SALARY>
   </EMPLOYEE>
   <EMPLOYEE>
     <EMPNO>2</EMPNO>
     <EMPNAME>VISHAL</EMPNAME>     
     <SALARY>3000</SALARY>
   </EMPLOYEE>  
 </EMPLOYEELIST>'

EXEC XML_TO_TABLE @FileXML;


---USING OUT PARAMETER OF XML TYPE
ALTER PROC TABLE_TO_XML (@OUT_XML XML OUT) AS
BEGIN
	SET @OUT_XML=(SELECT * FROM EMP 
	FOR XML PATH('EMPLOYEE'),ROOT('EMPLOYEELIST'))

END

DECLARE @OUT_XML XML
EXEC TABLE_TO_XML @OUT_XML OUT
SELECT @OUT_XML







-----------------------FUNCTIONS------
	--ALWAYS RETURN TYPE
	--CAN NOT PERFORM DML
	--NOT ALLOWED TO HANDLE ERROR INSIDE FUNCTION
	--FUCNTION IS CALLED IN SELECT STATEMENT
	--TWO TYPES OF FUNCTION
		--SCALAR
		--TABLE VALUES

--SCALAR FUNCTION 
	--SCALAR FUNCTION MAY OR MAY NOT HAVE PARAMETER, BUT ALWAYS RETURNS A SINGLE(SCALAR) VALUE
	--THE RETURNED VALUE CAN BE OF ANY DATA TYPE, EXCEPT TEXT, IMAGE, CURSOR, AND TIMESTAMP

CREATE FUNCTION CUBES(@NUM INT) RETURNS INT AS
BEGIN
	RETURN @NUM*@NUM*@NUM
END

SELECT DBO.CUBES(5) AS CUBE

SELECT * FROM EMP

--TABLE VALUES FUNCTION
--INLINE FUNCTION
CREATE FUNCTION EMP_NETSAL (@ENO INT) RETURNS TABLE
AS
RETURN
 	(SELECT ISNULL(SAL,0)+ISNULL(COMM,0)  AS NETSAL FROM EMP
	WHERE EMPNO=@ENO)

SELECT * FROM DBO.EMP_NETSAL(7499)
--SELECT * FROM DBO.EMP_NETSAL()

--MULTI LINE FUNCTION
--USING TABLE VARIABLE
CREATE FUNCTION EMP_DETAILS (@ENAME VARCHAR(20)) 
RETURNS @OUTPUT TABLE
( EMPNAME VARCHAR(20),
	SALARY NUMERIC(10,2),
	COMMISION NUMERIC(10,2),
	NETSAL NUMERIC(10,2)
)
AS
BEGIN
	INSERT INTO @OUTPUT SELECT ENAME, SAL,COMM, (ISNULL(SAL,0)+ISNULL(COMM,0)) FROM EMP WHERE ENAME=@ENAME
	RETURN
END

SELECT * FROM EMP_DETAILS('BHAVANA')


----------------------TRANSACTION

CREATE TABLE HDFC(
	H_ACCNO VARCHAR(10) PRIMARY KEY,
	H_BALANCE NUMERIC(10,2)
)

INSERT INTO HDFC VALUES('H101',1000)

DROP TABLE SBI
CREATE TABLE SBI(
	S_ACCNO VARCHAR(10) PRIMARY KEY,
	S_BALANCE NUMERIC(10,2)
)

INSERT INTO SBI VALUES('S123',50000)

SELECT * FROM HDFC
SELECT * FROM SBI

--WRITE A FUNCTION WHICH TAKES ACCNO AND AMOUNT AS PARA
--CHECK IF GIVEN ACCOUNT AFTER DEDUCTING AMOUNT BALANCE SHOULD BE > =0
--IF SUCCESSED RETURN 0 ELSE 1

CREATE PROC  VERIFY_ACCNO(@ACCNO VARCHAR(10),@MSG CHAR(1) OUT)
AS
BEGIN
	DECLARE @ACC VARCHAR(10)
	SELECT @ACC = S_ACCNO FROM SBI WHERE S_ACCNO=@ACCNO;
	IF @@ROWCOUNT=1
		SET @MSG='Y'
	ELSE
		SET @MSG='N'
END

DECLARE @MSG CHAR(1)
EXEC VERIFY_ACCNO 'S123',@MSG OUT
PRINT @MSG

CREATE FUNCTION CHECK_BALANCE(@FROM_ACC VARCHAR(10), @AMNT NUMERIC(10,2))
RETURNS NUMERIC(10,2) AS
BEGIN
	DECLARE @BAL NUMERIC(10,2)=-1
	SELECT @BAL=(S_BALANCE-@AMNT) FROM SBI WHERE S_ACCNO=@FROM_ACC
	RETURN @BAL
END;

SELECT DBO.CHECK_BALANCE('S123',100000)

CREATE PROC TRANSFER_MONEY(@FROMACC VARCHAR(20), @TOACC VARCHAR(20), @AMNT NUMERIC(10,2)) AS
BEGIN
	DECLARE @BAL NUMERIC(10,2)=-1, @TRANSBI INT=0, @TRANHDFC INT=0, @VALID CHAR(1)

	--IS MY SBI ACCOUNT IS VALID?
	EXEC VERIFY_ACCNO @FROMACC, @VALID OUT

	IF @VALID='N'
		RAISERROR('FROM ACCOOUNT IS NOT VALID',16,1)
	ELSE
	BEGIN
		--CHECK FOR SUFFICIANT BALANCE
		SELECT @BAL=DBO.CHECK_BALANCE(@FROMACC,@AMNT)
		IF(@BAL<0)
			RAISERROR('IN-SUFFICIANT BALANCE',16,1)
		ELSE
		BEGIN
			BEGIN TRANSACTION
			--DEBIT FROM SBI
			UPDATE SBI SET S_BALANCE=S_BALANCE-@AMNT WHERE S_ACCNO=@FROMACC
			SELECT @TRANSBI=@@ROWCOUNT

			--CREDIT IN HDFC
			UPDATE HDFC SET H_BALANCE=H_BALANCE+@AMNT WHERE H_ACCNO=@TOACC
			SELECT @TRANHDFC=@@ROWCOUNT

			--CHECK STATUS IN BOTH TERANSACTION
			IF @TRANSBI=1 AND @TRANHDFC=1
			BEGIN
				COMMIT TRANSACTION
				PRINT 'TRANSACTION SUCCESSFUL'
			END
			ELSE
			BEGIN
				ROLLBACK TRANSACTION
				RAISERROR('TRANSACTION FAIL',16,3)
			END
		END
	END
END

SELECT * FROM HDFC
SELECT * FROM SBI

EXEC TRANSFER_MONEY 'S121','H111',10000 --FROM ACCOOUNT IS NOT VALID

EXEC TRANSFER_MONEY 'S123','H111',100000 --IN-SUFFICIANT BALANCE

EXEC TRANSFER_MONEY 'S123','H111',10000 --TO ACCOOUNT IS NOT VALID

EXEC TRANSFER_MONEY 'S123','H101',10000 --TRANSACTION SUCCESSFUL


-----------TRIGGER---------------
/* 
CREATE TRIGGER TRIGGER_NAME
ON TABLE_NAME
AFTER/FOR/INSTEAD OF
INSERT/UPDATE/DELETE
AS
BEGIN
.............
END
*/
CREATE TRIGGER EMPNO_NOUPDATE_TRIGGER
ON EMP
FOR UPDATE AS
BEGIN
	IF UPDATE(EMPNO)
	BEGIN
		ROLLBACK TRANSACTION 
		RAISERROR('CANNOT CHANGE VALUE OF PRIMARY KEY',16,1)
	END
END

UPDATE EMP SET EMPNO=201 WHERE EMPNO=1

--THERE ARE TWO TABLE FOR TRIGGER
/*
		INSERTED(NEW)		DELETED(OLD)
INSERT		NEW				---
DELETE		---				DELETE
UPDATE		NEWDATA			EXISTINGDATA
*/

--WHENEVER UPDATE SALARY, YOU CAN INCREASE FROM CURRENT SAL BUT CAN NOT DECREASE
CREATE TRIGGER UPDATE_SALARY_TRIGGER ON EMP
FOR UPDATE AS
BEGIN
	IF UPDATE(SAL)
	BEGIN
		DECLARE @NEWSAL NUMERIC(10,2), @OLDSAL NUMERIC(10,2)
		SELECT @NEWSAL=SAL FROM INSERTED
		SELECT @OLDSAL=SAL FROM DELETED
		IF @OLDSAL>@NEWSAL
		BEGIN
			ROLLBACK TRANSACTION 
			RAISERROR('NEW SALARY IS LESS THAN CURRENT SALARY. So, NO UPDATE',16,1)
		END
	END
END

SELECT *FROM EMP

UPDATE EMP SET SAL=3000 WHERE EMPNO=1

--IF THE DAY OF PERFORMING INSERT/UPDATE/DELETE IS A WEDNESDAY THEN DO NOT ALLOW TO PERFORM DML
ALTER TRIGGER WEDNESDAY_TRIGGER ON EMP
FOR INSERT,UPDATE,DELETE AS
BEGIN
	IF (SELECT DATENAME(DW,GETDATE()))='WEDNESDAY'
	BEGIN
		ROLLBACK TRANSACTION 
		RAISERROR('THIS OPERTION CAN NOT PERFORM ON WEDNESDAY',16,1)
	END
END

SELECT *FROM EMP

INSERT INTO EMP(EMPNO,ENAME) VALUES(3,'HIMSNAKJDKJSA')
UPDATE EMP SET SAL=5000 WHERE EMPNO=1
DELETE FROM EMP WHERE EMPNO=1

DROP TRIGGER WEDNESDAY_TRIGGER


--LOG FILE TRIGGER
SELECT SUSER_NAME()

DROP TABLE LOG_TABLE

CREATE TABLE LOG_TABLE(
	LOGID INT IDENTITY PRIMARY KEY,
	USERNAME VARCHAR(255),
	TABLENAME VARCHAR(30),
	OPERTION CHAR(1),
	EMPLOYEE_NO INT,
	ACTIONDATE DATETIME
)

DROP TRIGGER LOG_TRIGGER

CREATE TRIGGER LOG_TRIGGER ON EMP
AFTER INSERT, DELETE, UPDATE AS
BEGIN
	DECLARE @I INT, @D INT,@ENO INT
	SELECT @I=COUNT(*) FROM INSERTED;
	SELECT @D=COUNT(*) FROM DELETED;
	
	IF @I>0 AND @D=0 --INSERT
	BEGIN
		SELECT @ENO=EMPNO FROM INSERTED
		INSERT INTO LOG_TABLE VALUES(SUSER_NAME(), 'EMP','I',@ENO,GETDATE())
	END
	IF @I>0 AND @D>0 --UPDATE
	BEGIN
		SELECT @ENO=EMPNO FROM DELETED
		INSERT INTO LOG_TABLE VALUES(SUSER_NAME(), 'EMP','U',@ENO,GETDATE())
	END
	IF @I=0 AND @D>0 --DELETE
	BEGIN
		SELECT @ENO=EMPNO FROM DELETED
		INSERT INTO LOG_TABLE VALUES(SUSER_NAME(), 'EMP','D',@ENO,GETDATE())
	END
END

SELECT * FROM LOG_TABLE

INSERT INTO EMP(EMPNO, ENAME) VALUES(10,'GUPTAJI')

UPDATE EMP SET SAL=5000 WHERE EMPNO=1

DELETE FROM EMP WHERE EMPNO=10

SELECT DEPTNO,COUNT(JOB) FROM EMP GROUP BY JOB

SELECT * FROM EMP WHERE MGR=(SELECT DEPNO,EMPNO FROM EMP WHERE EMPNO=1)

ALTER TABLE EMP DROP COLUMN SAL
SELECT * FROM PRODUCT

SELECT *,DENSE_RANK() OVER (ORDER BY PRICE DESC) FROM PRODUCT

INSERT INTO EMP(EMPNO, DEPTNO) VALUES(11,10)

