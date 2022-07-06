using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.Areas.Section
{
    partial class SectionList
    {
        private IEnumerable<TitleDto> Titles { get; set; } = new List<TitleDto>();

        protected override async Task OnInitializedAsync()
        {
            Titles = await TitleRepository.GetAllAsync();
        }
    }
}