using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjStoredProcedure.Models;

namespace prjStoredProcedure.Controllers
{
    public class HomeController : Controller
    {
        EmployeeEntities db = new EmployeeEntities();
       
        public ActionResult Index(int depId = 1)
        {
            var tDepartment = db.usp_GetAllDepartment().ToList();
            var tEmployee = db.usp_GetEmployeeByDepId(depId).ToList();

            //部門名稱
            ViewBag.DepName = db.tDepartment
                .Where(m => m.fDepId == depId)
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
            //部門
            ViewBag.DepartmentId = new SelectList(db.usp_GetAllDepartment(), "fDepId", "fDepName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ObjectParameter param = new ObjectParameter("fEmpId", typeof(Int32));

                    var result = db.usp_PR_Employee_Insert(
                        param,
                        employee.fName,
                        employee.fPhone,
                        employee.fDepId);

                    //員工編號
                    var EmployeeId = param.Value; 
                    return RedirectToAction("Index", new { depId = employee.fDepId });
                }
                catch
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var tDepartment = db.usp_GetAllDepartment().ToList();
            var tEmployee = db.usp_GetEmployeeByEmpID(id).FirstOrDefault();
            ViewModelDepEmpByEmp result = new ViewModelDepEmpByEmp()
            {
                department = tDepartment,
                employee = tEmployee
            };

            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tEmployee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.usp_PR_Employee_UpdateByPK(
                        employee.fEmpId,
                        employee.fName,
                        employee.fPhone,
                        employee.fDepId);

                    return RedirectToAction("Index", new { depId = employee.fDepId });
                }
                catch
                {
                    throw;
                }
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            string fDepId = "1";
            if (!string.IsNullOrWhiteSpace(id))
            {
                var isExists = db.usp_GetEmployeeByEmpID(int.Parse(id)).FirstOrDefault();

                if (isExists != null)
                {
                    fDepId = isExists.fDepId.ToString();
                    var result = db.usp_PR_Employee_DeleteByPK(id);
                }
            }

            return RedirectToAction("Index", new { depId = fDepId });

        }

        /// <summary>
        /// 取得部門資料
        /// </summary>
        /// <returns></returns>
        public JsonResult JsonDepartment()
        {
            var result = db.usp_GetAllDepartment().ToList();            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}