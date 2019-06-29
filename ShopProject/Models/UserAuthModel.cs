using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopProject.Models
{
    public class UserAuthModel
    {
        [Required]
        [MinLength(5,ErrorMessage = "Длина имени меньше 5 символов")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage ="Длина пароля меньше 5 символов")]
        public string Password { get; set; }
    }
}