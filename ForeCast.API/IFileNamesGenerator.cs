using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeCast.API
{
    public interface IFileNamesGenerator
    {
        (string File, string Bucket) CreateFileNames(DateTime date);
    }
}
