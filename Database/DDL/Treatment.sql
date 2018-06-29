CREATE TABLE [dbo].[Treatment]
(
	[TreatmentID] INT,
	[PetName] VARCHAR(50),
	[OwnerID] INT,
	[ProcedureID] INT,
	[Date] DATE,
	[Notes] VARCHAR(200),
	[Price] MONEY,
	CONSTRAINT FK_TOwnerID FOREIGN KEY (OwnerID) REFERENCES [Owner] (OwnerID),
	CONSTRAINT Fk_ProcedureID FOREIGN KEY (ProcedureID) REFERENCES [Procedure] (ProcedureID),
	CONSTRAINT Pk_Treatment PRIMARY KEY (TreatmentID)

)
