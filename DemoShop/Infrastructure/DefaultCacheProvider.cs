using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Caching;

namespace DemoShop.Infrastructure
{
    public class DefaultCacheProvider : InterfaceCacheProvider
    {
      //  private Cache Cache { get { return HttpContext.Current.Cache; } }
        
        public bool CheckSet(string key)
        {
             //return (Cache.Get(key) != null);
              return (HttpContext.Current.Cache.Get(key) != null);  
        }

        public object Get(string key)
        {
            //return Cache.Get(key);
            return HttpContext.Current.Cache.Get(key);
        }

        public void Remove(string key)
        {
            //Cache.Remove(key);
            HttpContext.Current.Cache.Remove(key);
        }

        public void Set(string key, object data, int lengthOfTime)
        {
            //Cache.Insert(key, data, null, DateTime.Now.AddSeconds(lengthOfTime), Cache.NoSlidingExpiration);
            HttpContext.Current.Cache.Insert(key, data, null, DateTime.Now.AddSeconds(lengthOfTime), Cache.NoSlidingExpiration);
        }
    }
}