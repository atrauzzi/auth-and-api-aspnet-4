using System.Web;


namespace AuthAndApi.Aspnet4 {

    public static class HttpSessionStateBaseExtensions {

        public static void SetAuthAndApiState(this HttpSessionStateBase session, State state) {
            session[$"auth-and-api:state:{state.Key}"] = state;
        }

        public static State GetAuthAndApiState(this HttpSessionStateBase session, string key) {
            return session[$"auth-and-api:state:{key}"] as State;
        }

        public static bool HasAuthAndApiState(this HttpSessionStateBase session, string key) {
            return session.GetAuthAndApiState($"auth-and-api:state:{key}") != null;
        }

        public static bool HasStatelessBridge(this HttpSessionStateBase session) {
            return session.GetStatelessBridge() != null;
        }

        public static State GetStatelessBridge(this HttpSessionStateBase session) {
            return session["auth-and-api:state-bridge"] as State;
        }

        public static void SetStatelessBridge(this HttpSessionStateBase session, State state) {
            session["auth-and-api:state-bridge"] = state;
        }

    }

}
