using System;
using System.ComponentModel.DataAnnotations;

namespace MarvelVsDC.Dominio
{
    public class WeakPoint
    {
        public TipoDoPontoFraco Type { get; set; }
        [RegularExpression(@"^[\S][a-zA-Z\s]+$", ErrorMessage = "Caracteres não permitido.")]
        [MaxLength(100, ErrorMessage = "O campo name não pode ter mais de 100 caracteres.")]
        public string name { get; set; }
        [RegularExpression(@"^[\S][a-zA-Z\s]+$", ErrorMessage = "Caracteres não permitido.")]
        [MaxLength(100, ErrorMessage = "O campo description não pode ter mais de 100 caracteres.")]
        public string Description { get; set; }
        [Range(1, Double.PositiveInfinity, ErrorMessage = "O campo damage não pode ser menor que 1.")]
        public double Damage { get; set; }
    }

    public enum TipoDoPontoFraco
    {
        Love,
        Joia,
        Place,
        Artefato,
        Inimigo
    }
}