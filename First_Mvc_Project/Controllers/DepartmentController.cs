using First_Task_Mvc.BLL;
using First_Task_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace First_Task_Mvc.Controllers
{
    public class DepartmentController : Controller
    {
       
        DepartmentBLL deptbll = new DepartmentBLL();
        public ViewResult Index()
        {
            var depts = deptbll.GetAll();

            return View(depts);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model = deptbll.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult Create(Department dept)//model binder
        {
            deptbll.Create(dept);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var depts = deptbll.GetAll();
            ViewBag.Depts = new SelectList(depts, "DeptId", "DeptName");
            return View();
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Department dept= deptbll.GetById(id.Value);
            if (dept == null)
            {
                return NotFound();
            }
            ViewBag.Depts = new SelectList(deptbll.GetAll(), "DeptId", "DeptName", dept.DeptId);
            return View(dept);

        }
        [HttpPost]
        public IActionResult Update(Department dept)
        {
            deptbll.Update(dept);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            deptbll.Delete(id.Value);
            return RedirectToAction("Index");
        }
    
}
}
