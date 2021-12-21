using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index(String searchText)
        {
            SupplierContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SupplierContext)) as SupplierContext;
            if (context != null)
            {
                if (searchText != "" && searchText != null)
                {
                    return View(context.searchSupplier(searchText));
                }
                return View(context.getSuppliers());
            }
            else
            {
                return RedirectToAction("Insert");
            }
            
            
        }
        public IActionResult Insert(Supplier obj)
        {
            return View(obj);

        }
        [HttpPost]
        public IActionResult insertSupplier(Supplier obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SupplierContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SupplierContext)) as SupplierContext;

                    context.insert(obj);
                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    throw;

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
                SupplierContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SupplierContext)) as SupplierContext;
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
        public IActionResult Update(Supplier obj)
        {
            return View(obj);


        }
        [HttpPost]
        public IActionResult updateSupplier(Supplier obj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    SupplierContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SupplierContext)) as SupplierContext;

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
    }

}
