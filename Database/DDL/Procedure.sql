CREATE TABLE [dbo].[Procedure]
(
	[ProcedureID] INT,
	[Description] VARCHAR(200),
	[Price] MONEY,
	CONSTRAINT Pk_Procedure PRIMARY KEY (ProcedureID)
)
