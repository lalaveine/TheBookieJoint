using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheBookieJoint.Models {

    public class Product {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название книги")]
        [RegularExpression(@"([\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo} -.,0-9]+)", ErrorMessage = "Поле \"Название книги\" может содержать только буквы (в т.ч. иероглифы), цифры, пробелы, дефисы, точки и запятые")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя и фамилию автора книги")]
        [RegularExpression(@"([\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo} -]+)", ErrorMessage = "Поле \"Автор\" может содержать только буквы (в т.ч. иероглифы), пробелы и дефисы")]
        [StringLength(100)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имена и фамилии переводчиков книги")]
        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Переводчики\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(500)]
        public string Translators { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите описание книги")]
        // [RegularExpression(@"([\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo} -.,]+)", ErrorMessage = "Поле \"Описание\" может содержать только буквы (в т.ч. иероглифы), точки, запятые, пробелы и дефисы")]
        [StringLength(1500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите язык оригинала книги")]
        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Язык оригинала\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(100)]
        public string OriginalLanguage { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите язык этого издания книги")]
        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Язык издания\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(100)]
        public string Language { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ISBN")]
        [RegularExpression(@"([0-9-]+)", ErrorMessage = "Поле \"ISBN\" может содержать только цифры и дефисы")]
        [StringLength(100)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите жанр книги")]
        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Жанр\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(100)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите издателя книги")]
        [RegularExpression(@"([\p{IsCyrillic} -.,]+)", ErrorMessage = "Поле \"Издатель\" может содержать только кириллические символы, точки, запятые, пробелы и дефисы")]
        [StringLength(100)]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите год издания книги")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Поле \"Год издания\" может содержать только цифры")]
        [StringLength(100)]
        public string PublicationYear { get; set; }

        [Range(0, uint.MaxValue, ErrorMessage = "Это поле должно содержать положительное число")]
        public uint NumberOfCopies { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть положительным числом")]
        public decimal Price { get; set; }
        
    }
}
