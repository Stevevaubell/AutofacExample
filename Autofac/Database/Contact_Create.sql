CREATE TABLE dbo.Contact
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(255) NOT NULL,
	Email nvarchar(255) NOT NULL,
	RequestBody nvarchar(255) NOT NULL,
	DateTimeRequested datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Contact ADD CONSTRAINT
	PK_Contact PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

INSERT INTO Contact (Name, Email, RequestBody, DateTimeRequested)
SELECT 'Test 1', 'Test1@mail.com', 'Test 1 Body', GETDATE() UNION ALL
SELECT 'Test 2', 'Test2@mail.com', 'Test 2 Body', GETDATE() UNION ALL
SELECT 'Test 3', 'Test3@mail.com', 'Test 3 Body', GETDATE() UNION ALL
SELECT 'Test 4', 'Test4@mail.com', 'Test 4 Body', GETDATE() UNION ALL
SELECT 'Test 5', 'Test5@mail.com', 'Test 5 Body', GETDATE() UNION ALL
SELECT 'Test 6', 'Test6@mail.com', 'Test 6 Body', GETDATE() 