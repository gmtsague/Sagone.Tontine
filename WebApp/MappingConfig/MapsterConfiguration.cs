//using Tontine.Entities.Models;
using Mapster;
using System.Reflection;
using System;
using Tontine.Entities.Models_v1_4_sans;

namespace WebApp.MappingConfig
{
    //public static class MapsterConfiguration
    //{
    //    public static void AddMapster(this IServiceCollection services)
    //    {
    //        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
    //        //Assembly applicationAssembly = typeof(BaseDto<,>).Assembly;
    //        //typeAdapterConfig.Scan(applicationAssembly);
    //        typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
    //    }
    //}

    public class MapsterConfig: ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            TypeAdapterConfig.GlobalSettings.Default
                .IgnoreMember((member, side) => member.Name.Equals("CreateAt") || member.Name.Equals("UpdateAt") || member.Name.Contains("Navigation")); // !validTypes.Contains(member.Type));

            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.ConvertSourceMemberName(name => name.Replace("Core", "").Replace("Meet", "").Replace("Navigation", "Ref")));


            config.AdaptTo("[name]Dto").ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), @"Tontine.Entities.Models_v1_4_sans")
            //var adapteur = config.AdaptTo(string.Format("{0}", "[name]Dto").Replace("Core", "")).ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), @"Tontine.Entities.Models_v1_4_sans")
                .ForType<CoreAnnee>(cfg => {
                cfg.Ignore(poco => poco.CreateAt);
                    cfg.Ignore(poco => poco.UpdateAt);
                })
            .ForType<CorePerson>(cfg => {
                cfg.Ignore(poco => poco.CreateAt);
                cfg.Ignore(poco => poco.UpdateAt);
            })
            .ForType<CoreCountry>(cfg => {
                cfg.Ignore(poco => poco.CreateAt);
                cfg.Ignore(poco => poco.UpdateAt);
            })
            .ForType<CoreBank>(cfg => {
                cfg.Ignore(poco => poco.CreateAt);
                cfg.Ignore(poco => poco.UpdateAt);
            })
            .ForType<CoreSubdivision>(cfg => {
                cfg.Ignore(poco => poco.CreateAt);
                cfg.Ignore(poco => poco.UpdateAt);
            });
            //   .ForTypes(Assembly.GetExecutingAssembly().GetTypes()).(cfg => {
            //       cfg.Ignore(poco => poco.CreateAt);
            //       cfg.Ignore(poco => poco.UpdateAt);
            //});

            //TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.ConvertSourceMemberName(name => name.Replace("Meet", "")));


            //     .ForTypes(adapteur.);
            //adapteur(cfg =>
            // {
            //     cfg.Ignore(poco => poco.CreateAt);
            //     cfg.Ignore(poco => poco.UpdateAt);
            // });
            //.ForType<Student>(cfg => {
            //    cfg.Ignore(poco => poco.LastName);
            //});
            //    .ExcludeTypes(typeof(LabosContext))
            //.ExcludeTypes(type => type.IsEnum)
            config.GenerateMapper("[name]Mapper").ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), @"Tontine.Entities.Models_v1_4_sans");
        }
    }
}
