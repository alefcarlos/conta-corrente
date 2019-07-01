using Flunt.Notifications;

namespace Framework.Shared
{
    public class Response : Notifiable
    {
        public object Result { get; private set; }

        public Response()
        {

        }

        public Response(object result)
        {
            SetResult(result);
        }

        public void SetResult(object result)
        {
            Result = result;
        }
    }
}
