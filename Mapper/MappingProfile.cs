using AutoMapper;
using Backend.DTO.Brand;
using Backend.DTO.Cart;
using Backend.DTO.Cateogy;
using Backend.DTO.Featured;
using Backend.DTO.Merchant;
using Backend.DTO.Order;
using Backend.DTO.Payment;
using Backend.DTO.Product;
using Backend.DTO.Review;
using Backend.DTO.Shipping;
using Backend.DTO.StockHistory;
using Backend.DTO.Wishlist;
using Backend.Models;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductReadDto>()
            .ForMember(dest => dest.MerchantName, opt => opt.MapFrom(src => src.Merchant != null ? src.Merchant.Name : null))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Category_Name : null))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Brand_Name : null));

            CreateMap<Product, ProductListDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Brand_Name));

            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            //Merchant
            CreateMap<User, MerchantReadDto>();
            CreateMap<MerchantCreateDto, User>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "Merchant"));
            CreateMap<MerchantUpdateDto, User>();

            //Brand
            CreateMap<Brand, BrandReadDto>();
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<BrandUpdateDto, Brand>();

            //Category
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            //Orders
            CreateMap<Order, OrderReadDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderDetails))
            .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
            .ForMember(dest => dest.Shipping, opt => opt.MapFrom(src => src.Shipping));

            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Product_Name));

            CreateMap<Payment, PaymentDto>();
            CreateMap<Shipping, ShippingDto>();

            CreateMap<Order, OrderListDto>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.OrderDetails.Sum(d => d.Unit_Price * d.Quantity)));

            CreateMap<OrderCreateDto, Order>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.Items));

            CreateMap<OrderItemDto, OrderDetail>();


            //Payment
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>()
                    .ForMember(dest => dest.Payment_Date, opt => opt.MapFrom(src => DateTime.Now));


            //Shipping
            CreateMap<Shipping, ShippingReadDto>();
            CreateMap<ShippingCreateDto, Shipping>();
            CreateMap<ShippingUpdateDto, Shipping>();


            //Review
            CreateMap<Review, ReviewReadDto>()
            .ForMember(d => d.CustomerName, o => o.MapFrom(src => src.Customer.Name))
            .ForMember(d => d.ProductName, o => o.MapFrom(src => src.Product.Product_Name));

            CreateMap<ReviewCreateDto, Review>()
            .ForMember(d => d.Review_Date, o => o.MapFrom(src => DateTime.Now));

            CreateMap<ReviewUpdateDto, Review>();


            //Cart
            CreateMap<CartItem, CartItemReadDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Product_Name));
            CreateMap<ShoppingCart, CartReadDto>();
            CreateMap<CartItemCreateDto, CartItem>();

            //Wishlist
            CreateMap<WishlistItem, WishlistItemReadDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Product_Name));
            CreateMap<Wishlist, WishlistReadDto>();
            CreateMap<WishlistItemCreateDto, WishlistItem>();

            //Featured
            CreateMap<FeaturedProduct, FeaturedReadDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Product_Name));

            CreateMap<FeaturedCreateDto, FeaturedProduct>();
            CreateMap<FeaturedUpdateDto, FeaturedProduct>();

            //StockHistory
            CreateMap<StockHistory, StockHistoryReadDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Product_Name));
            CreateMap<StockHistoryCreateDto, StockHistory>();

         }
    }
 }