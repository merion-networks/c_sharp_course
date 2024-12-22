using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectBlock9.Web.Views.Home
{
    public class AdminDashBoardModel : PageModel
    {
        private readonly ILogger<AdminDashBoardModel> _logger;

        public AdminDashBoardModel(ILogger<AdminDashBoardModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
