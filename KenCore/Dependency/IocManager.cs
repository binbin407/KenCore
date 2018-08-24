﻿using Autofac;

namespace KenCore.Dependency
{
    public class IocManager
    {
        public IContainer Container { get; private set; }
        public ContainerBuilder ContainerBuilder { get; }
        static IocManager()
        {

        }

        private IocManager()
        {
            ContainerBuilder = new ContainerBuilder();
        }
        public static IocManager Instance { get; } = new IocManager();

        internal void InitContainer()
        {
            Container = ContainerBuilder.Build();
        }
    }
}
