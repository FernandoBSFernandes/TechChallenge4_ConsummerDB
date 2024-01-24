using AutoMapper;

namespace Consummer.Profiles
{
    public class ConsummerProfile : Profile
    {
        public ConsummerProfile()
        {
            CreateMap<Core.Model.Usuario, Core.TableModel.Usuario>();
        }
    }
}
