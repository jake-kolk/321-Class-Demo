// <copyright file="Command.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Represents a spreadsheet command that can be executed and reversed.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="purpose">The user-visible purpose of the command.</param>
        protected Command(string purpose)
        {
            if (string.IsNullOrWhiteSpace(purpose))
            {
                throw new ArgumentException("Purpose cannot be null or whitespace.", nameof(purpose));
            }

            this.Purpose = purpose;
        }

        /// <summary>
        /// Gets the user-visible purpose of this command.
        /// </summary>
        public string Purpose { get; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// Gets a command that reverses this command.
        /// </summary>
        /// <returns>The inverse command, or <see langword="null"/> if not reversible.</returns>
        public virtual Command? GetInverse()
        {
            return null;
        }
    }
}
