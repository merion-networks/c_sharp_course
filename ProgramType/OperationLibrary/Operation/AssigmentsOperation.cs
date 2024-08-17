using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationLibrary.Operation
{
    public class AssigmentsOperation
    {
        public AssigmentsOperation()
        {
            // Простое присваивание (=)
            int test = 0;

            // Составное присваивание (+=, *=, -=, /=, %=)

            int result = 0;
            result += 5; //     result = result + 5;

            string massage = "Привет!";

            massage += " Как дела?"; // Привет! Как дела?
        }
    }
}
