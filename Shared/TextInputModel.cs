using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrettifyIt.Shared
{
    public class TextInputModel
    {
        [Required]
        [StringLength(5000000, ErrorMessage = "Text is too long.")]
        public string Text { get; set; }
    }
}
