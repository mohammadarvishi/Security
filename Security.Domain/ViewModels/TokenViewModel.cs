using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.ViewModels
{
    public class TokenViewModel
    {
        public string UserId { get; set; }

        public string Token { get; set; }

    }
}
