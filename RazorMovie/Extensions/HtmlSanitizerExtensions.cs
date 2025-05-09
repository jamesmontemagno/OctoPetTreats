using Ganss.XSS;

namespace RazorMovie.Extensions;

public static class HtmlSanitizerExtensions
{
    public static IServiceCollection AddHtmlSanitizer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(o =>
        {
            var htmlSanitizer = new Ganss.XSS.HtmlSanitizer();

            htmlSanitizer.RemovingAtRule += (sender, args) =>
            {
            };
            htmlSanitizer.RemovingTag += (sender, args) =>
            {
                if (args.Tag.TagName.Equals("img", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!args.Tag.ClassList.Contains("img-fluid"))
                    {
                        args.Tag.ClassList.Add("img-fluid");
                    }

                    args.Cancel = true;
                }
            };

            htmlSanitizer.RemovingAttribute += (sender, args) =>
            {
                if (args.Tag.TagName.Equals("img", StringComparison.InvariantCultureIgnoreCase) &&
                    args.Attribute.Name.Equals("src", StringComparison.InvariantCultureIgnoreCase) &&
                    args.Reason == Ganss.XSS.RemoveReason.NotAllowedUrlValue)
                {
                    args.Cancel = true;
                }
            };
            htmlSanitizer.RemovingStyle += (sender, args) => { args.Cancel = true; };
            htmlSanitizer.AllowedAttributes.Add("class");
            htmlSanitizer.AllowedTags.Add("iframe");
            htmlSanitizer.AllowedTags.Add("style");
            htmlSanitizer.AllowedTags.Remove("img");
            htmlSanitizer.AllowedAttributes.Add("webkitallowfullscreen");
            htmlSanitizer.AllowedAttributes.Add("allowfullscreen");
            htmlSanitizer.AllowedSchemes.Add("mailto");
            htmlSanitizer.AllowedSchemes.Add("bitcoin");
            htmlSanitizer.AllowedSchemes.Add("lightning");
            return htmlSanitizer;
        });

        return serviceCollection;
    }
}
