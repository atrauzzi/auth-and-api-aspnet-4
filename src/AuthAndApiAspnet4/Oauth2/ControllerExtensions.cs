using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AuthAndApi.Driver.Oauth2;
using Oauth2Driver = AuthAndApi.Driver.Oauth2.Driver;
using System.Linq;
using System.Web;


namespace AuthAndApi.Aspnet4.Oauth2 {

    public static class ControllerExtensions {

        public struct HandleResult {

            public RedirectResult Redirect { get; }

            public Authorization Authorization { get; }

            public HandleResult(RedirectResult redirect) {
                Redirect = redirect;
                Authorization = null;
            }

            public HandleResult(Authorization authorization) {
                Redirect = null;
                Authorization = authorization;
            }

        }

        public static ActionResult StartOauth2(this Controller controller, Oauth2Driver driver, string returnRouteName = "external-login-return") {

            if(driver.GrantType == Oauth2Driver.GrantTypes.AuthorizationCode) { 

                var returnUri = new Uri(controller.Url.RouteUrl(returnRouteName, new {service = driver.Name}, controller.Request.Url.Scheme));

                var state = driver.Start(returnUri);
                controller.Session.SetAuthAndApiState(state);

                return new RedirectResult(state.AuthorizationUri.ToString());

            }

            throw new NotSupportedException("Unsupported grant type.");

        }

        public static HandleResult HandleOauth2(this Controller controller, Oauth2Driver driver) {

            var requestData = controller.Request.QueryString.Cast<string>().ToDictionary(
                key => key,
                key => controller.Request.QueryString[key]
            );

            if(driver.GrantType == Oauth2Driver.GrantTypes.AuthorizationCode) {

                string authorizationCode;

                if(!requestData.TryGetValue("code", out authorizationCode))
                    throw new HttpException(422, "Invalid authorization code.");

                driver.

            }

            throw new HttpException(404, "Unsupported grant type.");

        }

    }

}
