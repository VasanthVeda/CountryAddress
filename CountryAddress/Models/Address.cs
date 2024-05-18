using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CountryAddress.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? District { get; set; }
    }
    public class AddressViewModel
    {
        public int Id { get; set; }
        public int SelectedCountry { get; set; }
        public int SelectedState { get; set; }
        public int SelectedDistrict { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Districts { get; set; }
        public List<Address> Addresses { get; set; }
    }
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Address> Address { get; set; }

    }
}
