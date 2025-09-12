namespace Blog.Services
{
    public interface IServicioUsuarios
    {
        string? ObtenerUsuarioId();
        Task<bool> PuedeUsuarioBorrarComentarios();
        Task<bool> PuedeUsuarioHacerCRUDEntradas();
    }
}
