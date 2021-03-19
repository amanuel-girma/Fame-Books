using FAMEBooks.Models;
using FAMEBooks.Repositories;
using FAMEBooks.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            // var result = await categoryRepository.GetCategories();
            return View();
        }

        public async Task<JsonResult> Categories()
        {
            return Json(await categoryRepository.GetCategories());
        }

        // GET: CategoryController/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create(ViewModels.Category.CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryRepository.AddAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(model);
        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await categoryRepository.GetCategory(id);

            var model = new EditViewModel
            {
                CategoryName = result.CategoryName,
                CategoryId = result.CategoryId
            };
            return View(model);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await categoryRepository.UpdateAsync(model);
                if (result == null)
                {
                    ModelState.AddModelError("", "Error while updating item.");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await categoryRepository.GetCategory(id);
            return View(result);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Models.Category model)
        {
            try
            {
                var result = await categoryRepository.DeleteAsync(model.CategoryId);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error deleting item.");
                return View(model);
            }
            catch
            {
                return View();
            }
        }

    }
}
