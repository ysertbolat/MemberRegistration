using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new() //generic yapacağımız için T verdik çünkü birçok yerde kullanacağız
                                        // T'nin belirli yerlerde kullanmak için versiyonlarını yazdık
    {
        List<T> GetList(Expression<Func<T,bool>> filter=null); //istersek datanın tümünü ya da bir kısmını göndermek için expression'dan yararlandık

        T Get(Expression<Func<T, bool>> filter = null); //tek nesne döndürmek için

        T Add(T entity); //temel operasyonlar

        T Update(T entity);

        void Delete(T entity);
    }
}
