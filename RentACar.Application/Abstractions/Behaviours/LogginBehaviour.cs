using MediatR;
using Microsoft.Extensions.Logging;
using RentACar.Application.Abstractions.Messaging;

namespace RentACar.Application.Abstractions.Behaviours
{
    public class LogginBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LogginBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation($"Ejecutando el command request {name}");
                var result = await next();
                _logger.LogInformation($"El comando {name} se ha ejecutado exitosamente");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"El comando ${name} no se ha podidi ejecutar");
                throw;
            }
        }
    }
}
