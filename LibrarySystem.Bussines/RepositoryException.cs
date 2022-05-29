using System;

namespace LibrarySystem.Bussines
{
    /// <summary>
    /// Represents an error that occurred in WEB.
    /// </summary>
    public class RepositoryException : Exception
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="RepositoryException"/> class.
        /// </summary>
        public RepositoryException()
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="RepositoryException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">the error message</param>
        public RepositoryException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="RepositoryException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">the error message</param>
        /// <param name="innerException">the exception that is the cause of the current exception</param>
        public RepositoryException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
