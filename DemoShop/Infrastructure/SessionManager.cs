using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DemoShop.Infrastructure
{
    public class SessionManager : InterfaceSessionManager
    {
        private HttpSessionState Session;

        public SessionManager()
        {
            Session = HttpContext.Current.Session;
        }

        public void Delete()
        {
            Session.Abandon();
        }

        public T Get<T>(string key)
        {
            return (T)Session[key];
        }

        public T Get<T>(string key, Func<T> createDefault)
        {
            T returnValue;
            if (Session[key] !=null && Session[key].GetType() == typeof(T))
            {
                returnValue = (T)Session[key];
            }
            else
            {
                returnValue = createDefault();
                Session[key] = returnValue;
            }
            return returnValue;
        }

        public void Set<T>(string name, T value)
        {
            Session[name] = value;
        }

        public T TryGet<T>(string key)
        {
            try
            {
                return (T)Session[key];
            }
            catch(NullReferenceException)
            {
                return default(T);
            }
        }
    }
}