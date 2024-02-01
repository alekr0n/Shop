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
        [Required(ErrorMessage = "The name field is required.")]
        public string name { get; set; }

        [Display(Name = "Last name")]
        [StringLength(25)]
        [Required(ErrorMessage = "The last name field is required.")]
        public string surname { get; set; }

        [Display(Name = "Addres")]
        [StringLength(35)]
        [Required(ErrorMessage = "The address field is required.")]
        public string adress { get; set; }

        [Display(Name = "Number phone")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The phone number field is required.")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "The email field is required.")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

    }
}
