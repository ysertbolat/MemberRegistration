using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key); //hangi birimle çalışacağımız belli olmadığı için generic method yaptık
        void Add(string key, object data, int cacheTime); //eklemek için
        bool IsAdd(string key); //eklenmiş mi diye kontrol için
        void Remove(string key); //silmek için
        void RemoveByPattern(string pattern); //bir pattern ile silmek için
        void Clear(); //temizlemek için
    }
}
