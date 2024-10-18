using AutoMapper;

namespace IdentityServer.WebApi.Assemblers.Implementors {
    public abstract class BaseModelAssembler {
        protected IMapper mapper {
            get {
                return MappingInitializer.Instance.Mapper;
            }
        }

        protected BaseModelAssembler() { }
    }
}

