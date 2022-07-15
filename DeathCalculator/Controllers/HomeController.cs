using DeathCalculator.Models;
using DeathCalculator.Service;
using System.Web.Mvc;

namespace DeathCalculator.Controllers
{
    public class HomeController : Controller
    {
        #region Constants

        const int INVALID_INPUT_RESULT = -1;

        #endregion

        #region Fields

        private readonly IDeathCalculatorService _deathCalculatorService;

        #endregion

        #region Constructors

        public HomeController(IDeathCalculatorService deathCalculatorService)
        {
            this._deathCalculatorService = deathCalculatorService;
        }

        #endregion

        #region (public) Methods

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DeathCalculatorViewModel model)
        {
            if (this._deathCalculatorService.IsValidData(model.AgeOfDeathA, model.YearOfDeathA, model.AgeOfDeathB, model.YearOfDeathB))
            {

                double averageKillAB = this._deathCalculatorService.GetAverageKilledPerson(model.AgeOfDeathA, model.YearOfDeathA, model.AgeOfDeathB, model.YearOfDeathB);

                return View("Result", new ResultViewModel() { Result = averageKillAB });
            }
            return View("Result", new ResultViewModel() { Result = INVALID_INPUT_RESULT });
        }
        #endregion
    }
}