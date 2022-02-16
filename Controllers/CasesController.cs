using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
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
        private readonly IToastNotification toastNotification;

        public CasesController(DataContext context,IToastNotification toastNotification)
        {
            this.context = context;
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cases = await context.cases.Include(m=>m.category).Include(m=>m.SocialStatus).OrderByDescending(m=>m.Daterequested).ToListAsync();
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

            var Cases = new Cases
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
                Feedback = model.Feedback
            };
            await context.cases.AddAsync(Cases);
            await context.SaveChangesAsync();
            toastNotification.AddSuccessToastMessage("Case Created SuccessFully");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var Case = await context.cases.FindAsync(id);
            if (Case == null)
                return NotFound();

            var CaseVM = new CasesVM
            {
                Id = Case.Id,
                Name = Case.Name,
                PhoneNumber = Case.PhoneNumber,
                NationalId = Case.NationalId,
                NationalImagePath = Case.NationalImagePath,
                PersonalImage = Case.PersonalImage,
                DateOfBirth = Case.DateOfBirth,
                Feedback = Case.Feedback,
                SocialStatusId = Case.SocialStatusId,
                CategoryId = Case.CategoryId,
                Category = await context.categories.ToListAsync(),
                SocialStatus = await context.socialStatuses.ToListAsync(),
            };

            return View(CaseVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CasesVM model)
        {
            model.Category = await context.categories.ToListAsync();
            model.SocialStatus = await context.socialStatuses.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Case = await context.cases.FindAsync(model.Id);
            if (Case == null)
                return NotFound();

            var files = Request.Form.Files;
            if (files.Count == 2)
            {
                if (files.Any())
                {
                    var image1 = files[0];
                    var image2 = files[1];
                    
                    var AllowdExtention = new List<string> { ".png", ".jpg", ".jpeg", ".jfif" };
                    if (!AllowdExtention.Contains(Path.GetExtension(image1.FileName)) &&
                        !AllowdExtention.Contains(Path.GetExtension(image2.FileName)))
                    {
                        ModelState.AddModelError(string.Empty, "only .jpg and .png and .jfif images are allowed");
                        return View(model);
                    }

                    var OneMB = 1024 * 1024;
                    if (image1.Length > OneMB && image2.Length > OneMB)
                    {
                        ModelState.AddModelError(string.Empty, "image cannot be more than 1MB");
                        return View(model);
                    }

                    var datastream1 = new MemoryStream();
                    await image1.CopyToAsync(datastream1);
                    var datastream2 = new MemoryStream();
                    await image2.CopyToAsync(datastream2);
                    Case.NationalImagePath =datastream1.ToArray();
                    Case.PersonalImage = datastream2.ToArray();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please rechoose the image");
                return View(model);
            }
            Case.Name = model.Name;
            Case.PhoneNumber = model.PhoneNumber;
            Case.NationalId = model.NationalId;
            Case.CategoryId = model.CategoryId;
            Case.SocialStatusId = model.SocialStatusId;
            Case.DateOfBirth = model.DateOfBirth;
            Case.Feedback = model.Feedback;
            context.Update(Case);
            await context.SaveChangesAsync();
            toastNotification.AddSuccessToastMessage("Case Updated SuccessFully");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var Case = await context.cases.Include(m=>m.category).Include(m=>m.SocialStatus).Include(m=>m.status).SingleOrDefaultAsync(m=>m.Id == id);
            if (Case == null)
                return NotFound();

            return View(Case);
        }
    }
}
