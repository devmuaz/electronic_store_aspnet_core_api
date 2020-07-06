using AutoMapper;
using ElectronicsStore.Domain.Models;
using ElectronicsStore.Resources;
using ElectronicsStore.Resources.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.Mapping {
    public class ResourceToModelProfile : Profile {

        public ResourceToModelProfile() {
            // Categories Mapping.
            CreateMap<CategorySaveRequest, Category>();
            CreateMap<CategoryUpdateRequest, Category>();

            // Products Mapping.
            CreateMap<ProductSaveRequest, Product>().ForMember(dest => dest.Images, opt => opt.Ignore());

            // Users Mapping.
            CreateMap<UserSignInRequest, User>();
            CreateMap<UserSignUpRequest, User>().ForMember(dest => dest.AvatarImage, opt => opt.Ignore());
        }
    }
}
