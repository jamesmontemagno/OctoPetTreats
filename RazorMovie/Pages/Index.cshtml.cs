using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorMovie.SharedServices;

namespace RazorMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Safe _safe;

        public IndexModel(ILogger<IndexModel> logger, Safe safe)
        {
            _logger = logger;
            _safe = safe;
        }

        public IHtmlContent RawInput { get; private set; }
        public IHtmlContent JsonInput { get; private set; }

        public void OnGet()
        {
            //use _safe to sanitize input
            RawInput = _safe.Raw("<script>alert('Hello')</script>");
            JsonInput = _safe.Json("<script>alert('Hello')</script>");
        }
    }
}
