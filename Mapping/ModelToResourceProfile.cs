using AutoMapper;
using ElectronicsStore.Domain.Models;
using ElectronicsStore.Resources;
using ElectronicsStore.Resources.Responses;
using System.Linq;

namespace ElectronicsStore.Mapping {
    public class ModelToResourceProfile : Profile {

        public ModelToResourceProfile() {
            // Categories Mapping.
            CreateMap<Category, CategoryResponse>();

            // Products Mapping.
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(f => f.Filename).ToList()));

            // Users Mapping.
            CreateMap<User, UserResponse>();
        }
    }
}
