CREATE TABLE [dbo].[TblFormInfoParameters] (
    [Id_FormInfo]       INT            NOT NULL,
    [Id_ParameterTypes] INT            NOT NULL,
    [ParamterTitle]     NVARCHAR (100) NOT NULL,
    [IsMandotory]       BIT            NOT NULL,
    CONSTRAINT [FK_TblFormInfoParameters_TblFormInfos] FOREIGN KEY ([Id_FormInfo]) REFERENCES [dbo].[TblFormInfos] ([Id]),
    CONSTRAINT [FK_TblFormInfoParameters_TblParameterTypes] FOREIGN KEY ([Id_ParameterTypes]) REFERENCES [dbo].[TblParameterTypes] ([Id])
);

