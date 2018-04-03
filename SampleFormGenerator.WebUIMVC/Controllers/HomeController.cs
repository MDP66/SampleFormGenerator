using SampleFormGenerator.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SampleFormGenerator.WebUIMVC.Controllers
{
    public class HomeController : AsyncController
    {
        public HomeController()
        {

        }
        private Forms _forms;
        public HomeController(Forms forms)
        {
            _forms = forms;
        }
        public async Task<ActionResult> Index()
        {
            var forms = await _forms.GetAvailableForms();
            return View(forms);
        }
    }
}