using System.Web.Mvc;


namespace AuthAndApi.Aspnet4 {

    public struct CallbackResult {

        public RedirectResult Redirect { get; }

        public bool HasRedirect => Redirect != null;

        public Authorization Authorization { get; }

        public bool HasAuthorization => Authorization != null;

        public CallbackResult(RedirectResult redirect) {
            Redirect = redirect;
            Authorization = null;
        }

        public CallbackResult(Authorization authorization) {
            Redirect = null;
            Authorization = authorization;
        }

    }

}
