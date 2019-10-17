using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
// This Class is being used with dependency injection, simple specking we start with a class, then make a Interface by right-clicking on the class and selecting Extract Interface, this will make a new class with the same name, just with a "I" at the front.
// it only contains, method signatures, and any public properties, from the class it's linked to.
// any number of methods can be places here, but must be added to the interface.
// on the startup.cs in "public void ConfigureServices(IServiceCollection services)" place the line services.AddSingleton<ITextFileOperations, TextFileOperations>();.
// multiple interfaces could be used, for example when a user logs in, they may have any number of security policy's automatically placed on them or information provided for them.
// A switch would be one way of doing this.
namespace DeepMusic.Services
{
    public class TextFileOperations : ITextFileOperations
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        //Warning IHostingEnvironment Interface is now obsolete
        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment?view=aspnetcore-3.0
        // The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.
        public TextFileOperations(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //public void ChooseOPeration()
        //{
        //    //get the logged in role
        //    switch (role)
        //    {

        //        case:
        //            "Admin",

        //            Loadinfo();

        //            break:

        //        case:
        //            "Member",
        //            LoadinfoMember();
        //            break;





        //    }


        //}


        public IEnumerable<string> Loadinfo()

        {
            //Gets or sets the absolute path to the directory that contains the web-servable application content files.
            string webRootPath = _hostingEnvironment.WebRootPath;
            //FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "~/Docs/info.txt"));
            FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "info.txt"));
            string[] lines = File.ReadAllLines(filePath.ToString());
            return lines.ToList();
        }

        //public IEnumerable<string> LoadAdmin()

        //{
        //    //Gets or sets the absolute path to the directory that contains the web-servable application content files.
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    //FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "~/Docs/info.txt"));
        //    FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "admin.txt"));
        //    string[] lines = File.ReadAllLines(filePath.ToString());
        //    return lines.ToList();
        //}

        //public IEnumerable<string> Loadnewuser()

        //{
        //    //Gets or sets the absolute path to the directory that contains the web-servable application content files.
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    //FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "~/Docs/info.txt"));
        //    FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "newUser.txt"));
        //    string[] lines = File.ReadAllLines(filePath.ToString());
        //    return lines.ToList();
        //}



    }
}
