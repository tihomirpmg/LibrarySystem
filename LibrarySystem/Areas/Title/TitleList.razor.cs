using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Areas.Title
{
    partial class TitleList
    {
        private IEnumerable<TitleDto> Titles { get; set; } = new List<TitleDto>();

        protected override async Task OnInitializedAsync()
        {
            Titles = await TitleRepository.GetAllBooksAsync();
        }
    }
}
