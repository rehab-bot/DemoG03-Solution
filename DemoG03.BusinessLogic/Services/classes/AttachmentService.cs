using DemoG03.BusinessLogic.Services.interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Services.classes
{
    public class AttachmentService : IAttachmentServices
    { List<string> allowedExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".pdf" };
        const int maxSizeInBytes =2* 1024 * 1024; 

        public string? Upload(IFormFile file, string folderName)
        {
            // 1.Check Extension
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension))
            {
                return null; 
            }
            // 2.Check Size
            if (file.Length >maxSizeInBytes || file.Length ==0 )
            {
                return null;
            }
            // 3.Save File to Folder
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","files", folderName);
            //4.Get File Name (make it unique)
            var uniqueFileName = $"{Guid.NewGuid()}{file.FileName}";
            //5. Get File Path
            var filePath = Path.Combine(folderPath, uniqueFileName);
            //6.Create file Stream 
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            //7. copy file
            file.CopyTo(fileStream);
            //8.Return File Name (relative path)
            return uniqueFileName;
        }
        public bool Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            else         
            {
                return false;
            }

        }

       
    }
}
