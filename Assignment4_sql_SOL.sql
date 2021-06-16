SELECT * FROM EMP;

--1		LIST empname, hiredate and the no of years completed by each employee in organization
SELECT ENAME, HIREDATE,DATEDIFF(YY,HIREDATE,GETDATE()) AS NO_OF_YEARS FROM EMP

--2		LIST ALL EMP WHO HAVE JOINED BEFORE 2000
SELECT * FROM EMP WHERE YEAR(HIREDATE) < 2000

--3		LIST ALL EMP WHO HAVE COMPLETED 35 YEARS OF SERVICE
SELECT * FROM EMP WHERE DATEDIFF(YY,HIREDATE,GETDATE()) > 35

--4		LIST ALL EMP AS PER THE MONTH OF JOINING IRRESPECITVE OF THE YEARS . EXAMPLE JAN, FEB .... DEC
SELECT  DATEPART(MM,HIREDATE) AS MONTH_JOIN,* FROM EMP  ORDER BY MONTH_JOIN

--5		LIST ALL EMP WHO HAVE JOINED IN DEC 81
SELECT * FROM EMP WHERE DATEPART(MM,HIREDATE)='12'  AND DATEPART(YY,HIREDATE)='1981'

--6		LIST EACH YEAR   IN WHICH ALL EMP HAVE JOINED
SELECT DISTINCT YEAR(HIREDATE) AS YEAR_EMP_JOINED FROM EMP

--7		For each employee display the number of days passed since the employee joined the company
SELECT *,DATEDIFF(DD,HIREDATE,GETDATE()) AS NO_OF_DAYS_PASSED FROM EMP


--8		list empname, hiredate and dayoftheweek when employee joined the organization
SELECT ENAME, HIREDATE,DATENAME(DW,HIREDATE)AS DAY_OF_WEEK FROM EMP

--9		LIST THE YEAR AND TOTAL NO OF EMP JOINED IN THAT YEAR  
-- 1981		3
-- 1985		5
SELECT YEAR(HIREDATE)AS YEAR_EMP_JOINE,COUNT(EMPNO)AS NO_OF_EMP_JOINED FROM EMP GROUP BY YEAR(HIREDATE)


--10	LIST FULL DETAILS OF OLDEST  EMPLOYEE
SELECT TOP 1 * FROM EMP ORDER BY HIREDATE ASC

--------------------------------------------------------------------------------
--11
--DISPLAY EMP NAME IN PROPER CASE
--Smith
--Allen
--Ward
SELECT UPPER(SUBSTRING(ENAME,1,1))+LOWER(SUBSTRING(ENAME,2,LEN(ENAME))) FROM EMP


--12
--All employees who are not receiving commission are 
--entitled  to Rs. 250 as an additional amount,  show the net earnings  of all employees
/*SELECT *,
CASE 
	WHEN COMM IS NULL THEN ISNULL(SAL,0)+250
	ELSE ISNULL(SAL,0)+COMM
END AS NET_EARNING
FROM EMP
*/

SELECT *, ISNULL(SAL,0)+ISNULL(COMM,250) AS NET_EARNING FROM EMP

--13
 ---- Display the name, job and bonus for all employees, 
 --assuming all managers gets a bonus of Rs. 500, 
 --clerk gets Rs. 200 
 --and all other except president get Rs. 350. 
 --The president gets 20% of his salary as bonus
 SELECT ENAME,JOB, 
 CASE
	WHEN JOB='MANAGER' THEN 500
	WHEN JOB='CLERK' THEN 200
	WHEN JOB='PRESIDENT' THEN 0.2*SAL
	ELSE 350
END AS BONUS
FROM EMP
 
 --------------------------------
--14	 Find the  job of the employees receiving commission
SELECT DISTINCT JOB FROM EMP WHERE COMM IS NOT NULL AND COMM!=0
 
--15	 Show the daily salary of all employees assuming a month has 30 days without any decimal
 SELECT *, FORMAT(SAL/30,'0')AS DAILY_SALARY FROM EMP

--16	display record of last joined employee
SELECT TOP 1 * FROM EMP ORDER BY HIREDATE DESC

--17	list empname, hiredate, sal , comm and netsal in date, number and currency format of India
SELECT ENAME, FORMAT ( HIREDATE,'d','HI-IN') AS HIREDATE_INDIAN,FORMAT (SAL,'c','HI-IN')AS SALARY_INDIAN, FORMAT (COMM,'C','HI-IN')AS COMM_INDIAN,FORMAT (ISNULL(SAL,0)+ISNULL(COMM,0),'C','HI-IN')AS NETSAL_INDIAN FROM EMP

--18	show empoyee data as per year or joing
		/*for each year jan to dec give sr no 1, 2, ...
		year change again start number for 1
		HINT: (PARTION BY)
		EX:
			SORT EMP BASED YEAR AND GIVE SRNO TO RECORD FOR EACH YEAR AND RESET SRNO FOR EACH YEAR.*/
SELECT  ROW_NUMBER() OVER(PARTITION BY YEAR(HIREDATE) ORDER BY YEAR(HIREDATE) DESC) AS 'SRNO_YEAR',* FROM EMP 
			
 
--19	CASE SENSITIVE
/*IN MS SQL SERVER HOW TO WORK ON CASE SENSITIVE DATA
YOU NEED TO SET THE DATA FORMAT OT BE CASE SENITIVE.*/
--SELECT SERVERPROPERTY('COLLATION')
--SP_HELP

--METHOD: USE COLLATE SQL_Latin1_General_Cp1_CS_AS AT THE END OF QUERY TO CHANGE CASE INSENSITIVE TO CASE SENSITIVE
SELECT * FROM EMP WHERE ENAME ='KINg' COLLATE SQL_Latin1_General_Cp1_CS_AS
SELECT * FROM EMP WHERE ENAME ='KIng' COLLATE SQL_Latin1_General_Cp1_CS_AS
SELECT * FROM EMP WHERE ENAME  ='KING' COLLATE SQL_Latin1_General_Cp1_CS_AS

