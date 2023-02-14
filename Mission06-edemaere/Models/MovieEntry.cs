using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission06_edemaere.Models
{
    public class MovieEntry
    {
        [Required(AllowEmptyStrings = false)]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        public short Year { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Director { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
