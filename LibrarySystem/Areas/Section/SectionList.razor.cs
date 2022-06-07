using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Areas.Section
{
    partial class SectionList
    {
        private IEnumerable<TitleDto> Titles { get; set; } = new List<TitleDto>();

        protected override void OnInitialized()
        {
            Titles =  TitleRepository.GetAllBooks();
        }
    }
}
