using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SISAPI.Models
{
    public class BasicHttpAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (Thread.CurrentPrincipal.Identity.Name.Length == 0)
            {
                // Get the header value
                AuthenticationHeaderValue auth = actionContext.Request.Headers.Authorization;
                // ensure its schema is correct
                if (auth != null && string.Compare(auth.Scheme, "Basic", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    // get the credientials
                    string credentials = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(auth.Parameter));
                    int separatorIndex = credentials.IndexOf(':');
                    if (separatorIndex >= 0)
                    {
                        // get user and password
                        string passedUserName = credentials.Substring(0, separatorIndex);
                        string passedPassword = credentials.Substring(separatorIndex + 1);
                        string userName = System.Configuration.ConfigurationManager.AppSettings["username"];
                        string password = System.Configuration.ConfigurationManager.AppSettings["password"];

                        // validate
                        if (passedUserName == userName && passedPassword == password)
                        {
                            Thread.CurrentPrincipal = actionContext.ControllerContext.RequestContext.Principal = new GenericPrincipal(new GenericIdentity(userName, "Basic"), new string[] { });
                        }
                    }
                }
            }
            return base.IsAuthorized(actionContext);
        }
    }
}