using System;
using System.Security.Claims;
using Cortside.AspNetCore.Auditable;
using Cortside.Common.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using RecipeBox.Data;

namespace RecipeBox.DomainService.Tests {
    public abstract class DomainServiceTest<T> : IDisposable {
        protected DatabaseContext GetDatabaseContext() {
            var databaseContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase($"db-{Guid.NewGuid():d}")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            return new DatabaseContext(databaseContextOptions, new SubjectPrincipal([new Claim("sub", Guid.NewGuid().ToString())]), new DefaultSubjectFactory());
        }

        protected T Service { get; set; }
        protected Mock<IHttpContextAccessor> HttpContextAccessorMock { get; set; } = new Mock<IHttpContextAccessor>();

        public void SetupHttpUser(Claim claim) {
            Mock<HttpContext> httpContext = new Mock<HttpContext>();
            Mock<ClaimsPrincipal> user = new Mock<ClaimsPrincipal>();
            if (claim != null) {
                httpContext.SetupGet(x => x.User).Returns(user.Object);
                HttpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext.Object);
                user.Setup(x => x.FindFirst(claim.Type)).Returns(claim);
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
        }
    }
}

