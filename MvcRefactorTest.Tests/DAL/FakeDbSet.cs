using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRefactorTest.Tests.DAL
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq.Expressions;

    using MvcRefactorTest.Domain;

    public class FakeDbSet<T> : IDbSet<T>
        where T : User  
    {
        private readonly HashSet<T> _data;

        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new HashSet<T>();
            _query = _data.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        T IDbSet<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        T IDbSet<T>.Remove(T entity)
        {
            throw new NotImplementedException();
        }

        T IDbSet<T>.Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<T> Local
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        Type IQueryable.ElementType
        {
            get
            {
                return _query.ElementType;
            }
        }

        Expression IQueryable.Expression
        {
            get
            {
                return _query.Expression;
            }
        }

        IQueryProvider IQueryable.Provider
        {
            get
            {
                return _query.Provider;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public void Add(T item)
        {
            _data.Add(item);
        }

        public void Remove(T item)
        {
            _data.Remove(item);
        }

        public void Attach(T item)
        {
            _data.Add(item);
        }

        public void Detach(T item)
        {
            _data.Remove(item);
        }
    }
}

