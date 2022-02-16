using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paramdic.Data;
using Paramdic.Models;
using Paramdic.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            var cases = await context.cases.ToListAsync();
            return View(cases);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CasesVM()
            {
                SocialStatus = await context.socialStatuses.OrderBy(x => x.Name).ToListAsync(),
                Category = await context.categories.OrderBy(x => x.Name).ToListAsync(),
                status = await context.statuses.OrderBy(x => x.Name).ToListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CasesVM model)
        {
            model.status = await context.statuses.OrderBy(x => x.Name).ToListAsync();
            model.SocialStatus = await context.socialStatuses.OrderBy(x => x.Name).ToListAsync();
            model.Category = await context.categories.OrderBy(x => x.Name).ToListAsync();
            if (!ModelState.IsValid)
                return View(model);

            var files = Request.Form.Files;
            if (!files.Any())
            {
                ModelState.AddModelError(string.Empty, "please select image");
                return View(model);
            }

            //check on extention image
            var image1 = files[0];
            var image2 = files[1];
            var allowedExtentions = new List<String> { ".png", ".jpg", ".jpeg", ".jfif" };
            if (!allowedExtentions.Contains(Path.GetExtension(image1.FileName.ToLower())) && 
                !allowedExtentions.Contains(Path.GetExtension(image2.FileName.ToLower())))              
            {
                ModelState.AddModelError(string.Empty, "only .jpg and .png and .jfif images are allowed");
                return View(model);
            }
            //check image size
            int oneMB = 1024 * 1024;
            if (image1.Length > oneMB && image2.Length > oneMB)
            {
                ModelState.AddModelError(string.Empty, "image cannot be more than 1MB");
                return View(model);
            }
            using var datastream1 = new MemoryStream();
            await image1.CopyToAsync(datastream1);
            using var datastream2 = new MemoryStream();
            await image2.CopyToAsync(datastream2);

            var cases = new Cases
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                NationalId = model.NationalId,
                DateOfBirth = model.DateOfBirth,
                Daterequested = DateTime.Now,
                SocialStatusId = model.SocialStatusId,
                CategoryId = model.CategoryId,
                StatusID = 1,
                NationalImagePath = datastream1.ToArray(),
                PersonalImage = datastream2.ToArray(),
                Feedback =model.Feedback
            };
            await context.cases.AddAsync(cases);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
