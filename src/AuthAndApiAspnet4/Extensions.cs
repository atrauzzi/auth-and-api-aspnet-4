using System.Web;


namespace AuthAndApi.Aspnet4 {

    public static class Extensions {

        public static void SetAuthAndApiState(this HttpSessionStateBase session, State state) {
            session[$"auth_and_api_{state.Key}"] = state;
        }

        public static State GetAuthAndApiState(this HttpSessionStateBase session, string key) {
            return session[key] as State;
        }

    }

}
