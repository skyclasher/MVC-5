using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace MvcMovie.Models
{
    public class Profile
    {
        public int ID { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [DisplayName("First Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirsName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        [Display(Name = "Date Of Birth"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Address { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string City { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string State { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Postal { get; set; }

        [StringLength(1, MinimumLength = 1)]
        [Required]
        public string Gender { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Department { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Designation { get; set; }


        //constructor for default value
        public Profile()
        {
            ID = 0;
            UserId = HttpContext.Current.User.Identity.GetUserId();
        }
    }
}