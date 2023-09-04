﻿namespace Domain.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException()
        {
  
        }
        public DuplicateEmailException(string message)
            :base(message)
        {
                
        }
    }
}
