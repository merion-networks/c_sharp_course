using Microsoft.AspNetCore.Mvc;


namespace InheritanceLibrary.Controller
{
    public class ProductsController : BaseController
    {
        public IActionResult GetProduct(int idProduct)
        {
            try
            {
                //Логика получения продукта
                return Ok(new { idProduct });
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
