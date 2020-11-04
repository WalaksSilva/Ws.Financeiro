using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class Login
    {
        public bool success { get; set; }
        public User data { get; set; }
    };

    public class User
    {
        public string accessToken { get; set; }
    };
}
