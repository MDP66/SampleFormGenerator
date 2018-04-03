using SampleFormGenerator.BAL.Contracts;
using SampleFormGenerator.Model.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SampleFormGenerator.WebUIMVC.Controllers
{
    public class FormController : Controller
    {
        #region init
        public FormController()
        {

        }
        private IFrom _forms;
        public FormController(IFrom forms)
        {
            _forms = forms;
        }
        #endregion

        #region Index ( show and save form data )
        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            var formParameters = await _forms.GetFormLayoutAsync(id);
            ViewBag.Id = id;
            return View(formParameters);
        }

        [HttpPost]
        public async Task<ActionResult> Index(int id, List<vmParameterData> model) 
        {
            var saveState = await _forms.SaveFormAsync(id,model);
            if (saveState.State)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = saveState.ErrorMessage;
            return View(model);
        }
        #endregion

        #region History of filled data
        [HttpGet]
        public async Task<ActionResult> History(int id)
        {
            return View();
        }
        #endregion

    }
}