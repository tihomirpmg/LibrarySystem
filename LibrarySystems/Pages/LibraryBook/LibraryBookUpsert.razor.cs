using LibrarySystem.Bussines;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace LibrarySystems.Pages.LibraryBook
{
    partial class LibraryBookUpsert
    {
        [Parameter]
        public int? Id { get; set; }
        private LibraryBookDTo LibraryBookModel { get; set; } = new LibraryBookDTo();
        private string Title { get; set; } = "Create";
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        public bool hasError = false;
        public string errorMessage;
        public string errorText;

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationState;
            if (!authenticationState.User.IsInRole(LibrarySystem.Common.Details.Role_Admin))
            {
                NavigationManager.NavigateTo("/identity/account/login");
            }

            if (Id != null)
            {
                Title = "Update";
                LibraryBookModel = await LibraryBookRepository.GetBook(Id.Value);
            }
            else
            {
                LibraryBookModel = new LibraryBookDTo();
            }
        }

        private async Task HandleLibraryBookUpsert()
        {
            try
            {
                var bookDetailsByName = await LibraryBookRepository.IsBookUnique(LibraryBookModel.Name, LibraryBookModel.Id);
                if (bookDetailsByName != null)
                {
                    return;
                }

                if (LibraryBookModel.Id != 0 && Title == "Update")
                {
                    var updateBookResult = await LibraryBookRepository.UpdateBook(LibraryBookModel.Id, LibraryBookModel);
                }
                else
                {
                    var createdResult = await LibraryBookRepository.CreateBook(LibraryBookModel);
                }
            }
            catch (RepositoryException ex)
            {
                hasError = true;
                errorMessage = "An error occurred while adding image to title.";
                errorText = ex.Message;
            }
            NavigationManager.NavigateTo("library-book");
        }
    }
}
