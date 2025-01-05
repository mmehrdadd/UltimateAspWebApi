using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Company Name Is a Required Field")]
        [MaxLength(60, ErrorMessage = "Maximum Length is 60 Charactars")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Company Address Is a Required Field")]
        [MaxLength(60, ErrorMessage = "Maximum Length is 60 Charactars")]
        public string? Address { get; set; }
        public string? Country { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
