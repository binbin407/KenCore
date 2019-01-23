using System;

namespace Ken.Models
{
    /// <summary>
    /// 影人
    /// </summary>
    public class FilmMaker: EntityBase
    {
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnName { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string CnName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        /// 星座
        /// </summary>
        public string Constellation { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        public string Birthplace { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }
    }
}
