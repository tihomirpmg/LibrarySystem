﻿using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystems.Pages.Title
{
    partial class TitleList
    {
        private IEnumerable<TitleDTO> Titles { get; set; } = new List<TitleDTO>();

        protected override async Task OnInitializedAsync()
        {
            Titles = await TitleRepository.GetAllBooks();
        }
    }
}
