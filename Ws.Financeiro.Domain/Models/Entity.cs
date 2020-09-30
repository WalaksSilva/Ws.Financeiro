using System.ComponentModel.DataAnnotations;

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
