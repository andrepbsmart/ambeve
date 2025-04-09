using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Rules;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Profile for mapping between User entity and CreateSaleResponse
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>();

            CreateMap<CreateItemSaleCommand, ItemSale>()
            .ConstructUsing((src, context) =>
            {
                var policy = context.Items["DiscountPolicy"] as IDiscountPolicy;
                return new ItemSale(policy!);
            })
            .AfterMap((src, dest, context) =>
            {
                dest.ProductID = src.ProductID;
                dest.ProductName = src.ProductName;
                dest.Quantity = src.Quantity;
                dest.UnitPrice = src.UnitPrice;
            });

            //CreateMap<CreateItemSaleCommand, ItemSale>()
            // .AfterMap((src, dest, context) =>
            // {
            //     var policy = context.Items["DiscountPolicy"] as IDiscountPolicy;
            //     dest.ApplyDiscountPolicy(policy!);
            // });
        }
    }
}
