using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheBookieJoint.Models {

    public class Product {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Введите название книги")]
        [RegularExpression(@"([\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo} -.,0-9]+)", ErrorMessage = "Название книги может содержать только буквы (в т.ч. иероглифы), цифры, пробелы, дефисы, точки и запятые")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите имя и фамилию автора книги")]
        [RegularExpression(@"([\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo} -]+)", ErrorMessage = "Имя и фамилия могут содержать только буквы (в т.ч. иероглифы), пробелы и дефисы")]
        public string Author { get; set; }
        public string Translators { get; set; }
        public string Description { get; set; }
        public string OriginalLanguage { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string PublicationYear { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное число")]

        public decimal Price { get; set; }
        
    }
}
