using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    public class Carro
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Nome não pode passar de 50 caracteres")]
        public string Nome { get; set; }
        [ForeignKey("Modelo")]
        [Required]
        public int ModeloId  { get; set; }
        [Required]
        public virtual Modelo Modelo { get; set; }
        [Required]
        [Range(1970,2023, ErrorMessage ="Ano não permitido")]
        public int Ano { get; set; }


        
        public void Salvar() {
            try
            {
                var db = new BaseContext();
                db.Carros.Add(this);
                db.SaveChanges();
            }
            catch (DbEntityValidationException erro) {

                var mensagens = string.Empty;
                foreach(var verr in erro.EntityValidationErrors)
                {
                    foreach(var ve in verr.ValidationErrors)
                    {
                        mensagens += "Campo: " + ve.PropertyName + " Erro - " + ve.ErrorMessage + ", ";
                    }
                }
                throw new Exception(mensagens);
            }
    }
        public List<Carro> Todos()
        {
            var db = new BaseContext();
            return db.Carros.ToList();
        }
    }
}
