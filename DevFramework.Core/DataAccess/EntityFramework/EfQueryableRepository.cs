using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        DbContext _context;
        IDbSet<T> _entities; //tablomuz bunu döndürecek


        public EfQueryableRepository(DbContext context) //construcktor ile herhangi bir projeye bağlı olmadan ilerlememizi sağlayacak
        {
            _context = context;
        }
        public IQueryable<T> Table => this.Entities; //T'ye ne verirsem tabloya kendini attach edecek
        //Table çağırıldığında this.Entities return edilecek
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null) //arka arkaya queryableyi çağıracağı için bunu yaptık
                {
                    _entities = _context.Set<T>(); //contexte ne gönderilirse ona abone ol demek
                }
                //null değilse yine aynı tabloyu döndürmesi için 
                return _entities;
            }
        }
    }
}
