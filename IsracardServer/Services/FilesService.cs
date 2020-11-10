using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IsracardServer.Services
{
    public class FilesService
    {
        public bool UploadFile(string fileName, IFormFile formFile, IWebHostEnvironment env, string host, out string path)
        {
            path = "";
            string subPath = Path.Combine(env.WebRootPath, Consts.Consts.UPLOADS_DIRECTORY); // your code goes here

            if (!Directory.Exists(subPath))
                Directory.CreateDirectory(subPath);

            string filePath = Path.Combine(subPath, fileName);
            if (!File.Exists(filePath))
            {
                using (Stream stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                    path = $"https://{host}/{Consts.Consts.UPLOADS_DIRECTORY}/{fileName}";
                    return true;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
