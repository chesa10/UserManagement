using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Frontend.Models;
using UserManagement.Web.Services.Abstractions;
using UserManagement.Web.Services.ServiceModel;

namespace UserManagement.Frontend.Controllers
{
    public class UserController(IUserHttpService userService, IGroupHttpService groupHttpService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            return this.View(new UserListViewModel
            {
                Users = await userService.GetUserListAsync()
            });
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            var groups = await groupHttpService.GetGroupListAsync();
            await SetGroup(groups);
            return this.View(new AddUserViewModel
            {
                Groups = groups,
                GroupIds = new List<int>() { 1 }
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel request)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await userService.AddUserAsync(new User
                    {
                        Name = request.Name,
                        Surname = request.Surname,
                        Email = request.Email,
                        ContactNumber = request.ContactNumber,
                        GroupIds = request.GroupIds.ToList(),
                    });

                    return this.RedirectToAction(nameof(this.UserList));
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            var groups = await groupHttpService.GetGroupListAsync();
            await SetGroup(groups);
            request.Groups = groups;
            request.GroupIds = new List<int>() { 1 };
            return this.View(request);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var groups = await groupHttpService.GetGroupListAsync();
            await SetGroup(groups);
            var user = await userService.GetUserById(id);
            return this.View(new UpdateUserViewModel
            {
                Id = id,
                Groups = groups,
                Name = user.Name,
                Surname= user.Surname,
                Email= user.Email,
                ContactNumber = user.ContactNumber,
                GroupIds = user.Groups.Select(g => g.Id).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel request)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await userService.UpdateUserAsync(new User
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Surname = request.Surname,
                        Email = request.Email,
                        ContactNumber = request.ContactNumber,
                        GroupIds = request.GroupIds.ToList(),
                    });

                    return this.RedirectToAction(nameof(this.UserList));
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            var groups = await groupHttpService.GetGroupListAsync();
            await SetGroup(groups);
            request.Groups = groups;    
            return this.View(request);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return this.View(new DeleteUserViewModel
            {
                User = await userService.GetUserById(id)
            });
        }

        [HttpPost, ActionName("DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await userService.DeleteUser(id);
                    return this.RedirectToAction(nameof(this.UserList));
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }
            return this.View();
        }

        private async Task SetGroup(IList<Group> groups)
        {
            var selects = from g in groups
                          select new SelectListItem
                          {
                              Text = g.Name,
                              Value = g.Id.ToString(),
                          };
            ViewBag.Selects = new MultiSelectList(groups, "Id", "Name");
        }
    }
}
