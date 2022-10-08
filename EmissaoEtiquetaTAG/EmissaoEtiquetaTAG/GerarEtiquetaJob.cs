using Quartz;

internal class GerarEtiquetaJob : IJob
{
    private readonly IEtiqueta _etiqueta;
    public GerarEtiquetaJob(IEtiqueta etiqueta)
    {
        _etiqueta = etiqueta;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        await _etiqueta.Emitir();
    }
}