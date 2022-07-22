namespace HotelDomain.Queries
{
    public interface IQueryHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
