using MemberRegistration.DataAccess.Concrete.EntityFramework.Mappings;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.DataAccess.Concrete.EntityFramework
{
    public class MembershipContext : DbContext //DbContext için EntityFramework paketini implemente edin
    {
        public MembershipContext()
        {
            Database.SetInitializer<MembershipContext>(null); //hazır bir veri tabanı kullandığımız için veri tabanı üretmiyoruz
        }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MemberMap());
        }
    }
}
