using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsracardServer.Models
{
    public class CustomTask
    {
        public CustomTask(string imagePath, string text)
        {
            ImagePath = imagePath;
            Text = text;
        }

        public string ImagePath { get; set; }
        public string Text { get; set; }
    }
}
