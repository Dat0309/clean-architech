using ApplicationCore.Constants;
using System.Globalization;

namespace ApplicationCore.Helpers
{
    /// <summary>
    /// App Exception
    /// </summary>
    public class AppException : ApplicationException
    {
        public AppException() : base() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }

    /// <summary>
    /// Null Table Exception using when not found URL
    /// </summary>
    public class NullTableException : ApplicationException
    {
        public NullTableException() : base(ContentManager.NullTableExceptionMsg) { }
        public NullTableException(string message) : base(message) { }
        public NullTableException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }

    }

    /// <summary>
    /// Invalid Model State Exception
    /// </summary>
    public class InvalidModelStateException : ApplicationException
    {
        public InvalidModelStateException() : base(ContentManager.InvalidModelStateMsg) { }
        public InvalidModelStateException(string message) : base(message) { }
        public InvalidModelStateException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }

    /// <summary>
    /// Invalid Id Exception
    /// </summary>
    public class InvalidIdException : ApplicationException
    {
        public InvalidIdException() : base(ContentManager.InvalidMsg) { }
        public InvalidIdException(string message) : base(message) { }
        public InvalidIdException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }

    /// <summary>
    /// Record Not Found Exception
    /// </summary>
    public class RecordNotFoundException : ApplicationException
    {
        public RecordNotFoundException() : base(ContentManager.RecordNotFoundMsg) { }
        public RecordNotFoundException(string message) : base(message) { }
        public RecordNotFoundException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
