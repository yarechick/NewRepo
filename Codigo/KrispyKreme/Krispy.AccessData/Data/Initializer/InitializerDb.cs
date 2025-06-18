
using Krispy.AccessData.Data.Initializer.Initializer;
using Krispy.Models.Model.Catalogs;
using Krispy.Models.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Krispy.AccessData.Data.Initializer
{
    public class InitializerDb : IInitializerDb
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<InitializerDb> _logger;

        public InitializerDb(IServiceProvider serviceProvider, ILogger<InitializerDb> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public void MigrateAndSeed()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                _logger.LogInformation("Iniciando migración de la base de datos...");
                context.Database.Migrate();

                _logger.LogInformation("Sembrando datos iniciales...");

                if (!context.Sucursal.Any())
                {
                    var sucursalesIniciales = new[]
                    {
                        new Sucursal { Nombre= "Sucursal 1", Direccion ="Dirección S/N", CorreoElectronico = "sucursal1@donas.com", NumeroTelefono = "5588447788", Cp ="01140",Activo = true },
                        new Sucursal { Nombre= "Sucursal 2", Direccion ="Dirección S/N", CorreoElectronico = "sucursal2@donas.com", NumeroTelefono = "5583447788", Cp ="01141",Activo = true },
                        new Sucursal { Nombre= "Sucursal 3", Direccion ="Dirección S/N", CorreoElectronico = "sucursal3@donas.com", NumeroTelefono = "5567447788", Cp ="01142",Activo = true },
                        new Sucursal { Nombre= "Sucursal 4", Direccion ="Dirección S/N", CorreoElectronico = "sucursal4@donas.com", NumeroTelefono = "5588449088", Cp ="01143",Activo = true },
                        new Sucursal { Nombre= "Sucursal 5", Direccion ="Dirección S/N", CorreoElectronico = "sucursal5@donas.com", NumeroTelefono = "5586847890", Cp ="01144",Activo = true }

                    };

                    context.Sucursal.AddRange(sucursalesIniciales);
                    context.SaveChanges();

                }

                if (!context.EstatusOrden.Any())
                {
                    var estatusOrdenIniciales = new[]
                    {
                        new EstatusOrden { Nombre= "Pendiente de pago", Descripcion ="Orden pendiente", Activo = true },
                        new EstatusOrden { Nombre= "Pagada", Descripcion ="Orden cancelada", Activo = true },
                        new EstatusOrden { Nombre= "Cancelada", Descripcion ="Orden cancelada", Activo = true },

                    };

                    context.EstatusOrden.AddRange(estatusOrdenIniciales);
                    context.SaveChanges();

                }


                _logger.LogInformation("Datos iniciales sembrados correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante la migración o siembra de datos.");
                throw;
            }
        }
    }
}
