using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vizew.WebUI.Models.Entity
{
    public class Info:BaseEntity
    {

       
        [Required(ErrorMessage = "'{0}' qeyd etmək mütləqdir")]
        [StringLength(150)]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "'{0}' qeyd etmək mütləqdir")]
        [StringLength(150)]
        [DisplayName("Elektron Ünvan")]
        public string Email { get; set; }
        [Required(ErrorMessage = "'{0}' qeyd etmək mütləqdir")]
        [StringLength(150)]
        [DisplayName("Müraciətin məzmunu")]
        public string Message { get; set; }
        [DisplayName("Oxunub")]
        public bool IsRead { get; set; }

    }
}