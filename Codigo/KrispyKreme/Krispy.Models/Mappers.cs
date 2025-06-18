using AutoMapper;
using Krispy.Models.Dtos.Catalogs;
using Krispy.Models.Dtos.Transactional;
using Krispy.Models.Dtos.Users;
using Krispy.Models.Model.Catalogs;
using Krispy.Models.Model.Transactional;
using Krispy.Models.Model.Users;
using System.Globalization;

namespace Krispy.Models
{
    public class Mappers : Profile
    {
        public Mappers()
        {

            //User 
            CreateMap<Usuario, AccesoDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            //Catalogs
            CreateMap<Sucursal, SucursalDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();

            //Transactional
            CreateMap<Orden, OrdenGralDto>()
                .ForMember(dest => dest.EstatusOrden, opt => opt.MapFrom(src => src.EstatusOrden.Nombre))
                .ForMember(dest => dest.Vendedor, opt => opt.MapFrom(src => src.Usuario.NombreUsuario))
                .ForMember(dest => dest.Sucursal, opt => opt.MapFrom(src => src.Sucursal.Nombre))
                .ForMember(dest => dest.MetodoPago, opt => opt.MapFrom(src => src.MetodoPago.Nombre))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.FechaOrden, opt => opt.MapFrom(src=> src.FechaOrden.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ReverseMap();
            CreateMap<DetalleOrden, CDetalleOrdenDto>()
                //.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
                //.ForMember(dest => dest.OrdenId, opt => opt.MapFrom(src => src.Orden.OrdenId))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.PrecioUnitario))
                .ReverseMap();
            CreateMap<Orden, COrdenDto>()
                   .ForMember(dest => dest.DetalleOrden, opt => opt.MapFrom(src => src.DetalleOrden))
                   .ReverseMap();

           

        }
    }

}
