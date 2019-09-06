USE [VISA2015]
GO

UPDATE [dbo].[Region]
   SET 
      [mgCode] ='AS'
 WHERE [NameOfRegion] = 0 
GO


UPDATE [dbo].[Region]
   SET 
      [mgCode] ='AH'
 WHERE [NameOfRegion] = 1 
GO
UPDATE [dbo].[Region]
   SET 
      [mgCode] ='MR'
 WHERE [NameOfRegion] = 5 
GO
UPDATE [dbo].[Region]
   SET 
      [mgCode] ='LB'
 WHERE [NameOfRegion] = 4 
GO
UPDATE [dbo].[Region]
   SET 
      [mgCode] ='DZ'
 WHERE [NameOfRegion] = 3 
GO


UPDATE [dbo].[Region]
   SET 
      [mgCode] ='BN'
 WHERE [NameOfRegion] = 2 
GO



USE [VISA2015]
GO

UPDATE [dbo].[EducationLevel]
   SET 
      [mgCode] = '2'
 WHERE TitleOfEducationLevel  ='Ýokary'

 UPDATE [dbo].[EducationLevel]
   SET 
      [mgCode] = '5'
 WHERE TitleOfEducationLevel  ='Orta'

  UPDATE [dbo].[EducationLevel]
   SET 
      [mgCode] = '1'
 WHERE TitleOfEducationLevel  ='Ýörite Orta'