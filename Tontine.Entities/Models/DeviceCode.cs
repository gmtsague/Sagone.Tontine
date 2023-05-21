using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

[Table("DeviceCodes", Schema = "tontine")]
[Index("DeviceCode1", Name = "IX_DeviceCodes_DeviceCode", IsUnique = true)]
[Index("Expiration", Name = "IX_DeviceCodes_Expiration")]
public partial class DeviceCode
{
    [Key]
    [StringLength(200)]
    public string UserCode { get; set; } = null!;

    [Column("DeviceCode")]
    [StringLength(200)]
    public string DeviceCode1 { get; set; } = null!;

    [StringLength(200)]
    public string? SubjectId { get; set; }

    [StringLength(100)]
    public string? SessionId { get; set; }

    [StringLength(200)]
    public string ClientId { get; set; } = null!;

    [StringLength(200)]
    public string? Description { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime Expiration { get; set; }

    [StringLength(50000)]
    public string Data { get; set; } = null!;
}
