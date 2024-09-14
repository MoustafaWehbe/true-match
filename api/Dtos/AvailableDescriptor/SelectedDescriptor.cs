namespace api.Dtos
{
    public class SelectedDescriptor
    {
        public int AvalibaleDescriptorId { get; set; }
        public required string DescriptorId { get; set; }
        public List<string>? ChoicesIds { get; set; }
        public object? SingleValue { get; set; }
    }
}
