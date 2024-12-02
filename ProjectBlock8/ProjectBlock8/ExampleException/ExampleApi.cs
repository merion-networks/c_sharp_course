using ProjectBlock8.ExampleCustumException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlock8.ExampleException
{
    public class ExampleApi
    {
        public void MetodApi()
        {

            try
            {
               throw  new ApiException(404, "Страница не найдена");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Ошибка API (статус: {ex.StatusCode}): {ex.Message}");
            }

        }
    }
}
