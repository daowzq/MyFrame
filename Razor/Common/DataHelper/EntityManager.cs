using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Razor.DataHelper
{
    public class EntityManager
    {
        // Methods
        public static void InitializeEntity(string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(assembly, source);
        }

        public static void InitializeEntity(string[] assemblyNames, params Type[] types)
        {
            Assembly[] assemblysByNames = ObjectHelper.GetAssemblysByNames(assemblyNames);
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(assemblysByNames, source, types);
        }

        public static void InitializeEntity(Assembly[] assemblies, Assembly[] exAssemblies, params Type[] exceptTypes)
        {
            IList<Assembly> list = new List<Assembly>(assemblies);
            IList<Type> list2 = new List<Type>();
            foreach (Assembly assembly in exAssemblies)
            {
                list.Add(assembly);
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (!exceptTypes.Contains<Type>(type))
                    {
                        list2.Add(type);
                    }
                }
            }
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(list.ToArray<Assembly>(), source, list2.ToArray<Type>());
        }

        public static void InitializeEntity(string[] assemblyNames, string[] exAssemblyNames, params Type[] exceptTypes)
        {
            Assembly[] assemblysByNames = ObjectHelper.GetAssemblysByNames(assemblyNames);
            Assembly[] exAssemblies = ObjectHelper.GetAssemblysByNames(exAssemblyNames);
            InitializeEntity(assemblysByNames, exAssemblies, exceptTypes);
        }
    }
}
