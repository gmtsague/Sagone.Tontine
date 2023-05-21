using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreUserDto
    {
        public int UserId { get; set; }
        public int ProfilId { get; set; }
        public int LangueId { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }
        public bool IsActif { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public DateOnly? LastConnexion { get; set; }
        public CoreLangueDto Langue { get; set; }
        public CoreProfilDto Profil { get; set; }
    }
}