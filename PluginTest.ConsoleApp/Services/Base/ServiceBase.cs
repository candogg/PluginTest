using System;

namespace PluginTest.ConsoleApp.Services.Base
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public abstract class ServiceBase<T> where T : class, new()
    {
        private static T derivedObject;
        private static readonly object lockObject = new object();

        public static T DerivedObject
        {
            get
            {
                if (derivedObject == null)
                {
                    lock (lockObject)
                    {
                        if (derivedObject == null)
                        {
                            derivedObject = Activator.CreateInstance<T>();
                        }
                    }
                }
                return derivedObject;
            }
        }
    }
}
