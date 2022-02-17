using MarvelVsDC.Dominio;

namespace MarvelVsDC.DTO
{
    public class ResultadoCombate
    {
        public string IdVencedor { get; set; }
        public Heroi heroi { get; set; }
        public Vilao Vilao { get; set; }
        public string Message { get; set; }
    }
}