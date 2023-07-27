using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.Entity
{
    public class TokenDB
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
