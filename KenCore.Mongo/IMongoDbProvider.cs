﻿using KenCore.Dependency;
using KenCore.Domain;
using MongoDB.Driver;

namespace KenCore.Mongo
{
    public interface IMongoDbProvider: ISingletonDependency
    {
        bool EnableSoftDelete<TEntity>();
        IMongoCollection<TEntity> MasterMongoCollection<TEntity>() where TEntity : class;
        IMongoCollection<TEntity> SlaveMongoCollection<TEntity>() where TEntity : class;
        EntityDescribe EntityDescribe<TEntity>();
    }
}
