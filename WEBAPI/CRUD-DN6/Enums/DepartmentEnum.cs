using System.Text.Json.Serialization;

namespace CRUD_DN6.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        HR,
        Engineering,
        Janitor,
        Finantial,
        Reception
    }
}
