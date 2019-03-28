using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.WebAPI.Responses
{
    /// <summary>
    /// Payload para responses
    /// </summary>
    public sealed class PayloadResponse<TData> : PayloadResponse
    {
        private PayloadResponse() { }

        /// <summary>
        /// Dado de retorno de uma determinada operação
        /// </summary>
        public TData Data { get; private set; }

        public static PayloadResponse<T> Create<T>(T data, bool succes = true)
        {
            return new PayloadResponse<T>
            {
                Data = data,
                Success = succes
            };
        }
    }

    /// <summary>
    /// Payload para responses
    /// </summary>
    public class PayloadResponse
    {
        /// <summary>
        /// Indica se a operação foi realizada com sucesso
        /// </summary>
        public bool Success { get; set; }

        public static PayloadResponse Create(bool succes = true)
        {
            return new PayloadResponse
            {
                Success = succes
            };
        }
    }
}
