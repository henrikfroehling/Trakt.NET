namespace TraktApiSharp.Experimental.Responses
{
    using Exceptions;
    using System;

    public abstract class ATraktResponse<TContentType> : TraktNoContentResponse
    {
        public bool HasValue { get; }

        protected TContentType _value;

        public TContentType Value
        {
            get
            {
                if (HasValue)
                    return _value;
                else
                    throw new InvalidOperationException("response has no value");
            }
        }

        protected ATraktResponse() : base()
        {
            HasValue = false;
        }

        protected ATraktResponse(TContentType value)
        {
            _value = value;
            HasValue = value != null;
            IsSuccess = value != null;
        }

        protected ATraktResponse(TraktException exception) : base(exception)
        {
            HasValue = false;
        }

        public override bool Equals(object obj)
        {
            if (obj is ATraktResponse<TContentType>)
                return Equals((ATraktResponse<TContentType>)obj);

            return false;
        }

        public bool Equals(ATraktResponse<TContentType> other)
        {
            if (HasValue && other.HasValue)
                return Equals(_value, other._value);

            return HasValue == other.HasValue;
        }

        public override int GetHashCode() => HasValue ? Value.GetHashCode() : base.GetHashCode();
    }
}
