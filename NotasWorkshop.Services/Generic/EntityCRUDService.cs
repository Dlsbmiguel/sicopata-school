﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SicopataSchool.Core.BaseModel.BaseEntity;
using SicopataSchool.Core.BaseModel.BaseEntityDto;
using SicopataSchool.Model.Contexts.SicopataSchool;
using SicopataSchool.Model.Repositories;
using SicopataSchool.Model.UnitOfWorks;

namespace SicopataSchool.Services.Generic
{
    public class EntityCRUDService<TEntity, TEntityDto> : IEntityCRUDService<TEntity, TEntityDto> where TEntity : class, IBaseEntity
      where TEntityDto : class, IBaseEntityDto
    {

        protected IMapper _mapper { get; set; }
        protected IUnitOfWork<ISicopataSchoolDbContext> _uow { get; set; }
        protected readonly IRepository<TEntity> _repository;

        public EntityCRUDService(IMapper mapper, IUnitOfWork<ISicopataSchoolDbContext> uow)
        {
            _mapper = mapper;
            _uow = uow;
            _repository = _uow.GetRepository<TEntity>();
        }

        public virtual IQueryable<TEntity> Get()
        {
            var list = _repository.GetAll();
            return list;
        }
        public virtual async Task<TEntityDto> GetById(int id)
        {
            TEntity entity = _repository.GetByIdAsNoTracking(id);

            if (entity is null)
                return null;

            //TEntity result =  Task.FromResult(entity);

            TEntityDto dto = _mapper.Map<TEntityDto>(entity);

            return dto;
        }
        public virtual async Task<TEntityDto> Save(TEntityDto entityDto)
        {
            TEntity entity = _mapper.Map<TEntity>(entityDto);
            _repository.Add(entity);
            await _uow.Commit();

            entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }
        public virtual async Task<TEntityDto> Update(int id, TEntityDto entityDto)
        {
            TEntity entity = _repository.GetById(id);
            if (entity is null)
                return null;

            _mapper.Map(entityDto, entity);

            _repository.Update(entity);

            await _uow.Commit();

            entityDto = _mapper.Map(entity, entityDto);

            return entityDto;
        }
        public virtual async Task<TEntityDto> Delete(int id)
        {
            TEntity entity = _repository.GetById(id);

            if (entity is null)
                return null;

            _repository.Delete(entity);
            await _uow.Commit();

            TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }
    }
}
