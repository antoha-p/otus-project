using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    /// <summary>
    /// Класс исключений для информирования об ошибке при работе с данными 
    /// </summary>
    public class DataOperationException : Exception
    {
        public DataOperationException()
        {
        }

        public DataOperationException(string message)
            : base(message)
        {
        }

        public DataOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DataOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
