using System;
using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microservice.Whatevers.Domain.Entities;
using Microservice.Whatevers.Services.Models;
using Microservice.Whatevers.Data.Repositories;

namespace Microservice.Whatevers.Services
{
    public abstract class BaseService<TEntity, TModel> : IService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        protected BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            if (id == Guid.Empty) return;
            _repository.Delete(id);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty) return;
            await _repository.DeleteAsync(id, cancellationToken);
        }

        public TModel Edit(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _repository.Update(entity);
            return _mapper.Map<TModel>(entity);
        }

        public async Task<TModel> EditAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _repository.UpdateAsync(entity, cancellationToken);
            return _mapper.Map<TModel>(entity);
        }

        public bool Exists(Guid id) => _repository.Exists(id);

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken) =>
            await _repository.ExistsAsync(id, cancellationToken);

        public IList<TModel> GetAll() =>
            _repository.SelectAll()
               .ProjectTo<TModel>(_mapper.ConfigurationProvider)
               .ToList();

        public async Task<IList<TModel>> GetAllAsync(CancellationToken cancellationToken) =>
            await _repository.SelectAll()
               .ProjectTo<TModel>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

        public TModel GetById(Guid id) => _mapper.Map<TModel>(_repository.SelectById(id));

        public async Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _mapper.Map<TModel>(await _repository.SelectByIdAsync(id, cancellationToken));

        public TModel Save(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _repository.Insert(entity);
            return _mapper.Map<TModel>(entity);
        }

        public async Task<TModel> SaveAsync(TModel model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _repository.InsertAsync(entity, cancellationToken);
            return _mapper.Map<TModel>(entity);
        }
    }
}