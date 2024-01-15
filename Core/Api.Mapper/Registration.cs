using Api.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Api.Mapper;
public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper,AutoMapper.Mapper>();
    }
}
