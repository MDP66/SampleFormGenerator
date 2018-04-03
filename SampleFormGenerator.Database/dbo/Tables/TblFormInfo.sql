CREATE TABLE [dbo].[TblFormInfo] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TblForm] PRIMARY KEY CLUSTERED ([Id] ASC)
);

