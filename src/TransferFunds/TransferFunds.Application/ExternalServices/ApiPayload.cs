namespace TransferFunds.Application.ExternalServices
{
    /// <summary>
    /// Payload das apis
    /// </summary>
    public class ApiPayload<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
    }
}
