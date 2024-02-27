using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuspensionManagerWebApp.Data;
using SuspensionManagerWebApp.Models;

namespace SuspensionManagerWebApp.Controllers
{
    public class SusElementPostingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SusElementPostingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
			List<SusElement> susElementsFromDb = _context.SusElements.Where(x => x.UserName == User.Identity.Name).ToList();
			return View(susElementsFromDb);
        }

        public IActionResult AddEditSusElement(int id)
        {
            if(id != 0)
            {
                var susElementFromDB = _context.SusElements.Where(x => x.Id == id).SingleOrDefault();
                if(susElementFromDB != null)
                {
					return View(susElementFromDB);
				}
                else
                {
                    return BadRequest();
                }
                
            }

            return View();
        }

		public IActionResult AddEditSusElementEntry(SusElement susElement)
		{
            if (susElement.Id == 0)
            {
                susElement.UserName = User.Identity.Name;
                var settingsList = new List<Setting>();
                susElement.Settings = settingsList;
                _context.SusElements.Add(susElement);   
            }
            else
            {
                var susElementToUpdate = _context.SusElements.Where(x => x.Id == susElement.Id).SingleOrDefault();
                susElementToUpdate.Manufacturer = susElement.Manufacturer;
                susElementToUpdate.Model = susElement.Model;
                susElementToUpdate.ModelYear = susElement.ModelYear;
                susElementToUpdate.Length = susElement.Length;
                susElementToUpdate.Stroke = susElement.Stroke;
                susElementToUpdate.SuspensionTyp = susElement.SuspensionTyp; 
            }
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        public IActionResult ShowSusElement(int id)
        {
            if(id != 0)
            {
				var susElement = _context.SusElements.Where(x => x.Id == id).Include(x => x.Settings).SingleOrDefault();
                if (susElement != null)
                {
                    switch (susElement.SuspensionTyp)
                    {
                        case "airFork":
                            //TODO Luftgabel hinzufügen
                            break;
                        case "coilFork":
                            //TODO Stahlfederdämpfer hinzufügen
                            break;
                        case "airShock":
                            //TODO AirSetting später rauslöschen
                            //var airSetting = new AirShockSetting();
                            //airSetting.LSC = "1";
                            //airSetting.HSC = "1";
                            //airSetting.LSR = "1";
                            //airSetting.HSR = "1";
                            //airSetting.AirPressure = "300";
                            //airSetting.Note = "BBLAAAAAAAAAAAAAAAAAAAAA";
                            //airSetting.Date = DateTime.Now.ToString();
                            //susElement.Settings.Add(airSetting);
                            //_context.SaveChanges();
                            return View("ShowAirShock", susElement);
                            //TODO Hier gehts weiter
                            break;
                        case "coilShock":
                            //TODO Stahlfederdämpfer hinzufügen
                            break;
                        default: return BadRequest();
                            break;
                    }
                }
			}
            else
            {
                return BadRequest();
            }
            
            return View();
        }

        public IActionResult AirShockSetting(int idSetting, int idSusElement)
        {
            var susElementFromDB = _context.SusElements.Where(x => x.Id== idSusElement).Include(x => x.Settings).SingleOrDefault();
            if (susElementFromDB != null)
            {
                foreach(Setting setting in susElementFromDB.Settings)
                {
                    if(setting.Id == idSetting)
                    {

                        AirShockSetting airShockSettingFromDB = setting as AirShockSetting; 
                        return PartialView("_AirShockSetting", airShockSettingFromDB);
                    }
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
            
        }

		public IActionResult DeleteSusElement(int id)
        {
            //TODO Java Script Section hinzufügen um DialogBox zum Bestätigen anzeigen zu lassen
            if (id ==0)
            {
                return BadRequest();
            }else
            {
                var susElement = _context.SusElements.Where(x => x.Id == id).SingleOrDefault();
                if (susElement != null)
                {
					_context.SusElements.Remove(susElement);
					_context.SaveChanges();
					return RedirectToAction("Index");
				}
                else
                {
                    return NotFound();
                }
                
            }

            
        }

    
    }
}
