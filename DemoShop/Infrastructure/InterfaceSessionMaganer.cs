using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.Infrastructure
{
    public interface InterfaceSessionManager
    {
        T Get<T>(string key);
        T Get<T>(string key, Func<T> createDefault);
        void Set<T>(string name, T value);
        T TryGet<T>(string key);
        void Delete();
    }
}