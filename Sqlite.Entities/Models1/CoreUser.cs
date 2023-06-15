using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class CoreUser
{
    public long UserId { get; set; }

    public long ProfilId { get; set; }

    public long LangueId { get; set; }

    public string Username { get; set; } = null!;

    public string Passwd { get; set; } = null!;

    public byte[] IsActif { get; set; } = null!;

    public byte[]? ExpirationDate { get; set; }

    public byte[]? LastConnexion { get; set; }

    public virtual CoreLangue Langue { get; set; } = null!;

    public virtual CoreProfil Profil { get; set; } = null!;
}
