using System.Collections.Generic;

namespace EventStream.Storage
{
    public interface IStorage<T>
    {
        Dictionary<string, T> Load();
        void Remove(string key);
        void Store(T data);

        bool HasData { get; }
    }
}