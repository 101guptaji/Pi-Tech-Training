create PROC INSERTEMP_SP(@ENO INT, @ENAME VARCHAR(20), @HIRE DATETIME, @SAL NUMERIC(10,2)) AS
BEGIN
	INSERT INTO EMP(EMPNO, ENAME, HIREDATE,SAL) VALUES(@ENO,@ENAME, @HIRE,@SAL)
END

EXEC INSERTEMP_SP 101,'jITESH','06/24/2021',5200

SELECT * FROM EMP

DELETE FROM EMP WHERE EMPNO < 100

create TABLE USERDATA(
	USERNAME VARCHAR(20) PRIMARY KEY,
	PASSWORD VARCHAR(20) NOT NULL
)

INSERT INTO USERDATA VALUES('ADMIN','123')
INSERT INTO USERDATA VALUES('USER1','123')
INSERT INTO USERDATA VALUES('USER2','123')

SELECT * FROM USERDATA