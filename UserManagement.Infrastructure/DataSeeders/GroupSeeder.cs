using UserManagement.Infrastructure.Persistence;
using Group = UserManagement.Domain.Entities.Group;

namespace UserManagement.Infrastructure.DataSeeders
{
    internal class GroupSeeder(UserManagementDBContext dbContext) : IGroupSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Groups.Any())
                {
                    dbContext.Groups.AddRange(GetGroups());
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<Group> GetGroups()
        {
            List<Group> groups = [
            new()
            {
                Name = "Third part cover Group",
                Description = "The most basic level of coverage, focusing on protecting you from legal liability if you cause damage to another person's vehicle",
                Permissions =
                [
                    new()
                    {
                        Name = "Level 1",
                        Description = "Level 1"
                    },
                    new()
                    {
                        Name = "Level 2",
                        Description = "Level 2"
                    }
                ],
                Users =
                [
                    new()
                    {
                        Name = "Wilson",
                        Surname = "Zulu",
                        Email = "wilsonzulu10@gmail.com",
                        ContactNumber = "0785005991"
                    },
                    new()
                    {
                        Name = "Brian",
                        Surname = "Tlean",
                        Email = "Tlean@gmail.com",
                        ContactNumber = "0885005991"
                    },
                    new()
                    {
                        Name = "Mpeke",
                        Surname = "Mathebula",
                        Email = "Mathebula@gmail.com",
                        ContactNumber = "0*85005991"
                    }
                ]
            },
            new()
            {
                Name = "Comprehensive cover Group",
                Description = "The most extensive protection, covering various risks like accidents, theft, vandalism, fire, and natural disasters, as well as third-party liability",
                Permissions =
                [
                    new()
                    {
                        Name = "Level 3",
                        Description = "Level 3"
                    }
                ],
                Users = 
                [
                    new()
                    {
                        Name = "Abram",
                        Surname = "Mmako",
                        Email = "abramchesammako@gmail.com",
                        ContactNumber = "0799610258"
                    },
                    new()
                    {
                        Name = "Mercy",
                        Surname = "Dlamini",
                        Email = "Dlamini@gmail.com",
                        ContactNumber = "0889610258"
                    }
                ]
            }
            ];

            return groups;
        }
    }
}
