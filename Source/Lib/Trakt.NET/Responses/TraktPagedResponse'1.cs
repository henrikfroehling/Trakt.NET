namespace TraktNet.Responses
{
    using Exceptions;
    using Interfaces;
    using Requests.Handler;
    using Requests.Interfaces;
    using Requests.Interfaces.Base;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>A Trakt paged list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public class TraktPagedResponse<TResponseContentType>
        : TraktListResponse<TResponseContentType>,
          ITraktPagedResponse<TResponseContentType>,
          IEquatable<TraktPagedResponse<TResponseContentType>>,
          IEqualityComparer<TraktPagedResponse<TResponseContentType>>
    {
        private IRequest<TResponseContentType> _request;
        private TraktClient _client;

        /// <summary>Gets the page count for this response.</summary>
        public int? PageCount { get; set; }

        public int? ItemCount { get; set; }

        /// <summary>Returns whether the response can retrieve the previous page.</summary>
        public bool HasPreviousPage => Page.HasValue && PageCount.HasValue && Page.Value > 1;

        /// <summary>Returns whether the response can retrieve the next page.</summary>
        public bool HasNextPage => Page.HasValue && PageCount.HasValue && Page.Value < PageCount.Value;

        /// <summary>
        /// Gets the previous retrievable page for this response, if <see cref="HasPreviousPage" /> is true.
        /// <para>
        /// If this response is already the first page response or if there are no more pages to retrieve,
        /// this response instance will be returned.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{TResponseContentType}"/> instance containing the items of the previous page and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <typeparamref name="TResponseContentType" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TResponseContentType>> GetPreviousPageAsync(CancellationToken cancellationToken = default)
        {
            if (HasPreviousPage && _request != null)
            {
                Debug.Assert(_request is ISupportsPagination);
                Debug.Assert(_client != null);

                var page = (_request as ISupportsPagination).Page;

                if (page.HasValue && page.Value > 1)
                {
                    page = page.Value - 1;
                    (_request as ISupportsPagination).Page = page;
                    var requestHandler = new RequestHandler(_client);
                    return requestHandler.ExecutePagedRequestAsync(_request, cancellationToken);
                }
            }

            // There is no previous page or request is not set because API endpoint supports a "limit" but not paging.
            // Just return the current response.
            return Task.FromResult(this);
        }

        /// <summary>
        /// Gets the next retrievable page for this response, if <see cref="HasNextPage" /> is true.
        /// <para>
        /// If this response is already the last page response or if there are no more pages to retrieve,
        /// this response instance will be returned.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{TResponseContentType}"/> instance containing the items of the next page and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{TResponseContentType}" /> and <typeparamref name="TResponseContentType" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<TResponseContentType>> GetNextPageAsync(CancellationToken cancellationToken = default)
        {
            if (HasNextPage && _request != null)
            {
                Debug.Assert(_request is ISupportsPagination);
                Debug.Assert(_client != null);

                var page = (_request as ISupportsPagination).Page;

                if (page.HasValue && page.Value < PageCount.Value)
                {
                    page = page.Value + 1;
                    (_request as ISupportsPagination).Page = page;
                    var requestHandler = new RequestHandler(_client);
                    return requestHandler.ExecutePagedRequestAsync(_request, cancellationToken);
                }
            }

            // There is no next page or request is not set because API endpoint supports a "limit" but not paging.
            // Just return the current response.
            return Task.FromResult(this);
        }

        /// <summary>
        /// Compares this instance with another <see cref="TraktPagedResponse{TResponseContentType}" /> instance.
        /// </summary>
        /// <param name="other">Another <see cref="TraktPagedResponse{TResponseContentType}" /> instance, which will be compared with this instance.</param>
        /// <returns>True, of both instances are equal, otherwise false.</returns>
        public bool Equals(TraktPagedResponse<TResponseContentType> other)
        {
            if (other == null)
                return false;

            return base.Equals(other) && other.Page == Page
                && other.Limit == Limit
                && other.PageCount == PageCount
                && other.ItemCount == ItemCount;
        }

        public bool Equals(TraktPagedResponse<TResponseContentType> left, TraktPagedResponse<TResponseContentType> right)
            => left.Equals(right);

        public int GetHashCode(TraktPagedResponse<TResponseContentType> obj) => obj.GetHashCode();

        /// <summary>Enables implicit conversion to <see cref="TraktPagedResponse{TResponseContentType}" /> for this type.</summary>
        /// <param name="value">The <see cref="List{TResponseContentType}" /> instance, which will be converted to <see cref="TraktPagedResponse{TResponseContentType}" />.</param>
        public static implicit operator TraktPagedResponse<TResponseContentType>(List<TResponseContentType> value)
            => new()
            {
                Value = value,
                HasValue = value != null,
                IsSuccess = value != null
            };

        /// <summary>Enables implicit conversion to bool for this type.</summary>
        /// <param name="response">The <see cref="TraktPagedResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TraktPagedResponse<TResponseContentType> response) => response.IsSuccess && response.HasValue;

        internal void SetRequestAndClient(IRequest<TResponseContentType> pagedRequest, TraktClient client)
        {
            Debug.Assert(pagedRequest != null);
            Debug.Assert(pagedRequest is ISupportsPagination);
            Debug.Assert(client != null);
            _request = pagedRequest;
            _client = client;
        }
    }
}
