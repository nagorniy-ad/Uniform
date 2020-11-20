using AutoMapper;

namespace Uniform.Services
{
    public static class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperFormServiceProfile>(); });
            return new Mapper(mapperConfiguration);
        }
    }
}
