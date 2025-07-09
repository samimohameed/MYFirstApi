namespace MYFirstApi.Models.Dto
{
    public class UpdateEmployeeDto
    {
        public required string name { get; set; }
        public required string email { get; set; }
        public string? phone { get; set; }
        public decimal salary { get; set; }
    }
}
