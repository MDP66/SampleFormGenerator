using SampleFormGenerator.DAL.Repositories;
using SampleFormGenerator.Model.ViewModel;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleFormGenerator.BAL
{
    public class Forms
    {
        private FormInfosRepository formInfosRepository { get; set; }
        public Forms(FormInfosRepository formInfosRepository)
        {
            this.formInfosRepository = formInfosRepository;
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
    }
}
