using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class CategoryController : Controller
    {

        public IActionResult Index(string searchText)
        {
            ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;
            if (searchText != "" && searchText != null)
            {
                return View(context.searchCatagories(searchText));
            }
            else
            {
                return View(context.getCategories());
            }
          
            
        }


        public IActionResult Insert(ProductCategory obj)
        {
            return View(obj);

        }
        [HttpPost]
        public IActionResult insertCategory(ProductCategory obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;

                    context.insert(obj);
                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {

                    return RedirectToAction("Index");
                }
            }
            else

            {
                return RedirectToAction("Insert");
            }
            
        }
        public IActionResult Delete(int id)
        {
            try
            {
                ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;
                context.delete(id);
                return RedirectToAction("Index");

            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return RedirectToAction("Index");
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                
                return RedirectToAction("Index");
            }
            
            
        }
       



        public IActionResult Update(ProductCategory obj)
        {
            return View(obj);


        }
        [HttpPost]
        public IActionResult updateCategory(  ProductCategory obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;

                    context.update(obj);

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    return RedirectToAction("update");

                }
            }
            else
            {
                return RedirectToAction("Update");
            }
            
            
        }

    }
    
}
