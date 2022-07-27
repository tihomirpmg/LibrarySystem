using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Business;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace LibrarySystem.Areas.Title;

partial class TitleUpsert
{
    [Parameter]
    public int? Id { get; set; }

    private TitleDto TitleModel { get; set; } = new TitleDto();

    private string Create { get; set; } = "Create";

    private ImageDto TitleImage { get; set; } = new ImageDto();

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
            Create = "Update";
            TitleModel = await TitleRepository.GetAsync(Id.Value);
        }
        else
        {
            TitleModel = new TitleDto();
        }
    }

    private async Task HandleLibraryBookUpsert()
    {
        try
        {
            if (TitleModel.Id != 0 && Create == "Update")
            {
                var updateBookResult = await TitleRepository.UpdateAsync(TitleModel.Id, TitleModel);
            }
            else
            {
                var createdResult = await TitleRepository.CreateAsync(TitleModel);
            }
        }
        catch (RepositoryException ex)
        {
            hasError = true;
            errorMessage = "An error occurred while adding image to title.";
            errorText = ex.Message;
        }
        NavigationManager.NavigateTo("add-title");
    }

    private async Task HandleImageUpload(string imageUrl)
    {
        try
        {
            if (imageUrl == null)
            {
                throw new RepositoryException("Image url is null.");
            }
            else if (TitleModel.ImageUrls == null)
            {
                TitleModel.ImageUrls = new List<string>();
                TitleModel.ImageUrls.Add(imageUrl);
            }
        }
        catch (RepositoryException ex)
        {
            hasError = true;
            errorMessage = "An error occurred while uploading image to title.";
            errorText = ex.Message;
        }
    }

    private async Task AddTitleImage(TitleDto bookDetails)
    {
        foreach (var imageUrl in TitleModel.ImageUrls)
        {
            if (TitleModel.TitleImages == null || TitleModel.TitleImages.Where(x => x.BookImageUrl == imageUrl).Count() == 0)
            {
                TitleImage = new ImageDto()
                {
                    BookId = bookDetails.Id,
                    BookImageUrl = imageUrl
                };
                await ImagesRepository.CreateNewImageAsync(TitleImage);
            }
        }
    }
}