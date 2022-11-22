using MediatR;

namespace Triton.Sample.Application.Features.Directors.Queries.GetDirectorsList
{
    public class GetDirectorsListQuery : IRequest<List<DirectorVM>>
    {
        public string _Username { get; set; } = string.Empty;

        public GetDirectorsListQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
