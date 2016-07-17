using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Respostas
    {
        [Key]
        public long? RespostaId { get; set; }
        [DisplayName("Descrição da Resposta")]
        [Required(ErrorMessage ="Resposta Obrigatória")]
        public string DescResposta { get; set; }

        [DisplayName("Alternativa Correta")]
        [Required(ErrorMessage ="Alternativa Obrigatória")]
        public string AltCorreta { get; set; }
    }
}