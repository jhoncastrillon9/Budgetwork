using Badgetwork.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Badgetwork.Infrastructure.Repository
{
    public class BaseRepository<TEntity> where TEntity : class, new()
    {
        protected BadgetworkContext _entities;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(BadgetworkContext entities)
        {
            _entities = entities;
            _dbSet = entities.Set<TEntity>();
        }

        /// <summary>
        /// Retorna todas las entidades
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Consulta una entidad por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Inserta la entidad pero no la guarda
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);            
        }

        /// <summary>
        /// Insertar un rango
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<Boolean> InsertRange(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return await _entities.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Inserta y guarda la entidad en DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Boolean> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await _entities.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Inserta y guarda varias entidades
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<Boolean> CreateBatch(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return await _entities.SaveChangesAsync() > 0;
        }


        /// <summary>
        /// Actualiza una entidad y guarda la info
        /// </summary>
        /// <param name="editedEntity"></param>
        /// <param name="originalEntity"></param>
        /// <param name="changed"></param>
        /// <returns></returns>
        public Task Modify(TEntity entity, out bool changed)
        {

            changed = _entities.Entry(entity).State == EntityState.Modified;

            return _entities.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina una entidad y guardar\
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);

            return _entities.SaveChangesAsync();
        }

        /// <summary>
        /// Consulta listado filtrando
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> condition)
        {
            return await _dbSet.Where(condition).ToListAsync();
        }

        /// <summary>
        /// Guardar Cambios
        /// </summary>
        /// <returns></returns>
        public Task SaveChanges()
        {
            return _entities.SaveChangesAsync();
        }
    }
}
