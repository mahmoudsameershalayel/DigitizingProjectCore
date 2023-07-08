using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //Product
            CreateMap<Product , CreateUpdateProductDto>().ReverseMap();
            CreateMap<Product , ProductViewModel>().ReverseMap();
            CreateMap<ProductViewModel, CreateUpdateProductDto>().ReverseMap();


            //CategoryOfProduct
            CreateMap<CategoryForProduct , CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForProduct , CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, CreateUpdateCategoryDto>().ReverseMap();


            //Brand
            CreateMap<Brand , CreateUpdateBrandDto>().ReverseMap();
            CreateMap<Brand , BrandViewModel>().ReverseMap();

            //City
            CreateMap<City , CityViewModel>().ReverseMap();
        }
    }
}
