namespace HotelDomain.Commands
{
    public interface ICommandHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}