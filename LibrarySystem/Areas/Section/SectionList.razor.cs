using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Areas.Section
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
