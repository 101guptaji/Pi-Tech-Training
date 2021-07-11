Use Master
go

IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
    WHERE name = N'Library'
    )
BEGIN
    SELECT 'Database Northwind already Exist' AS Message
END
ELSE
BEGIN
    CREATE DATABASE Library
    SELECT 'New Database is Created'
END
go

Use Library
go


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

drop  table Book

CREATE TABLE  Book (
	BookCode int IDENTITY (1, 1) NOT NULL ,
	BookName nvarchar (15) NOT NULL ,
	 Author nvarchar(20) NULL,
	IsIssuable bit not null CONSTRAINT DF_BOOK_ISISSUABLE  DEFAULT (1),
	IsIssued bit not null CONSTRAINT DF_BOOK_ISISSUED  DEFAULT (0),
	CONSTRAINT PK_Book PRIMARY KEY  CLUSTERED 
	(
		BookCode
	)
)
go

alter table Book alter column BookName varchar(50)

set identity_insert BOOK on
go

INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(1, 'BLACK HOUSE', 'AUSTEN JANE', 1,0); 
INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(2, 'HARRY POTTER', 'Rowling, J', 1,0);
INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(3, 'Hamlet Price', 'Dr. Chuck', 0,0);
INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(4, 'War and Peace', 'Tolstoy, Leo', 1,0);
INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(5, 'You can win', 'Shiv Khera', 0,0);
INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(6, 'The Hulk', 'Tom Cruise, Janni', 1,0);
INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(7, 'Sucide', 'Abhijeet singh', 1,1);
INSERT INTO Book(BookCode, BookName, Author, IsIssuable, IsIssued) VALUES(8, 'Avenger: End Game', 'Robert Honery', 1,0);

INSERT INTO Book(BookCode, BookName) VALUES(9, 'The Wednesday');

set identity_insert BOOK off
go

INSERT INTO Book(BookName) VALUES('The Birth of Legend');
INSERT INTO Book VALUES('The Birth of Legend',NULL, 1,1);

select * from Book





CREATE TABLE MemberType (
	MemberTypeId int IDENTITY (1, 1) NOT NULL ,
	MemberType nvarchar (20) NOT NULL,
	No_of_BookAllowed int not null,
	DaysAllowed int not null,
	CONSTRAINT PK_MemberType PRIMARY KEY  CLUSTERED 
	(
		MemberTypeId
	)
)
go

INSERT INTO MemberType VALUES ('Student', 3,10);
INSERT INTO MemberType VALUES ('Faculty', 25,90);

select * from MemberType




CREATE TABLE Member (
	MemberCode int IDENTITY (1, 1) NOT NULL ,
	MemberName nvarchar (20) NOT NULL ,
	MemberTypeId int not null,
	No_of_BookIssued int null Constraint DF_Member_BookIssued Default 0,
	CONSTRAINT PK_Member PRIMARY KEY  CLUSTERED 
	(
		MemberCode
	),
	CONSTRAINT FK_MemberType FOREIGN KEY(MemberTypeId) REFERENCES dbo.MemberType (MemberTypeId)
)
go

set identity_insert Member on;
INSERT INTO Member(MemberCode, MemberName, MemberTypeId, No_of_BookIssued) VALUES(101, 'Jitendra singh',2, 1);
INSERT INTO Member(MemberCode, MemberName, MemberTypeId, No_of_BookIssued) VALUES(102, 'Himanshu',1,0);
INSERT INTO Member(MemberCode, MemberName, MemberTypeId, No_of_BookIssued) VALUES(103, 'Pooja',2, 0);
INSERT INTO Member(MemberCode, MemberName, MemberTypeId, No_of_BookIssued) VALUES(104, 'Hari lal',1, 1);
INSERT INTO Member(MemberCode, MemberName, MemberTypeId, No_of_BookIssued) VALUES(105, 'Anjali',1, 0);

set identity_insert Member off;

select * from Member





CREATE TABLE IssueBook (
	IssueCode int IDENTITY (1, 1) NOT NULL ,
	MemberCode int not null,
	BookCode int not null,
	IssueDate DateTime not null Constraint DF_ISSUEBOOK_ISSUEDATE Default GetDate(),
	DueDate DateTime not null,
	ReturnDate DateTime Null,
	CONSTRAINT PK_IssueBook PRIMARY KEY  CLUSTERED 
	(
		IssueCode
	),
	CONSTRAINT FK_Member FOREIGN KEY 
	(
		MemberCode
	) REFERENCES dbo.Member 
	(
		MemberCode
	),
	CONSTRAINT FK_Book FOREIGN KEY 
	(
		BookCode
	) REFERENCES dbo.Book
	(
		BookCode
	)
)
go

set identity_insert IssueBook ON;

INSERT INTO IssueBook(IssueCode, MemberCode, BookCode, IssueDate, DueDate, ReturnDate) VALUES(1,103, 2, '06/10/2021','09/10/2021','07/05/2021')

set identity_insert IssueBook off;

INSERT INTO IssueBook( MemberCode, BookCode, IssueDate, DueDate, ReturnDate) VALUES(105, 1, '06/17/2021','06/27/2021','06/25/2021')
INSERT INTO IssueBook(MemberCode, BookCode, IssueDate, DueDate, ReturnDate) VALUES(102, 4, '07/01/2021','07/10/2021','07/10/2021');

INSERT INTO IssueBook(MemberCode, BookCode, IssueDate, DueDate, ReturnDate) VALUES(101, 7, GETDATE(),DATEADD(DD,90,GETDATE()),NULL)
INSERT INTO IssueBook(MemberCode, BookCode, IssueDate, DueDate, ReturnDate) VALUES(104, 11, GETDATE(),DATEADD(DD,10,GETDATE()),NULL)


select * from IssueBook