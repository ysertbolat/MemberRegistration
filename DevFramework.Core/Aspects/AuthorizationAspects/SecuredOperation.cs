using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {
        public string Roles { get; set; } //Productmanager getall kısmından oluşturduğumuz değişken

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(','); //yetkili arasını ayırmak için yazdığımız kod
            bool isAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i])) //mevcut kullanıcı ... rolüne sahipse
                {
                    isAuthorized = true;
                }
            }
            //rollerimiz karşılaştırıp mevcut rollerimiz varsa isAuthorize true olacak

            if (isAuthorized == false)
            {
                throw new SecurityException("You are not authorized!");
            }
            //eğer isAuthorize false ise yukarıdaki yazı karşımıza çıkacak
        }
    }
}
