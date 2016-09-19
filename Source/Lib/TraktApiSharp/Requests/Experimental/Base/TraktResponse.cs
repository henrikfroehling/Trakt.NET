namespace TraktApiSharp.Requests.Experimental.Base
{
    using Exceptions;
    using System;

    public class TraktResponse<TItem> : ITraktResponseHeaders
    {
        public bool HasValue { get; }

        private TItem _value;

        public TItem Value
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

        public TraktResponse(TItem value)
        {
            _value = value;
            HasValue = value != null;
        }

        public TraktResponse(TraktException exception)
        {
            Exception = exception;
            HasValue = false;
        }

        public static explicit operator TItem(TraktResponse<TItem> response) => response.Value;

        public static implicit operator TraktResponse<TItem>(TItem value) => new TraktResponse<TItem>(value);

        public override bool Equals(object obj)
        {
            if (obj is TraktResponse<TItem>)
                return Equals((TraktResponse<TItem>)obj);

            return false;
        }

        public bool Equals(TraktResponse<TItem> other)
        {
            if (HasValue && other.HasValue)
                return Equals(_value, other._value);

            return HasValue == other.HasValue;
        }

        public override int GetHashCode() => HasValue ? Value.GetHashCode() : base.GetHashCode();
    }
}
