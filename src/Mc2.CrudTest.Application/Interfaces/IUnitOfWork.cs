﻿namespace Mc2.CrudTest.Application.Interfaces;

public interface IUnitOfWork
{
    Task Begin();
    void CommitPartial();
    Task Commit();
    Task Rollback();
    Task Complete();
}