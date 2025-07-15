namespace API.Common
{
    public class GenericReponse
    {
        public string Message { get; set; } = null;

        public bool IsSuccess {  get; set; }

        public object? Data { get; set; }
        public Dictionary<string, string[]> Errors {  get; set; }
    }
}
