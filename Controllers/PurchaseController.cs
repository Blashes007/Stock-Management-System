using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Index(string searchText)
        {
            PurchaseContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.PurchaseContext)) as PurchaseContext;
            if (searchText != "" && searchText != null)
            {
                return View(context.searchProduct(searchText));
            }
            else
            {
                return View(context.getPurchaseDetails());
            }
            
        }

        public IActionResult InsertPurchase(Purchase obj)
        {
            SupplierContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SupplierContext)) as SupplierContext;
            List<Supplier> categoryList = context.getSuppliers();
            ProductContext context2 = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;
            List<Product> productList = context2.getProduct();
            ViewBag.productData = categoryList;
            ViewBag.productData2 = productList;
            return View(obj);
        }
        [HttpPost]
        public IActionResult insertPurchase(Purchase obj)
        {
            
                try
                {
                    PurchaseContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.PurchaseContext)) as PurchaseContext;
                    context.insert(obj);
                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {

                    return RedirectToAction("Index");
                 }
            

        }
        public IActionResult UpdatePurchase(Purchase obj)
        {

            SupplierContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SupplierContext)) as SupplierContext;
            List<Supplier> categoryList = context.getSuppliers();
            ProductContext context2 = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;
            List<Product> productList = context2.getProduct();
            ViewBag.productData = categoryList;
            ViewBag.productData2 = productList;
            return View(obj);


        }
        [HttpPost]
        public IActionResult updatePurchase(Purchase obj)
        {

                try
                {


                    PurchaseContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.PurchaseContext)) as PurchaseContext;

                    context.update(obj);

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    throw;

                }


        }
        public IActionResult Delete(Purchase obj)
        {
            try
            {
                PurchaseContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.PurchaseContext)) as PurchaseContext;
                context.delete( obj);
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

