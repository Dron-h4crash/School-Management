using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using task2.BLL.DTO;
using task2.BLL.Infrastructure;
using task2.BLL.Interfaces;
using task2.Models;

namespace task2.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService peopleService;

        public PeopleController(IPeopleService serv)
        {
            this.peopleService = serv;
            IEnumerable<PeopleDTO> peopleDtos = peopleService.GetPeoples();
        }

        public ActionResult Index()
        {
            IEnumerable<PeopleDTO> peopleDtos = peopleService.GetPeoples();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PeopleDTO, PeopleViewModel>()).CreateMapper();
            var peoples = mapper.Map<IEnumerable<PeopleDTO>, List<PeopleViewModel>>(peopleDtos);
            return View(peoples);
        }

        public ActionResult AddPeople()
        {
            var people = new PeopleViewModel();
            return View(people);
        }

        public JsonResult AddPeopleJSON(PeopleViewModel people)
        {
            try
            {
                var peopleDto = new PeopleDTO
                {
                    FirstName = people.FirstName,
                    LastName = people.LastName,
                    SecondName = people.SecondName,
                    Email = people.Email,
                    Phone = people.Phone,
                    DateBirthday = people.DateBirthday
                };

                peopleService.AddPeople(peopleDto);
                return Json(new { success = true, data = people }, JsonRequestBehavior.AllowGet);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Json(new { success = false, errorstring = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            peopleService.Dispose();
            base.Dispose(disposing);
        }
    }
}