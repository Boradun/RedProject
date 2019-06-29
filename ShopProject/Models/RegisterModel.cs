using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopProject.Models
{
    public class RegisterModel
    {
        [Required]
        [MinLength(5,ErrorMessage ="Длина должна быть не меньше 5")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Длина должна быть не меньше 5")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Введите действительный Email")]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}