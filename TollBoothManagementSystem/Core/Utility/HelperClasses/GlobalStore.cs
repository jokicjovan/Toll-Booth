using System.Collections.Generic;

namespace TollBoothManagementSystem.Core.Utility.HelperClasses
{
    public class GlobalStore
    {
        private static readonly Dictionary<string, object?> _storedObjects;

        static GlobalStore()
        {
            _storedObjects = new Dictionary<string, object?>();
        }

        public static void AddObject(string key, object? obj)
        {
            if (_storedObjects.ContainsKey(key))
            {
                _storedObjects[key] = obj;
                return;
            }

            _storedObjects.Add(key, obj);
        }

        public static T? ReadObject<T>(string key)
        {
            return (T?)_storedObjects[key];
        }
    }
}
