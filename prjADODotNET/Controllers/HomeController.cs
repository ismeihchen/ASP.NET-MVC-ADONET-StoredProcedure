using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjADODotNET.Models;

namespace prjADODotNET.Controllers
{
    public class HomeController : Controller
    {
        EmpRepository db = new EmpRepository();

        // GET: Home
        public ActionResult Index(int id = 1)
        {

            var tDepartment = db.GetAllDepartment();
            var tEmployee = db.GetEmployeesByDepId(id);

            //部門名稱
            ViewBag.DepName = tEmployee
                .Where(m => m.fDepId == id)
                .FirstOrDefault().fDepName + "部門";

            ViewModelDepEmpByDep result = new ViewModelDepEmpByDep()
            {
                department = tDepartment,
                employee = tEmployee
            };

            return View(result);
        }

        public ActionResult Create()
        {
            ////部門
            //ViewBag.DepartmentId = new SelectList(db.GetAllDepartment(), "fDepId", "fDepName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                var result = db.AddEmployee(employee);
                return RedirectToAction("Index", new { id = employee.fDepId });
            }
            return View();
        }

        public ActionResult Edit(int id)
        {          
            var tEmployee = db.GetEmployeesByEmpID(id);
            return View(tEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                db.UpdateEmployee(employee);
                return RedirectToAction("Index", new { id = employee.fDepId });
            }
            return View();
        }


        public ActionResult Delete(string id)
        {
            int fDepId = 1;
            if (!string.IsNullOrWhiteSpace(id))
            {
                var tEmployee = db.GetEmployeesByEmpID(Convert.ToInt32(id));

                if (tEmployee != null)
                {
                    fDepId = (int)tEmployee.fDepId;
                    db.DeleteEmployee(Convert.ToInt32(id));
                }
            }

            return RedirectToAction("Index", new { id = fDepId });
        }
      
        /// <summary>
        /// 取得部門資料
        /// </summary>
        /// <returns></returns>
        public JsonResult JsonDepartment()
        {
            var result = db.GetAllDepartment();
            return Json(result, JsonRequestBehavior.AllowGet);          
        }
    }
}