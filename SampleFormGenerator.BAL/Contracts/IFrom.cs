using SampleFormGenerator.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFormGenerator.BAL.Contracts
{
    public interface IFrom
    {
        Task<List<vmForms>> GetAvailableForms();
        Task<List<vmParameters>> GetFormLayoutAsync(int id);
    }
}
