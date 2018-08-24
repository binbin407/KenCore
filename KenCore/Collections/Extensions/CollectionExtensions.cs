using System;
using System.Collections.Generic;
using System.Text;

namespace KenCore.Collections.Extensions
{
    /// <summary>
    /// Collections 扩展方法 
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 非空判断
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        /// <summary>
        /// 如果不在集合中就添加到这个集合中.
        /// </summary>
        /// <param name="source">集合</param>
        /// <param name="item">要添加的集合项</param>
        /// <typeparam name="T">集合类型</typeparam>
        /// <returns>是否添加</returns>
        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Contains(item))
            {
                return false;
            }

            source.Add(item);
            return true;
        }
    }
}
