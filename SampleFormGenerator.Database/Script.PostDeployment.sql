/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO TblParameterTypes VALUES(N'عددی','(\d)*',N'اطلاعات پر نشده است','NumberEditor','NumberView')
INSERT INTO TblParameterTypes VALUES(N'رشته ای','(\w)*',N'اطلاعات پر نشده است','TextEditor','TextView')
INSERT INTO TblParameterTypes VALUES(N'تاریخ',NULL,NULL,'DateEditor','DateView')