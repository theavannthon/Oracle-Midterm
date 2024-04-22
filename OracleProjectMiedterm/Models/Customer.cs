using System.ComponentModel.DataAnnotations.Schema;

namespace OracleProjectMiedterm.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        //public bool IsHidden { get; set; }

        public string? CustomerCode { get; set; }

        public string? CustomerName { get; set; }

        public string? Images { get; set; }

        public string? Sex { get; set; }

        public DateTime? Dob { get; set; }

        public string? Pob { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        


    }
}
