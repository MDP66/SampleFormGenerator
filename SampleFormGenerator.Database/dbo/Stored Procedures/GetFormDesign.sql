CREATE PROCEDURE [dbo].[GetFormDesign]
(
	@Id INT
)
AS
BEGIN
	SELECT 
		TblFormInfoParameters.Id, TblFormInfoParameters.ParamterTitle,TblFormInfoParameters.IsMandotory,TblFormInfoParameters.ParameterOrder,
		TblParameterTypes.RegexValidator,TblParameterTypes.RegexValidatorMessage,TblParameterTypes.EditorType as [Type]
	FROM
		TblFormInfoParameters 
		INNER JOIN TblParameterTypes ON TblParameterTypes.Id = TblFormInfoParameters.Id_ParameterTypes
	WHERE
		TblFormInfoParameters.Id_FormInfo = @Id
	ORDER BY
		TblFormInfoParameters.ParameterOrder
END