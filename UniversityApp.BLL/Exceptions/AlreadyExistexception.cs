namespace UniversityApp.BLL.Exceptions
{
    public class AlreadyExistexception:Exception
    {
        public AlreadyExistexception()
        {
            
        }
        public AlreadyExistexception(string message):base(message)
        {
            
        }
        public AlreadyExistexception(string message,Exception innerException):base(message,innerException)
        {
            
        }
    }
}
