namespace Blog.Services;

public interface IServicioImagenes
{
    Task<byte[]> GenerarPortadaEntrada(string titulo);
}