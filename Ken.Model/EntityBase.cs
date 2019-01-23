using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ken.Models
{
    public abstract class EntityBase 
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }

        protected EntityBase()
        {
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
    }
}
