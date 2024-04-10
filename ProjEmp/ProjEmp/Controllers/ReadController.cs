using Microsoft.AspNetCore.Mvc;
using ProjEmp.Data;
using ProjEmp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjEmp.Controllers
{
    public class ReadController : Controller
    {
        public EmpDbContext _EmpContext;

        public ReadController(EmpDbContext EmpContext){_EmpContext = EmpContext;}

        public IActionResult Index(){List<EmpVewMdl> emp = _EmpContext.Employees.ToList();
            return View(emp);}

        public IActionResult Edit(int id){
            EmpVewMdl employee = _EmpContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null){return NotFound();}
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmpVewMdl model)
        {
            if (ModelState.IsValid){
                _EmpContext.Employees.Update(model);
                _EmpContext.SaveChanges();
                return RedirectToAction("Index");}
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            EmpVewMdl employee = _EmpContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) { return NotFound(); }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmpVewMdl model)
        {
            //EmpVewMdl employee = _EmpContext.Employees.FirstOrDefault(e => e.Id == id);
            _EmpContext.Employees.Remove(model);
            _EmpContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
