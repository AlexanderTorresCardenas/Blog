using System.ComponentModel.DataAnnotations;

namespace Blog.Configurations;

public class ConfiguracionesIA
{
    public const string Seccion = "ConfiguracionesIA";
    [Required]
    public required string ModeloTexto { get; set; }
    [Required]
    public required string ModeloImagenes { get; set; }
    [Required]
    public required string ModeloSentimientos { get; set; }
    [Required]
    public required string LlaveOpenAI { get; set; }


}
