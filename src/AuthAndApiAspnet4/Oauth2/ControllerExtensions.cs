using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using AuthAndApi.Oauth2;


namespace AuthAndApi.Aspnet4.Oauth2 {

    public static class ControllerExtensions {

        public static ActionResult StartOauth2AuthorizationCode(this Controller controller, AuthorizationCodeDriver driver, string returnRouteName = "external-login-callback") {

            var returnUri = new Uri(controller.Url.RouteUrl(returnRouteName, new {service = driver.Name}, controller.Request.Url.Scheme));
            
            var state = driver.Start(returnUri);
            controller.Session.SetAuthAndApiState(state);

            return new RedirectResult(state.AuthorizationUri.ToString());

        }

        public static async Task<CallbackResult> Oauth2AuthorizationCodeCallback(this Controller controller, AuthorizationCodeDriver driver) {

            var requestData = controller.Request.QueryString.Cast<string>().ToDictionary(
                key => key,
                key => controller.Request.QueryString[key]
            );

            string stateKey;
            string authorizationCode;

            if (!requestData.TryGetValue("state", out stateKey))
                throw new HttpException(422, "Missing state key.");

            if(!requestData.TryGetValue("code", out authorizationCode))
                throw new HttpException(422, "Missing authorization code.");

            var state = controller.Session.GetAuthAndApiState(stateKey) as AuthorizationCodeState;
            var authorization = await driver.Complete(state, authorizationCode);

            return new CallbackResult(authorization);

        }

        // ToDo: Make an extension method to iterate over pending authorizations and apply them.

    }

}
