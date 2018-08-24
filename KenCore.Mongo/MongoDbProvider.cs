﻿using KenCore.Configuration;
using KenCore.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace KenCore.Mongo
{
    public class MongoDbProvider: IMongoDbProvider
    {
        private static readonly ConcurrentDictionary<string, MongoClient> MongoClients = new ConcurrentDictionary<string, MongoClient>();

        private readonly KenCoreConfiguration _kenCoreConfiguration;
        private readonly EntityManager _entityManager;

        public MongoDbProvider(KenCoreConfiguration kenCoreConfiguration, EntityManager entityManager)
        {
            _kenCoreConfiguration = kenCoreConfiguration;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取主库
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private IMongoDatabase MasterDatabase(string dbName)
        {

            var databaseConnectionString = _kenCoreConfiguration.MasterDataBaseConnectionString(dbName);
            if (MongoClients.ContainsKey(databaseConnectionString))
            {
                return MongoClients[databaseConnectionString].GetDatabase(dbName);
            }

            var mongoClient = new MongoClient(databaseConnectionString);
            if (!MongoClients.ContainsKey(databaseConnectionString))
            {
                MongoClients.TryAdd(databaseConnectionString, mongoClient);
            }
            return mongoClient.GetDatabase(dbName);
        }

        /// <summary>
        /// 获取从库
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private IMongoDatabase SlaveDatabase(string dbName)
        {

            var databaseConnectionString = _kenCoreConfiguration.SlaveDataBaseConnectionString(dbName);
            if (MongoClients.ContainsKey(databaseConnectionString))
            {
                return MongoClients[databaseConnectionString].GetDatabase(dbName);
            }
            var mongoClient = new MongoClient(databaseConnectionString);
            MongoClients.TryAdd(databaseConnectionString, mongoClient);
            return mongoClient.GetDatabase(dbName);
        }

        /// <summary>
        /// 获取主库 MongoCollection
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>IMongoCollection</returns>
        public IMongoCollection<TEntity> MasterMongoCollection<TEntity>() where TEntity : class
        {
            var entityDescribe = EntityDescribe<TEntity>();

            return MasterDatabase(entityDescribe.DbName).GetCollection<TEntity>(entityDescribe.TableName);

        }

        /// <summary>
        /// 获取从库MongoCollection
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>IMongoCollection</returns>
        public IMongoCollection<TEntity> SlaveMongoCollection<TEntity>() where TEntity : class
        {
            //获取实体对象信息
            var entityDescribe = EntityDescribe<TEntity>();

            if (entityDescribe.ReadSecondary && _kenCoreConfiguration.EnableSecondaryDb(entityDescribe.DbName))
            {
                return SlaveDatabase(entityDescribe.DbName).GetCollection<TEntity>(entityDescribe.TableName);
            }

            return MasterDatabase(entityDescribe.DbName).GetCollection<TEntity>(entityDescribe.TableName);
        }

        /// <summary>
        /// 是否可以软删除
        /// </summary>
        /// <returns></returns>
        public bool EnableSoftDelete<TEntity>()
        {
            var entityDescribe = EntityDescribe<TEntity>();
            if (!entityDescribe.SoftDeleteEntity)
            {
                return false;
            }
            return _kenCoreConfiguration.EnableSoftDelete(entityDescribe.DbName) && entityDescribe.SoftDeleteEntity;
        }

        public EntityDescribe EntityDescribe<TEntity>()
        {
            //获取实体对象信息
            return _entityManager.GetEntityDescribe(typeof(TEntity));
        }
    }
}
