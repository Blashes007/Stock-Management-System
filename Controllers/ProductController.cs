using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string searchText)
        {
            ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;
            if (searchText != "" && searchText != null)
            {
                return View(context.searchProduct(searchText));
            }
            else
            {
                return View(context.getProduct());
            }
            


        }
        public IActionResult InsertProduct(Product obj)
        {

            ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;
            List<ProductCategory> list = context.getCategories();
            ViewBag.productData = list;
            return View(obj);
        }
        [HttpPost]
        public IActionResult insertProduct(Product obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;

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
                return RedirectToAction("InsertProduct");
            }
            
        }
        public IActionResult Update(Product obj)
        {

            ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;
            List<ProductCategory> list = context.getCategories();
            ViewBag.productData = list;
            return View(obj);


        }
        [HttpPost]
        public IActionResult updateProduct(Product obj)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;

                    context.update(obj);

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    throw;

                }
            }
            else
            {
                return RedirectToAction("Update");
            }
            

        }
        public IActionResult Delete(int id)
        {
            try
            {
                ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;
                context.delete(id);
                return RedirectToAction("Index");

            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }


        }

    }
}
