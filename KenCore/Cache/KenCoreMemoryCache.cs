using KenCore.Dependency;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace KenCore.Cache
{
    public class KenCoreMemoryCache : ICache, ISingletonDependency
    {
        private static readonly MemoryCache Cache = new MemoryCache(new MemoryCacheOptions());
        public long Decrement(string key, long value)
        {

            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            T x = default(T);
            if (key != null && Cache.TryGetValue(key, out x))
            {
                return x;
            }
            return x;
        }

        public T Get<T>(string key, Func<T> func, int cacheTime)
        {
            var x = Cache.Get(key);
            if (x == null)
            {
                var value = func();

                Set(key, value, cacheTime);

                return value;
            }
            return (T)x;
        }

        public long Increment(string key, long value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            Cache.Remove(key);

            return true;
        }

        public bool Set<T>(string key, T data, int cacheTime)
        {
            if (key != null)
            {
                Cache.Set(key, data, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(cacheTime)
                });
                return true;
            }
            return false;
        }
    }
}
