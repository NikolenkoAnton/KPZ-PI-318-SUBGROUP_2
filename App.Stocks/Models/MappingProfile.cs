using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App.Stocks.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Company, CompanyView>()
                //.ForMember("CurrentStocksPrice", comp => comp.AllowNull())
                .ForMember("CurrentStocksPrice", comp => comp.AllowNull())
                //.ForMember("CurrentStocksPrice", comp => comp.MapFrom(c => c.CurrentStocksPrice))
                .AfterMap((src, dest) => dest.CurrentStocksPrice = dest.IsAvailableToView ? dest.CurrentStocksPrice : null);


            CreateMap<IQueryable<Company>, IQueryable<CompanyView>>();

            CreateMap<Stock, StockView>()
                .ForMember(s => s.Cost, st => st.MapFrom(stck => stck.Cost.ToString() + " $"))
                .ForMember("Date", stck => stck.MapFrom(s => s.DateView));

            CreateMap<Stock, StocksListItemView>()
            .ForMember(dest => dest.Cost, (opt) => opt.MapFrom(st => 5 > 0 ? 2 : 5));

            //CreateMap<StocksListView,StocksListView>(MemberList.Source)

            CreateMap<Stock, StocksListItemView>()
                .ForMember(s => s.Date, st => st.MapFrom(stck => stck.DateView));

            
               

            //CreateMap<IEnumerable<Stock>, StocksListView>();
            //.ForMember("Date", comp => comp.MapFrom(c => c.DateView));
            CreateMap<IEnumerable<Stock>, IEnumerable<StockView>>();
        }
    }
}
