using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Utf8Json;

namespace OilView.Models
{
    public class FileManager : IFileRepository
    {
        private readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;

        public async Task<FileData> ReadAsync(string path)
        {
            if (await _storageFolder.TryGetItemAsync(path) == null) return null;
            var storage = await _storageFolder.GetFileAsync(path);
            using (var steam = await storage.OpenStreamForReadAsync())
            {
                return await JsonSerializer.DeserializeAsync<FileData>(steam);
            }
        }

        public async Task WriteAsync(string path, FileData fileData)
        {
            var storage = await _storageFolder.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting);
            using (var stream = await storage.OpenStreamForWriteAsync())
            {
                await JsonSerializer.SerializeAsync(stream, fileData);
            }
        }
    }
}
