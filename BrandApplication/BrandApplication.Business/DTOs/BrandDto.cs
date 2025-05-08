namespace BrandApplication.Business.DTOs
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<ModelDto> Models { get; set; }

        public BrandDto()
        {
            BrandName = string.Empty;
            Models = new List<ModelDto>();
        }
    }
}
