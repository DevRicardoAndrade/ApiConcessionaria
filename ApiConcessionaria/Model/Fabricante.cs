using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Model
{
    public class Fabricante
    {
        [Key]
        public int FabricanteId { get; set; }
        [Required(ErrorMessage = "Campo Nome do Fabricante é obrigatório!")]
        [MaxLength(255, ErrorMessage = "Campo Nome do Fabricante deve ter no máximo 255 caracteres!")]
        public string? Nome { get; set; }
        public ICollection<Veiculo>? Veiculos { get; set; }
    }
}
