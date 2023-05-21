using System.ComponentModel.DataAnnotations.Schema;

namespace Tontine.Entities.Models
{
    [NotMapped]
    public class BaseDbEntity
    {
        /// <summary>
        /// create_uid
        /// </summary>
        [NotMapped]
        public long? CreateUid { get; set; }

        /// <summary>
        /// update_uid
        /// </summary>
        [NotMapped]
        public long? UpdateUid { get; set; }

        /// <summary>
        /// Create_at
        /// </summary>
        [NotMapped]
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// Update_at
        /// </summary>
        [NotMapped] 
        public DateTime UpdateAt { get; set; }
    }
}
