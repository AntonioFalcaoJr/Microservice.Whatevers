using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Repositories.Base;
using Microservice.Whatevers.Services.Interfaces;
using Microservice.Whatevers.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Services
{
    public abstract class ServiceBase<TEntity, TModel, TId> : IService<TEntity, TModel, TId>
        where TEntity : EntityBase<TId>
        where TModel : BaseModel
        where TId : struct
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity, TId> _repository;

        protected ServiceBase(IRepository<TEntity, TId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(TId id)
        {
            if (Equals(id, Guid.Empty)) return;
            _repository.Delete(id);
        }

        public async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            if (Equals(id, Guid.Empty)) return;
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

        public bool Exists(TId id) => _repository.Exists(id);

        public async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken) =>
            await _repository.ExistsAsync(id, cancellationToken);

        public IList<TModel> GetAll() =>
            _repository.SelectAll()
               .ProjectTo<TModel>(_mapper.ConfigurationProvider)
               .ToList();

        public async Task<IList<TModel>> GetAllAsync(CancellationToken cancellationToken) =>
            await _repository.SelectAll()
               .ProjectTo<TModel>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

        public TModel GetById(TId id) => _mapper.Map<TModel>(_repository.SelectById(id));

        public async Task<TModel> GetByIdAsync(TId id, CancellationToken cancellationToken) =>
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