using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GatherWise.Models
{
    [Table("invitations")]
    public class Invitation : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("event_id")]
        public Guid EventId { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("sent_at")]
        public DateTime SentAt { get; set; }
    }
}
