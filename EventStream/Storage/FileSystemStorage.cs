using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EventStream.Storage
{
    public class FileSystemStorage<T> : IStorage<T>
    {
        private readonly string _storageDirectoryPath;

        public FileSystemStorage(string storageDirectoryPath)
        {
            _storageDirectoryPath = storageDirectoryPath;
            Directory.CreateDirectory(storageDirectoryPath);
        }

        public void Remove(string key)
        {
            File.Delete(key);
        }

        public Dictionary<string, T> Load()
        {
            var result = new Dictionary<string, T>();
            var files = Directory.GetFiles(_storageDirectoryPath);

            foreach (var file in files)
            {
                result[file] = JsonConvert.DeserializeObject<T>(file);
            }

            return result;
        }

        public void Store(T eventsToSend)
        {
            File.WriteAllText(
                Path.Combine(_storageDirectoryPath, Guid.NewGuid().ToString()),
                JsonConvert.SerializeObject(eventsToSend));
        }

        public bool HasData => Directory.GetFiles(_storageDirectoryPath).Length > 0;
    }
}