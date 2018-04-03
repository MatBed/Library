using OperationsOnData.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace OperationsOnData.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string number, string accessKey)
        {
            bool result = FormsAuthentication.Authenticate(number, accessKey);
            if (result)
                FormsAuthentication.SetAuthCookie(number, false);

            return result;
        }
    }
}