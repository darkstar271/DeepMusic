using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DeepMusic.Services
{
    public class TextFileOperations : ITextFileOperations
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public TextFileOperations(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<string> Loadinfo()

        {
            //Gets or sets the absolute path to the directory that contains the web-servable application content files.
            string webRootPath = _hostingEnvironment.WebRootPath;
            //FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "~/Docs/info.txt"));
            FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "info.txt"));
            string[] lines = File.ReadAllLines(filePath.ToString());
            return lines.ToList();


        }





    }
}
