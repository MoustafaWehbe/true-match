using System.Text.Json;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class AvailableDescriptorMapper
    {
        public static AvailableDescriptorDto ToAvailableDescriptorDto(this AvailableDescriptor availableDescriptorModel)
        {
            return new AvailableDescriptorDto
            {
                Id = availableDescriptorModel.Id,
                SectionName = availableDescriptorModel.SectionName,
                DisplayType = availableDescriptorModel.DisplayType,
                Prompt = availableDescriptorModel.Prompt,
                Descriptors = JsonSerializer.Deserialize<List<Descriptor>>(availableDescriptorModel.Descriptors!)
            };
        }
    }
}