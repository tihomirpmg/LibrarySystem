using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Areas.LibraryBook
{
    partial class LibraryBookList
    {
        private IEnumerable<LibraryBookDto> LibraryBooks { get; set; } = new List<LibraryBookDto>();

        protected override async Task OnInitializedAsync()
        {
            LibraryBooks = await LibraryBookRepository.GetAllBooks();
        }
    }
}
