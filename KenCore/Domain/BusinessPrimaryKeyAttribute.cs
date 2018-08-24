﻿using System;

namespace KenCore.Domain
{
    /// <summary>
    /// 业务主键
    /// </summary>
    public class BusinessPrimaryKeyAttribute: Attribute
    {

        /// <summary>
        /// 业务主键类型
        /// </summary>
        public Type BusinessPrimaryKeyType { get; set; }

        /// <summary>
        /// 业务主键属性访问
        /// </summary>
        public PropertyDescriptor KeyDescriptor { get; set; }
    }
}
