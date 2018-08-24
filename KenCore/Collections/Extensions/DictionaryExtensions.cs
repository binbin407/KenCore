using System;
using System.Collections.Generic;
using System.Text;

namespace KenCore.Collections.Extensions
{
    /// <summary>
    /// Dictionary 扩展方法
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 这个方法用于在字典中获得一个值，如果它确实存在的话
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="dictionary">字典集合</param>
        /// <param name="key">Key</param>
        /// <param name="value">键值（如果键不存在的话，默认值）</param>
        /// <returns>字典中有关键词返回True</returns>
        internal static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T value)
        {
            object valueObj;
            if (dictionary.TryGetValue(key, out valueObj) && valueObj is T)
            {
                value = (T)valueObj;
                return true;
            }

            value = default(T);
            return false;
        }

        /// <summary>
        /// 用给定的键从字典中获得一个值。如果找不到，返回默认值。
        /// </summary>
        /// <param name="dictionary">字典集合</param>
        /// <param name="key">Key</param>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <returns>返回找到的值，找不到的话返回默认值</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue obj;
            return dictionary.TryGetValue(key, out obj) ? obj : default(TValue);
        }

        /// <summary>
        /// 用给定的键从字典中获得一个值。如果找不到，返回默认值。
        /// </summary>
        /// <param name="dictionary">字典集合</param>
        /// <param name="key">Key</param>
        /// <param name="factory">如果在字典中没有找到，则用于创建值的工厂方法</param>
        /// <returns>返回找到的值，找不到的话返回默认值</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
        {
            TValue obj;
            if (dictionary.TryGetValue(key, out obj))
            {
                return obj;
            }

            return dictionary[key] = factory(key);
        }

        /// <summary>
        /// 用给定的键从字典中获得一个值。如果找不到，返回默认值。.
        /// </summary>
        /// <param name="dictionary">字典集合</param>
        /// <param name="key">Key</param>
        /// <param name="factory">如果在字典中没有找到，则用于创建值的工厂方法</param>
        /// <returns>返回找到的值，找不到的话返回默认值.</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
        {
            return dictionary.GetOrAdd(key, k => factory());
        }
    }
}
