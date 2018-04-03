CREATE TABLE [dbo].[TblFormData] (
    [Id]          INT           NOT NULL,
    [Date]        SMALLDATETIME NOT NULL,
    [Id_FormInfo] INT           NOT NULL,
    CONSTRAINT [PK_TblFormData] PRIMARY KEY CLUSTERED ([Id] ASC)
);

