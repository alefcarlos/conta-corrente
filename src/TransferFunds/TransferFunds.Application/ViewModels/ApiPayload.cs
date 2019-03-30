namespace TransferFunds.Application.ViewModels
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
