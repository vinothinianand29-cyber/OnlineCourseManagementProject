using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseManagementProject.Models;
using OnlineCourseManagementProject.Models.Database;

namespace OnlineCourseManagementProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseDbContext _ctx;
        public CourseController(CourseDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseDetails store)
        {
            if(ModelState.IsValid)
            {
                _ctx.CourseDatas.Add(store);
                _ctx.SaveChanges();
                ViewData["Msg"]= "Data submitted Successfully";
                return View();
            }
            return View();
        }

        public IActionResult Read(int CourseId, int page=1)
        {
            int pageSize = 5;
            var totalRecords =  _ctx.CourseDatas.Count();
            var data = _ctx.CourseDatas.Skip((page-1)* pageSize).Take(pageSize).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages=(int)Math.Ceiling((double)totalRecords/pageSize);
            return View(data);
        }

        public IActionResult Edit(int CourseId)
        {
            var data = _ctx.CourseDatas.Find(CourseId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(CourseDetails save)
        {
           _ctx.CourseDatas.Update(save);
            _ctx.SaveChanges();
            return RedirectToAction("Read");
        }

        public IActionResult Delete(int CourseId)
        {
            var data = _ctx.CourseDatas.Find(CourseId);
            if(data!=null)
            {
                _ctx.CourseDatas.Remove(data);
                _ctx.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }

        public IActionResult SearchCourses(string search)
        {
            var data = _ctx.CourseDatas.Where(x => x.CourseName.Contains(search)).ToList();
            return View(data);
        }

        public IActionResult FilterTrainer(string trainer)
        {
            var data = _ctx.CourseDatas
                           .Where(x => x.Trainer.Contains(trainer))
                           .ToList();

            return View(data);
        }

        public IActionResult ActiveCourses()
        {
           var data = _ctx.CourseDatas.Where(x=>x.IsAvailable == true).ToList();
            return View(data);
        }

        public IActionResult DeleteAll()
        {
          var data = _ctx.CourseDatas.ToList();
            if (data.Any())
            {
                _ctx.CourseDatas.RemoveRange(data);
                _ctx.SaveChanges();
            }
            return RedirectToAction("Read");
        }

    }
}
