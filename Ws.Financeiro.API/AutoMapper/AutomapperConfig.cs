using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Ws.Financeiro.API.ViewModels;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.API.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Gasto, GastoViewModel>().ReverseMap();
        }
    }
}
