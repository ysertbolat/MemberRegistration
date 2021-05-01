using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    //başlamadan önce nuget paketlerinden NHiberNate'i DevFramework.Core kısmına yükleyin
    public abstract class NHibernateHelper : IDisposable //dispose edeceğimiz interface'i oluşturuyoruz
    {
        static ISessionFactory _sessionFactory;

        public virtual ISessionFactory SessionFactory //SessionFactory'i çözümleyecek yapıyı oluşturuyoruz
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); }
        }

        protected abstract ISessionFactory InitializeFactory(); //InitializeFactory'nin döndürülme kısmını yazacağız

        public virtual ISession OpenSession() //context'i açıp kapatmak için bunu yazıyoruz
        {
            return SessionFactory.OpenSession();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this); //GarbageCollector kullanarak SuppressFinalize yapıp çağırıyoruz
        }

        //virtual methodlar = Virtual (sanal metod)‘lar kalıtıldığı sınıflarda içeriği değiştirilebilen metodlardır.
        //GC = Çöp toplayıcısı (garbage collector) heap'te herhangi bir nesne varsa halen bir uygulama tarafından kullanılıp kullanılmadığımı kontrol eder.
        //SuppressFinalize = dispose edilmiş kayıtları bellekten silmek için kullanılır deniyor
        //şuan Nhibernate için hangi veri tabanıyla çalışacaksak ona göre uygun ortam hazırladık ve context'i ayarladık
    }
}
