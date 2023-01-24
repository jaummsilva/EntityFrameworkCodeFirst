using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    public class Cliente
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Nome muito grande")]
        public string Nome { get; set; }
        public void Salvar()
        {
            var db = new BaseContext();
            db.Clientes.Add(this);
            db.SaveChanges();
        }

        public List<Cliente> Todos()
        {
            var db = new BaseContext();
            return db.Clientes.ToList();
        }
    }
}
