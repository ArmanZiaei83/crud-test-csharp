﻿using Mc2.CrudTest.Persistence.Contexts;
using Mc2.CrudTest.Persistence.InMemoryDatabase;

namespace Mc2.CrudTest.AcceptanceTests.Infrastructures
{
    public class TestProvider
    {
        protected readonly EFDataContext _dataContext;
        protected readonly EFDataContext _readDataContext;

        protected TestProvider()
        {
            EFInMemoryDatabase memoryDatabase = new EFInMemoryDatabase();
            _dataContext = memoryDatabase.CreateDataContext<EFDataContext>();
            _readDataContext =
                memoryDatabase.CreateDataContext<EFDataContext>();
        }

        protected void Save<T>(T entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}