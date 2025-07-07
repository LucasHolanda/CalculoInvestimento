using AutoMapper;
using CalculoInvestimento.Domain.Entities;

namespace CalculoInvestimento.WebApi.CalcularCdb
{
    public class InvestimentoCdbProfile : Profile
    {
        public InvestimentoCdbProfile()
        {
            CreateMap<InvestimentoCdb, InvestimentoCdbDto>().ReverseMap();
        }
    }
}
