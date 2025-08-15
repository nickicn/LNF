using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Org.BouncyCastle.Asn1.Esf;

namespace LNF.API.Models;

[Table("transactions")]
public class Transaction
{        
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    public TransactionType Type { get; set; }

    [Required]
    public DateTime DateTransaction { get; set; }

    [StringLength(1000)]
    public string Notes { get; set; }

    [Required]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [Required]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}