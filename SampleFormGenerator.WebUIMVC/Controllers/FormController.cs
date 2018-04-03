using SampleFormGenerator.BAL.Contracts;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SampleFormGenerator.WebUIMVC.Controllers
{
    public class FormController : Controller
    {
        public FormController()
        {

        }
        private IFrom _forms;
        public FormController(IFrom forms)
        {
            _forms = forms;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            var formParameters = await _forms.GetFormLayoutAsync(id);
            return View(formParameters);
        }
    }
}