using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index(string searchText)
        {
            CustomerContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.CustomerContext)) as CustomerContext;
            if (context != null)
            {
                if (searchText != "" && searchText != null)
                {
                    return View(context.searchCustomer(searchText));
                }
                return View(context.getCustomer());
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
        public IActionResult insertCustomer(Supplier obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.CustomerContext)) as CustomerContext;

                    context.insert(obj);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Insert");
                }
                

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
        public IActionResult updateCustomer(Supplier obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.CustomerContext)) as CustomerContext;

                    context.update(obj);

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Update");
                }

                

            }

            catch (Exception ex)
            {
                throw;

            }

        }
        public IActionResult Delete(int id)
        {
            try
            {
                CustomerContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.CustomerContext)) as CustomerContext;
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
