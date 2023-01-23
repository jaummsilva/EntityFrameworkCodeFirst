﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    public class Carro
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        [ForeignKey("Modelo")]
        public int ModeloId  { get; set; }
        public virtual Modelo Modelo { get; set; }
        public int Ano { get; set; }

        public void Salvar()
        {
            var db = new BaseContext();
            db.Carros.Add(this);
            db.SaveChanges();
        }

        public List<Carro> Todos()
        {
            var db = new BaseContext();
            return db.Carros.ToList();
        }
    }
}
