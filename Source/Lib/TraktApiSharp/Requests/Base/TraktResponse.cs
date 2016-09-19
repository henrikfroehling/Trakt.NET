namespace TraktApiSharp.Requests.Base
{
    using Exceptions;
    using System;

    public class TraktResponse<T> : ITraktResponseHeaders
    {
        public bool HasValue { get; }

        private T _value;

        public T Value
        {
            get
            {
                if (HasValue)
                    return _value;
                else
                    throw new InvalidOperationException("response has no value");
            }
        }

        public TraktException Exception { get; set; }

        public int? UserCount { get; set; }

        public string SortBy { get; set; }

        public string SortHow { get; set; }

        public TraktResponse(T value)
        {
            _value = value;
            HasValue = true;
        }

        public TraktResponse(TraktException exception)
        {
            Exception = exception;
            HasValue = false;
        }

        public static explicit operator T(TraktResponse<T> response) => response.Value;

        public static implicit operator TraktResponse<T>(T value) => new TraktResponse<T>(value);

        public override bool Equals(object obj)
        {
            if (obj is TraktResponse<T>)
                return Equals((TraktResponse<T>)obj);

            return false;
        }

        public bool Equals(TraktResponse<T> other)
        {
            if (HasValue && other.HasValue)
                return Equals(_value, other._value);

            return HasValue == other.HasValue;
        }

        public override int GetHashCode() => HasValue ? Value.GetHashCode() : base.GetHashCode();
    }
}
