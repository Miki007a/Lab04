namespace BazaTest
{
    using BazaTest.Data;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Running;
    using Microsoft.EntityFrameworkCore;

    public class BenchmarkRunnerService
    {
        private readonly ApplicationDbContext _context;
        private readonly string? _connectionString;


        public BenchmarkRunnerService(ApplicationDbContext context)
        {
            _context = context;
            _connectionString = _context.Database.GetConnectionString();
        }
        public void Run()
        {


            var config = DefaultConfig.Instance
            .WithOptions(ConfigOptions.DisableOptimizationsValidator) // Disables release mode validation
            .WithOptions(ConfigOptions.DisableLogFile) // Stops excessive logging
            .WithOptions(ConfigOptions.JoinSummary); // Ensures output is merged

            BenchmarkRunner.Run<DatabaseBenchmark>(config);

        }
    }   

}
