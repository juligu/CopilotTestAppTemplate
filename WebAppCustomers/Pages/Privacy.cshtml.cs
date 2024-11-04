using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppCustomers.Pages
{
    public class PrivacyModel : PageModel
    {
        public string Name { get; set; }
        
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string name)
        {
            Name = name;
        }
    }

}
