using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

[Table("events")]
public class Event : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }

    [Column("location")]
    public string Location { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
