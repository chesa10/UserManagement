using System.Net.Http.Json;
using UserManagement.Web.Services.Abstractions;
using UserManagement.Web.Services.Endpoints;
using UserManagement.Web.Services.ServiceModel;

namespace UserManagement.Web.Services
{
    public class GroupHttpService(HttpClient httpClient) : IGroupHttpService
    {
        public async Task<List<Group>> GetGroupListAsync()
        {
            var response = await httpClient.GetAsync(GroupEndpointsEnum.GroupList);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot fetch groups: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<Group>>() ?? [];
        }
    }
}



