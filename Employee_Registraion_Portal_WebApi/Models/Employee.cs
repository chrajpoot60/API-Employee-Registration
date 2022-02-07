using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Registraion_Portal_WebApi.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        //if required used here then we need to provide each required field during put()
        public string EmpName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "tinyint")]
        public int Gender { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string EmailId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(6)")]
        public string Pincode { get; set; }
        //[Column(TypeName = "tinyint")]
        public byte IsActive { get; set; } //automatically create column in database as tinyint 
    }
}
