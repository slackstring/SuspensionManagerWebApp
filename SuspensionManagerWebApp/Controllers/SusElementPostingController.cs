using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuspensionManagerWebApp.Data;
using SuspensionManagerWebApp.Models;
using System;

namespace SuspensionManagerWebApp.Controllers
{
    
    public class SusElementPostingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static int activeSusElement;          //BAD PRACTICE! In Webanwendungen keine globalen Variabeln benutzen, lieber Cookies nutzen!

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
               // var settingsList = new List<Setting>();
               // susElement.Settings = settingsList;
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

        public IActionResult DeleteSusElement(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                var susElement = _context.SusElements.Where(x => x.Id == id).Include(x => x.Settings).SingleOrDefault();
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

        public IActionResult ShowSusElement(int id)
        {
            if(id != 0)
            {
                activeSusElement = id;
				var susElement = _context.SusElements.Where(x => x.Id == id).Include(x => x.Settings).SingleOrDefault();
                if (susElement != null)
                {
                    return View("ShowSusElement", susElement);
                }
			}
            else
            {
                return BadRequest();
            }

            return BadRequest();
        }

        public IActionResult ShowSetting(int idSetting, int idSusElement)
        {
            activeSusElement = idSusElement;
            var susElementFromDB = _context.SusElements.Where(x => x.Id== idSusElement).Include(x => x.Settings).SingleOrDefault();
            if (susElementFromDB != null)
            {
                if(idSetting != 0)
                {
                    foreach (Setting setting in susElementFromDB.Settings)
                    {
                        if (setting.Id == idSetting)
                        {
                            switch (susElementFromDB.SuspensionTyp)
                            {
                                case "airShock":
                                    AirShockSetting airShockSettingFromDB = setting as AirShockSetting;
                                    return PartialView("_AirShockSetting", airShockSettingFromDB);
                                    break;
                                case "airFork":
                                    AirForkSetting airForkSettingFromDB = setting as AirForkSetting;
                                    return PartialView("_AirForkSetting", airForkSettingFromDB);
                                    break;
                                case "coilShock":
                                    CoilShockSetting coilShockSettingFromDB = setting as CoilShockSetting;
                                    return PartialView("_CoilShockSetting", coilShockSettingFromDB);
                                    break;
                                case "coilFork":
                                    CoilForkSetting coilForkSettingFromDB = setting as CoilForkSetting;
                                    return PartialView("_CoilForkSetting", coilForkSettingFromDB);
                                    break;
                                default:
                                    //TODO
                                    break;
                            }

                        }
                    }
                }
                else
                {
                    switch (susElementFromDB.SuspensionTyp)
                    {
                        case "airShock":                            
                            return PartialView("_AirShockSetting");
                            break;
                        case "airFork":                           
                            return PartialView("_AirForkSetting");
                            break;
                        case "coilShock":
                            return PartialView("_CoilShockSetting");
                            break;
                        case "coilFork":
                            return PartialView("_CoilForkSetting");
                            break;
                        default:
                            //TODO
                            break;
                    }
                }
                return BadRequest();
            }
            return BadRequest();
        }

   

        public IActionResult AddEditAirShockSetting(AirShockSetting setting)
        {
            var susElementFromDb = _context.SusElements.Where(x => x.Id == activeSusElement).Include(x => x.Settings).SingleOrDefault();
            if (setting.Id == 0)
            {
                setting.Date = DateTime.Now.ToString();
                setting.SusElementID = activeSusElement;
                susElementFromDb.Settings.Add(setting);
                _context.SaveChanges();
            }
            else
            {
               // var susElementFromDb = _context.SusElements.Where(x => x.Id == activeSusElement).Include(x => x.Settings).SingleOrDefault();
                var settingToDelete = susElementFromDb.Settings.Where(x => x.Id == setting.Id).SingleOrDefault();
                susElementFromDb.Settings.Remove(settingToDelete);
                susElementFromDb.Settings.Add(setting);
                _context.SaveChanges();
                
            }

            return RedirectToAction("ShowSusElement", new { id = activeSusElement });
        }

        public IActionResult DeleteSetting(int id)
        {
            var susElementFromDb = _context.SusElements.Where(x => x.Id == activeSusElement).Include(x => x.Settings).SingleOrDefault();
            var settingToDelete = susElementFromDb.Settings.Where(x => x.Id == id).SingleOrDefault();
            susElementFromDb.Settings.Remove(settingToDelete);
            _context.SaveChanges();
            return RedirectToAction("ShowSusElement", new { id = activeSusElement });
        }

        [HttpPost]  //Backend Call via Ajax to Delete SusElement after Swal.Fire PopUp
		public IActionResult DeleteSettingById(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }
            else
            {
                var susElementFromDB = _context.SusElements.Where(x => x.Id == activeSusElement).Include(x => x.Settings).SingleOrDefault();
                var settingToDelete = susElementFromDB.Settings.Where(x => x.Id ==id).SingleOrDefault();  
                if (settingToDelete != null)
                {
                    susElementFromDB.Settings.Remove(settingToDelete);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost] //Backend Call via Ajax to Delete SusElement after Swal.Fire PopUp
        public IActionResult DeleteSusElementById(int id)
        {
            if (id == 0)
            {
                return BadRequest();    
            }
            else
            {
                var susElementToDelete = _context.SusElements.Where(x => x.Id == id).Include(x => x.Settings).SingleOrDefault();
                if (susElementToDelete != null)
                {
                    _context.SusElements.Remove(susElementToDelete);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    
    }
}
