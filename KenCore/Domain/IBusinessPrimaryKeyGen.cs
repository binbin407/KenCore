using KenCore.Dependency;
using System;

namespace KenCore.Domain
{
    public interface IBusinessPrimaryKeyGen: ISingletonDependency
    {
        object Gen(Type businessPrimaryKeyType);
    }
}
