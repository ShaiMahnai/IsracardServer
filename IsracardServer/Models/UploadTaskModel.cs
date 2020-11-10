using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IsracardServer.Models
{
    public class UploadTaskModel
    {
        public string Text { get; set; }
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
