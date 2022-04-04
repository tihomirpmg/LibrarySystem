using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystems.Pages.Section
{
    partial class SectionList
    {
        private IEnumerable<TitleDTO> Titles { get; set; } = new List<TitleDTO>();

        protected override async Task OnInitializedAsync()
        {
            Titles = await TitleRepository.GetAllBooks();
        }
    }
}
