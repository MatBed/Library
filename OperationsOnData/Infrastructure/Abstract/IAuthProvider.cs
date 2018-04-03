using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationsOnData.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string number, string accessKey);
    }
}