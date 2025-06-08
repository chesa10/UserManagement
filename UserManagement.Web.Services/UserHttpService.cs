using System.Net.Http.Json;
using UserManagement.Web.Services.Abstractions;
using UserManagement.Web.Services.Endpoints;
using UserManagement.Web.Services.ServiceModel;

namespace UserManagement.Web.Services
{
    public class UserHttpService(HttpClient httpClient) : IUserHttpService
    {
        public async Task<int> AddUserAsync(User user)
        {
            var response = await httpClient.PostAsync(UserEndpointsEnum.AddUserEndpoint, JsonContent.Create(user));
            handlerException(response, nameof(AddUserAsync));
            return await response.Content.ReadFromJsonAsync<int>();
        }
        public async Task DeleteUser(int id)
        {
            var response = await httpClient.DeleteAsync(UserEndpointsEnum.DeleteUserEndpoint + id.ToString());
            handlerException(response, nameof(DeleteUser));
        }
        public async Task<User?> GetUserById(int id)
        {
            var response = await httpClient.GetAsync(UserEndpointsEnum.GetUserByIdEndpoint + id.ToString());
            handlerException(response, nameof(GetUserById));
            return await response.Content.ReadFromJsonAsync<User>();
        }
        public async Task<List<User>> GetUserListAsync()
        {
            var response = await httpClient.GetAsync(UserEndpointsEnum.GetUserListEndpoint);
            handlerException(response, nameof(GetUserListAsync));
            return await response.Content.ReadFromJsonAsync<List<User>>() ?? [];
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            var response = await httpClient.PutAsync(UserEndpointsEnum.UpdateUserEndpoint, JsonContent.Create(user));
            handlerException(response, nameof(UpdateUserAsync));
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        private void handlerException(HttpResponseMessage response, string methodName)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to {methodName}: {response.StatusCode}");
            }
        }
    }
}
