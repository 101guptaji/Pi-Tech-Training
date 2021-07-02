select * from EMP
select * from DEPT

select count(EMPNO),max(sal), min(sal) from EMP where JOB='CLERk'




--20.	Write a stored procedure in SQL Server name it as JobWiseDetails which takes Job as in parameter and return Total Employee, Max Salary and Min Salary for the Job
alter proc JobWiseDetails(@job varchar(20), @totalEmp int out, @maxSal numeric(10,2) out, @minSal numeric(10,2) out)
as
select @totalEmp=count(EMPNO), @maxSal=max(sal), @minSal=min(sal) from EMP where JOB=@job 


declare @totalEmp int, @maxSal numeric(10,2), @minSal numeric(10,2)
exec JobWiseDetails 'Clerk',@totalEmp out, @maxSal out, @minSal out
print @minSal

--For Job = Manager
--Total emp = 3
--Max Salary = 2975
--Min Salary = 2450

