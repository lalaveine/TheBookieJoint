using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheBookieJoint.Models {
    public class Order {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
        
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        [RegularExpression(@"([\p{IsCyrillic} -]+)", ErrorMessage = "Имя и фамилия могут содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(50, ErrorMessage = "Строка не может быть больше 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните первый адрес")]
        [RegularExpression(@"([а-яА-Я -]+)", ErrorMessage = "Адрес может содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(100)]
        public string Line1 { get; set; }

        [RegularExpression(@"([а-яА-Я -]+)", ErrorMessage = "Адрес может содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(100)]
        public string Line2 { get; set; }

        [RegularExpression(@"([а-яА-Я -]+)", ErrorMessage = "Адрес может содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(100)]
        public string Line3 { get; set; }
        
        [Required(ErrorMessage = "Пожалуйста, ведите название города")]
        [RegularExpression(@"([а-яА-Я -]+)", ErrorMessage = "Название города может содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        [StringLength(100)]
        public string State { get; set; }

        [StringLength(100)]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        [StringLength(100)]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}