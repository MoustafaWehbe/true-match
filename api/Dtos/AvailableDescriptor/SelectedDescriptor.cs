namespace api.Dtos
{
    public class SelectedDescriptor
    {
        public int AvailableDescriptorId { get; set; }
        public required string DescriptorId { get; set; }
        public List<string>? ChoicesIds { get; set; }
        public string? SingleValue { get; set; }
    }
}
