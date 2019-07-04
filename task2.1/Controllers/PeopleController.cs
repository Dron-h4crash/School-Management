using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Web.Mvc;
using task2._1.Hubs;
using task2.BLL.DTO;
using task2.BLL.Infrastructure;
using task2.BLL.Interfaces;
using task2.Models;
using task2.Util;

namespace task2.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService peopleService;
        

        public PeopleController(IPeopleService serv)
        {
            this.peopleService = serv;
            this.peopleService.tevent.dataChanged += DataChanged;
        }

        public ActionResult Index()
        {
            IEnumerable<PeopleDTO> peopleDtos = peopleService.GetPeoples();
            var peoples = MapperUtils.mapper.Map<IEnumerable<PeopleDTO>, List<PeopleViewModel>>(peopleDtos);

            return View(peoples);
        }

        public ActionResult AddPeople(int? id=null)
        {
            PeopleViewModel people = null;
            if (id.HasValue)
            {
                var peopleDTO = peopleService.GetPeople(id.Value);
                people = MapperUtils.mapper.Map<PeopleDTO, PeopleViewModel>(peopleDTO);
            }
            else
            {
                people = new PeopleViewModel();
            }

            return View(people);
        }

        public ActionResult DelPeople(int id)
        {
            peopleService.DelPeople(id);
            return RedirectToAction("Index");
        }

        public JsonResult AddPeopleJSON(PeopleViewModel people)
        {
            try
            {
                
                var peopleDto = new PeopleDTO
                {
                    Id = people.Id,
                    FirstName = people.FirstName,
                    LastName = people.LastName,
                    SecondName = people.SecondName,
                    Email = people.Email,
                    Phone = people.Phone,
                    DateBirthday = people.DateBirthday
                };

                if (people.Id > 0)
                {
                    peopleService.EditPeople(peopleDto);
                }
                else
                {
                    peopleService.AddPeople(peopleDto);
                }
                return Json(new { success = true, data = people }, JsonRequestBehavior.AllowGet);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Json(new { success = false, errorstring = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private void DataChanged()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            // отправляем сообщение
            context.Clients.All.onDataChanged();
        }

        protected override void Dispose(bool disposing)
        {
            peopleService.Dispose();
            base.Dispose(disposing);
        }
    }
}