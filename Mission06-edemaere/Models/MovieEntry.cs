using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission06_edemaere.Models
{
    public class MovieEntry
    {
        //Populates automatically
        [Key]
        [Required]
        public int EntryId { get; set; }

        //Required title
        [Required(AllowEmptyStrings = false, ErrorMessage ="Title is required.")]
        public string Title { get; set; }

        //Required year
        [Required(ErrorMessage = "Year is required.")]
        public short Year { get; set; }

        //Required director
        [Required(AllowEmptyStrings = false, ErrorMessage = "No one directed the movie? Yeah right. Please enter the director's name.")]
        public string Director { get; set; }

        //Required rating, but since it's a dropdown there will always be something selected by default
        [Required]
        public string Rating { get; set; }

        //Optional
        public bool Edited { get; set; }

        //Optional
        public string LentTo { get; set; }

        //Optional, limited to 25 characters
        [StringLength(25)]
        public string Notes { get; set; }


        //Foreign Key Relationship for Category table
        [Required(AllowEmptyStrings = false)]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
