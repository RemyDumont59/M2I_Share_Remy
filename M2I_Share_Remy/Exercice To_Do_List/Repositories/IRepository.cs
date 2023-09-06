﻿using System.Linq.Expressions;

namespace Exercice02.Repositories
{
    // cette interface représent les interractions de CRUD
    // que l'on pourra faire ensuite de différentes manières (FakeDb, EFCore, MongoDb, ...)
    public interface IRepository<TEntity> // s'adapte à plusieurs entités
    {
        bool Add(TEntity entity);
        bool Delete(int id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        bool Update(TEntity entity);
    }
}
