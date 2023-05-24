using Dapper;
using DapperMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DapperMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View(DapperOrm.ReturnList<AddProduct>("GetAllProducts"));
        }

        //for insert operation
        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
            if(id == 0) 
                return View();
            else
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@SN", id);
             
                return View(DapperOrm.ReturnList<AddProduct>("ProductViewById", p).FirstOrDefault<AddProduct>());

            }
        }
        [HttpPost]
        public ActionResult AddorEdit(AddProduct prod) 
        {  
            DynamicParameters d = new DynamicParameters();
            d.Add("@SN", prod.SN);
            d.Add("@Product", prod.Product);
            d.Add("@Description", prod.Description);
            d.Add("@Price", prod.Price);
            d.Add("@Created", DateTime.Now); // Set the current date and time
            DapperOrm.ExecuteWithoutReturn("AddOrEditProduct", d);

            return RedirectToAction("Index");
        }
      
        public ActionResult Delete(int id)
        {
            DynamicParameters d = new DynamicParameters();
            d.Add("@SN", id);
            DapperOrm.ExecuteWithoutReturn("ProductDeleteById", d);
           
            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int id)
        {
            DynamicParameters d = new DynamicParameters();
            d.Add("@SN", id);
            DapperOrm.ExecuteWithoutReturn("ShowProduct", d);
            return View(DapperOrm.ReturnSingle<AddProduct>("ShowProduct", d));
        }
    }
}
