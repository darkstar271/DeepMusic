using System.Collections.Generic;

namespace DeepMusic.Services
{
    public interface ITextFileOperations
    {
        IEnumerable<string> Loadinfo();
    }
}