public class Etiqueta : IEtiqueta
{
    public Task Emitir()
    {
        _ = Task.Run(() => Console.WriteLine($"Imprimindo etiqueta {DateTime.Now}"));
        return Task.CompletedTask;
    }
}