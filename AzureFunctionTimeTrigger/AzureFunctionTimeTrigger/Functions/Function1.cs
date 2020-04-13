using System;
using System.Diagnostics;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionTimeTrigger.Functions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("%CRONExecucao%", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();
                log.LogInformation("Inicio do processo.");

                // FAÇA ALGUMA COISA AQUI
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

                sw.Stop();
                log.LogInformation($"Fim do processo. Tempo: {sw.Elapsed}");

            }
            catch (Exception ex)
            {
                log.LogError("Erro - Execução Historico de Clientes. Message: {0}.", ex.Message);
            }
        }
    }
}
