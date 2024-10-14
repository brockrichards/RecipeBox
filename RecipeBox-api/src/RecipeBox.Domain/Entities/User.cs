using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Cortside.AspNetCore.Auditable.Entities;
using Cortside.Common.Messages;
using Cortside.Common.Messages.MessageExceptions;
using Microsoft.AspNetCore.Identity;

namespace RecipeBox.Domain.Entities {
    [Table("User")]
    public class User : IdentityUser {
        const string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
        protected User() {
            // Required by EF as it doesn't know about Customer
        }

        public User(string userName, string email, string password) {
            Update(userName, email, password);
            UserResourceId = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; private set; }

        public Guid UserResourceId { get; private set; }

        public Subject CreatedSubject { get; private set; }

        public DateTime CreatedDate {  get; private set; }

        public Subject LastModifiedSubject { get; private set; }

        public DateTime LastModifiedDate { get; private set; }

        public void Update(string userName, string email, string password) {
            var messages = new MessageList();
            messages.Aggregate(() => string.IsNullOrWhiteSpace(userName) || userName.Length < 6, () => new InvalidValueError(nameof(userName), userName));
            messages.Aggregate(() => string.IsNullOrWhiteSpace(password), () => new InvalidValueError(nameof(userName), userName));
            messages.Aggregate(() => string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, regex, RegexOptions.IgnoreCase), () => new InvalidValueError(nameof(email), email));
            messages.ThrowIfAny<ValidationListException>();

            UserName = userName;
            Email = email;
        }
    }
}

