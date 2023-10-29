using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingBenchmark.Db;

public interface IProduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    long Id { get; set; }

    string Name { get; set; }

    double Price { get; set; }
}


