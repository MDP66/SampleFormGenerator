using SampleFormGenerator.DAL.Repositories;
using SampleFormGenerator.Model.ViewModel;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SampleFormGenerator.Model.Entities;
using SampleFormGenerator.Model.Contracts;
using SampleFormGenerator.BAL.Contracts;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Transactions;

namespace SampleFormGenerator.BAL
{
    public class Forms : IFrom
    {
        private IRepository<TblFormInfos> formInfosRepository;
        private IRepository<TblFormData> formDataRepository;
        private IRepository<TblFormValues> formValueRepository;
        private GeneralRepository generalRepository;


        public Forms(IRepository<TblFormInfos> formInfosRepository,
                     IRepository<TblFormData> formDataRepository,
                     IRepository<TblFormValues> formValueRepository,
                     GeneralRepository generalRepository)
        {
            this.formInfosRepository = formInfosRepository;
            this.generalRepository = generalRepository;
            this.formDataRepository = formDataRepository;
            this.formValueRepository = formValueRepository;
        }

        public async Task<List<vmForms>> GetAvailableForms()
        {
            try
            {
                var forms = await formInfosRepository.SelectAsync("");
                var results = new List<vmForms>();
                foreach (var item in forms)
                {
                    results.Add(new vmForms(item.Id, item.Title));
                }
                return results;
            }
            catch (System.Exception)
            {
                return new List<vmForms>();
            }
        }

        public async Task<List<vmParameterData>> GetFormLayoutAsync(int id)
        {
            try
            {
                var parameters = await generalRepository.QueryAsync<vmParameterData>("EXEC GetFormDesign @id = @id", new { id });
                return parameters.ToList();
            }
            catch (System.Exception)
            {
                return new List<vmParameterData>();
            }
        }

        #region Save
        public async Task<vmSaveState> SaveFormAsync(int id, List<vmParameterData> model)
        {
            var state = new vmSaveState();
            state.State = false;

            var connection = new DAL.Tools.SqlDbConnection().CreateDbConnection();
            setConnection(connection);
            var tran = new TransactionScope(TransactionScopeOption.Required);
            try
            {
                var formData = await SaveFormDataAsync(id);
                var saveData = await SaveFormValuesAsync(formData.Id, model);
                //tran.Commit();
                tran.Complete();
                state.State = true;
            }
            catch (Exception ex)
            {
                state.ErrorMessage = "There is an error while saving your data.";
                //tran.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return state;
        }

        /// <summary>
        /// save user entered values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task<bool> SaveFormValuesAsync(int id, List<vmParameterData> model)
        {
            foreach (var item in model)
            {
                await formValueRepository.SaveAsync(new TblFormValues
                {
                    Id_FormData = id,
                    Id_FormInfoParamater = item.Id,
                    IsValidationPassed = validateResult(item.RegexValidator, item.Value),
                    Value = item.Value
                });
            }
            return true;
        }

        /// <summary>
        /// validate result
        /// </summary>
        /// <param name="regexValidator"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool validateResult(string regexValidator, string value)
        {
            return Regex.IsMatch(value, regexValidator);
        }

        /// <summary>
        /// save new instance of TblFormData
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<TblFormData> SaveFormDataAsync(int id)
        {
            return await formDataRepository.SaveAsync(new TblFormData
            {
                Id_FormInfo = id,
                Date = DateTime.Now
            });
        }

        /// <summary>
        /// set same connection for transactions
        /// </summary>
        /// <param name="connection"></param>
        private void setConnection(IDbConnection connection)
        {
            connection.Open();
            formDataRepository.injectConnection(connection);
            formValueRepository.injectConnection(connection);
        }
        #endregion

    }
}
