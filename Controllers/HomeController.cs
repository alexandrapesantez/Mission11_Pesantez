using Microsoft.AspNetCore.Mvc;
using Mission11_Pesante.Models; // Import necessary models
using Mission11_Pesante.Models.ViewModels;
using Mission11_Pesante.Models.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace Mission11_Pesante.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository _repo;

        // Constructor to inject the IBookStoreRepository dependency
        public HomeController(IBookStoreRepository temp)
        {
            _repo = temp;
        }

        // Action method to display a paginated list of books
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10; // Define the number of items per page

            // Construct a BookList model containing paginated book data
            var blah = new BookList
            {
                Books = _repo.Book
                    .OrderBy(x => x.Title) // Order the books by title
                    .Skip((pageNum - 1) * pageSize) // Skip items based on the current page number
                    .Take(pageSize), // Take only the required number of items for the current page

                // Create pagination information for display
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum, // Set the current page number
                    ItemsPerPage = pageSize, // Set the number of items per page
                    TotalItems = _repo.Book.Count() // Calculate the total number of items
                }
            };

            // Return the view with the paginated list of books
            return View(blah);
        }
    }
}
