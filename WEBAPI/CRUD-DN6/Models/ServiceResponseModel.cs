namespace CRUD_DN6.Models
{
    public class ServiceResponseModel<T>
    {
        public T? data { get; set; }
        public string message { get; set; } = string.Empty;
        public bool success { get; set; } = true;
    }
}
