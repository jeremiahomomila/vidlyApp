using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vidly.Models
{

    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
       
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Memberhship Type")]
        public byte MembershipTypeId { get; set; }

        [Display (Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

    }
}