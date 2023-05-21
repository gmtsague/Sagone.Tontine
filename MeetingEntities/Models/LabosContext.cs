using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

public partial class LabosContext : DbContext
{
    public LabosContext()
    {
    }

    public LabosContext(DbContextOptions<LabosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoreAnnee> CoreAnnees { get; set; }

    public virtual DbSet<CoreAnnualSetting> CoreAnnualSettings { get; set; }

    public virtual DbSet<CoreAutorisation> CoreAutorisations { get; set; }

    public virtual DbSet<CoreBank> CoreBanks { get; set; }

    public virtual DbSet<CoreBankaccount> CoreBankaccounts { get; set; }

    public virtual DbSet<CoreCommande> CoreCommandes { get; set; }

    public virtual DbSet<CoreCountry> CoreCountries { get; set; }

    public virtual DbSet<CoreEtablissement> CoreEtablissements { get; set; }

    public virtual DbSet<CoreFrequenceDivision> CoreFrequenceDivisions { get; set; }

    public virtual DbSet<CoreLangue> CoreLangues { get; set; }

    public virtual DbSet<CoreModepaie> CoreModepaies { get; set; }

    public virtual DbSet<CorePerson> CorePeople { get; set; }

    public virtual DbSet<CorePhonenumber> CorePhonenumbers { get; set; }

    public virtual DbSet<CorePhoto> CorePhotos { get; set; }

    public virtual DbSet<CoreProfil> CoreProfils { get; set; }

    public virtual DbSet<CoreSubdivision> CoreSubdivisions { get; set; }

    public virtual DbSet<CoreUser> CoreUsers { get; set; }

    public virtual DbSet<MeetAntenne> MeetAntennes { get; set; }

    public virtual DbSet<MeetBureau> MeetBureaus { get; set; }

    public virtual DbSet<MeetConfigVisa> MeetConfigVisas { get; set; }

    public virtual DbSet<MeetEngagement> MeetEngagements { get; set; }

    public virtual DbSet<MeetEntreeCaisse> MeetEntreeCaisses { get; set; }

    public virtual DbSet<MeetInscription> MeetInscriptions { get; set; }

    public virtual DbSet<MeetMaxAllowSignature> MeetMaxAllowSignatures { get; set; }

    public virtual DbSet<MeetMembreBureau> MeetMembreBureaus { get; set; }

    public virtual DbSet<MeetOrdrePassage> MeetOrdrePassages { get; set; }

    public virtual DbSet<MeetPoste> MeetPostes { get; set; }

    public virtual DbSet<MeetPreference> MeetPreferences { get; set; }

    public virtual DbSet<MeetPresence> MeetPresences { get; set; }

    public virtual DbSet<MeetPret> MeetPrets { get; set; }

    public virtual DbSet<MeetRubrique> MeetRubriques { get; set; }

    public virtual DbSet<MeetSeance> MeetSeances { get; set; }

    public virtual DbSet<MeetSortieCaisse> MeetSortieCaisses { get; set; }

    public virtual DbSet<MeetSuspensionMembre> MeetSuspensionMembres { get; set; }

    public virtual DbSet<MeetTypeRubrique> MeetTypeRubriques { get; set; }

    public virtual DbSet<MeetVisa> MeetVisas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;port=5434;Database=labos;Username=laborentin;Password=Laborentin120");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoreAnnee>(entity =>
        {
            entity.HasKey(e => e.AnneeId).HasName("pk_core_annee");

            entity.ToTable("core_annee", "tontine_v14", tb => tb.HasComment("Represente une annee "));

            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.BureauId).HasComment("Bureau_id");
            entity.Property(e => e.CopyDataFromPrevious).HasComment("Copy_data_from_previous");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Datedebut).HasComment("Date de debut de l'annee");
            entity.Property(e => e.Datefin).HasComment("Date de fin de l'annee");
            entity.Property(e => e.FrequenceId).HasComment("Frequence_id");
            entity.Property(e => e.IsClosed).HasComment("Indique que l'annee et cloturee et ses donnees ne sont plus modifiables");
            entity.Property(e => e.IsCurrent).HasComment("Indique l'annee de travail");
            entity.Property(e => e.Libelle).HasComment("Libelle de l'annee");
            entity.Property(e => e.Nbdivision)
                .HasDefaultValueSql("12")
                .HasComment("Nombre de divisions de l'annee");
            entity.Property(e => e.PreviousYearId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Bureau).WithMany(p => p.CoreAnnees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_meet_bur");

            entity.HasOne(d => d.Frequence).WithMany(p => p.CoreAnnees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_fre");

            entity.HasOne(d => d.PreviousYear).WithMany(p => p.InversePreviousYear)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");
        });

        modelBuilder.Entity<CoreAnnualSetting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("pk_core_annual_setting");

            entity.ToTable("core_annual_setting", "tontine_v14", tb => tb.HasComment("core_Annual_setting"));

            entity.Property(e => e.SettingId).HasComment("Identifiant de l'entite");
            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Copyengagements).HasComment("CopyEngagements");
            entity.Property(e => e.Copymembers).HasComment("CopyMembers");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.MaxAllowPhotoLiens).HasComment("Nombre max de liens autorises pour la photo d'une personne");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.CoreAnnualSettings)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");

            entity.HasOne(d => d.Etab).WithMany(p => p.CoreAnnualSettings)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_eta");
        });

        modelBuilder.Entity<CoreAutorisation>(entity =>
        {
            entity.HasKey(e => e.ChoixId).HasName("pk_core_autorisations");

            entity.ToTable("core_autorisations", "tontine_v14", tb => tb.HasComment("core_Autorisations"));

            entity.Property(e => e.ChoixId).HasComment("Choix_id");
            entity.Property(e => e.Idcmde).HasComment("Idcmde");
            entity.Property(e => e.IsActive).HasComment("Is_active");
            entity.Property(e => e.ProfilId).HasComment("Profil_id");

            entity.HasOne(d => d.IdcmdeNavigation).WithMany(p => p.CoreAutorisations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_com");

            entity.HasOne(d => d.Profil).WithMany(p => p.CoreAutorisations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_pro");
        });

        modelBuilder.Entity<CoreBank>(entity =>
        {
            entity.HasKey(e => e.BankId).HasName("pk_core_bank");

            entity.ToTable("core_bank", "tontine_v14", tb => tb.HasComment("Etablissement financier"));

            entity.Property(e => e.BankId).HasComment("Identifiant de la banque");
            entity.Property(e => e.Adresse).HasComment("Adresse postale de la banque");
            entity.Property(e => e.Coderib).HasComment("Numero de compte de l'association chez la baqnue");
            entity.Property(e => e.CountryId).HasComment("Identifiant du pays");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Email).HasComment("Contact telephonique de la banque No2");
            entity.Property(e => e.Libelle).HasComment("Libelle de la banque");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CoreBanks)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_cou");
        });

        modelBuilder.Entity<CoreBankaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("pk_core_bankaccount");

            entity.ToTable("core_bankaccount", "tontine_v14", tb => tb.HasComment("core_Bankaccount"));

            entity.Property(e => e.AccountId).HasComment("Account_id");
            entity.Property(e => e.BankId).HasComment("Identifiant de la banque");
            entity.Property(e => e.CompteNo).HasComment("Compte_no");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.IsActive).HasComment("Is_active");
            entity.Property(e => e.PersonId).HasComment("Person_id");
            entity.Property(e => e.Solde).HasComment("Solde");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Bank).WithMany(p => p.CoreBankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_ban");

            entity.HasOne(d => d.Etab).WithMany(p => p.CoreBankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_eta");

            entity.HasOne(d => d.Person).WithMany(p => p.CoreBankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_per");
        });

        modelBuilder.Entity<CoreCommande>(entity =>
        {
            entity.HasKey(e => e.Idcmde).HasName("pk_core_commandes");

            entity.ToTable("core_commandes", "tontine_v14", tb => tb.HasComment("core_Commandes"));

            entity.Property(e => e.Idcmde).HasComment("Idcmde");
            entity.Property(e => e.Libelle).HasComment("Libelle");
        });

        modelBuilder.Entity<CoreCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("pk_core_country");

            entity.ToTable("core_country", "tontine_v14", tb => tb.HasComment("core_country"));

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du pays");
            entity.Property(e => e.CodeIso2).HasComment("Code (2 caracteres) ISO du pays");
            entity.Property(e => e.CodeIso3).HasComment("Code (3 caracteres) ISO du pays");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Devise).HasComment("Devise du pays");
            entity.Property(e => e.Libelle).HasComment("Nom du pays");
            entity.Property(e => e.PhoneCode).HasComment("Code telephonique du pays");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");
        });

        modelBuilder.Entity<CoreEtablissement>(entity =>
        {
            entity.HasKey(e => e.EtabId).HasName("pk_core_etablissement");

            entity.ToTable("core_etablissement", "tontine_v14", tb => tb.HasComment("core_Etablissement"));

            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.Adresse).HasComment("Adresse");
            entity.Property(e => e.ConnString).HasComment("Conn_string");
            entity.Property(e => e.CountryId).HasComment("Identifiant du pays");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Creationdate).HasComment("Creationdate");
            entity.Property(e => e.DatabaseName).HasComment("Database_name");
            entity.Property(e => e.DeployedUrl).HasComment("Deployed_Url");
            entity.Property(e => e.EnableMultiAntenne).HasComment("Enable_multi_antenne");
            entity.Property(e => e.Libelle).HasComment("Libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CoreEtablissements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_eta_associati_core_cou");
        });

        modelBuilder.Entity<CoreFrequenceDivision>(entity =>
        {
            entity.HasKey(e => e.FrequenceId).HasName("pk_core_frequence_division");

            entity.ToTable("core_frequence_division", "tontine_v14", tb => tb.HasComment("core_Frequence_Division"));

            entity.Property(e => e.FrequenceId).HasComment("Frequence_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Libelle).HasComment("Libelle");
            entity.Property(e => e.NbDays).HasComment("Nb_Days");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");
        });

        modelBuilder.Entity<CoreLangue>(entity =>
        {
            entity.HasKey(e => e.LangueId).HasName("pk_core_langue");

            entity.ToTable("core_langue", "tontine_v14", tb => tb.HasComment("core_Langue"));

            entity.Property(e => e.LangueId).HasComment("Identifiant de la langue");
            entity.Property(e => e.IsActive).HasComment("Isactive");
            entity.Property(e => e.IsDefault).HasComment("Indique la langue par defaut");
            entity.Property(e => e.Isocode).HasComment("Code ISO de la langue");
            entity.Property(e => e.Libelle).HasComment("Libelle de la langue");
        });

        modelBuilder.Entity<CoreModepaie>(entity =>
        {
            entity.HasKey(e => e.ModepaieId).HasName("pk_core_modepaie");

            entity.ToTable("core_modepaie", "tontine_v14", tb => tb.HasComment("Mode de paiement utilise par un membre"));

            entity.Property(e => e.ModepaieId).HasComment("Identifiant du mode de paiement");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.IsCash).HasComment("Indique si le mode represnte le CASH");
            entity.Property(e => e.Libelle).HasComment("Libelle du mode de paiement");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");
        });

        modelBuilder.Entity<CorePerson>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("pk_core_person");

            entity.ToTable("core_person", "tontine_v14", tb => tb.HasComment("Represente un membre de la reunion"));

            entity.Property(e => e.PersonId).HasComment("Person_id");
            entity.Property(e => e.AdhesionDate).HasComment("Adhesion_date");
            entity.Property(e => e.Adresse).HasComment("Adresse");
            entity.Property(e => e.AnneePromo).HasComment("Annee_promo");
            entity.Property(e => e.CniExpireDate).HasComment("CNI_Expire_date");
            entity.Property(e => e.CountryId).HasComment("Identifiant du pays");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Datenais).HasComment("Datenais");
            entity.Property(e => e.Email).HasComment("Email");
            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.IsActive).HasComment("Indique si le membre est suspendu ou pas");
            entity.Property(e => e.IsVisible)
                .HasDefaultValueSql("true")
                .HasComment("Cette personne represente un utilisateur systeme");
            entity.Property(e => e.Lieunais).HasComment("lieunais");
            entity.Property(e => e.Nocni).HasComment("Nocni");
            entity.Property(e => e.Nom).HasComment("Nom");
            entity.Property(e => e.Prenom)
                .HasDefaultValueSql("''::character varying")
                .HasComment("Prenom");
            entity.Property(e => e.Sexe).HasComment("Sexe");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CorePeople)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_cou");

            entity.HasOne(d => d.Etab).WithMany(p => p.CorePeople)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_eta");
        });

        modelBuilder.Entity<CorePhonenumber>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("pk_core_phonenumber");

            entity.ToTable("core_phonenumber", "tontine_v14", tb => tb.HasComment("core_Phonenumber"));

            entity.Property(e => e.PhoneId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du numero de telephone");
            entity.Property(e => e.BankId).HasComment("Identifiant de la banque");
            entity.Property(e => e.CountryId).HasComment("Identifiant du pays");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.IsDefaut).HasComment("Represente le numero par defaut");
            entity.Property(e => e.PersonId).HasComment("Person_id");
            entity.Property(e => e.PhoneNo).HasComment("Numero telephone");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Bank).WithMany(p => p.CorePhonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_ban");

            entity.HasOne(d => d.Country).WithMany(p => p.CorePhonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_cou");

            entity.HasOne(d => d.Person).WithMany(p => p.CorePhonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<CorePhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("pk_core_photos");

            entity.ToTable("core_photos", "tontine_v14", tb => tb.HasComment("core_Photos"));

            entity.Property(e => e.PhotoId)
                .ValueGeneratedNever()
                .HasComment("Identifiant d'une photo");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.Fileext).HasComment("Extension du fichier");
            entity.Property(e => e.Filename).HasComment("Filename");
            entity.Property(e => e.Filepath).HasComment("Chemin d'acces au fichier");
            entity.Property(e => e.Image).HasComment("Image");
            entity.Property(e => e.IsSignature).HasComment("Represente une signature");
            entity.Property(e => e.MaxAllowLiens).HasComment("Nombre max de liens autorises");
            entity.Property(e => e.NbActualLiens).HasComment("Nombre de liens actuels");
            entity.Property(e => e.PersonId).HasComment("Person_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.CorePhotos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_eta");

            entity.HasOne(d => d.Person).WithMany(p => p.CorePhotos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<CoreProfil>(entity =>
        {
            entity.HasKey(e => e.ProfilId).HasName("pk_core_profil");

            entity.ToTable("core_profil", "tontine_v14", tb => tb.HasComment("core_Profil"));

            entity.Property(e => e.ProfilId).HasComment("Profil_id");
            entity.Property(e => e.Candelete).HasComment("Candelete");
            entity.Property(e => e.Libelle).HasComment("Libelle");
        });

        modelBuilder.Entity<CoreSubdivision>(entity =>
        {
            entity.HasKey(e => new { e.AnneeId, e.DivisionId }).HasName("pk_core_subdivision");

            entity.ToTable("core_subdivision", "tontine_v14", tb => tb.HasComment("Represente le decoupage mensuel de l'annee"));

            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.DivisionId)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de la division");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Libelle).HasComment("Libelle de la division");
            entity.Property(e => e.MonthDate).HasComment("Date de debut de la division");
            entity.Property(e => e.MonthDay).HasComment("Jour du mois ou aura lieu la reunion");
            entity.Property(e => e.Numordre).HasComment("Numero d'ordre de la division");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.CoreSubdivisions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_sub_associati_core_ann");
        });

        modelBuilder.Entity<CoreUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_core_user");

            entity.ToTable("core_user", "tontine_v14", tb => tb.HasComment("core_User"));

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasComment("User_Id");
            entity.Property(e => e.ExpirationDate).HasComment("Date d'expiration");
            entity.Property(e => e.IsActif).HasComment("Compte actif");
            entity.Property(e => e.LangueId).HasComment("Identifiant de la langue");
            entity.Property(e => e.LastConnexion).HasComment("Last_connexion");
            entity.Property(e => e.Passwd).HasComment("Mot de passe");
            entity.Property(e => e.ProfilId).HasComment("Profil_id");
            entity.Property(e => e.Username).HasComment("Nom d'utilisateur");

            entity.HasOne(d => d.Langue).WithMany(p => p.CoreUsers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_lan");

            entity.HasOne(d => d.Profil).WithMany(p => p.CoreUsers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_pro");
        });

        modelBuilder.Entity<MeetAntenne>(entity =>
        {
            entity.HasKey(e => new { e.EtabId, e.AntenneId }).HasName("pk_meet_antenne");

            entity.ToTable("meet_antenne", "tontine_v14", tb => tb.HasComment("Represente ue antenne de l'association"));

            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.AntenneId)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de l'antenne");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Creationdate).HasComment("Date de creation de l'antenne");
            entity.Property(e => e.Libelle).HasComment("Libelle de l'antenne");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.MeetAntennes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ant_associati_core_eta");
        });

        modelBuilder.Entity<MeetBureau>(entity =>
        {
            entity.HasKey(e => e.BureauId).HasName("pk_meet_bureau");

            entity.ToTable("meet_bureau", "tontine_v14", tb => tb.HasComment("Meet_Bureau"));

            entity.Property(e => e.BureauId).HasComment("Bureau_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Debut).HasComment("Debut");
            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.Fin).HasComment("Fin");
            entity.Property(e => e.Libelle).HasComment("Libelle");
            entity.Property(e => e.Nbabstention).HasComment("NbAbstention");
            entity.Property(e => e.Nbperson).HasComment("Nbperson");
            entity.Property(e => e.Nbvotes).HasComment("Nbvotes");
            entity.Property(e => e.Resumevote).HasComment("Resumevote");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.MeetBureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_bur_associati_core_eta");
        });

        modelBuilder.Entity<MeetConfigVisa>(entity =>
        {
            entity.HasKey(e => e.ConfigvisaId).HasName("pk_meet_config_visas");

            entity.ToTable("meet_config_visas", "tontine_v14", tb => tb.HasComment("Represente l'ensemble des autorisatios de signature de documents au sein de l'association"));

            entity.Property(e => e.ConfigvisaId).HasComment("Identifiant de la configuration de signature");
            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasComment("Numero d'ordre de la signature pour un type de document");
            entity.Property(e => e.PosteId).HasComment("Poste_id");
            entity.Property(e => e.SignByOrdre).HasComment("Sign_by_ordre");
            entity.Property(e => e.TyperubId).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetConfigVisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_core_ann");

            entity.HasOne(d => d.Poste).WithMany(p => p.MeetConfigVisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_meet_pos");

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetConfigVisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_meet_typ");
        });

        modelBuilder.Entity<MeetEngagement>(entity =>
        {
            entity.HasKey(e => e.EngagementId).HasName("pk_meet_engagement");

            entity.ToTable("meet_engagement", "tontine_v14", tb => tb.HasComment("Meet_Engagement"));

            entity.Property(e => e.EngagementId).HasComment("Engagement_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Cumulverse).HasComment("Cumul des versements sur une rubrique");
            entity.Property(e => e.EngagementDate).HasComment("Engagement_Date");
            entity.Property(e => e.IsClosed).HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)");
            entity.Property(e => e.IsOutcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.PersonId).HasComment("Person_id");
            entity.Property(e => e.RubriqueId).HasComment("Identifiant d'une configuration");
            entity.Property(e => e.Solde).HasComment("Solde");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetEngagements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_eng_associati_core_per");

            entity.HasOne(d => d.Rubrique).WithMany(p => p.MeetEngagements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_eng_associati_meet_rub");
        });

        modelBuilder.Entity<MeetEntreeCaisse>(entity =>
        {
            entity.HasKey(e => e.OperationId).HasName("pk_meet_entree_caisse");

            entity.ToTable("meet_entree_caisse", "tontine_v14", tb => tb.HasComment("Meet_Entree_caisse"));

            entity.Property(e => e.OperationId).HasComment("Operation_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.EngagementId).HasComment("Engagement_id");
            entity.Property(e => e.IsOutcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.ModepaieId).HasComment("Identifiant du mode de paiement");
            entity.Property(e => e.Montantverse).HasComment("MontantVerse");
            entity.Property(e => e.PresenceId).HasComment("Identiifant de la signature");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Engagement).WithMany(p => p.MeetEntreeCaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_meet_eng");

            entity.HasOne(d => d.Modepaie).WithMany(p => p.MeetEntreeCaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_core_mod");

            entity.HasOne(d => d.Presence).WithMany(p => p.MeetEntreeCaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_meet_pre");
        });

        modelBuilder.Entity<MeetInscription>(entity =>
        {
            entity.HasKey(e => e.Idinscrit).HasName("pk_meet_inscription");

            entity.ToTable("meet_inscription", "tontine_v14", tb => tb.HasComment("Represente le renoouvellement de la presence d'un membre au sein de 'association au cours d'une annee"));

            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.AntenneId).HasComment("Identifiant de l'antenne");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Cumuldettes)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumulees applicable la nouvelle annee");
            entity.Property(e => e.Cumulpenalites)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumules de penelites applicable la nouvelle annee");
            entity.Property(e => e.Dateinscrit).HasComment("Date de l'inscription");
            entity.Property(e => e.Datesuspension).HasComment("Date de derniere suspension d'un membre");
            entity.Property(e => e.Endette).HasComment("Indique si le membre est endette");
            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.IsActive).HasComment("Statut actif ou non d'un membre");
            entity.Property(e => e.Nocni).HasComment("Nocni");
            entity.Property(e => e.PersonId).HasComment("Person_id");
            entity.Property(e => e.ReportNouveau).HasComment("Report a nouveau indiquant les dettes d'un membre au terme d'un exercice precedent");
            entity.Property(e => e.Soldedebut).HasComment("SoldeDebut");
            entity.Property(e => e.Soldefin)
                .HasDefaultValueSql("0")
                .HasComment("SoldeFin");
            entity.Property(e => e.Tauxcotisation).HasComment("Report a nouveau du membre pour la nouvelle annee");
            entity.Property(e => e.TotalVerse).HasComment("Total_verse");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetInscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_core_ann");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetInscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_core_per");

            entity.HasOne(d => d.MeetAntenne).WithMany(p => p.MeetInscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_meet_ant");
        });

        modelBuilder.Entity<MeetMaxAllowSignature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_meet_max_allow_signature");

            entity.ToTable("meet_max_allow_signature", "tontine_v14", tb => tb.HasComment("Meet_Max_allow_signature"));

            entity.Property(e => e.Id).HasComment("Id");
            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.MaxSignature).HasComment("La valeur de cet attribut a partir de la somme des lignes faisant reference a un type de rubrique pour une annee donnee");
            entity.Property(e => e.TyperubId).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetMaxAllowSignatures)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_max_associati_core_ann");

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetMaxAllowSignatures)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_max_associati_meet_typ");
        });

        modelBuilder.Entity<MeetMembreBureau>(entity =>
        {
            entity.HasKey(e => e.BureaudetailsId).HasName("pk_meet_membre_bureau");

            entity.ToTable("meet_membre_bureau", "tontine_v14", tb => tb.HasComment("Meet_Membre_Bureau"));

            entity.Property(e => e.BureaudetailsId).HasComment("bureaudetails_id");
            entity.Property(e => e.BureauId).HasComment("Bureau_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.PosteId).HasComment("Poste_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Bureau).WithMany(p => p.MeetMembreBureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_bur");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetMembreBureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_ins");

            entity.HasOne(d => d.Poste).WithMany(p => p.MeetMembreBureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_pos");
        });

        modelBuilder.Entity<MeetOrdrePassage>(entity =>
        {
            entity.HasKey(e => e.PassageId).HasName("pk_meet_ordre_passage");

            entity.ToTable("meet_ordre_passage", "tontine_v14", tb => tb.HasComment("Meet_Ordre_Passage"));

            entity.Property(e => e.PassageId).HasComment("passage_id");
            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Commentaire).HasComment("Commentaire");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.DivisionId).HasComment("Identifiant de la division");
            entity.Property(e => e.Heuredebut).HasComment("HeureDebut");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.Montantpercu).HasComment("MontantPercu");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetOrdrePassages)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ord_associati_meet_ins");

            entity.HasOne(d => d.CoreSubdivision).WithMany(p => p.MeetOrdrePassages)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ord_associati_core_sub");
        });

        modelBuilder.Entity<MeetPoste>(entity =>
        {
            entity.HasKey(e => e.PosteId).HasName("pk_meet_poste");

            entity.ToTable("meet_poste", "tontine_v14", tb => tb.HasComment("Poste occupe par un membre de l'association"));

            entity.Property(e => e.PosteId).HasComment("Poste_id");
            entity.Property(e => e.Code).HasComment("Les valeurs autorisees sont: {PRESIDENT, TRESORIER, SG, SGA, CC, CENSOR, MEMBER}");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Libelle).HasComment("Libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");
        });

        modelBuilder.Entity<MeetPreference>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("pk_meet_preference");

            entity.ToTable("meet_preference", "tontine_v14", tb => tb.HasComment("Meet_Preference"));

            entity.Property(e => e.SettingId)
                .ValueGeneratedNever()
                .HasComment("Identifiant de l'entite");
            entity.Property(e => e.EnableAutoDispatchIncome)
                .HasDefaultValueSql("true")
                .HasComment("Enable_auto_dispatch_income");
            entity.Property(e => e.EnableAutoGenPresence)
                .HasDefaultValueSql("true")
                .HasComment("Enable_auto_gen_presence");
            entity.Property(e => e.EnableFixedAmountFees).HasComment("Enable_fixed_amount_fees");
            entity.Property(e => e.EnableFixedFeesByAnten).HasComment("Enable_fixed_fees_by_anten");
            entity.Property(e => e.EnableMaxDelayPenalites)
                .HasDefaultValueSql("true")
                .HasComment("Enable_max_delay_penalites");
            entity.Property(e => e.EnableSecoursInsurance).HasComment("Enable_Secours_insurance");
            entity.Property(e => e.EnableSigningOutcome).HasComment("Enable_signing_outcome");
            entity.Property(e => e.TauxInteretMensuel).HasComment("Taux d'interet mensuel pour un pret");
            entity.Property(e => e.TauxInteretPenalite).HasComment("Taux d'interet applicable en cas de non respect de l'echeance d'un pret");
            entity.Property(e => e.TauxPenaliteCotisation).HasComment("Taux d'interet applicable en cas de penalite pour echec a une cotiisation");

            entity.HasOne(d => d.Setting).WithOne(p => p.MeetPreference)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_generalis_core_ann");
        });

        modelBuilder.Entity<MeetPresence>(entity =>
        {
            entity.HasKey(e => e.PresenceId).HasName("pk_meet_presence");

            entity.ToTable("meet_presence", "tontine_v14", tb => tb.HasComment("Represente l'etat des presences des membres a une seance de reunion et l'ensemble des signatures apposees par les membres (beneficiaire et bureau) de l'association sur un document"));

            entity.Property(e => e.PresenceId).HasComment("Identiifant de la signature");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Dateop).HasComment("Dateop");
            entity.Property(e => e.Globalverse).HasComment("globalverse");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.IsAbsent).HasComment("Is_absent");
            entity.Property(e => e.NumBordero).HasComment("Num_bordero");
            entity.Property(e => e.SeanceId).HasComment("Seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetPresences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_ins");

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetPresences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_sea");
        });

        modelBuilder.Entity<MeetPret>(entity =>
        {
            entity.HasKey(e => e.SortiecaisseId).HasName("pk_meet_pret");

            entity.ToTable("meet_pret", "tontine_v14", tb => tb.HasComment("Meet_Pret"));

            entity.Property(e => e.SortiecaisseId).HasComment("Sortiecaisse_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Dateevts).HasComment("Date effective a laquelle a lieu l'evenement");
            entity.Property(e => e.DureeFinale).HasComment("Duree_finale");
            entity.Property(e => e.DureeInitiale).HasComment("Duree du pret en nombre de mois");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.IsClosed).HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)");
            entity.Property(e => e.MontantInteret).HasComment("Montant de l'interet");
            entity.Property(e => e.MontantPenalite).HasComment("Montant applicable en cas de penalite sur les interets ou en cas d'absence de cotisation");
            entity.Property(e => e.Montantpercu).HasComment("Montant percu par le beneficiaire de l'evenement");
            entity.Property(e => e.Note).HasComment("Observation generale concernant le deroulement de l'evenement");
            entity.Property(e => e.RefNo).HasComment("No de Reference permettant d'identifier le pret");
            entity.Property(e => e.SeanceId).HasComment("Seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");
            entity.Property(e => e.Visarestants).HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetPrets)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_ins");

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetPrets)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_sea");
        });

        modelBuilder.Entity<MeetRubrique>(entity =>
        {
            entity.HasKey(e => e.RubriqueId).HasName("pk_meet_rubrique");

            entity.ToTable("meet_rubrique", "tontine_v14", tb => tb.HasComment("Represente la personnalisation de certaines valeurs appliquees aux types d'eveneents au cours d'une annee"));

            entity.Property(e => e.RubriqueId).HasComment("Identifiant d'une configuration");
            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Commentaire).HasComment("Commentaire");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.IsOutcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.Libelle).HasComment("Description de la rubrique (evenement)");
            entity.Property(e => e.MontantPerson).HasComment("Montant total associe a l'evenement");
            entity.Property(e => e.Montantroute).HasComment("Montant du deplacement d'un membre mandate par l'association");
            entity.Property(e => e.Nbmandataire).HasComment("Nombre de membres representant l'asociation a l'evenement");
            entity.Property(e => e.TyperubId).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetRubriques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_rub_associati_core_ann");

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetRubriques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_rub_associati_meet_typ");
        });

        modelBuilder.Entity<MeetSeance>(entity =>
        {
            entity.HasKey(e => e.SeanceId).HasName("pk_meet_seance");

            entity.ToTable("meet_seance", "tontine_v14", tb => tb.HasComment("Meet_seance"));

            entity.Property(e => e.SeanceId).HasComment("Seance_id");
            entity.Property(e => e.AnneeId).HasComment("Identifiant de l'annee");
            entity.Property(e => e.AntenneId).HasComment("Identifiant de l'antenne");
            entity.Property(e => e.Closedate).HasComment("Date et heure de fermeture de la reunion");
            entity.Property(e => e.Compterendu).HasComment("Compte rendu de la seance de reunion");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Depensecollation).HasComment("DepenseCollation");
            entity.Property(e => e.DivisionId).HasComment("Identifiant de la division");
            entity.Property(e => e.EtabId).HasComment("Etab_id");
            entity.Property(e => e.Opendate).HasComment("Date et heure d'ouverture de la reunion");
            entity.Property(e => e.Status).HasComment("Le statut {CLOSED} indique que la reunion est cloturee et ses donnees ne sont plus modifiables");
            entity.Property(e => e.TotalEntrees).HasComment("Total_entrees");
            entity.Property(e => e.TotalSorties).HasComment("Total_Sorties");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.CoreSubdivision).WithMany(p => p.MeetSeances)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sea_associati_core_sub");

            entity.HasOne(d => d.MeetAntenne).WithMany(p => p.MeetSeances)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sea_associati_meet_ant");
        });

        modelBuilder.Entity<MeetSortieCaisse>(entity =>
        {
            entity.HasKey(e => e.SortiecaisseId).HasName("pk_meet_sortie_caisse");

            entity.ToTable("meet_sortie_caisse", "tontine_v14", tb => tb.HasComment("Meet_Sortie_Caisse"));

            entity.Property(e => e.SortiecaisseId).HasComment("Sortiecaisse_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Dateevts).HasComment("Date effective a laquelle a lieu l'evenement");
            entity.Property(e => e.EngagementId).HasComment("Engagement_id");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.IsClosed).HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)");
            entity.Property(e => e.ListeMandataires).HasComment("Liste des membres designes pour le deplacement");
            entity.Property(e => e.MontantRoute).HasComment("Montant dedie au deplacement des membres");
            entity.Property(e => e.Montantpercu).HasComment("Montant percu par le beneficiaire de l'evenement");
            entity.Property(e => e.Note).HasComment("Observation generale concernant le deroulement de l'evenement");
            entity.Property(e => e.SeanceId).HasComment("Seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");
            entity.Property(e => e.Visarestants).HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.");

            entity.HasOne(d => d.Engagement).WithMany(p => p.MeetSortieCaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_eng");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetSortieCaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_ins");

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetSortieCaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_sea");
        });

        modelBuilder.Entity<MeetSuspensionMembre>(entity =>
        {
            entity.HasKey(e => e.SuspensionId).HasName("pk_meet_suspension_membre");

            entity.ToTable("meet_suspension_membre", "tontine_v14", tb => tb.HasComment("Meet_Suspension_Membre"));

            entity.Property(e => e.SuspensionId).HasComment("Suspension_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.DateRetour).HasComment("Date_retour");
            entity.Property(e => e.DateSuspension).HasComment("Date_suspension");
            entity.Property(e => e.IsActive).HasComment("Is_active");
            entity.Property(e => e.PersonId).HasComment("Person_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetSuspensionMembres)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sus_associati_core_per");
        });

        modelBuilder.Entity<MeetTypeRubrique>(entity =>
        {
            entity.HasKey(e => e.TyperubId).HasName("pk_meet_type_rubrique");

            entity.ToTable("meet_type_rubrique", "tontine_v14", tb => tb.HasComment("Represente un type d'evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc."));

            entity.Property(e => e.TyperubId).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.AutoGenerated).HasComment("Indique si le systeme cree automatiquement une rubrique correspondante quand sa valeur est TRUE");
            entity.Property(e => e.Candelete).HasComment("Indique si l'utlisateur peut supprimer cette information");
            entity.Property(e => e.Code).HasComment("Les valeurs autorisees sont : {PRET, FONDENTRAIDE, COLLATION, EPARGNE, COTISATION, AIDE-NAISSANCE, AIDE-DECES, AIDE-MARIAGE, AIDE-DECES-CONJOINT, AIDE-DECES-FRERE, SECOURS, PENALITE-AIDES-DECES, PROJET}");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.IsActive).HasComment("Lorsque sa valeur est a TRUE, le systeme peut proposser a l'utilisateur (ou automatiquement) la creation des rubrique associee a ce type.");
            entity.Property(e => e.IsOutcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.Libelle).HasComment("Libelle du type d'evenement");
            entity.Property(e => e.Maxsignature).HasComment("Nombre de signatures autorises pour signer un documents associe a ce type devenement");
            entity.Property(e => e.MontantPerson).HasComment("Montant total associe a l'evenement");
            entity.Property(e => e.Montantpenalite).HasComment("Montant de la penalite applicable en cas d'absence aa l'evenement");
            entity.Property(e => e.Montantroute).HasComment("Montant du deplacement d'un membre mandate par l'association");
            entity.Property(e => e.Nbmandataire).HasComment("Nombre de membres representant l'asociation a l'evenement");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasComment("Defini l'ordre dans lequel les rubriques de ce type peuevnt beneficier d'une repartition automatique du montant verse par un membre d'une reunion");
            entity.Property(e => e.Required).HasComment("Indique que toutes les rubriques de ce type sont automatiquement cotisees par les membres d'une reunion");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");
        });

        modelBuilder.Entity<MeetVisa>(entity =>
        {
            entity.HasKey(e => e.VisaId).HasName("pk_meet_visas");

            entity.ToTable("meet_visas", "tontine_v14", tb => tb.HasComment("Meet_Visas"));

            entity.Property(e => e.VisaId).HasComment("Identiifant de la signature");
            entity.Property(e => e.ConfigvisaId).HasComment("Identifiant de la configuration de signature");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.CreateUid).HasComment("create_uid");
            entity.Property(e => e.Datesign).HasComment("Date de signature");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.MeetOperation).HasComment("Meet_Operation");
            entity.Property(e => e.Receiver).HasComment("Indique si le signataire est le beneficiare");
            entity.Property(e => e.SignByOrdre).HasComment("Indique si le document est signe par ordre");
            entity.Property(e => e.SortiecaisseId).HasComment("Sortiecaisse_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.UpdateUid).HasComment("update_uid");

            entity.HasOne(d => d.Configvisa).WithMany(p => p.MeetVisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_con");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetVisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_ins");

            entity.HasOne(d => d.MeetOperationNavigation).WithMany(p => p.MeetVisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_pre");

            entity.HasOne(d => d.Sortiecaisse).WithMany(p => p.MeetVisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_sor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
