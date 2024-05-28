using System.Runtime.Serialization;

namespace OnlineBooking.Domain.Exceptions
{
    public class BookRelatedException : Exception
    {
        public BookRelatedException()
        {
        }

        public BookRelatedException(string? message) : base(message)
        {
        }

        public BookRelatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BookRelatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
