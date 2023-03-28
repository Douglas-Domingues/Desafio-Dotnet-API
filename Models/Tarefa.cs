using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrilhaApiDesafio.Models
{
    public class Tarefa
    {
        [Key]
        public int IDTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInc { get; set; }
        public DateTime? DataAlt { get; set; }
        public EnumStatusTarefa? Status { get; set; }
    }
}