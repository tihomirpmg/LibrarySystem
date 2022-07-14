using System.Threading.Tasks;
using LibrarySystem.Business;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace LibrarySystem.Areas.LibraryBook;

partial class LibraryBookUpsert
{
    [Parameter]
    public int? Id { get; set; }

    private LibraryBookDto LibraryBookModel { get; set; } = new LibraryBookDto();

    private string Title { get; set; } = "Create";

    [CascadingParameter]
    public Task<AuthenticationState> AuthenticationState { get; set; }

    public bool hasError = false;
    public string errorMessage;
    public string errorText;

    protected override async Task OnInitializedAsync()
    {
        var authenticationState = await AuthenticationState;
        if (!authenticationState.User.IsInRole(LibrarySystem.Common.RoleNames.Admin))
        {
            NavigationManager.NavigateTo("/identity/account/login");
        }

        if (Id != null)
        {
            Title = "Update";
            LibraryBookModel = await LibraryBookRepository.GetAsync(Id.Value);
        }
        else
        {
            LibraryBookModel = new LibraryBookDto();
        }
    }

    private async Task HandleLibraryBookUpsert()
    {
        try
        {
            if (LibraryBookModel.Id != 0 && Title == "Update")
            {
                var updateBookResult = await LibraryBookRepository.UpdateAsync(LibraryBookModel.Id, LibraryBookModel);
            }
            else
            {
                var createdResult = await LibraryBookRepository.CreateAsync(LibraryBookModel);
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
