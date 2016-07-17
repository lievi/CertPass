using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Perguntas
    {
        [Key]
        public long? PerguntaId { get; set; }
        [DisplayName("Pergunta")]
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string DescPergunta { get; set; }

        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt1 { get; set; }

        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt2 { get; set; }

        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt3 { get; set; }

        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt4 { get; set; }

        //ForengKey
        public long? RespostaId { get; set; }
        public Respostas Resposta { get; set; }

    }
}