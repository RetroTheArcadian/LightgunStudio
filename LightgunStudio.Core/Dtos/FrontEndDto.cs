namespace LightgunStudio.Core.Dtos
{
    public class FrontEndDto
    {
        public required string Title { get; set; }
        public string? ImagePath { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
