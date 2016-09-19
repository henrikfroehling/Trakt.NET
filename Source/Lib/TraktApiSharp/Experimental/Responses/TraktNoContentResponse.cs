namespace TraktApiSharp.Experimental.Responses
{
    using Exceptions;

    public class TraktNoContentResponse
    {
        public bool IsSuccess { get; protected set; }

        public TraktException Exception { get; protected set; }

        internal TraktNoContentResponse()
        {
            IsSuccess = false;
        }

        internal TraktNoContentResponse(TraktException exception)
        {
            Exception = exception;
            IsSuccess = exception == null;
        }

        internal TraktNoContentResponse(bool success)
        {
            IsSuccess = success;
        }

        internal TraktNoContentResponse(bool success, TraktException exception)
        {
            Exception = exception;
            IsSuccess = success;
        }

        public override bool Equals(object obj)
        {
            if (obj is TraktNoContentResponse)
                return Equals((TraktNoContentResponse)obj);

            return false;
        }

        public bool Equals(TraktNoContentResponse other) => IsSuccess == other.IsSuccess && Exception == other.Exception;

        public override int GetHashCode() => base.GetHashCode();
    }
}
