using KenCore.Dependency;
using KenCore.Domain;
using KenCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KenCore.Module
{
    public class KenModuleManager
    {
        private readonly List<KenModule> _kenModules;

        private readonly Type _startKenModuleType;
        internal IocManager IocManager { get; }
        public KenModuleManager(Type startKenModuleType, IocManager iocManager)
        {
            _startKenModuleType = startKenModuleType;
            _kenModules = new List<KenModule>();
            IocManager = iocManager;
        }

        public void BulidKenModules()
        {
            //查找程序依赖的模块
            BuildKenModules(_startKenModuleType);
            var sortModules = _kenModules.OrderByDescending(m => m.Sort).ToList();
            //实体对象信息管理
            EntityManager.Bulid(IocManager.ContainerBuilder, sortModules.Select(m => m.KenModuleAssembly).ToArray());

            //各个模块初始化
            sortModules.ForEach(m => m.PreInit());
            sortModules.ForEach(m => m.RegisterByConvention());
            sortModules.ForEach(m => m.Init());
            //对象转换
            MapperManager.BulidMapper(sortModules.Select(x => x.KenModuleAssembly).ToList());
        }

        private void BuildKenModules(Type kenModuleType, int sort = 0)
        {

            if (!KenModule.IsKenModule(kenModuleType))
            {
                throw new ArgumentException("This type is not an AmBlitz module: " + kenModuleType.AssemblyQualifiedName);
            }
            var kenModule = _kenModules.FirstOrDefault(m => m.KenModuleType == kenModuleType);
            if (kenModule == null)
            {
                var module = (KenModule)Activator.CreateInstance(kenModuleType);
                module.KenModuleType = kenModuleType;
                module.KenModuleAssembly = kenModuleType.Assembly;
                module.Sort = sort;
                module.ContainerBuilder = IocManager.ContainerBuilder;
                _kenModules.Add(module);
            }
            else
            {
                if (kenModule.Sort < sort)
                {
                    kenModule.Sort = sort;
                }
            }
            if (!kenModuleType.IsDefined(typeof(DependsOnAttribute), true))
            {
                return;
            }
            var dependsAttrs = kenModuleType.GetCustomAttributes(typeof(DependsOnAttribute), true)
                .Cast<DependsOnAttribute>().ToList();

            foreach (var depend in dependsAttrs)
            {
                foreach (var dependtyModuleType in depend.DependedModuleTypes)
                {
                    BuildKenModules(dependtyModuleType, sort + 1);
                }
            }
        }
    }
}
