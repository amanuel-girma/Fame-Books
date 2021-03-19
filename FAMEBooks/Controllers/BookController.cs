using FAMEBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAMEBooks.ViewModels;
using FAMEBooks.Repositories;
using Microsoft.AspNetCore.Authorization;
using FAMEBooks.ViewModels.Book;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace FAMEBooks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly UserManager<AppUser> userManager;

        public BookController(IBookRepository bookRepository,
                              ICategoryRepository categoryRepository,
                              UserManager<AppUser> userManager)
        {
            this.bookRepository = bookRepository;
            this.categoryRepository = categoryRepository;
            this.userManager = userManager;
        }

        public ViewResult Index()
        {
            return View();
        }

        public async Task<List<DisplayViewModel>> Books()
        {
            var result = await bookRepository.GetBooks();
            return result;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await categoryRepository.Categories(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            model.BookId = Guid.NewGuid();
            model.CreatedByUserId = userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                try
                {
                    await bookRepository.AddAsync(model);
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
            var book = await bookRepository.GetBook(id);
            ViewBag.Categories = new SelectList(await categoryRepository.Categories(), "CategoryId", "CategoryName", new { id = book.CategoryId });
            var model = new EditViewModel
            {
                Author = book.Author,
                //AvailableBookCount = book.BookCount,
                BookCount = book.BookCount,
                BookId = book.BookId,
                CategoryId = book.CategoryId,
                DatePublished = book.DatePublished,
                ISBN = book.ISBN,
                Pages = book.Pages,
                Publisher = book.Publisher,
                //Status = Status.Available,
                Title = book.Title,
            };
            return View(model);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            model.UpdatedByUserId = userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                var result = await bookRepository.UpdateAsync(model.BookId, model);
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
            var book = await bookRepository.GetBook(id);

            var bookToDelete = new DisplayViewModel
            {
                Author = book.Author,
                BookCount = book.BookCount,
                CategoryId = book.CategoryId,
                DatePublished = book.DatePublished,
                ISBN = book.ISBN,
                Pages = book.Pages,
                Publisher = book.Publisher,
                Title = book.Title,
                BookId = book.BookId,
                DateCreated = book.DateCreated,
                Category = book.Category.CategoryName,
                CreatedBy = book.BookCreatedBy.FirstName + " " + book.BookCreatedBy.LastName,
                UpdatedBy = book.BookUpdatedBy != null ? book.BookUpdatedBy.FirstName + " " + book.BookUpdatedBy.LastName : "No Updates",
            };
            return View(bookToDelete);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayViewModel model)
        {
            try
            {
                var result = await bookRepository.DeleteAsync(model.BookId);
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
