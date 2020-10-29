using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CustomTag { get; set; }
    }
}
