﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace LibrarySystem.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);

        bool DeleteFile(string fileName);
    }
}
