using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categorias
    {
        [Key]
        public long? CategoriaId { get; set; }

        [Required(ErrorMessage ="Nome Obrigatório")]
        [DisplayName("Categoria")]
        public string NomeCateg{ get; set; }

        public virtual ICollection<Perguntas> Perguntas { get; set; }
    }
}
