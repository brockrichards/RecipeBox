#pragma warning disable S3376 // Attribute, EventArgs, and Exception type names should end with the type being extended

using Cortside.Common.Messages.MessageExceptions;

namespace RecipeBox.Exceptions {
    public class InvalidIngredientMessage : BadRequestResponseException {
        public InvalidIngredientMessage() : base("Ingredient is not valid.") {
        }

        public InvalidIngredientMessage(string message) : base($"Ingredient is not valid. {message}") {
        }

        public InvalidIngredientMessage(string message, System.Exception exception) : base(message, exception) {
        }

        protected InvalidIngredientMessage(string key, string property, params object[] properties) : base(key, property, properties) {
        }

        protected InvalidIngredientMessage(string message, string property) : base(message, property) {
        }
    }
}

