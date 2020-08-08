using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilView.Models;

namespace OilView
{
    public interface IFileRepository
    {
        Task<FileData> ReadAsync(string path);

        Task WriteAsync(string path, FileData fileData);
    }
}
