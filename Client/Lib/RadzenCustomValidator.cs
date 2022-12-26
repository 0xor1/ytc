using Dnsk.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Radzen;
using Radzen.Blazor;

namespace Dnsk.Client.Lib;

public class RadzenCustomValidator: ValidatorBase
{
    public override string Text { get; set; } = "Invalid";

    private List<string> SubRules { get; set; } = new();

    [Parameter]
    [EditorRequired]
    public Func<IRadzenFormComponent, (bool Valid, List<String> SubRules)> Validator { get; set; }

    protected override bool Validate(IRadzenFormComponent component)
    {
        var res = Validator(component);
        SubRules = res.SubRules;
        return res.Valid;
    }
    
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (!Visible || IsValid)
            return;
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "style", Style);
        builder.AddAttribute(2, "class", GetCssClass());
        builder.AddMultipleAttributes(3, Attributes);
        if (!Text.IsNullOrWhiteSpace())
        {
            builder.AddContent(4, Text);
        }
        if (SubRules.Any())
        {
            builder.OpenElement(5, "ul");
            builder.AddAttribute(6, "class", "p-l-1h m-y-0");
            foreach (var subRule in SubRules)
            {
                builder.OpenElement(7, "li");
                builder.AddContent(8, subRule);
                builder.CloseElement();
            }
            builder.CloseElement();
        }
        builder.CloseElement();
    }
}