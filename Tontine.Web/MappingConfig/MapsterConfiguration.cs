using Tontine.Web.Dto;
using Mapster;
using System.Reflection;

namespace Tontine.Web.MappingConfig
{
    public static class MapsterConfiguration
    {
        public static void AddMapster(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            Assembly applicationAssembly = typeof(BaseDto<,>).Assembly;
            typeAdapterConfig.Scan(applicationAssembly);
        }
    }

    public class MapsterConfig: ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
           // config.AdaptTo("[name]Dto").ForAllTypesInNamespace(Assembly.LoadFile(@"D:\\Laboratory\\project-Tontine\\src\Sagone.Tontine\\Tontine.Entities\\bin\\Debug\\net7.0\\Tontine.Entities.dll"), @"Tontine.Entities.Models");
            config.AdaptTo("[name]Dto").ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), @"Tontine.Entities.Models");
        }
    }
}
