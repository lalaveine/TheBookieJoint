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
        [RegularExpression(@"([\p{IsCyrillic} -]+)", ErrorMessage = "Поле \"Имя и фамилия\" может содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(100, ErrorMessage = "Имя и фамилия не может быть больше 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните первый адрес")]
        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Адрес\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(100)]
        public string Line1 { get; set; }

        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Адрес\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(100)]
        public string Line2 { get; set; }

        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Адрес\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(100)]
        public string Line3 { get; set; }
        
        [Required(ErrorMessage = "Пожалуйста введите название страны")]
        [RegularExpression(@"([\p{IsCyrillic} -]+)", ErrorMessage = "Поле \"Страна\" может содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(100)]
        public string Country { get; set; }


        [Required(ErrorMessage = "Пожалуйста, ведите название города")]
        [RegularExpression(@"([\p{IsCyrillic} -]+)", ErrorMessage = "Поле \"Город\" может содержать только кириллические символы, пробелы и дефисы")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Пожалуйста, ведите почтовый индекс")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Почтовый индекс может содержать только цифры")]
        [StringLength(100)]
        public string PostalCode { get; set; }

        public bool GiftWrap { get; set; }
    }
}