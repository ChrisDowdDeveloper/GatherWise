using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

[Table("events")]
public class EventModel : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }

    [Column("location")]
    public string Location { get; set; }

    [Column("details")]
    public string Details { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("image_url")]
    public string ImageUrl { get; set; }
}
