using System.Collections.Generic;

namespace DeepMusic.Services
{
    // This interface is attached to "TextFileOperations" 
    public interface ITextFileOperations
    {
        IEnumerable<string> Loadinfo(); // This is the method signature of "Loadinfo" just another method in "TextFileOperations" 
        //IEnumerable<string> LoadnewUser();
        //IEnumerable<string> Loadadmin();
    }
}