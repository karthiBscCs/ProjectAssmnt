using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjEmp.Data;
using ProjEmp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjEmp.Controllers
{
    public class HomeController : Controller
    {
        public EmpDbContext _EmpContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(EmpDbContext EmpContext,ILogger<HomeController> logger){
            _EmpContext = EmpContext;
            _logger = logger;}
        
        public IActionResult Index(){return View();}

        public IActionResult Create(){return View();}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,EmailId,Dept")] EmpVewMdl employee)
        {
            try
            {
                //_EmpContext.IsDbCntd();
                if (ModelState.IsValid){
                    _EmpContext.Add(employee);
                    await _EmpContext.SaveChangesAsync();
                    var redirectUrl = Url.Action("Index");
                    return Json(new { redirectUrl });}
            }
            catch (Exception ex){ModelState.AddModelError("", ex.Message);}
            return View(employee);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
