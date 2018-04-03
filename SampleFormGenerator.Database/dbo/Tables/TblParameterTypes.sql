CREATE TABLE [dbo].[TblParameterTypes] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [Title]                 NVARCHAR (100) NOT NULL,
    [RegexValidator]        NVARCHAR (500) NULL,
    [RegexValidatorMessage] NVARCHAR (200) NULL,
    [EditorType]            VARCHAR (100)  NOT NULL,
    [ViewerType]            VARCHAR (100)  NOT NULL,
    CONSTRAINT [PK_TblParameterTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

