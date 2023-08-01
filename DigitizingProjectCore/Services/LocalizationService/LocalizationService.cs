using DigitizingProjectCore.Resources;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace DigitizingProjectCore.Services.LocalizationService
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;
        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(ApplicationResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("ApplicationResource", assemblyName.Name);   
        }
        public LocalizedString Getkey(string key)
        {
            return _localizer[key];
        }
    }
}
