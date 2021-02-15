USE [REDARBOR_TEST]
GO

INSERT INTO [dbo].[Employee]
           ([CompanyId]
           ,[CreatedOn]
           ,[DeletedOn]
           ,[Email]
           ,[Fax]
           ,[Name]
           ,[LastLogin]
           ,[Password]
           ,[PortalId]
           ,[RoleId]
           ,[StatusId]
           ,[Telephone]
           ,[UpdatedOn]
           ,[Username])
     VALUES
           (0
           ,'2000-01-01 00:00:00'
           ,'2000-01-01 00:00:00'
           ,'test0@test.test.tmp'
           ,'000.000.000'
           ,'test0'
           ,'2000-01-01 00:00:00'
           ,'test'
           ,0
           ,0
           ,0
           ,'000.000.000'
           ,'2000-01-01 00:00:00'
           ,'test0')
GO


INSERT INTO [dbo].[Employee]
           ([CompanyId]
           ,[CreatedOn]
           ,[DeletedOn]
           ,[Email]
           ,[Fax]
           ,[Name]
           ,[LastLogin]
           ,[Password]
           ,[PortalId]
           ,[RoleId]
           ,[StatusId]
           ,[Telephone]
           ,[UpdatedOn]
           ,[Username])
     VALUES
           (1
           ,'2000-01-01 00:00:00'
           ,'2000-01-01 00:00:00'
           ,'test1@test.test.tmp'
           ,'000.000.000'
           ,'test1'
           ,'2000-01-01 00:00:00'
           ,'test'
           ,1
           ,1
           ,1
           ,'000.000.000'
           ,'2000-01-01 00:00:00'
           ,'test1')
GO