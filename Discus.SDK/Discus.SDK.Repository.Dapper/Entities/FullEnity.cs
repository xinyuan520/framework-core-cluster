using System.ComponentModel.DataAnnotations.Schema;

namespace Discus.SDK.Repository.Dapper.Entities
{
    public class FullEnity : Entity, ICreateEntity, IEditEntity
    {
        [Column("create_by_id")]
        public long CreateById { get; set; }
        [Column("create_by_time")]
        public DateTime CreateByTime { get; set; }
        [Column("edit_by_id")]
        public long EditById { get; set; }
        [Column("edit_by_time")]
        public DateTime EditByTime { get; set; }
    }
}
