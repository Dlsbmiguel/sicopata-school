using System;
using System.Collections.Generic;
using System.Text;

namespace SicopataSchool.Core.Models
{
    public class AppSettings
    {
        public string ApiUrl { get; set; }
        public string[] ClientUrls { get; set; }
        public string FileStoreFolder { get; set; }
        public string TemplateEmailPath { get; set; }
    }
}
