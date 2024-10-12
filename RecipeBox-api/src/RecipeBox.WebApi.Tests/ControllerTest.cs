using System;
using Cortside.AspNetCore.Auditable;
using Cortside.Common.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeBox.Data;

namespace RecipeBox.WebApi.Tests {
    public abstract class ControllerTest<T> : IDisposable where T : ControllerBase {
        protected T Controller { get; set; }
        protected Mock<IHttpContextAccessor> HttpContextAccessorMock { get; set; } = new Mock<IHttpContextAccessor>();

        protected ControllerContext GetControllerContext() {
            var controllerContext = new ControllerContext {
                HttpContext = new DefaultHttpContext()
            };
            return controllerContext;
        }

        public DatabaseContext GetDatabaseContext() {
            var databaseContextOptions = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase($"db-{Guid.NewGuid():d}").Options;
            return new DatabaseContext(databaseContextOptions, SubjectPrincipal.From(HttpContextAccessorMock.Object.HttpContext.User), new DefaultSubjectFactory());
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            // Cleanup
        }
    }
}

