USE [VISA2015]
GO

UPDATE [dbo].[IRegistration_Data]
  set counter = SUBSTRING (  ManualApplicationNumber ,CHARINDEX('-',ManualApplicationNumber)+1, 4)

GO


