using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Business;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;

namespace LibrarySystem.Areas.Title
{
    partial class TitleUpsert
    {
        [Parameter]
        public int? Id { get; set; }

        private TitleDto TitleModel { get; set; } = new TitleDto();

        private string Create { get; set; } = "Create";

        private ImageDto TitleImage { get; set; } = new ImageDto();

        private List<string> DeleteImageNames { get; set; } = new List<string>();

        private bool IsImageUploadProcessStarted { get; set; } = false;


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
                if (TitleModel?.TitleImages != null)
                {
                    TitleModel.ImageUrls = TitleModel.TitleImages.Select(u => u.BookImageUrl).ToList();
                }
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
                    if (TitleModel.ImageUrls != null && TitleModel.ImageUrls.Any())
                    {
                        if (DeleteImageNames != null && DeleteImageNames.Any())
                        {
                            foreach (var deletedImageName in DeleteImageNames)
                            {
                                var imageName = deletedImageName.Replace($"BookImages/", "");
                                var result = FileUpload.DeleteFile(imageName);
                                await ImagesRepository.DeleteImageByImageUrlAsync(deletedImageName);
                            }
                        }

                        await AddTitleImage(updateBookResult);
                    }
                }
                else
                {
                    var createdResult = await TitleRepository.CreateAsync(TitleModel);
                    await AddTitleImage(createdResult);
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
                 TitleModel.ImageUrls.Add(imageUrl);
            }
            catch (RepositoryException ex)
            {
                if(imageUrl == null)
                {
                    throw new RepositoryException("Image url is null.");
                }
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
                if (imageUrl == null)
                {
                    throw new RepositoryException("Image url is null.");
                }
            }
        }
        internal async Task DeletePhoto(string imageUrl)
        {
            try
            {
                var imageIndex = TitleModel.ImageUrls.FindIndex(x => x == imageUrl);
                var imageName = imageUrl.Replace($"BookImages/", "");
                if ((TitleModel.Id == 0) && Create == "Create")
                {
                    var result = FileUpload.DeleteFile(imageName);
                }
                else
                {
                    DeleteImageNames ??= new List<string>();
                    DeleteImageNames.Add(imageUrl);
                }
                TitleModel.ImageUrls.RemoveAt(imageIndex);
            }
            catch (RepositoryException ex)
            {
                hasError = true;
                errorMessage = "An error occurred while removing image.";
                errorText = ex.Message;
            }
        }
    }
}