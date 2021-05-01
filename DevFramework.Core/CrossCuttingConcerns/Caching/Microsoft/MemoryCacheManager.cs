using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        public static ObjectCache Default { get; private set; }

        protected ObjectCache Cache
        {
            get
            {
                return MemoryCacheManager.Default;
            }
        }
        public void Add(string key, object data, int cacheTime=60)
        {
            if (data==null)
            {
                return;
            }

            //bir kural ekledik daha sonra cachede ne kadar durması için AbsoluteExpiration methodundan yararlandık dakika olarak belirledik
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)};
            Cache.Add(new CacheItem(key, data), policy);
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            //burada regex'e ihtiyacımız var 
            var regex = new Regex(pattern,RegexOptions.Singleline|RegexOptions.Compiled|RegexOptions.IgnoreCase);
            //generic method ile nereyi silmek istersek ona göre seçimler yapılması için yazacağımız kod;
            var keysToRemove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
}
