using System;
using Data.Repositories;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IEmployeeRepository Employee{ get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        // ReSharper disable UnassignedField.Local
        private readonly EmployeeContext _dbContext;
        private bool _disposed;
        // ReSharper restore UnassignedField.Local


        private IEmployeeRepository _employeeRepository;

        public IEmployeeRepository Employee
        {
            get
            {
                return _employeeRepository ??
                       (_employeeRepository = new EmployeeRepository(_dbContext));
            }
        }

        public UnitOfWork()
        {
            _dbContext = new EmployeeContext();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // not sure what this does but it was used in an example
        }
    }
}
