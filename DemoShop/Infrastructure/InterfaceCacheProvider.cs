using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.Infrastructure
{
    public interface InterfaceCacheProvider
    {
        void Set(string key, object data, int lengthOfTime);
        bool CheckSet(string key);
        object Get(string key);
        void Remove(string key);
    }
}