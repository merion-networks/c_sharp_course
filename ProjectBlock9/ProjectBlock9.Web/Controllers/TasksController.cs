using DependencyInjection.DI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ProjectBlock9.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        public IActionResult Index()
        {
            var tasks = taskService.GetTasks();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Add(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                taskService.AddTask(description);
            }

            return RedirectToAction("Index");

        }
    }
}
