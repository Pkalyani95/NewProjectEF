using NewProjectEF.BusinessEntities;
using NewProjectEF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;




namespace NewProjectEF
{
    public class CourseController : Controller
    {

        public IActionResult CoursesList()
        {
            var DbContext = new AcademyDbContext();
            var Courses=DbContext.Courses.ToList();

            return View(Courses);
        }

        public IActionResult CourseEditor()
        {
            var model=new CourseEditorModel();
            return View (model);
        }

        [HttpPost]
        public ActionResult Create(CourseEditorModel editormodel)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course();
                course.CourseTitle = editormodel.CourseTitle;
                course.DurationInDays = editormodel.DurationInDays;
                course.Price = editormodel.Price;
                course.IsActive = editormodel.IsActive;

                var DbContext = new AcademyDbContext();
                DbContext.Courses.Add(course);
                DbContext.SaveChanges();
                return RedirectToAction("coursesList");
            }
            else
            {
                ModelState.AddModelError("", "Course record not created, please fix errors and save again!");

                return View("CourseEditor", editormodel);
            }
            }
        [HttpGet]
        public IActionResult EditCourse(int courseId)
        {
            var DbContext = new AcademyDbContext();
            var courseobj = DbContext.Courses.Where(p => p.CourseId == courseId).FirstOrDefault();
            var editorModel = new CourseEditorModel();
            editorModel.CourseTitle = courseobj.CourseTitle;
            editorModel.DurationInDays= courseobj.DurationInDays;
            editorModel.Price = courseobj.Price;
            editorModel.IsActive = courseobj.IsActive;
            

            return View(editorModel);
        }
        [HttpPost]
        public IActionResult Update(CourseEditorModel editorModel)
        {
            if (ModelState.IsValid)
            {
                var DbContext = new AcademyDbContext();
                var courseobj = DbContext.Courses.Where(p => p.CourseId == editorModel.CourseID).FirstOrDefault();
                courseobj.CourseTitle = editorModel.CourseTitle;
                courseobj.DurationInDays = editorModel.DurationInDays;
                courseobj.Price = editorModel.Price;
                courseobj.IsActive = editorModel.IsActive;

                DbContext.Courses.Update(courseobj);

                DbContext.SaveChanges();

                return RedirectToAction("CoursesList");

            }
            else
            {
                ModelState.AddModelError("", "Course record not updated, please fix errors and save again!");
                return View("EditCourse", editorModel);
            }

        }

        [HttpGet]
        public ViewResult CourseRO(int courseId)
        {
            var DbContext = new AcademyDbContext();
            var courseobj = DbContext.Courses.Where(p => p.CourseId == courseId).FirstOrDefault();

            return View(courseobj);
        }

        [HttpPost]
        public JsonResult DeleteCourse(int courseId)
        {
            var DbContext = new AcademyDbContext();

            var courseobj = DbContext.Courses.Where(p => p.CourseId == courseId).FirstOrDefault();

            DbContext.Courses.Remove(courseobj);
            DbContext.SaveChanges();

            return Json(true);
        }
    }

}

