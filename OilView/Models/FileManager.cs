using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace OilView.Models
{
    public class FileManager : IFileRepository
    {
        public async Task<FileData> ReadAsync(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("ファイルが見つかりませんでした。");
            using (var stream = File.Open(path, FileMode.Open))
            {
                return await JsonSerializer.DeserializeAsync<FileData>(stream);
            }
        }

        public async Task WriteAsync(string path, FileData fileData)
        {
            using (var stream = File.Open(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(stream, fileData);
            }
        }
    }
}
