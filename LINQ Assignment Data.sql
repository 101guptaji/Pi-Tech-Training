use Northwind
select * from Categories

insert into Categories (CategoryName) values('Stationary')

 Declare @EntityKeyValue1 int= 2
SELECT
    [Extent1].[ProductID] AS [ProductID],
    [Extent1].[ProductName] AS [ProductName],
    [Extent1].[SupplierID] AS [SupplierID],
    [Extent1].[CategoryID] AS [CategoryID],
   [Extent1].[QuantityPerUnit] AS [QuantityPerUnit],
    [Extent1].[UnitPrice] AS [UnitPrice],
    [Extent1].[UnitsInStock] AS [UnitsInStock],
    [Extent1].[UnitsOnOrder] AS [UnitsOnOrder],
    [Extent1].[ReorderLevel] AS [ReorderLevel],
    [Extent1].[Discontinued] AS [Discontinued]
    FROM [dbo].[Products] AS [Extent1]
    WHERE [Extent1].[CategoryID] = @EntityKeyValue1

SELECT [ProductID]
FROM [dbo].[Products]
WHERE @@ROWCOUNT > 0 AND [ProductID] = scope_identity()

select * from Products


alter proc GetProdCount(@catId int)
as
Declare @count int
select @count=count(ProductID) from Products where CategoryID=@catId
select @count

exec GetProdCount 1

alter proc GetTotalProd(@catId int, @count int out)
as
select @count=count(ProductID) from Products where CategoryID=@catId



-----------------------Linq Assignment---------------------
Create database LINQAssignment
use LINQAssignment

DROP TABLE EMP
DROP TABLE DEPT


CREATE TABLE DEPT
       (DEPTNO int not null constraint dept_deptno_pk primary key,
        DNAME VARCHAR(14),
        LOC VARCHAR(13) )

INSERT INTO DEPT VALUES (10, 'ACCOUNTING', 'NEW YORK');
INSERT INTO DEPT VALUES (20, 'RESEARCH',   'DALLAS');
INSERT INTO DEPT VALUES (30, 'SALES',      'CHICAGO');
INSERT INTO DEPT VALUES (40, 'OPERATIONS', 'BOSTON');


CREATE TABLE EMP
       (EMPNO int NOT NULL constraint emp_empno_pk primary key,
        ENAME VARCHAR(10),
        JOB VARCHAR(9),
        MGR int,
        HIREDATE DATEtime,
        SAL NUmeric(7, 2),
        COMM Numeric(7, 2),
        DEPTNO int constraint emp_deptno_fk references dept(deptno)
		)

INSERT INTO EMP VALUES
        (7369, 'SMITH',  'CLERK',     7902, '12/17/1980',
          800, NULL, 20)
INSERT INTO EMP VALUES
        (7499, 'ALLEN',  'SALESMAN',  7698,'02/20/1981', 1600,  300, 30)
INSERT INTO EMP VALUES
        (7521, 'WARD',   'SALESMAN',  7698, '02/22/1981', 1250,  500, 30)
INSERT INTO EMP VALUES
        (7566, 'JONES',  'MANAGER',   7839, '04/2/1981',  2975, NULL, 20)
INSERT INTO EMP VALUES
        (7654, 'MARTIN', 'SALESMAN',  7698, '09/28/1981', 1250, 1400, 30)
INSERT INTO EMP VALUES
        (7698, 'BLAKE',  'MANAGER',   7839,'05/01/1981',  2850, NULL, 30)
INSERT INTO EMP VALUES
        (7782, 'CLARK',  'MANAGER',   7839, '06/09/1981',  2450, NULL, 10)
INSERT INTO EMP VALUES
        (7788, 'SCOTT',  'ANALYST',   7566, '12/09/1982' , 3000, NULL, 20)
INSERT INTO EMP VALUES
        (7839, 'KING',   'PRESIDENT', NULL, '11/17/1981' , 5000, NULL, null)
INSERT INTO EMP VALUES
        (7844, 'TURNER', 'SALESMAN',  7698, '09/08/1981' ,  1500,    0, 30)
INSERT INTO EMP VALUES
        (7876, 'ADAMS',  'CLERK',     7788, ' 01/12/1983', 1100, NULL, 20)
INSERT INTO EMP VALUES
        (7900, 'JAMES',  'CLERK',     7698, '12/03/1981' ,   950, NULL, 30)
INSERT INTO EMP VALUES
        (7902, 'FORD',   'ANALYST',   7566, '12/03/1981' ,  3000, NULL, 20)
INSERT INTO EMP VALUES
        (7934, 'MILLER', 'CLERK',     7782, '01/23/1982' , 1300, NULL, 10)


select * from dept
select * from emp