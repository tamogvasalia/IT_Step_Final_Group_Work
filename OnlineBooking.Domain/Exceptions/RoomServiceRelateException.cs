using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.Domain.Exceptions
{
    public class RoomServiceRelateException : Exception
    {
        public RoomServiceRelateException()
        {
        }

        public RoomServiceRelateException(string? message) : base(message)
        {
        }

        public RoomServiceRelateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoomServiceRelateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
