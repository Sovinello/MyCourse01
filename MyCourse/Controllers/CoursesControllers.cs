using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyCourse.Models.Services.Application;
using MyCourse.Models.ViewModels; 

namespace MyCourse.Controllers
{

    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;        

        /*
        Abbiamo registrato il courseService nel configure service di Startup.cs.
        Grazie alla DInjection asp.netCore puo crearne un' istanza di courseService ed iniettarlo
        attraverso il costruttore all' interno dei componenti dipendenti (come questo controller)
        quindi il CoursesController er il CourseService al momento sono fortemente accoppiati quindi
        dipendenti.
        Per renderli debolmente accoppiati questi componenti facciamo dipendere questo controller 
        da un' interfaccia anziche da una classe
        */
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Catalogo dei corsi";            
            var courseService = new CourseService();
            List<CourseViewModel> courses = courseService.GetCourses();            
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            var courseService = new CourseService();
            CourseDetailViewModel course = courseService.GetCourse(id);
            ViewData["Title"] = course.Title.ToUpper();
            return View(course);
        }
    }
}