using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public abstract class Entity
    {
        //protected Entity()
        //{
        //    Id = Guid.NewGuid();
        //}

        public int Id { get; set; }
    }
}
