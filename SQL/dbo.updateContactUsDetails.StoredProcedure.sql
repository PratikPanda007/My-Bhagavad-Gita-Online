USE [BGVT]
GO
/****** Object:  StoredProcedure [dbo].[updateContactUsDetails]    Script Date: 12-01-2023 16:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pratik Kumar Panda
-- Create date: 12/31/2022
-- Description:	This SP will store contact us details that the user fills
-- =============================================
CREATE PROCEDURE [dbo].[updateContactUsDetails]
	-- Add the parameters for the stored procedure here
	@fname varchar(100),
	@lname varchar(100),
	@job varchar(20),
	@email varchar(50),
	@message nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[ContactUs]
           ([FirstName]
           ,[LastName]
           ,[Job]
           ,[Email]
           ,[Message]
           ,[IsActive])
     VALUES
           (@fname
           ,@lname
           ,@job
           ,@email
           ,@message
           ,1)
END
GO
