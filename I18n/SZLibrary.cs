using Fluid;

namespace Dnsk.I18n;

public static partial class S
{
    
    
    public static readonly IReadOnlyDictionary<string, IReadOnlyDictionary<string, IFluidTemplate>> Library =
        new Dictionary<string, IReadOnlyDictionary<string, IFluidTemplate>>()
        {
            {
                EN, 
                English
            },
            {
                ES, 
                Spanish
            },
            {
                FR, 
                French
            },
            {
                DE, 
                German
            },
            {
                IT, 
                Italian
            }
        };
}