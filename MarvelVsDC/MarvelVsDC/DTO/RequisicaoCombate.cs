using System.ComponentModel.DataAnnotations;

namespace MarvelVsDC.DTO
{
    public class RequisicaoCombate
    {
        // [RegularExpression(@"^[\S][0-9\s]+$", ErrorMessage = "Caracteres não permitido.")]
        [MaxLength(100, ErrorMessage = "O campo nome não pode ter mais de 100 caracteres.")]
        public string IdHeroi { get; set; }
        // [RegularExpression(@"^[\S][0-9\s]+$", ErrorMessage = "Caracteres não permitido.")]
        [MaxLength(100, ErrorMessage = "O campo nome não pode ter mais de 100 caracteres.")]
        public string idVilao { get; set; }
        [RegularExpression(@"^[\S][a-zA-Z\s]+$", ErrorMessage = "Caracteres não permitido.")]
        [MaxLength(100, ErrorMessage = "O campo nome não pode ter mais de 100 caracteres.")]
        public string local { get; set; }
    }
}