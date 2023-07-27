using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.ViewModels
{
    public class InputViewModel
    {
        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string UserId { get; set; }
    }
}
