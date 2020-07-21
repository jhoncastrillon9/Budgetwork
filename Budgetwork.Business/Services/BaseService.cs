using Badgetwork.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Budgetwork.Business.Services
{
    public class BaseService<TEntity> where TEntity : class, new()
    {
        private BaseRepository<TEntity> _BaseRepository;
        public BaseService(BaseRepository<TEntity> BaseRepository)
        {
            _BaseRepository = BaseRepository;
        }

        /// <summary>
        /// Retorna el listado de entidades
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _BaseRepository.GetAll();
        }

        /// <summary>
        /// Consulta una entidad por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindById(int id)
        {
            return await _BaseRepository.FindById(id);
        }

        /// <summary>
        /// Inserta la entidad pero no la guarda
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Insert(TEntity entity)
        {
            await _BaseRepository.Insert(entity);
        }

        /// <summary>
        /// Insertar un rango
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<Boolean> InsertRange(IEnumerable<TEntity> entities)
        {
            return await _BaseRepository.InsertRange(entities);
        }

        /// <summary>
        /// Inserta y guarda la entidad en DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Boolean> Create(TEntity entity)
        {
            return await _BaseRepository.Create(entity);
        }

        /// <summary>
        /// Inserta y guarda varias entidades
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<Boolean> CreateBatch(IEnumerable<TEntity> entities)
        {
            return await _BaseRepository.CreateBatch(entities);
        }


        /// <summary>
        /// Actualiza una entidad y guarda la info
        /// </summary>
        /// <param name="editedEntity"></param>
        /// <param name="originalEntity"></param>
        /// <param name="changed"></param>
        /// <returns></returns>
        public async Task<Boolean> Modify(TEntity entity)
        {
            await _BaseRepository.Modify(entity, out bool changed);
            return changed;
        }

        /// <summary>
        /// Elimina una entidad y guardar\
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Delete(TEntity entity)
        {
            return _BaseRepository.Delete(entity);
        }

        /// <summary>
        /// Consulta listado filtrando
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> condition)
        {
            return await _BaseRepository.GetAllBy(condition);
        }

        /// <summary>
        /// Guardar Cambios
        /// </summary>
        /// <returns></returns>
        public Task SaveChanges()
        {
            return _BaseRepository.SaveChanges();
        }

    }
}
