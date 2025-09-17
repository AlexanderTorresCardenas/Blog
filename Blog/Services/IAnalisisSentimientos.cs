namespace Blog.Services;

public interface IAnalisisSentimientos
{
    Task AnalizarComentariosPendientes();
    Task ProcesarLotesPendientes();

}