using System;

namespace App.Configuration
{
    /// <summary>
    /// Describes that root module is using another module (passed through parameter)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ModuleUsingAttribute : Attribute
    {
        readonly Type _moduleType;
        public ModuleUsingAttribute(Type type)
        {
            if (!typeof(IModule).IsAssignableFrom(type))
                throw new ArgumentException($"{nameof(ModuleUsingAttribute)} could be used only with {nameof(IModule)} implementations");
            _moduleType = type;
        }
    }
}
