using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelVsDC.Dominio
{
    public class Vilao
    {
        public string Id { get; set; }
        [RegularExpression(@"^[\S][a-zA-Z\s]+$", ErrorMessage = "Caracteres não permitido.")]
        [MaxLength(100, ErrorMessage = "O campo nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }
        public bool IsMarvel { get; set; }
        public bool IsDC { get; set; }
        public List<Poder> Power { get; set; }
        public List<WeakPoint> PontoFraco { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "O campo Life não pode ser menor que 1.")]
        public int Life { get; set; }
        [RegularExpression(@"^[\S][a-zA-Z\s]+$", ErrorMessage = "Caracteres não permitido.")]
        [MaxLength(100, ErrorMessage = "O campo local de origem não pode ter mais de 100 caracteres.")]
        public string LocalDeorigem { get; set; }
    }
}
