CREATE TABLE [dbo].[Owner]
(
	[OwnerID] INT,
	[Surname] VARCHAR(50),
	[GivenName] VARCHAR(50),
	[Phone] INT,
	CONSTRAINT PK_Owner PRIMARY KEY (OwnerID)
)
