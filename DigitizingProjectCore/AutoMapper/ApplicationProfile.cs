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
            //Service
            CreateMap<Service, CreateUpdateServiceDto>().ReverseMap();
            CreateMap<Service , ServiceViewModel>().ReverseMap();

            //CategoryForService
            CreateMap<CategoryForService, CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForService, CategoryViewModel>().ReverseMap();

            //Product
            CreateMap<Product , CreateUpdateProductDto>().ReverseMap();
            CreateMap<Product , ProductViewModel>().ReverseMap();
            CreateMap<Product , AddProductWithCategoryAndBrand>().ReverseMap();


            //CategoryForProduct
            CreateMap<CategoryForProduct , CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForProduct , CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, CreateUpdateCategoryDto>().ReverseMap();


            //Brand
            CreateMap<Brand , CreateUpdateBrandDto>().ReverseMap();
            CreateMap<Brand , BrandViewModel>().ReverseMap();

            
            //City
            CreateMap<City , CityViewModel>().ReverseMap();


            //Distributor
            CreateMap<Distributor , DistributorViewModel>().ReverseMap();
            CreateMap<Distributor , CreateUpdateDistributorDto>().ReverseMap();
        }
    }
}
