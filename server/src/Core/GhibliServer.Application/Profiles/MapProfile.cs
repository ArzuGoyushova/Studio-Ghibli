using AutoMapper;
using GhibliServer.Application.Dtos.About;
using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Dtos.Basket;
using GhibliServer.Application.Dtos.Blog;
using GhibliServer.Application.Dtos.Category;
using GhibliServer.Application.Dtos.Color;
using GhibliServer.Application.Dtos.Event;
using GhibliServer.Application.Dtos.Movie;
using GhibliServer.Application.Dtos.Product;
using GhibliServer.Application.Dtos.Review;
using GhibliServer.Application.Dtos.Role;
using GhibliServer.Application.Dtos.Size;
using GhibliServer.Application.Dtos.Subscription;
using GhibliServer.Application.Dtos.Ticket;
using GhibliServer.Application.Dtos.TicketOrder;
using GhibliServer.Application.Dtos.User;
using GhibliServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IO;
using TicketOrderViewDto = GhibliServer.Application.Dtos.TicketOrder.TicketOrderViewDto;

namespace GhibliServer.Application.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductViewDto>()
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Pictures.Select(p => p.ImageUrl)))
                .ForMember(dest => dest.ColorIds, opt => opt.MapFrom(src => src.ProductColors.Select(pc => pc.ColorId)))
                .ForMember(dest => dest.SizeIds, opt => opt.MapFrom(src => src.ProductSizes.Select(ps => ps.SizeId))).ReverseMap();

            CreateMap<ProductCreateOrUpdateDto, Product>()
                .ForMember(dest => dest.ProductColors, opt => opt.Ignore())
                .ForMember(dest => dest.ProductSizes, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {

                    var existingColorIds = dest.ProductColors.Select(pc => pc.ColorId).ToList();
                    foreach (var cId in src.ColorIds)
                    {
                        if (!existingColorIds.Contains(cId))
                        {
                            dest.ProductColors.Add(new ProductColor { ColorId = cId });
                        }
                    }
                    dest.ProductColors.RemoveAll(pc => !src.ColorIds.Contains(pc.ColorId));


                    var existingSizeIds = dest.ProductSizes.Select(ps => ps.SizeId).ToList();
                    foreach (var sId in src.SizeIds)
                    {
                        if (!existingSizeIds.Contains(sId))
                        {
                            dest.ProductSizes.Add(new ProductSize { SizeId = sId });
                        }
                    }
                    dest.ProductSizes.RemoveAll(ps => !src.SizeIds.Contains(ps.SizeId));
                }).ReverseMap();


            CreateMap<Movie, MovieViewDto>()
               .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Pictures.Select(p => p.ImageUrl))).ReverseMap();


            CreateMap<MovieCreateOrUpdateDto, Movie>().ReverseMap();

            CreateMap<About, AboutCreateOrUpdateDto>().ReverseMap();
            CreateMap<About, AboutViewDto>().ReverseMap();

            CreateMap<Event, EventCreateOrUpdateDto>().ReverseMap();
            CreateMap<Event, EventViewDto>().ReverseMap();

            CreateMap<Blog, BlogCreateOrUpdateDto>().ReverseMap();
            CreateMap<Blog, BlogViewDto>().ReverseMap();

            CreateMap<Color, ColorCreateOrUpdateDto>().ReverseMap();
            CreateMap<Color, ColorViewDto>().ReverseMap();

            CreateMap<Size, SizeCreateOrUpdateDto>().ReverseMap();
            CreateMap<Size, SizeViewDto>().ReverseMap();

            CreateMap<Category, CategoryViewDto>()
            .ForMember(dest => dest.SubCategoryNames, opt => opt.MapFrom(src => src.SubCategories.Select(sub => sub.Name)))
            .ForMember(dest => dest.ProductNames, opt => opt.MapFrom(src => src.Products.Select(prod => prod.Name)))
            .ForMember(dest => dest.BlogTitles, opt => opt.MapFrom(src => src.Blogs.Select(blog => blog.Title)))
            .ForMember(dest => dest.MovieTitles, opt => opt.MapFrom(src => src.Movies.Select(movie => movie.Title))).ReverseMap();

            CreateMap<Category, CategoryCreateOrUpdateDto>().ReverseMap();

            CreateMap<AppUser, UserProfileViewDto>()
                .ForMember(dest => dest.MovieIds, opt => opt.MapFrom(src => src.UserMovies.Select(pc => pc.MovieId))).ReverseMap();

            CreateMap<UserProfileUpdateDto, AppUser>()
                .ForMember(dest => dest.UserMovies, opt => opt.MapFrom(src => src.MovieIds.Select(mId => new UserMovie { MovieId = mId }) ?? new List<UserMovie>()))
                .AfterMap((src, dest) =>
                {
                    if (src.MovieIds != null)
                    {
                        var existingMovieIds = dest.UserMovies?.Select(pc => pc.MovieId).ToList();

                        dest.UserMovies.RemoveAll(pc => !src.MovieIds.Contains(pc.MovieId));

                        foreach (var mId in src.MovieIds)
                        {
                            if (!existingMovieIds.Contains(mId))
                            {
                                dest.UserMovies.Add(new UserMovie { MovieId = mId });
                            }
                        }
                    }

                    if (src.Image != null)
                    {
                        string uniqueFileName = GetUniqueFileName(src.Image.FileName);
                        string uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(src.Image.FileName);

                        string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/users", uniqueFileNameWithExtension);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            src.Image.CopyTo(stream);
                        }

                        dest.ImageUrl = uniqueFileNameWithExtension;
                    }
                }).ReverseMap();

            CreateMap<Ticket, BasketItemAddDto>().ReverseMap();
            CreateMap<Ticket, TicketViewDto>().ReverseMap();
            CreateMap<TicketOrder, TicketOrderAddDto>()
                .ForMember(dest => dest.BasketItems, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<TicketOrder, Dtos.Basket.TicketOrderViewDto>()
                .ForMember(dest => dest.TicketOrderId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<TicketOrder, TicketOrderViewDto>()
                .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets))
               .ReverseMap();
            CreateMap<TicketOrder, UpdatePaymentStatusDto>()
               .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
              .ReverseMap();

            CreateMap<AppUser, UserViewDto>()
                .ReverseMap();
            CreateMap<AppUser, ChangeRolesDto>()
                .ReverseMap();

            CreateMap<IdentityRole, RoleViewDto>()
               .ReverseMap();
            CreateMap<IdentityRole, RoleCreateDto>()
              .ReverseMap();

            CreateMap<Review, ReviewAddDto>()
             .ReverseMap();
            CreateMap<Review, ReviewViewDto>()
             .ReverseMap();

            CreateMap<Subscription, SubscriptionViewDto>()
            .ReverseMap();
            CreateMap<Subscription, SubscriptionAddDto>()
            .ReverseMap();
        }


        public static List<Picture> MapPictures(List<IFormFile> formFiles, string imageType)
        {
            if (formFiles == null || formFiles.Count == 0)
            {
                return new List<Picture>();
            }

            List<Picture> pictures = new List<Picture>();
            string imagesFolderPath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/", "images", imageType);

            foreach (var formFile in formFiles)
            {
                string uniqueFileName = GetUniqueFileName(formFile.FileName);
                string uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(formFile.FileName);

                string filePath = Path.Combine(imagesFolderPath, uniqueFileNameWithExtension);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }

                var picture = new Picture
                {
                    ImageUrl = uniqueFileNameWithExtension
                };
                pictures.Add(picture);
            }
            return pictures;
        }


        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_" + Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
