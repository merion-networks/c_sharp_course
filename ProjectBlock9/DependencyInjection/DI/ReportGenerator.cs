using DependencyInjection.DI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DI
{
    public class ReportGenerator
    {
        private readonly IDataService dataService;

        public ReportGenerator(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public void GenerateReport()
        {
            var data = dataService.GetData();
        }
    }
}
