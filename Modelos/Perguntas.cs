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

        [DisplayName("Alternativa 1")]
        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt1 { get; set; }

        [DisplayName("Alternativa 2")]
        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt2 { get; set; }

        [DisplayName("Alternativa 3")]
        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt3 { get; set; }

        [DisplayName("Alternativa 4")]
        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string Alt4 { get; set; }

        [DisplayName("Alternativa Correta")]
        [Required(ErrorMessage = "Alternativa Obrigatória")]
        public string AltCorreta { get; set; }

        [DisplayName("Descrição da Resposta")]
        [Required(ErrorMessage = "Resposta Obrigatória")]
        public string DescResposta { get; set; }

        //Foren Key
        [DisplayName("Categoria")]
        public long? CategoriaId { get; set; }
        public Categorias Categorias { get; set; }

    }
}