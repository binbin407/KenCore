using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KenCore.Configuration
{
    public class KenCoreConfigurationPart
    {
        internal KenCoreConfiguration Configuration { get; }
        internal KenCoreConfigurationPart()
        {
            Configuration = new KenCoreConfiguration();
        }
        /// <summary>
        /// 设置数据库实体 程序集
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public KenCoreConfigurationPart SetDomainAssembly(Assembly assembly)
        {
            if (!Configuration.DomainAssembly.Contains(assembly))
            {
                Configuration.DomainAssembly.Add(assembly);
            }
            return this;
        }

        /// <summary>
        /// 配置主数据库信息（可重复调用配置多个数据库）
        /// </summary>
        /// <param name="dataBaseName">数据库名称</param>
        /// <param name="dbConnectionString">数据库连接字符串</param>
        /// <returns></returns>
        public KenCoreConfigurationPart MasterDataBases(string dataBaseName, string dbConnectionString)
        {
            if (string.IsNullOrEmpty(dataBaseName))
            {
                throw new ArgumentException($"数据库名称：{dataBaseName}不能为空！");
            }

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                throw new ArgumentException($"数据库：{dataBaseName} 主库连接不能为空！");
            }

            var dataBaseConfiguration = Configuration.DataBaseConfigurations.Find(m => m.DataBaseName == dataBaseName);
            if (dataBaseConfiguration != null)
            {
                Configuration.DataBaseConfigurations.Remove(dataBaseConfiguration);
            }

            dataBaseConfiguration = new DataBaseConfiguration
            {
                DataBaseName = dataBaseName,
                MasterDataBaseConnectionString = dbConnectionString,
                SlaveDataBaseConnectionStrings = new List<string>()
            };

            Configuration.DataBaseConfigurations.Add(dataBaseConfiguration);
            return this;
        }

        /// <summary>
        /// 配置从数据库信息（可重复调用配置多个数据库）
        /// </summary>
        /// <param name="dataBaseName">数据库名称</param>
        /// <param name="dbConnectionString">数据库连接字符串</param>
        /// <returns></returns>
        public KenCoreConfigurationPart SlaveDataBaseBases(string dataBaseName, string dbConnectionString)
        {
            if (string.IsNullOrEmpty(dataBaseName))
            {
                throw new ArgumentException("数据库名称不能为空");
            }

            if (string.IsNullOrEmpty(dbConnectionString))
            {
                throw new ArgumentException($"数据库：{dataBaseName} 数据库连接不能为空！");
            }

            var dataBaseConfiguration = Configuration.DataBaseConfigurations.Find(m => m.DataBaseName == dataBaseName);
            if (dataBaseConfiguration == null)
            {
                throw new ArgumentException($"数据库：{dataBaseName} 未配置！查找不到数据库信息");
            }

            if (!dataBaseConfiguration.SlaveDataBaseConnectionStrings.Contains(dbConnectionString))
            {
                dataBaseConfiguration.SlaveDataBaseConnectionStrings.Add(dbConnectionString);
            }
            return this;
        }

        /// <summary>
        /// 启用从库
        /// </summary>
        /// <param name="dataBaseName">数据库名称</param>
        /// <returns></returns>
        public KenCoreConfigurationPart UseSecondaryDb(string dataBaseName)
        {

            var dataBaseConfiguration = Configuration.DataBaseConfigurations.Find(m => m.DataBaseName == dataBaseName);
            if (dataBaseConfiguration == null)
            {
                throw new ArgumentException($"数据库：{dataBaseName} 未配置！查找不到数据库信息");
            }
            if (!dataBaseConfiguration.SlaveDataBaseConnectionStrings.Any())
            {
                throw new ArgumentException($"数据库：{dataBaseName} 必须配置至少一个从库连接字符串！");
            }
            dataBaseConfiguration.EnableSecondaryDb = true;
            return this;
        }

        /// <summary>
        /// 禁止软删除
        /// </summary>
        /// <param name="dataBaseName">数据库名称</param>
        /// <returns></returns>
        public KenCoreConfigurationPart DisableSoftDelete(string dataBaseName)
        {
            var dataBaseConfiguration = Configuration.DataBaseConfigurations.Find(m => m.DataBaseName == dataBaseName);
            if (dataBaseConfiguration == null)
            {
                throw new ArgumentException($"数据库：{dataBaseName} 未配置！查找不到数据库信息");
            }
            dataBaseConfiguration.DisableSoftDelete = true;
            return this;
        }

        /// <summary>
        /// 配置redis信息
        /// </summary>
        /// <param name="connect">host</param>
        public KenCoreConfigurationPart UseRedisDataBase(string connect)
        {
            Configuration.EnableRedis = true;
            Configuration.RedisConnect = connect;
            return this;
        }
    }
}
