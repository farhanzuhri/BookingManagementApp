namespace API.Utilities.Validations
{
    public class ResponseValidatorHandler
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public ResponseValidatorHandler(IEnumerable<string> errors)
        {
            Code = 400; // Assuming a default error code
            Status = "Bad Request";
            Message = "Validation failed";
            Errors = errors;
        }
    }
}




