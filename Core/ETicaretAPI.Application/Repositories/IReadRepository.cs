using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity //where yazarak iki türü de class türünde yaptık.
    {

        IQueryable<T> GetAll(bool tracking = true); //bool tracking = true ile gelecek olan datanın track edilip edilmeyeceğini ifade ediyoruz.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T,bool>>method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);



    }
}
