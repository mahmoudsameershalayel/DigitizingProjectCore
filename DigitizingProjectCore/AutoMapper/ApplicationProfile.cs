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
            //User
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, ResetPasswordDto>().ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();


            //Service
            CreateMap<Service, CreateUpdateServiceDto>().ReverseMap();
            CreateMap<Service , ServiceViewModel>().ReverseMap();
            CreateMap<Service, AddServiceWithCategory>().ReverseMap();


            //CategoryForService
            CreateMap<CategoryForService, CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForService, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, CreateUpdateCategoryDto>().ReverseMap();


            //Product
            CreateMap<Product , CreateUpdateProductDto>().ReverseMap();
            CreateMap<Product , ProductViewModel>().ReverseMap();
            CreateMap<Product , AddProductWithCategoryAndBrand>().ReverseMap();


            //CategoryForProduct
            CreateMap<CategoryForProduct , CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForProduct , CategoryViewModel>().ReverseMap();


            //News
            CreateMap<News, CreateUpdateNewsDto>().ReverseMap();
            CreateMap<News, NewsViewModel>().ReverseMap();
            CreateMap<News, AddProductWithCategoryAndBrand>().ReverseMap();


            //PhotoGallery
            CreateMap<PhotoGallery, CreateUpdatePhotoGalleryDto>().ReverseMap();
            CreateMap<PhotoGallery, PhotoGalleryViewModel>().ReverseMap();


            //CategoryForNews
            CreateMap<CategoryForNews, CreateUpdateCategoryDto>().ReverseMap();
            CreateMap<CategoryForNews, CategoryViewModel>().ReverseMap();

            //Solution 
            CreateMap<Solution , CreateUpdateSolutionDto>().ReverseMap();
            CreateMap<Solution , SolutionViewModel>().ReverseMap();
            CreateMap<Solution, AddSolutionWithCategoryAndBrandAndProduct>().ReverseMap();

            //Brand
            CreateMap<Brand , CreateUpdateBrandDto>().ReverseMap();
            CreateMap<Brand , BrandViewModel>().ReverseMap();


            //City
            CreateMap<City , CityViewModel>().ReverseMap();


            //Distributor
            CreateMap<Distributor , DistributorViewModel>().ReverseMap();
            CreateMap<Distributor , CreateUpdateDistributorDto>().ReverseMap();
            CreateMap<Distributor, AddDistibutorWithCity>().ReverseMap();


            //Configuration
            CreateMap<Configuration, SaveConfigurationDto>().ReverseMap();


            //HomePageBanner
            CreateMap<HomePageBanner, CreateUpdateHomePageDto>().ReverseMap();
            CreateMap<HomePageBanner, HomePageViewModel>().ReverseMap();
        }
    }
}
