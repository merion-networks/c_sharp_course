using DependencyInjection.DI;
using DependencyInjection.DI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ProjectBlock9.Web.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService userService;
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger logger;


        //public IUserService UserService { get; set; } //Setter Injection

        public UserController(IUserService userService, IServiceProvider serviceProvider,ILogger logger)
        {
            this.userService = userService;
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public void GetUser(int id)
        {
            var dataService = serviceProvider.GetService<IDataService>();
            var reportGenerator = new ReportGenerator(dataService);

            reportGenerator.GenerateReport();

            var user = userService.GetUserById(id);
            logger.LogInformation(user.ToString());
        }


        //Method Injection
        //public void GetUser(int id , IUserService userService)
        //{
        //    var user = userService.GetUserById(id);
        //}

        public IActionResult Index()
        {
            GetUser(1);
            return View();
        }
    }
}
