using KenCore.Domain;
using System;

namespace Ken.Models.User
{
    [Entity("KenData", "K_User")]
    public class KenUser: EntityBase
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
