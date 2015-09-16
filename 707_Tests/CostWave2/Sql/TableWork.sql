CREATE TABLE [dbo].[Users] (
    [No]       BIGINT        NOT NULL IDENTITY,
    [Email]    NVARCHAR (30) NOT NULL,
    [Password] NVARCHAR (30) NOT NULL,
    [Disc]     NTEXT         NOT NULL,
    PRIMARY KEY CLUSTERED ([No] ASC)
);




DECLARE @i INT = 0;
WHILE @i < 9999
BEGIN
	INSERT INTO [DataServer].[dbo].[Users]
			   ([Email]
			   ,[Password]
			   ,[Disc])
		 VALUES
			   ('hobis' + CONVERT(nvarchar(5), @i) + '@gmail.com'
				,'1111'
				,'xxxx')

	SET @i = @i + 1;
END;






INSERT INTO [DataServer].[dbo].[Users]
           ([Email]
           ,[Password]
           ,[Disc])
     VALUES
           ('hobisjung@gmail.com'
			,'1111'
			,'xxxx')
GO


SELECT [No]
      ,[Email]
      ,[Password]
      ,[Disc]
  FROM [DataServer].[dbo].[Users]
GO

