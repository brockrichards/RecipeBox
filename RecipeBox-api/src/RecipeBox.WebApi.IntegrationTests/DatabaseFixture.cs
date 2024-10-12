using System;
using System.Linq;
using Cortside.AspNetCore.Auditable.Entities;
using RecipeBox.Data;
using RecipeBox.TestUtilities;

namespace RecipeBox.WebApi.IntegrationTests {
    public static class DatabaseFixture {
        public static void SeedInMemoryDb(DatabaseContext dbContext) {
            var subject = new Subject(Guid.Empty, string.Empty, string.Empty, string.Empty, "system");
            if (!dbContext.Subjects.Any(x => x.SubjectId == subject.SubjectId)) {
                dbContext.Subjects.Add(subject);

                var User = EntityBuilder.GetUserEntity();
                dbContext.Users.Add(User);

                // intentionally using this override to avoid the not implemented exception
                dbContext.SaveChanges(true);
            }
        }
    }
}

