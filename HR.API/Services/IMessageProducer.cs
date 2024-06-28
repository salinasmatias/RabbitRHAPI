namespace HR.API.Services
{
    public interface IMessageProducer
    {
        void SendingMessage<T>(T message);
    }
}
