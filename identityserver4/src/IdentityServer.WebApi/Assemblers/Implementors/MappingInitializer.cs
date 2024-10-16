using System;
using IdentityServer.WebApi.Assemblers.Implementors.Profiles;
using AutoMapper;

namespace IdentityServer.WebApi.Assemblers.Implementors {
    public sealed class MappingInitializer {
        public IMapper Mapper { get; private set; }

        private static readonly Lazy<MappingInitializer> initializer = new Lazy<MappingInitializer>(() => new MappingInitializer());

        public static MappingInitializer Instance { get { return initializer.Value; } }

        public MappingInitializer() {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserModelProfile>();
            });

            this.Mapper = mapperConfig.CreateMapper();
        }
    }
}

