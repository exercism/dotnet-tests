using System;
using System.Globalization;
using System.Reflection;
using Xunit.Sdk;

namespace Exercism.Tests
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UseCultureAttribute : BeforeAfterTestAttribute
    {
        private readonly CultureInfo _culture;
        private readonly CultureInfo _uiCulture;

        private CultureInfo _originalCulture;
        private CultureInfo _originalUiCulture;

        public UseCultureAttribute()
        {
            _culture = CultureInfo.InvariantCulture;
            _uiCulture = CultureInfo.InvariantCulture;
        }
        
        public UseCultureAttribute(string culture)
            : this(culture, culture)
        {
        }

        public UseCultureAttribute(string culture, string uiCulture)
        {
            _culture = new CultureInfo(culture, false);
            _uiCulture = new CultureInfo(uiCulture, false);
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            _originalCulture = CultureInfo.CurrentCulture;
            _originalUiCulture = CultureInfo.CurrentUICulture;

            CultureInfo.CurrentCulture = _culture;
            CultureInfo.CurrentUICulture = _uiCulture;
        }

        public override void After(MethodInfo methodUnderTest)
        {
            CultureInfo.CurrentCulture = _originalCulture;
            CultureInfo.CurrentUICulture = _originalUiCulture;
        }
    }
}