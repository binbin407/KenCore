using System;

namespace KenCore.Domain
{
    public class NullBusinessPrimaryKeyGen : IBusinessPrimaryKeyGen
    {
        public object Gen(Type businessPrimaryKeyType)
        {
            return null;
        }
    }
}
