﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public  interface IStorageService
    {

       string SaveFile(IFormFile File, string FolderName);


       void RemoveFile(string pathToRemove);
    }
}
