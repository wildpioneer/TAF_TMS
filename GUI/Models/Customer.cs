using System.ComponentModel.DataAnnotations.Schema;

namespace SQL.Models
{
    public record Customer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string? Firstname { get; set; }

        [Column("lastname")]
        public string? Lastname { get; set; }    

        [Column("email")]
        public string? Email { get; set; }    

        [Column("age")]
        public int? Age { get; set; }    
    }
}