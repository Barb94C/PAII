using FluentValidation.Results;
using System.Runtime.Serialization;

namespace ESCMB.Application.Exceptions
{
    /// <summary>
    /// Las excepciones custom deben ir definidas aqui
    /// </summary>
    /// 
    [Serializable]
    public class BussinessException : ApplicationException
    {
        public BussinessException(string message, Exception exception) : base(message, exception)
        {
        }

        protected BussinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class EntityDoesExistException : ApplicationException
    {
        public EntityDoesExistException() : base(Constants.ENTITY_DOES_EXIST_EXCEPTION)
        {
        }

        protected EntityDoesExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class EntityDoesNotExistException : ApplicationException
    {
        public EntityDoesNotExistException() : base(Constants.ENTITY_DOESNOT_EXIST_EXCEPTION)
        {
        }

        protected EntityDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class InvalidEntityDataException : ApplicationException
    {
        public IList<string>? Messages { get; private set; }
        public InvalidEntityDataException(IList<ValidationFailure> failures) : base()
        {
            Messages = (from item in failures select item.ErrorMessage).ToList();
        }

        protected InvalidEntityDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
