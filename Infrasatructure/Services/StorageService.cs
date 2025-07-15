using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class StorageService : IStorageService
    {
        public void RemoveFile( string FileName)
        {
            var path=Directory.GetCurrentDirectory()+"/API/Uploads/"+FileName;

            if (File.Exists(path))
            {
                File.Delete(path);
            }
           
        }

        public string SaveFile(IFormFile File, string FolderName)
        {
            var path = Directory.GetCurrentDirectory() + "/API/Uploads/" + FolderName ;

            // التأكد من وجود المجلد، إذا لم يكن موجودًا فأنشئه
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            var fileName = Guid.NewGuid()+ Path.GetFileName(File.FileName); 

            var finalPath=Path.Combine(path, fileName);

            using (var stream = new FileStream(finalPath, FileMode.Create))
            {
                File.CopyTo(stream);
            }

            return FolderName+"/"+fileName;
        }
    }
}
