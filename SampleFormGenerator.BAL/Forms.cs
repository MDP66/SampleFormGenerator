using SampleFormGenerator.DAL.Repositories;
using SampleFormGenerator.Model.ViewModel;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SampleFormGenerator.Model.Entities;
using SampleFormGenerator.Model.Contracts;
using SampleFormGenerator.BAL.Contracts;

namespace SampleFormGenerator.BAL
{
    public class Forms : IFrom
    {
        private IRepository<TblFormInfos> formInfosRepository;
        private GeneralRepository generalRepository;
        public Forms(IRepository<TblFormInfos> formInfosRepository, GeneralRepository generalRepository)
        {
            this.formInfosRepository = formInfosRepository;
            this.generalRepository = generalRepository;
        }

        public async Task<List<vmForms>> GetAvailableForms()
        {
            var forms = await formInfosRepository.SelectAsync("");
            var results = new List<vmForms>();
            foreach (var item in forms)
            {
                results.Add(new vmForms(item.Id, item.Title));
            }
            return results;
        }

        public async Task<List<vmParameters>> GetFormLayoutAsync(int id)
        {
            var parameters = await generalRepository.QueryAsync<vmParameters>("EXEC GetFormDesign @id = @id", new { id });
            return parameters.ToList();
        }
    }
}
