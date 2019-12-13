using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;

namespace ClientApi.Diagnostics
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private string _connectionString = string.Empty;
        public DatabaseHealthCheck(string conenctionString)
        {
            _connectionString = conenctionString;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    await conn.OpenAsync(cancellationToken);
                }
                catch (SqlException ex)
                {
                    return await Task.FromResult(new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex));
                }
            }

            return await Task.FromResult(HealthCheckResult.Healthy("Client Database is Healthy."));
        }
    }
}
