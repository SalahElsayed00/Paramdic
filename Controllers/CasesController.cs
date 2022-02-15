using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paramdic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paramdic.Controllers
{
    public class CasesController : Controller
    {
        private readonly DataContext context;

        public CasesController(DataContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cases =await context.aidrequesteds.ToListAsync();
            return View(cases);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        { 
        
        }
    }
}
