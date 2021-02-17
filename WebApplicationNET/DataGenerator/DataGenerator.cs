using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNET.Models;

namespace WebApplicationNET.DataGenerator
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NegociosDBContext(serviceProvider.GetRequiredService<DbContextOptions<NegociosDBContext>>()))
            {
                if (context.Negocios.Any())
                {
                    return;
                }

                context.Negocios.AddRange(
                    new Negocio
                        {
                        Id = 1,
                        Name = "NegocioLunes",
                        DiaDeLaSemana = DayOfWeek.Monday,
                        HorarioApertura = "09:00",
                        HorarioCierre = "18:00"
                        },
                    new Negocio
                    {
                        Id = 2,
                        Name = "NegocioMartes",
                        DiaDeLaSemana = DayOfWeek.Tuesday,
                        HorarioApertura = "10:00",
                        HorarioCierre = "19:00"
                    },
                    new Negocio
                    {
                        Id = 3,
                        Name = "NegocioMiercoles",
                        DiaDeLaSemana = DayOfWeek.Wednesday,
                        HorarioApertura = "11:00",
                        HorarioCierre = "20:00"
                    },
                    new Negocio
                    {
                        Id = 4,
                        Name = "NegocioJueves",
                        DiaDeLaSemana = DayOfWeek.Thursday,
                        HorarioApertura = "12:00",
                        HorarioCierre = "21:00"
                    },
                    new Negocio
                    {
                        Id = 5,
                        Name = "NegocioViernes",
                        DiaDeLaSemana = DayOfWeek.Friday,
                        HorarioApertura = "13:00",
                        HorarioCierre = "22:00"
                    },
                    new Negocio
                    {
                        Id = 6,
                        Name = "NegocioSabado",
                        DiaDeLaSemana = DayOfWeek.Saturday,
                        HorarioApertura = "14:00",
                        HorarioCierre = "23:00"
                    },
                    new Negocio
                    {
                        Id = 7,
                        Name = "NegocioDomingo",
                        DiaDeLaSemana = DayOfWeek.Sunday,
                        HorarioApertura = "15:00",
                        HorarioCierre = "00:00"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
