using System.ComponentModel.DataAnnotations;

namespace acervoLivros.Models
{
    public class AcervoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o titulo do livro")]
        public string? Title { get; set; }


        [Required(ErrorMessage = "Digite uma descrição do livro")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "Digite o valor do livro")]
        public double? Price { get; set; }

        public DateTime Updating { get; set; } = DateTime.Now;
    }
}