namespace LightgunStudio.Core.Dtos
{
    public class ZipProgressDto
    {
        public ZipProgressDto(int total, int processed, string currentItem)
        {
            Total = total;
            Processed = processed;
            CurrentItem = currentItem;
        }
        public int Total { get; }
        public int Processed { get; }
        public string CurrentItem { get; }
    }
}
