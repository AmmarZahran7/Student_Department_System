using First_Task_Mvc.BLL;
using First_Task_Mvc.Context;
using First_Task_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace First_Task_Mvc.Controllers
{
    public class StudentsController : Controller
    {
        StudentBLL stdbll = new StudentBLL();
        DepartmentBLL deptbll = new DepartmentBLL();
        public ViewResult Index()
        {
            var students = stdbll.GetAll();

            return View(students);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model=stdbll.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult Create(Student student)//model binder
        {
            if (ModelState.IsValid)
            {
                stdbll.Create(student);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Depts = new SelectList(deptbll.GetAll(), "DeptId", "DeptName");
                return View(student);
            }

        }
        public IActionResult Create()
        {
            var depts = deptbll.GetAll();
            ViewBag.Depts=new SelectList(depts,"DeptId","DeptName");
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            stdbll.Delete(id.Value);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Student std = stdbll.GetById(id.Value);
            if (std == null)
            {
                return NotFound();
            }
            ViewBag.Depts = new SelectList(deptbll.GetAll(), "DeptId", "DeptName",std.DeptId);
            return View(std);

        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            stdbll.Update(std);
            return RedirectToAction("Index");
        }
    }
}
