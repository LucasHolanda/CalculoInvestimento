using AutoMapper;
using CalculoInvestimento.Domain.Service;
using MediatR;

namespace CalculoInvestimento.WebApi.CalcularCdb
{
    public class CalcularCdbHandler : IRequestHandler<CalcularCdbCommand, InvestimentoCdbDto>
    {
        private readonly ICalcularCdbService _calcularCdbService;
        private readonly IMapper _mapper;

        public CalcularCdbHandler(ICalcularCdbService calcularCdbService, IMapper mapper)
        {
            _calcularCdbService = calcularCdbService;
            _mapper = mapper;
        }

        public async Task<InvestimentoCdbDto> Handle(CalcularCdbCommand command, CancellationToken cancellationToken)
        {
            var investimentoCdb = await _calcularCdbService.CalcularAsync(command.Valor, command.PrazoMeses);
            if(investimentoCdb == null)
            {
                throw new InvalidOperationException("Nao foi possivel calcular o CDB!");
            }

            var result = _mapper.Map<InvestimentoCdbDto>(investimentoCdb);
            return result;
        }
    }
}