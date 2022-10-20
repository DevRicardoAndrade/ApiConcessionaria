using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiConcessionaria.Model
{
    public class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }
        [Required(ErrorMessage = "Campo Nome do Veículo é obrigatório!")]
        [MaxLength(255, ErrorMessage = "Campo Nome do Veículo deve ter no máximo 255 caracteres!")]
        public string? Nome { get; set; }
        public int? Ano_Fabricacao { get; set; }
        public int? Ano_Modelo { get; set; }
        public int? FabricanteId { get; set; }
        [JsonIgnore]
        public Fabricante? Fabricante { get; set; } 

    }
}
