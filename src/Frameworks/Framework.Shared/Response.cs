using Flunt.Notifications;

namespace Framework.Shared
{
    public class Response : Notifiable
    {
        public object Result { get; }

        public Response()
        {

        }

        public Response(object result)
        {
            Result = result;
        }
    }
}
