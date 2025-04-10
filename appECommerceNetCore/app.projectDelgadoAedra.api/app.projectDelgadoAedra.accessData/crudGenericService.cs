using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.projectDelgadoAedra.entities;
using app.projectDelgadoAedra.accessData.Context;
using Microsoft.EntityFrameworkCore;

namespace app.projectDelgadoAedra.accessData
{
    public class crudGenericService <TEntityBase> where TEntityBase : EntityBase
    {
        private readonly appDbContext _context;

        public crudGenericService(appDbContext context)
        {
            _context = context;
        }

        public async Task<TEntityBase> InsertEntity(TEntityBase entity)
        {
            await _context.Set<TEntityBase>().AddAsync(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<TEntityBase> SelectEntity(int id)
        {
            var entity = await _context.Set<TEntityBase>().SingleOrDefaultAsync(p => p.Id == id && p!.Estado);
            if (entity == null) return null!;
            return entity;
        }

        public async Task<List<TEntityBase>> SelectEntitiesAll()
        {
            var entities = await _context.Set<TEntityBase>().ToListAsync();
            if (entities == null) return null!;
            return entities;
        }
        public async Task UpdateEntity(TEntityBase entity)
        {
            _context.Set<TEntityBase>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<TEntityBase>().SingleOrDefaultAsync(p => p.Id==id);

            if (entity == null) return;

            _context.Set<TEntityBase>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
