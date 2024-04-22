namespace OracleProjectMiedterm.Models
{
    public class CustomerPic
    {
        public bool IsHidden { get; set; }

        public string? CustomerCode { get; set; }

        public string? CustomerName { get; set; }

        //public byte[]? ImageData { get; set; }

        //public IFormFile? Image { get; set; }
        public IFormFile? FileName { get; set; }
        public string? Sex { get; set; }

        public DateTime Dob { get; set; }

        public string? Pob { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}
