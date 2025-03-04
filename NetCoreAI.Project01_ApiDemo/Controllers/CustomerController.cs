using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project01_ApiDemo.Context;
using NetCoreAI.Project01_ApiDemo.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreAI.Project01_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomerController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CustomerList()
        {
            var value = _context.Customer.ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return Ok("Müşteri Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customer.Find(id);
            _context.Customer.Remove(value);
            _context.SaveChanges();
            return Ok("Müşteri Başarıyla Silindi");
        }
        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var value = _context.Customer.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
            return Ok("Müşteri Başarıyla Güncellendi");

        }
    }

}

