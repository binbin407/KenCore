using KenCore.Redis;
using KenCore.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace KenCoreTest
{
    [DependsOn(typeof(RedisModule))]
    public class KenCoreTestModule : KenModule
    {
    }
}
