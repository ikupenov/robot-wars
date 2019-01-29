using System.Collections.Generic;

namespace RobotWars.Extensions
{
    public static class DictionaryExtension
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key)
        {
            return @this.TryGetValue(key, out var value) ? value : default(TValue);
        }
    }
}
