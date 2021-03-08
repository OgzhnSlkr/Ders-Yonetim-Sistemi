using DersYonetimSistemi.Business.Abstract;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;
using DersYonetimSistemi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DersYonetimSistemi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILessonService _lessonManager;

        public HomeController(ILogger<HomeController> logger, ILessonService lessonService)
        {
            _lessonManager = lessonService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Lesson l = new Lesson();
            DaysOfLesson dl = new DaysOfLesson()
            {
                DayOfWeek = DayOfWeek.Monday,
                StartTime = "8.30",
                EndTime = "12.29",
                AddedDate = DateTime.Now
            };
            List<LessonDay> ld = new List<LessonDay>()
            {
                new LessonDay{
                    Lesson = l,
                    daysOfLesson = dl,
                    AddedDate = DateTime.Now
                },

            };

            l.AddedDate = DateTime.Now;
            l.LastAccessDate = DateTime.Now.AddDays(10);
            l.EndDate = DateTime.Now.AddDays(7);
            l.LessonCode = "Mat101";
            l.LessonCredit = 4;
            l.LessonCRN = 12345;
            l.LessonDays = ld;
            l.LessonDepartments = new List<LessonDepartment> { new LessonDepartment { Department = new Department { DepartmentName = "Feb", AddedDate = DateTime.Now, }, Lesson = l } };
            l.LessonDescription = "İlk Deneme Buuuuu";
            l.LessonName = "Matematik is The Best";
            l.TeacherId = 1;
            l.UserLessons = new List<UserLesson> { new UserLesson { Lesson = l, UserId = 1, AddedDate = DateTime.Now } };
            var result = _lessonManager.AddLesson(l,1);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
