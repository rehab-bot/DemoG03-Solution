using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Services.interfaces
{
    public interface IAttachmentServices
    {
        //Upload
        public string? Upload(IFormFile file, string folderName);
       //Delete 
        bool Delete(string filePath);
    }
}
