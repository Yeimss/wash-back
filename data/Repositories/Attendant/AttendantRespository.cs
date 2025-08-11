using core.Entities.Attendand;
using core.Interfaces.Repositories.Attendant;
using data.Models.Context;
using DTOs.Attendant;
using Microsoft.EntityFrameworkCore;

namespace data.Repositories.Attendant
{
    public class AttendantRespository : IAttendantRepository
    {
        private readonly LavaderoBDContext _context;
        public AttendantRespository(LavaderoBDContext context)
        {
            _context = context;
        }
        public async Task<Encargado> Get(int id)
        {
            var encargado = await _context.tbl_encargados.Select(e => new Encargado
            {
                Id = e.id,
                Name = e.name,
                Enterprice = e.idEnterpriceNavigation.enterprice,
                IdEnterprice = e.idEnterpriceNavigation.id

            }).FirstOrDefaultAsync(e => e.Id == id);
            return encargado;
        }
        public async Task<List<Encargado>> GetAll(int idEnterprice)
        {
            var encargados = await _context.tbl_encargados.Select(e => new Encargado
            {
                Id = e.id,
                Name = e.name,
                Enterprice = e.idEnterpriceNavigation.enterprice,
                IdEnterprice = e.idEnterpriceNavigation.id

            }).Where(e => e.IdEnterprice == idEnterprice)
            .ToListAsync();
            return encargados;
        }
        public async Task<bool> Insert(AttendantDto attendant)
        {
            tbl_encargado encargado = new tbl_encargado
            {
                name = attendant.Name,
                idEnterprice = attendant.IdEnterprice
            };
            await _context.tbl_encargados.AddAsync(encargado);
            var insertado = await _context.SaveChangesAsync();
            return insertado > 0;
        }
        public async Task<bool> Update(AttendantUpdateDto attendant)
        {
            tbl_encargado? encargado = await _context.tbl_encargados.FindAsync(attendant.Id);
            if (encargado == null)
            {
                return false;
            }
            encargado.idEnterprice = attendant.IdEnterprice;
            encargado.name = attendant.Name;

            _context.tbl_encargados.Update(encargado);
            var actualizado = await _context.SaveChangesAsync();
            return actualizado > 0;
        }
        public async Task<bool> Delete(int id)
        {
            tbl_encargado? encargado = await _context.tbl_encargados.FindAsync(id);
            if (encargado == null)
            {
                return false;
            }

            _context.tbl_encargados.Remove(encargado);
            var eliminado = await _context.SaveChangesAsync();
            return eliminado > 0;
        }
    }
}
