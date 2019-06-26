using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task2.BLL.DTO;
using task2.BLL.Infrastructure;
using task2.BLL.Interfaces;
using task2.Models;

namespace task2.Controllers
{
    public class HomeController : Controller
    {
        IPeopleService peopleService;
        public HomeController(IPeopleService serv)
        {
            peopleService = serv;
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
            try
            {
                var people = new PeopleViewModel();

                return View(people);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddPeople(PeopleViewModel people)
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
                return Redirect("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(people);
        }
        protected override void Dispose(bool disposing)
        {
            peopleService.Dispose();
            base.Dispose(disposing);
        }
    }
}