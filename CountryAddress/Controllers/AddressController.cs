using CountryAddress.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CountryAddress.Controllers
{
    public class AddressController : Controller
    {
        private readonly DatabaseContext _context;

        public AddressController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new AddressViewModel
            {
                Countries = _context.Address
                    .Select(a => new SelectListItem
                    {
                        Value = a.Country,
                        Text = a.Country
                    })
                    .Distinct()
                    .ToList(),
                States = new List<SelectListItem>(),
                Districts = new List<SelectListItem>(),
                Addresses = new List<Address>() // Empty list initially
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetStates(string country)
        {
            var states = _context.Address
                .Where(a => a.Country == country)
                .Select(a => new SelectListItem
                {
                    Value = a.State,
                    Text = a.State
                })
                .Distinct()
                .ToList();
            return Json(states);
        }

        [HttpGet]
        public IActionResult GetDistricts(string state)
        {
            var districts = _context.Address
                .Where(a => a.State == state)
                .Select(a => new SelectListItem
                {
                    Value = a.District,
                    Text = a.District
                })
                .Distinct()
                .ToList();
            return Json(districts);
        }

        [HttpGet]
        public IActionResult GetAddresses(string country, string state, string district)
        {
            // Filter addresses based on selected country, state, and district
            var addresses = _context.Address
                .Where(a => a.Country == country && a.State == state && a.District == district)
                .Select(a => new
                {
                    Id = a.Id,
                    Country = a.Country,
                    State = a.State,
                    District = a.District
                })
                .ToList();
            return Json(addresses);
        }

    }
}
