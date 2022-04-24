using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPersonal.Models
{
    public class Personal
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="ФИО")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Профессия")]
        public string Profession { get; set; }
        [Required]
        [Display(Name = "Отдел")]
        public string Department { get; set; }
        [Display(Name = "Зарплата")]
        public int Salary { get; set; }
    }
}