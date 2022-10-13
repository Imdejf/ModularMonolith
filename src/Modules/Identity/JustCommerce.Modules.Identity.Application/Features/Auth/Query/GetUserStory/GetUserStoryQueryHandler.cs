using JustCommerce.Modules.BuildingBlocks.Application.Data;
using JustCommerce.Modules.Identity.Application.Configuration.Query;
using JustCommerce.Modules.Identity.Application.Features.Auth.Dto;
using Dapper;

namespace JustCommerce.Modules.Identity.Application.Features.Auth.Query.GetUserStory
{
    internal class GetUserStoryQueryHandler : IQueryHandler<GetUserStoryQuery, UserStoreDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetUserStoryQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<UserStoreDto> Handle(GetUserStoryQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "[UserRegistration].[Id], " +
                               "[UserRegistration].[Login], " +
                               "[UserRegistration].[Email], " +
                               "[UserRegistration].[FirstName], " +
                               "[UserRegistration].[LastName], " +
                               "[UserRegistration].[Name], " +
                               "[UserRegistration].[StatusCode] " +
                               "FROM [users].[v_UserRegistrations] AS [UserRegistration] " +
                               "WHERE [UserRegistration].[Id] = @UserRegistrationId";

            return await connection.QuerySingleAsync<UserStoreDto>(
                sql,
                new
                {
                    query.UserRegistrationId
                });
        }
    }
}
