using System;

namespace SkillsTracker.Models
{
    public class MyFileException : ApplicationException
    {
        public MyFileException() : base()
        {
        }

        public MyFileException(string message) : base(message)
        {
        }

        public MyFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
