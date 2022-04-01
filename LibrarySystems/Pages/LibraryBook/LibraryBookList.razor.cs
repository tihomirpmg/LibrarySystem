using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystems.Pages.LibraryBook
{
    partial class LibraryBookList
    {
        private IEnumerable<LibraryBookDTo> LibraryBooks { get; set; } = new List<LibraryBookDTo>();

        protected override async Task OnInitializedAsync()
        {
            LibraryBooks = await LibraryBookRepository.GetAllBooks();
        }
    }
}
