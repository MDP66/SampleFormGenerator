CREATE TABLE [dbo].[TblFormValues] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Id_ParameterTypeId] INT            NOT NULL,
    [Id_FormData]        INT            NOT NULL,
    [Value]              NVARCHAR (200) NOT NULL,
    [IsValidationPassed] BIT            CONSTRAINT [DF_TblFormValues_IsValidationPassed] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TblFormValues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TblFormValues_TblFormData] FOREIGN KEY ([Id_FormData]) REFERENCES [dbo].[TblFormData] ([Id]),
    CONSTRAINT [FK_TblFormValues_TblParameterTypes] FOREIGN KEY ([Id_ParameterTypeId]) REFERENCES [dbo].[TblParameterTypes] ([Id])
);

