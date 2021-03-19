using FAMEBooks.Models;
using FAMEBooks.Repositories;
using FAMEBooks.ViewModels.Loan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMEBooks.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ILoanRepository loanRepository;
        private readonly UserManager<AppUser> userManager;

        public LoanController(IBookRepository bookRepository,
                              ILoanRepository loanRepository,
                              UserManager<AppUser> userManager)
        {
            this.bookRepository = bookRepository;
            this.loanRepository = loanRepository;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<List<DisplayViewModel>> GetBooks()
        {
            var result = await bookRepository.GetBooks();
            List<DisplayViewModel> model = new List<DisplayViewModel>();
            foreach (var item in result)
            {
                model.Add(
                    new DisplayViewModel
                    {
                        BookId = item.BookId.ToString(),
                        Title = item.Title,
                        DatePublished = item.DatePublished,
                        Status = item.Status.ToString(),
                        Category = item.Category
                    });
            }

            return model;
        }


        [HttpGet]
        public async Task<IActionResult> Borrow(Guid id)
        {
            var result = await bookRepository.GetBook(id: id);
            var model = new CreateViewModel()
            {
                BookId = result.BookId,
                Author = result.Author,
                DatePublished = result.DatePublished,
                Pages = result.Pages,
                Title = result.Title
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Borrow(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await loanRepository.AddAsync(new Loan
                {
                    Id = Guid.NewGuid(),
                    BookId = model.BookId,
                    BorrowStatus = Status.Requested,
                    BorrowedByUserId = userManager.GetUserId(User)
                });
                //update to redirec to current user borrow history
                return RedirectToAction(nameof(Requests));
            }
            return View(model: model);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, us")]
        public IActionResult Requests()
        {
            return View();
        }

        public async Task<List<DisplayLoanRequest>> GetRequests()
        {
            var result = await loanRepository.GetLoanRequests();
            return result;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Approve(Guid id)
        {
            var user = await userManager.GetUserAsync(User);
            var result = await loanRepository.GetLoanRequest(id);
            result.DateBorrowed = DateTime.Now.Date;
            result.ReturnDate = DateTime.Now.Date.AddDays(2);
            result.LendBy = user.FirstName + " " + user.LastName;
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Approve(DisplayLoanRequest model)
        {
            if (ModelState.IsValid)
            {
                var loan = await loanRepository.GetLoan(model.LoanId);
                loan.LendByUserId = userManager.GetUserId(User);
                loan.BorrowStatus = Status.Borrowed;
                loan.BorrowDate = DateTime.Now.Date;
                loan.BorrowEndDate = model.ReturnDate;

                var result = await loanRepository.UpdateAsync(loan);
                return RedirectToAction(nameof(Index));
            }
            return View(model: model);
        }
    }
}
