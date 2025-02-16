using System.Globalization;
using System.Reflection;
using Xunit.v3;

namespace Exercism.Tests;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class UseCultureAttribute : BeforeAfterTestAttribute
{
    private readonly CultureInfo _culture;
    private readonly CultureInfo _uiCulture;

    private CultureInfo? _originalCulture;
    private CultureInfo? _originalUiCulture;

    public UseCultureAttribute()
        : this(CultureInfo.InvariantCulture, CultureInfo.InvariantCulture)
    {
    }
        
    public UseCultureAttribute(string culture)
        : this(culture, culture)
    {
    }

    public UseCultureAttribute(string culture, string uiCulture)
        : this(new CultureInfo(culture, false), new CultureInfo(uiCulture, false))
    {
    }
    
    public UseCultureAttribute(CultureInfo culture, CultureInfo uiCulture)
    {
        _culture = culture;
        _uiCulture = uiCulture;
    }

    public override void Before(MethodInfo methodUnderTest, IXunitTest test)
    {
         _originalCulture = CultureInfo.CurrentCulture;
        _originalUiCulture = CultureInfo.CurrentUICulture;

        CultureInfo.CurrentCulture = _culture;
        CultureInfo.CurrentUICulture = _uiCulture;
    }

    public override void After(MethodInfo methodUnderTest, IXunitTest test)
    {
        CultureInfo.CurrentCulture = _originalCulture!;
        CultureInfo.CurrentUICulture = _originalUiCulture!;
    }
}