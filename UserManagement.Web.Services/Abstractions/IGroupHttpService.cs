using UserManagement.Web.Services.ServiceModel;

namespace UserManagement.Web.Services.Abstractions
{
    public interface IGroupHttpService
    {
        Task<List<Group>> GetGroupListAsync();
    }
}
