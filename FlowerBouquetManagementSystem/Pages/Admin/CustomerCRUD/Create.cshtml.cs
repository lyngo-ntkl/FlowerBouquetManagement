using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTOs;
using Repositories;
using Repositories.Implement;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using AutoMapper;
using BusinessObjects.Models;

namespace FlowerBouquetManagementSystem.Pages.Admin.CustomerCRUD
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        private IMapper _mapper;
        public CreateModel(CustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerDTO Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_customerRepository.GetAll().Where(x => x.Email.Equals(Customer.Email)) != null)
            {
                ModelState.AddModelError("DuplicateEmail", Customer.Email + " has been registered");
                return Page();
            }

            _customerRepository.Save(_mapper.Map<Customer>(Customer));

            return RedirectToPage("/Login");
        }
    }
}
