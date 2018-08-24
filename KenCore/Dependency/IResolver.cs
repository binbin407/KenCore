using System.Collections.Generic;

namespace KenCore.Dependency
{
    public interface IResolver: IScopedDependency
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
