USE [VISA2015]
GO
--oylenen 
UPDATE [dbo].[MaritalStatus]
   SET 
      [mgCode] = '2'
 WHERE Status LIKE 0
GO
--sallah 
UPDATE [dbo].[MaritalStatus]
   SET 
      [mgCode] = '1'
 WHERE Status LIKE 1
GO
--durmusa çykan 
UPDATE [dbo].[MaritalStatus]
   SET 
      [mgCode] = '2'
 WHERE Status LIKE 2
GO

--durmusa çymadyk
UPDATE [dbo].[MaritalStatus]
   SET 
      [mgCode] = '1'
 WHERE Status LIKE 3
GO

--ayrylsan
UPDATE [dbo].[MaritalStatus]
   SET 
      [mgCode] = '3'
 WHERE Status LIKE 4
GO
--çaga
UPDATE [dbo].[MaritalStatus]
   SET 
      [mgCode] = ''
 WHERE Status LIKE 5
GO

