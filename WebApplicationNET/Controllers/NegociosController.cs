using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationNET.Models;

namespace WebApplicationNET.Controllers
{
    [Route("api/Negocios")]
    [ApiController]
    public class NegociosController : ControllerBase
    {
        private readonly NegociosDBContext _context;

        public NegociosController(NegociosDBContext context)
        {
            _context = context;
        }

        // GET: api/Negocios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Negocio>>> GetNegocios()
        {
            return await _context.Negocios.ToListAsync();
        }

        // GET: api/Negocios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Negocio>> GetNegocio(int id)
        {
            var negocio = await _context.Negocios.FindAsync(id);

            if (negocio == null)
            {
                return NotFound();
            }

            return negocio;
        }

        // GET: api/Negocios/NegocioDomingo/2020/01/12
        [HttpGet("{negocioNombre}/{año}/{mes}/{dia}")]
        public async Task<ActionResult<HorarioNegocio>> GetHorarios(string negocioNombre, string año, string mes, string dia)
        {
            DateTime fecha = FormatDate(año, mes,dia);                      
            
            DayOfWeek diaDeLaSemana = fecha.DayOfWeek;

            var negocio = _context.Negocios.Where(x => x.DiaDeLaSemana == diaDeLaSemana && x.Name == negocioNombre);

            if (negocio == null)
            {
                return NotFound();
            }

            HorarioNegocio horarioNegocio = new HorarioNegocio();

            horarioNegocio.HorarioApertura = negocio.FirstOrDefault().HorarioApertura;
            horarioNegocio.HorarioCierre = negocio.FirstOrDefault().HorarioCierre;

            return horarioNegocio;
        }

        private DateTime FormatDate(string año, string mes, string dia)
        {
            return Convert.ToDateTime(String.Format("{0}-{1}-{2}", año, mes, dia));
        }
    }
}
