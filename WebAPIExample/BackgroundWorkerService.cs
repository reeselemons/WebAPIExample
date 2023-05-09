public class BackgroundWorkerService : BackgroundService
{
    public ILogger<BackgroundWorkerService> _logger { get; set; }

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service started.");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Service stopped.");
        return Task.CompletedTask;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //while (!stoppingToken.IsCancellationRequested)
        //{
        //    _logger.LogInformation($"Worker running at: {DateTimeOffset.Now}");
        //    await Task.Delay(1000, stoppingToken);
        //}
    }
}