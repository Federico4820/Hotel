using Hotel.Models;
using Hotel.Services;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerservice;

        public CustomerController(CustomerService service)
        {
            _customerservice = service;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var studenti = await _customerservice.GetAllAsync();
                var viewModel = studenti.Select(s => new CustomerViewModel
                {
                    CustomerId = s.CustomerId,
                    FullName = $"{s.Name} {s.Surname}",
                    Tell = s.Tell,
                    Email = s.Email
                });
                return View(viewModel);
            }
            catch
            {
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer custumer)
        {
            if (ModelState.IsValid)
            {
                await _customerservice.AddAsync(custumer);
                var customers = await _customerservice.GetAllAsync();
                var viewModel = customers.Select(s => new CustomerViewModel
                {
                    CustomerId = s.CustomerId,
                    FullName = $"{s.Name} {s.Surname}",
                    Tell = s.Tell,
                    Email = s.Email
                });
                return PartialView("_CustomersList", viewModel);
            }
            return PartialView("_Create", custumer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerservice.DeleteAsync(id);
            var customers = await _customerservice.GetAllAsync();
            return PartialView("_CustomersList", customers);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var customer = await _customerservice.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return PartialView("_CustomersList", customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerservice.UpdateAsync(customer);
                var studenti = await _customerservice.GetAllAsync();
                return PartialView("_CustomersList", studenti);
            }
            return PartialView("_Edit", customer);
        }
    }
}
