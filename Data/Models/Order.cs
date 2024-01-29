using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "First name")]
        [StringLength(25)]
        [Required(ErrorMessage = "The name must contain at least 2 characters")]
        public string name { get; set; }

        [Display(Name = "Last name")]
        [StringLength(25)]
        [Required(ErrorMessage = "The last name must contain at least 3 characters")]
        public string surname { get; set; }

        [Display(Name = "Adres")]
        [StringLength(35)]
        [Required(ErrorMessage = "The adres must contain at least 5 characters")]
        public string adress { get; set; }

        [Display(Name = "Number phone")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The number must contain at least 10 characters")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "The email must contain at least 15 characters")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

    }
}
