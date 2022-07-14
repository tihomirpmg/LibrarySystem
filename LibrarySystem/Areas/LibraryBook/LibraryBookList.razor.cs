using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.Areas.LibraryBook;

partial class LibraryBookList
{
    private IEnumerable<LibraryBookDto> LibraryBooks { get; set; } = new List<LibraryBookDto>();

    protected override async Task OnInitializedAsync()
    {
        LibraryBooks = await LibraryBookRepository.GetAllAsync();
    }
}
