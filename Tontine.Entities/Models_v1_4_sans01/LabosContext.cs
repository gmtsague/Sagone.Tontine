using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_sans01;

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

            entity.HasIndex(e => new { e.Datedebut, e.Datefin }, "ak_uniq_annee_core_ann").IsUnique();

            entity.HasIndex(e => e.BureauId, "association_24_fk");

            entity.HasIndex(e => e.PreviousYearId, "association_50_fk");

            entity.HasIndex(e => e.FrequenceId, "association_53_fk");

            entity.HasIndex(e => e.AnneeId, "core_annee_pk").IsUnique();

            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.BureauId)
                .HasComment("Bureau_id")
                .HasColumnName("bureau_id");
            entity.Property(e => e.CopyDataFromPrevious)
                .HasComment("Copy_data_from_previous")
                .HasColumnName("copy_data_from_previous");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Datedebut)
                .HasComment("Date de debut de l'annee")
                .HasColumnName("datedebut");
            entity.Property(e => e.Datefin)
                .HasComment("Date de fin de l'annee")
                .HasColumnName("datefin");
            entity.Property(e => e.FrequenceId)
                .HasComment("Frequence_id")
                .HasColumnName("frequence_id");
            entity.Property(e => e.IsClosed)
                .HasComment("Indique que l'annee et cloturee et ses donnees ne sont plus modifiables")
                .HasColumnName("is_closed");
            entity.Property(e => e.IsCurrent)
                .HasComment("Indique l'annee de travail")
                .HasColumnName("is_current");
            entity.Property(e => e.Libelle)
                .HasMaxLength(128)
                .HasComment("Libelle de l'annee")
                .HasColumnName("libelle");
            entity.Property(e => e.Nbdivision)
                .HasDefaultValueSql("12")
                .HasComment("Nombre de divisions de l'annee")
                .HasColumnName("nbdivision");
            entity.Property(e => e.PreviousYearId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("previous_year_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bureau).WithMany(p => p.CoreAnnees)
                .HasForeignKey(d => d.BureauId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_meet_bur");

            entity.HasOne(d => d.Frequence).WithMany(p => p.CoreAnnees)
                .HasForeignKey(d => d.FrequenceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_fre");

            entity.HasOne(d => d.PreviousYear).WithMany(p => p.InversePreviousYear)
                .HasForeignKey(d => d.PreviousYearId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");
        });

        modelBuilder.Entity<CoreAnnualSetting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("pk_core_annual_setting");

            entity.ToTable("core_annual_setting", "tontine_v14", tb => tb.HasComment("core_Annual_setting"));

            entity.HasIndex(e => e.EtabId, "association_40_fk");

            entity.HasIndex(e => e.AnneeId, "association_41_fk");

            entity.HasIndex(e => e.SettingId, "core_annual_setting_pk").IsUnique();

            entity.Property(e => e.SettingId)
                .HasComment("Identifiant de l'entite")
                .HasColumnName("setting_id");
            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.Copyengagements)
                .HasComment("CopyEngagements")
                .HasColumnName("copyengagements");
            entity.Property(e => e.Copymembers)
                .HasComment("CopyMembers")
                .HasColumnName("copymembers");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.MaxAllowPhotoLiens)
                .HasComment("Nombre max de liens autorises pour la photo d'une personne")
                .HasColumnName("max_allow_photo_liens");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.CoreAnnualSettings)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");

            entity.HasOne(d => d.Etab).WithMany(p => p.CoreAnnualSettings)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_eta");
        });

        modelBuilder.Entity<CoreAutorisation>(entity =>
        {
            entity.HasKey(e => e.ChoixId).HasName("pk_core_autorisations");

            entity.ToTable("core_autorisations", "tontine_v14", tb => tb.HasComment("core_Autorisations"));

            entity.HasIndex(e => e.ProfilId, "association_30_fk");

            entity.HasIndex(e => e.Idcmde, "association_31_fk");

            entity.HasIndex(e => e.ChoixId, "core_autorisations_pk").IsUnique();

            entity.Property(e => e.ChoixId)
                .HasComment("Choix_id")
                .HasColumnName("choix_id");
            entity.Property(e => e.Idcmde)
                .HasComment("Idcmde")
                .HasColumnName("idcmde");
            entity.Property(e => e.IsActive)
                .HasComment("Is_active")
                .HasColumnName("is_active");
            entity.Property(e => e.ProfilId)
                .HasComment("Profil_id")
                .HasColumnName("profil_id");

            entity.HasOne(d => d.IdcmdeNavigation).WithMany(p => p.CoreAutorisations)
                .HasForeignKey(d => d.Idcmde)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_com");

            entity.HasOne(d => d.Profil).WithMany(p => p.CoreAutorisations)
                .HasForeignKey(d => d.ProfilId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_pro");
        });

        modelBuilder.Entity<CoreBank>(entity =>
        {
            entity.HasKey(e => e.BankId).HasName("pk_core_bank");

            entity.ToTable("core_bank", "tontine_v14", tb => tb.HasComment("Etablissement financier"));

            entity.HasIndex(e => e.CountryId, "association_43_fk");

            entity.HasIndex(e => e.BankId, "core_bank_pk").IsUnique();

            entity.Property(e => e.BankId)
                .HasComment("Identifiant de la banque")
                .HasColumnName("bank_id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(1024)
                .HasComment("Adresse postale de la banque")
                .HasColumnName("adresse");
            entity.Property(e => e.Coderib)
                .HasMaxLength(64)
                .HasComment("Numero de compte de l'association chez la baqnue")
                .HasColumnName("coderib");
            entity.Property(e => e.CountryId)
                .HasComment("Identifiant du pays")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasComment("Contact telephonique de la banque No2")
                .HasColumnName("email");
            entity.Property(e => e.Libelle)
                .HasMaxLength(1024)
                .HasComment("Libelle de la banque")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CoreBanks)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_cou");
        });

        modelBuilder.Entity<CoreBankaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("pk_core_bankaccount");

            entity.ToTable("core_bankaccount", "tontine_v14", tb => tb.HasComment("core_Bankaccount"));

            entity.HasIndex(e => e.BankId, "association_17_fk");

            entity.HasIndex(e => e.PersonId, "association_27_fk");

            entity.HasIndex(e => e.EtabId, "association_28_fk");

            entity.HasIndex(e => e.AccountId, "core_bankaccount_pk").IsUnique();

            entity.HasIndex(e => new { e.BankId, e.CompteNo }, "uniq_bank_account").IsUnique();

            entity.Property(e => e.AccountId)
                .HasComment("Account_id")
                .HasColumnName("account_id");
            entity.Property(e => e.BankId)
                .HasComment("Identifiant de la banque")
                .HasColumnName("bank_id");
            entity.Property(e => e.CompteNo)
                .HasMaxLength(64)
                .HasComment("Compte_no")
                .HasColumnName("compte_no");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.IsActive)
                .HasComment("Is_active")
                .HasColumnName("is_active");
            entity.Property(e => e.PersonId)
                .HasComment("Person_id")
                .HasColumnName("person_id");
            entity.Property(e => e.Solde)
                .HasComment("Solde")
                .HasColumnName("solde");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bank).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_ban");

            entity.HasOne(d => d.Etab).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_eta");

            entity.HasOne(d => d.Person).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_per");
        });

        modelBuilder.Entity<CoreCommande>(entity =>
        {
            entity.HasKey(e => e.Idcmde).HasName("pk_core_commandes");

            entity.ToTable("core_commandes", "tontine_v14", tb => tb.HasComment("core_Commandes"));

            entity.HasIndex(e => e.Idcmde, "core_commandes_pk").IsUnique();

            entity.Property(e => e.Idcmde)
                .HasComment("Idcmde")
                .HasColumnName("idcmde");
            entity.Property(e => e.Libelle)
                .HasComment("Libelle")
                .HasColumnType("jsonb")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("pk_core_country");

            entity.ToTable("core_country", "tontine_v14", tb => tb.HasComment("core_country"));

            entity.HasIndex(e => e.CountryId, "core_country_pk").IsUnique();

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du pays")
                .HasColumnName("country_id");
            entity.Property(e => e.CodeIso2)
                .HasMaxLength(8)
                .HasComment("Code (2 caracteres) ISO du pays")
                .HasColumnName("code_iso2");
            entity.Property(e => e.CodeIso3)
                .HasMaxLength(8)
                .HasComment("Code (3 caracteres) ISO du pays")
                .HasColumnName("code_iso3");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Devise)
                .HasMaxLength(128)
                .HasComment("Devise du pays")
                .HasColumnName("devise");
            entity.Property(e => e.Libelle)
                .HasComment("Nom du pays")
                .HasColumnType("jsonb")
                .HasColumnName("libelle");
            entity.Property(e => e.PhoneCode)
                .HasMaxLength(8)
                .HasComment("Code telephonique du pays")
                .HasColumnName("phone_code");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<CoreEtablissement>(entity =>
        {
            entity.HasKey(e => e.EtabId).HasName("pk_core_etablissement");

            entity.ToTable("core_etablissement", "tontine_v14", tb => tb.HasComment("core_Etablissement"));

            entity.HasIndex(e => e.CountryId, "association_42_fk");

            entity.HasIndex(e => e.EtabId, "core_etablissement_pk").IsUnique();

            entity.HasIndex(e => e.DeployedUrl, "uniq_deployed_url").IsUnique();

            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(1024)
                .HasComment("Adresse")
                .HasColumnName("adresse");
            entity.Property(e => e.ConnString)
                .HasMaxLength(1024)
                .HasComment("Conn_string")
                .HasColumnName("conn_string");
            entity.Property(e => e.CountryId)
                .HasComment("Identifiant du pays")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Creationdate)
                .HasComment("Creationdate")
                .HasColumnName("creationdate");
            entity.Property(e => e.DatabaseName)
                .HasMaxLength(1024)
                .HasComment("Database_name")
                .HasColumnName("database_name");
            entity.Property(e => e.DeployedUrl)
                .HasMaxLength(1024)
                .HasComment("Deployed_Url")
                .HasColumnName("deployed_url");
            entity.Property(e => e.EnableMultiAntenne)
                .HasComment("Enable_multi_antenne")
                .HasColumnName("enable_multi_antenne");
            entity.Property(e => e.Libelle)
                .HasMaxLength(256)
                .HasComment("Libelle")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CoreEtablissements)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_eta_associati_core_cou");
        });

        modelBuilder.Entity<CoreFrequenceDivision>(entity =>
        {
            entity.HasKey(e => e.FrequenceId).HasName("pk_core_frequence_division");

            entity.ToTable("core_frequence_division", "tontine_v14", tb => tb.HasComment("core_Frequence_Division"));

            entity.HasIndex(e => e.NbDays, "ak_alt_key_frequence_core_fre").IsUnique();

            entity.HasIndex(e => e.FrequenceId, "core_frequence_division_pk").IsUnique();

            entity.Property(e => e.FrequenceId)
                .HasComment("Frequence_id")
                .HasColumnName("frequence_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Libelle)
                .HasMaxLength(128)
                .HasComment("Libelle")
                .HasColumnName("libelle");
            entity.Property(e => e.NbDays)
                .HasComment("Nb_Days")
                .HasColumnName("nb_days");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<CoreLangue>(entity =>
        {
            entity.HasKey(e => e.LangueId).HasName("pk_core_langue");

            entity.ToTable("core_langue", "tontine_v14", tb => tb.HasComment("core_Langue"));

            entity.HasIndex(e => e.LangueId, "core_langue_pk").IsUnique();

            entity.Property(e => e.LangueId)
                .HasComment("Identifiant de la langue")
                .HasColumnName("langue_id");
            entity.Property(e => e.IsActive)
                .HasComment("Isactive")
                .HasColumnName("is_active");
            entity.Property(e => e.IsDefault)
                .HasComment("Indique la langue par defaut")
                .HasColumnName("is_default");
            entity.Property(e => e.Isocode)
                .HasMaxLength(8)
                .HasComment("Code ISO de la langue")
                .HasColumnName("isocode");
            entity.Property(e => e.Libelle)
                .HasComment("Libelle de la langue")
                .HasColumnType("jsonb")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreModepaie>(entity =>
        {
            entity.HasKey(e => e.ModepaieId).HasName("pk_core_modepaie");

            entity.ToTable("core_modepaie", "tontine_v14", tb => tb.HasComment("Mode de paiement utilise par un membre"));

            entity.HasIndex(e => e.ModepaieId, "core_modepaie_pk").IsUnique();

            entity.Property(e => e.ModepaieId)
                .HasComment("Identifiant du mode de paiement")
                .HasColumnName("modepaie_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsCash)
                .HasComment("Indique si le mode represnte le CASH")
                .HasColumnName("is_cash");
            entity.Property(e => e.Libelle)
                .HasMaxLength(128)
                .HasComment("Libelle du mode de paiement")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<CorePerson>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("pk_core_person");

            entity.ToTable("core_person", "tontine_v14", tb => tb.HasComment("Represente un membre de la reunion"));

            entity.HasIndex(e => e.EtabId, "association_48_fk");

            entity.HasIndex(e => e.CountryId, "association_8_fk");

            entity.HasIndex(e => e.PersonId, "core_person_pk").IsUnique();

            entity.HasIndex(e => e.Nocni, "uniq_cni_person").IsUnique();

            entity.HasIndex(e => new { e.Nom, e.Prenom, e.Datenais, e.Lieunais, e.Sexe }, "uniq_person").IsUnique();

            entity.HasIndex(e => e.Email, "unique_email_person").IsUnique();

            entity.Property(e => e.PersonId)
                .HasComment("Person_id")
                .HasColumnName("person_id");
            entity.Property(e => e.AdhesionDate)
                .HasComment("Adhesion_date")
                .HasColumnName("adhesion_date");
            entity.Property(e => e.Adresse)
                .HasMaxLength(1024)
                .HasComment("Adresse")
                .HasColumnName("adresse");
            entity.Property(e => e.AnneePromo)
                .HasMaxLength(32)
                .HasComment("Annee_promo")
                .HasColumnName("annee_promo");
            entity.Property(e => e.CniExpireDate)
                .HasComment("CNI_Expire_date")
                .HasColumnName("cni_expire_date");
            entity.Property(e => e.CountryId)
                .HasComment("Identifiant du pays")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Datenais)
                .HasComment("Datenais")
                .HasColumnName("datenais");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasComment("Email")
                .HasColumnName("email");
            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.IsActive)
                .HasComment("Indique si le membre est suspendu ou pas")
                .HasColumnName("is_active");
            entity.Property(e => e.IsVisible)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasComment("Cette personne represente un utilisateur systeme")
                .HasColumnName("is_visible");
            entity.Property(e => e.Lieunais)
                .HasMaxLength(128)
                .HasComment("lieunais")
                .HasColumnName("lieunais");
            entity.Property(e => e.Nocni)
                .HasMaxLength(32)
                .HasComment("Nocni")
                .HasColumnName("nocni");
            entity.Property(e => e.Nom)
                .HasMaxLength(128)
                .HasComment("Nom")
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(128)
                .HasDefaultValueSql("''::character varying")
                .HasComment("Prenom")
                .HasColumnName("prenom");
            entity.Property(e => e.Sexe)
                .HasMaxLength(16)
                .HasComment("Sexe")
                .HasColumnName("sexe");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CorePeople)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_cou");

            entity.HasOne(d => d.Etab).WithMany(p => p.CorePeople)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_eta");
        });

        modelBuilder.Entity<CorePhonenumber>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("pk_core_phonenumber");

            entity.ToTable("core_phonenumber", "tontine_v14", tb => tb.HasComment("core_Phonenumber"));

            entity.HasIndex(e => e.PersonId, "association_10_fk2");

            entity.HasIndex(e => e.BankId, "association_44_fk");

            entity.HasIndex(e => e.CountryId, "association_5_fk2");

            entity.HasIndex(e => e.PhoneId, "core_phonenumber_pk").IsUnique();

            entity.Property(e => e.PhoneId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du numero de telephone")
                .HasColumnName("phone_id");
            entity.Property(e => e.BankId)
                .HasComment("Identifiant de la banque")
                .HasColumnName("bank_id");
            entity.Property(e => e.CountryId)
                .HasComment("Identifiant du pays")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsDefaut)
                .HasComment("Represente le numero par defaut")
                .HasColumnName("is_defaut");
            entity.Property(e => e.PersonId)
                .HasComment("Person_id")
                .HasColumnName("person_id");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(32)
                .HasComment("Numero telephone")
                .HasColumnName("phone_no");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bank).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_ban");

            entity.HasOne(d => d.Country).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_cou");

            entity.HasOne(d => d.Person).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<CorePhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("pk_core_photos");

            entity.ToTable("core_photos", "tontine_v14", tb => tb.HasComment("core_Photos"));

            entity.HasIndex(e => e.PersonId, "association_11_fk2");

            entity.HasIndex(e => e.EtabId, "association_39_fk");

            entity.HasIndex(e => e.PhotoId, "core_photos_pk").IsUnique();

            entity.Property(e => e.PhotoId)
                .ValueGeneratedNever()
                .HasComment("Identifiant d'une photo")
                .HasColumnName("photo_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.Fileext)
                .HasMaxLength(32)
                .HasComment("Extension du fichier")
                .HasColumnName("fileext");
            entity.Property(e => e.Filename)
                .HasMaxLength(1024)
                .HasComment("Filename")
                .HasColumnName("filename");
            entity.Property(e => e.Filepath)
                .HasMaxLength(1024)
                .HasComment("Chemin d'acces au fichier")
                .HasColumnName("filepath");
            entity.Property(e => e.Image)
                .HasMaxLength(254)
                .HasComment("Image")
                .HasColumnName("image");
            entity.Property(e => e.IsSignature)
                .HasComment("Represente une signature")
                .HasColumnName("is_signature");
            entity.Property(e => e.MaxAllowLiens)
                .HasComment("Nombre max de liens autorises")
                .HasColumnName("max_allow_liens");
            entity.Property(e => e.NbActualLiens)
                .HasComment("Nombre de liens actuels")
                .HasColumnName("nb_actual_liens");
            entity.Property(e => e.PersonId)
                .HasComment("Person_id")
                .HasColumnName("person_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.CorePhotos)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_eta");

            entity.HasOne(d => d.Person).WithMany(p => p.CorePhotos)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<CoreProfil>(entity =>
        {
            entity.HasKey(e => e.ProfilId).HasName("pk_core_profil");

            entity.ToTable("core_profil", "tontine_v14", tb => tb.HasComment("core_Profil"));

            entity.HasIndex(e => e.ProfilId, "core_profil_pk").IsUnique();

            entity.Property(e => e.ProfilId)
                .HasComment("Profil_id")
                .HasColumnName("profil_id");
            entity.Property(e => e.Candelete)
                .HasComment("Candelete")
                .HasColumnName("candelete");
            entity.Property(e => e.Libelle)
                .HasComment("Libelle")
                .HasColumnType("jsonb")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreSubdivision>(entity =>
        {
            entity.HasKey(e => new { e.AnneeId, e.DivisionId }).HasName("pk_core_subdivision");

            entity.ToTable("core_subdivision", "tontine_v14", tb => tb.HasComment("Represente le decoupage mensuel de l'annee"));

            entity.HasIndex(e => e.MonthDate, "ak_uniq_subdivision_core_sub").IsUnique();

            entity.HasIndex(e => e.AnneeId, "association_1_fk");

            entity.HasIndex(e => new { e.AnneeId, e.DivisionId }, "core_subdivision_pk").IsUnique();

            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.DivisionId)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de la division")
                .HasColumnName("division_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Libelle)
                .HasMaxLength(128)
                .HasComment("Libelle de la division")
                .HasColumnName("libelle");
            entity.Property(e => e.MonthDate)
                .HasComment("Date de debut de la division")
                .HasColumnName("month_date");
            entity.Property(e => e.MonthDay)
                .HasComment("Jour du mois ou aura lieu la reunion")
                .HasColumnName("month_day");
            entity.Property(e => e.Numordre)
                .HasComment("Numero d'ordre de la division")
                .HasColumnName("numordre");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.CoreSubdivisions)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_sub_associati_core_ann");
        });

        modelBuilder.Entity<CoreUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_core_user");

            entity.ToTable("core_user", "tontine_v14", tb => tb.HasComment("core_User"));

            entity.HasIndex(e => e.ProfilId, "association_32_fk");

            entity.HasIndex(e => e.LangueId, "association_38_fk");

            entity.HasIndex(e => e.UserId, "core_user_pk").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasComment("User_Id")
                .HasColumnName("user_id");
            entity.Property(e => e.ExpirationDate)
                .HasComment("Date d'expiration")
                .HasColumnName("expiration_date");
            entity.Property(e => e.IsActif)
                .HasComment("Compte actif")
                .HasColumnName("is_actif");
            entity.Property(e => e.LangueId)
                .HasComment("Identifiant de la langue")
                .HasColumnName("langue_id");
            entity.Property(e => e.LastConnexion)
                .HasComment("Last_connexion")
                .HasColumnName("last_connexion");
            entity.Property(e => e.Passwd)
                .HasMaxLength(254)
                .HasComment("Mot de passe")
                .HasColumnName("passwd");
            entity.Property(e => e.ProfilId)
                .HasComment("Profil_id")
                .HasColumnName("profil_id");
            entity.Property(e => e.Username)
                .HasMaxLength(128)
                .HasComment("Nom d'utilisateur")
                .HasColumnName("username");

            entity.HasOne(d => d.Langue).WithMany(p => p.CoreUsers)
                .HasForeignKey(d => d.LangueId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_lan");

            entity.HasOne(d => d.Profil).WithMany(p => p.CoreUsers)
                .HasForeignKey(d => d.ProfilId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_pro");
        });

        modelBuilder.Entity<MeetAntenne>(entity =>
        {
            entity.HasKey(e => new { e.EtabId, e.AntenneId }).HasName("pk_meet_antenne");

            entity.ToTable("meet_antenne", "tontine_v14", tb => tb.HasComment("Represente ue antenne de l'association"));

            entity.HasIndex(e => e.EtabId, "association_49_fk");

            entity.HasIndex(e => new { e.EtabId, e.AntenneId }, "meet_antenne_pk").IsUnique();

            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.AntenneId)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de l'antenne")
                .HasColumnName("antenne_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Creationdate)
                .HasComment("Date de creation de l'antenne")
                .HasColumnName("creationdate");
            entity.Property(e => e.Libelle)
                .HasMaxLength(128)
                .HasComment("Libelle de l'antenne")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.MeetAntennes)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ant_associati_core_eta");
        });

        modelBuilder.Entity<MeetBureau>(entity =>
        {
            entity.HasKey(e => e.BureauId).HasName("pk_meet_bureau");

            entity.ToTable("meet_bureau", "tontine_v14", tb => tb.HasComment("Meet_Bureau"));

            entity.HasIndex(e => e.EtabId, "association_45_fk");

            entity.HasIndex(e => e.BureauId, "meet_bureau_pk").IsUnique();

            entity.HasIndex(e => new { e.EtabId, e.Debut, e.Fin }, "uniq_bureau").IsUnique();

            entity.Property(e => e.BureauId)
                .HasComment("Bureau_id")
                .HasColumnName("bureau_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Debut)
                .HasComment("Debut")
                .HasColumnName("debut");
            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.Fin)
                .HasComment("Fin")
                .HasColumnName("fin");
            entity.Property(e => e.Libelle)
                .HasMaxLength(128)
                .HasComment("Libelle")
                .HasColumnName("libelle");
            entity.Property(e => e.Nbabstention)
                .HasComment("NbAbstention")
                .HasColumnName("nbabstention");
            entity.Property(e => e.Nbperson)
                .HasComment("Nbperson")
                .HasColumnName("nbperson");
            entity.Property(e => e.Nbvotes)
                .HasComment("Nbvotes")
                .HasColumnName("nbvotes");
            entity.Property(e => e.Resumevote)
                .HasComment("Resumevote")
                .HasColumnName("resumevote");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.MeetBureaus)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_bur_associati_core_eta");
        });

        modelBuilder.Entity<MeetConfigVisa>(entity =>
        {
            entity.HasKey(e => e.ConfigvisaId).HasName("pk_meet_config_visas");

            entity.ToTable("meet_config_visas", "tontine_v14", tb => tb.HasComment("Represente l'ensemble des autorisatios de signature de documents au sein de l'association"));

            entity.HasIndex(e => e.AnneeId, "association_6_fk");

            entity.HasIndex(e => e.PosteId, "association_7_fk");

            entity.HasIndex(e => e.TyperubId, "association_8_fk2");

            entity.HasIndex(e => e.ConfigvisaId, "meet_config_visas_pk").IsUnique();

            entity.HasIndex(e => new { e.PosteId, e.AnneeId, e.TyperubId }, "uniq_config_visas").IsUnique();

            entity.Property(e => e.ConfigvisaId)
                .HasComment("Identifiant de la configuration de signature")
                .HasColumnName("configvisa_id");
            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasComment("Numero d'ordre de la signature pour un type de document")
                .HasColumnName("numordre");
            entity.Property(e => e.PosteId)
                .HasComment("Poste_id")
                .HasColumnName("poste_id");
            entity.Property(e => e.SignByOrdre)
                .HasComment("Sign_by_ordre")
                .HasColumnName("sign_by_ordre");
            entity.Property(e => e.TyperubId)
                .HasComment("Identifiant du type d'evenement")
                .HasColumnName("typerub_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetConfigVisas)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_core_ann");

            entity.HasOne(d => d.Poste).WithMany(p => p.MeetConfigVisas)
                .HasForeignKey(d => d.PosteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_meet_pos");

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetConfigVisas)
                .HasForeignKey(d => d.TyperubId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_meet_typ");
        });

        modelBuilder.Entity<MeetEngagement>(entity =>
        {
            entity.HasKey(e => e.EngagementId).HasName("pk_meet_engagement");

            entity.ToTable("meet_engagement", "tontine_v14", tb => tb.HasComment("Meet_Engagement"));

            entity.HasIndex(e => e.RubriqueId, "association_2_fk");

            entity.HasIndex(e => e.PersonId, "association_59_fk");

            entity.HasIndex(e => e.EngagementId, "meet_engagement_pk").IsUnique();

            entity.Property(e => e.EngagementId)
                .HasComment("Engagement_id")
                .HasColumnName("engagement_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Cumulverse)
                .HasComment("Cumul des versements sur une rubrique")
                .HasColumnName("cumulverse");
            entity.Property(e => e.EngagementDate)
                .HasComment("Engagement_Date")
                .HasColumnName("engagement_date");
            entity.Property(e => e.IsClosed)
                .HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)")
                .HasColumnName("is_closed");
            entity.Property(e => e.IsOutcome)
                .HasComment("Indique si le type represente une sortie de caisse")
                .HasColumnName("is_outcome");
            entity.Property(e => e.PersonId)
                .HasComment("Person_id")
                .HasColumnName("person_id");
            entity.Property(e => e.RubriqueId)
                .HasComment("Identifiant d'une configuration")
                .HasColumnName("rubrique_id");
            entity.Property(e => e.Solde)
                .HasComment("Solde")
                .HasColumnName("solde");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetEngagements)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_eng_associati_core_per");

            entity.HasOne(d => d.Rubrique).WithMany(p => p.MeetEngagements)
                .HasForeignKey(d => d.RubriqueId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_eng_associati_meet_rub");
        });

        modelBuilder.Entity<MeetEntreeCaisse>(entity =>
        {
            entity.HasKey(e => e.OperationId).HasName("pk_meet_entree_caisse");

            entity.ToTable("meet_entree_caisse", "tontine_v14", tb => tb.HasComment("Meet_Entree_caisse"));

            entity.HasIndex(e => e.ModepaieId, "association_18_fk");

            entity.HasIndex(e => e.PresenceId, "association_20_fk");

            entity.HasIndex(e => e.EngagementId, "association_52_fk");

            entity.HasIndex(e => e.OperationId, "meet_entree_caisse_pk").IsUnique();

            entity.HasIndex(e => new { e.PresenceId, e.EngagementId }, "uniq_versement").IsUnique();

            entity.Property(e => e.OperationId)
                .HasComment("Operation_id")
                .HasColumnName("operation_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.EngagementId)
                .HasComment("Engagement_id")
                .HasColumnName("engagement_id");
            entity.Property(e => e.IsOutcome)
                .HasComment("Indique si le type represente une sortie de caisse")
                .HasColumnName("is_outcome");
            entity.Property(e => e.ModepaieId)
                .HasComment("Identifiant du mode de paiement")
                .HasColumnName("modepaie_id");
            entity.Property(e => e.Montantverse)
                .HasComment("MontantVerse")
                .HasColumnName("montantverse");
            entity.Property(e => e.PresenceId)
                .HasComment("Identiifant de la signature")
                .HasColumnName("presence_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Engagement).WithMany(p => p.MeetEntreeCaisses)
                .HasForeignKey(d => d.EngagementId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_meet_eng");

            entity.HasOne(d => d.Modepaie).WithMany(p => p.MeetEntreeCaisses)
                .HasForeignKey(d => d.ModepaieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_core_mod");

            entity.HasOne(d => d.Presence).WithMany(p => p.MeetEntreeCaisses)
                .HasForeignKey(d => d.PresenceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_meet_pre");
        });

        modelBuilder.Entity<MeetInscription>(entity =>
        {
            entity.HasKey(e => e.Idinscrit).HasName("pk_meet_inscription");

            entity.ToTable("meet_inscription", "tontine_v14", tb => tb.HasComment("Represente le renoouvellement de la presence d'un membre au sein de 'association au cours d'une annee"));

            entity.HasIndex(e => new { e.EtabId, e.AntenneId }, "association_3_fk");

            entity.HasIndex(e => e.PersonId, "association_4_fk");

            entity.HasIndex(e => e.AnneeId, "association_5_fk");

            entity.HasIndex(e => new { e.EtabId, e.AntenneId, e.PersonId, e.AnneeId }, "uniq_inscription").IsUnique();

            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.AntenneId)
                .HasComment("Identifiant de l'antenne")
                .HasColumnName("antenne_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Cumuldettes)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumulees applicable la nouvelle annee")
                .HasColumnName("cumuldettes");
            entity.Property(e => e.Cumulpenalites)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumules de penelites applicable la nouvelle annee")
                .HasColumnName("cumulpenalites");
            entity.Property(e => e.Dateinscrit)
                .HasComment("Date de l'inscription")
                .HasColumnName("dateinscrit");
            entity.Property(e => e.Datesuspension)
                .HasComment("Date de derniere suspension d'un membre")
                .HasColumnName("datesuspension");
            entity.Property(e => e.Endette)
                .HasComment("Indique si le membre est endette")
                .HasColumnName("endette");
            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.IsActive)
                .HasComment("Statut actif ou non d'un membre")
                .HasColumnName("is_active");
            entity.Property(e => e.Nocni)
                .HasMaxLength(32)
                .HasComment("Nocni")
                .HasColumnName("nocni");
            entity.Property(e => e.PersonId)
                .HasComment("Person_id")
                .HasColumnName("person_id");
            entity.Property(e => e.ReportNouveau)
                .HasComment("Report a nouveau indiquant les dettes d'un membre au terme d'un exercice precedent")
                .HasColumnName("report_nouveau");
            entity.Property(e => e.Soldedebut)
                .HasComment("SoldeDebut")
                .HasColumnName("soldedebut");
            entity.Property(e => e.Soldefin)
                .HasDefaultValueSql("0")
                .HasComment("SoldeFin")
                .HasColumnName("soldefin");
            entity.Property(e => e.Tauxcotisation)
                .HasComment("Report a nouveau du membre pour la nouvelle annee")
                .HasColumnName("tauxcotisation");
            entity.Property(e => e.TotalVerse)
                .HasComment("Total_verse")
                .HasColumnName("total_verse");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetInscriptions)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_core_ann");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetInscriptions)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_core_per");

            entity.HasOne(d => d.MeetAntenne).WithMany(p => p.MeetInscriptions)
                .HasForeignKey(d => new { d.EtabId, d.AntenneId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_meet_ant");
        });

        modelBuilder.Entity<MeetMaxAllowSignature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_meet_max_allow_signature");

            entity.ToTable("meet_max_allow_signature", "tontine_v14", tb => tb.HasComment("Meet_Max_allow_signature"));

            entity.HasIndex(e => e.AnneeId, "association_57_fk");

            entity.HasIndex(e => e.TyperubId, "association_58_fk");

            entity.HasIndex(e => e.Id, "meet_max_allow_signature_pk").IsUnique();

            entity.HasIndex(e => new { e.AnneeId, e.TyperubId }, "uniq_max_allow_siganture").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Id")
                .HasColumnName("id");
            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.MaxSignature)
                .HasComment("La valeur de cet attribut a partir de la somme des lignes faisant reference a un type de rubrique pour une annee donnee")
                .HasColumnName("max_signature");
            entity.Property(e => e.TyperubId)
                .HasComment("Identifiant du type d'evenement")
                .HasColumnName("typerub_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetMaxAllowSignatures)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_max_associati_core_ann");

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetMaxAllowSignatures)
                .HasForeignKey(d => d.TyperubId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_max_associati_meet_typ");
        });

        modelBuilder.Entity<MeetMembreBureau>(entity =>
        {
            entity.HasKey(e => e.BureaudetailsId).HasName("pk_meet_membre_bureau");

            entity.ToTable("meet_membre_bureau", "tontine_v14", tb => tb.HasComment("Meet_Membre_Bureau"));

            entity.HasIndex(e => e.Idinscrit, "association_23_fk");

            entity.HasIndex(e => e.BureauId, "association_46_fk");

            entity.HasIndex(e => e.PosteId, "association_47_fk");

            entity.HasIndex(e => e.BureaudetailsId, "meet_membre_bureau_pk").IsUnique();

            entity.HasIndex(e => new { e.Idinscrit, e.PosteId, e.BureauId }, "uniq_membre_bureau").IsUnique();

            entity.Property(e => e.BureaudetailsId)
                .HasComment("bureaudetails_id")
                .HasColumnName("bureaudetails_id");
            entity.Property(e => e.BureauId)
                .HasComment("Bureau_id")
                .HasColumnName("bureau_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.PosteId)
                .HasComment("Poste_id")
                .HasColumnName("poste_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bureau).WithMany(p => p.MeetMembreBureaus)
                .HasForeignKey(d => d.BureauId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_bur");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetMembreBureaus)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_ins");

            entity.HasOne(d => d.Poste).WithMany(p => p.MeetMembreBureaus)
                .HasForeignKey(d => d.PosteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_pos");
        });

        modelBuilder.Entity<MeetOrdrePassage>(entity =>
        {
            entity.HasKey(e => e.PassageId).HasName("pk_meet_ordre_passage");

            entity.ToTable("meet_ordre_passage", "tontine_v14", tb => tb.HasComment("Meet_Ordre_Passage"));

            entity.HasIndex(e => e.Idinscrit, "association_16_fk");

            entity.HasIndex(e => new { e.AnneeId, e.DivisionId }, "association_51_fk");

            entity.HasIndex(e => e.PassageId, "meet_ordre_passage_pk").IsUnique();

            entity.HasIndex(e => new { e.AnneeId, e.DivisionId, e.Idinscrit }, "uniq_ordre_passage").IsUnique();

            entity.Property(e => e.PassageId)
                .HasComment("passage_id")
                .HasColumnName("passage_id");
            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.Commentaire)
                .HasComment("Commentaire")
                .HasColumnName("commentaire");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.DivisionId)
                .HasComment("Identifiant de la division")
                .HasColumnName("division_id");
            entity.Property(e => e.Heuredebut)
                .HasComment("HeureDebut")
                .HasColumnName("heuredebut");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.Montantpercu)
                .HasComment("MontantPercu")
                .HasColumnName("montantpercu");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetOrdrePassages)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ord_associati_meet_ins");

            entity.HasOne(d => d.CoreSubdivision).WithMany(p => p.MeetOrdrePassages)
                .HasForeignKey(d => new { d.AnneeId, d.DivisionId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ord_associati_core_sub");
        });

        modelBuilder.Entity<MeetPoste>(entity =>
        {
            entity.HasKey(e => e.PosteId).HasName("pk_meet_poste");

            entity.ToTable("meet_poste", "tontine_v14", tb => tb.HasComment("Poste occupe par un membre de l'association"));

            entity.HasIndex(e => e.Code, "ak_alt_key_poste_meet_pos").IsUnique();

            entity.HasIndex(e => e.PosteId, "meet_poste_pk").IsUnique();

            entity.Property(e => e.PosteId)
                .HasComment("Poste_id")
                .HasColumnName("poste_id");
            entity.Property(e => e.Code)
                .HasMaxLength(64)
                .HasComment("Les valeurs autorisees sont: {PRESIDENT, TRESORIER, SG, SGA, CC, CENSOR, MEMBER}")
                .HasColumnName("code");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Libelle)
                .HasComment("Libelle")
                .HasColumnType("jsonb")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<MeetPreference>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("pk_meet_preference");

            entity.ToTable("meet_preference", "tontine_v14", tb => tb.HasComment("Meet_Preference"));

            entity.HasIndex(e => e.SettingId, "meet_preference_pk").IsUnique();

            entity.Property(e => e.SettingId)
                .ValueGeneratedNever()
                .HasComment("Identifiant de l'entite")
                .HasColumnName("setting_id");
            entity.Property(e => e.EnableAutoDispatchIncome)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasComment("Enable_auto_dispatch_income")
                .HasColumnName("enable_auto_dispatch_income");
            entity.Property(e => e.EnableAutoGenPresence)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasComment("Enable_auto_gen_presence")
                .HasColumnName("enable_auto_gen_presence");
            entity.Property(e => e.EnableFixedAmountFees)
                .HasComment("Enable_fixed_amount_fees")
                .HasColumnName("enable_fixed_amount_fees");
            entity.Property(e => e.EnableFixedFeesByAnten)
                .HasComment("Enable_fixed_fees_by_anten")
                .HasColumnName("enable_fixed_fees_by_anten");
            entity.Property(e => e.EnableMaxDelayPenalites)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasComment("Enable_max_delay_penalites")
                .HasColumnName("enable_max_delay_penalites");
            entity.Property(e => e.EnableSecoursInsurance)
                .HasComment("Enable_Secours_insurance")
                .HasColumnName("enable_secours_insurance");
            entity.Property(e => e.EnableSigningOutcome)
                .HasComment("Enable_signing_outcome")
                .HasColumnName("enable_signing_outcome");
            entity.Property(e => e.TauxInteretMensuel)
                .HasComment("Taux d'interet mensuel pour un pret")
                .HasColumnName("taux_interet_mensuel");
            entity.Property(e => e.TauxInteretPenalite)
                .HasComment("Taux d'interet applicable en cas de non respect de l'echeance d'un pret")
                .HasColumnName("taux_interet_penalite");
            entity.Property(e => e.TauxPenaliteCotisation)
                .HasComment("Taux d'interet applicable en cas de penalite pour echec a une cotiisation")
                .HasColumnName("taux_penalite_cotisation");

            entity.HasOne(d => d.Setting).WithOne(p => p.MeetPreference)
                .HasForeignKey<MeetPreference>(d => d.SettingId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_generalis_core_ann");
        });

        modelBuilder.Entity<MeetPresence>(entity =>
        {
            entity.HasKey(e => e.PresenceId).HasName("pk_meet_presence");

            entity.ToTable("meet_presence", "tontine_v14", tb => tb.HasComment("Represente l'etat des presences des membres a une seance de reunion et l'ensemble des signatures apposees par les membres (beneficiaire et bureau) de l'association sur un document"));

            entity.HasIndex(e => e.Idinscrit, "association_13_fk");

            entity.HasIndex(e => e.SeanceId, "association_14_fk");

            entity.HasIndex(e => e.PresenceId, "meet_presence_pk").IsUnique();

            entity.HasIndex(e => e.NumBordero, "uniq_no_bordero").IsUnique();

            entity.HasIndex(e => new { e.SeanceId, e.Idinscrit }, "uniq_presence").IsUnique();

            entity.Property(e => e.PresenceId)
                .HasComment("Identiifant de la signature")
                .HasColumnName("presence_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Dateop)
                .HasComment("Dateop")
                .HasColumnName("dateop");
            entity.Property(e => e.Globalverse)
                .HasComment("globalverse")
                .HasColumnName("globalverse");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.IsAbsent)
                .HasComment("Is_absent")
                .HasColumnName("is_absent");
            entity.Property(e => e.NumBordero)
                .HasMaxLength(128)
                .HasComment("Num_bordero")
                .HasColumnName("num_bordero");
            entity.Property(e => e.SeanceId)
                .HasComment("Seance_id")
                .HasColumnName("seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetPresences)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_ins");

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetPresences)
                .HasForeignKey(d => d.SeanceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_sea");
        });

        modelBuilder.Entity<MeetPret>(entity =>
        {
            entity.HasKey(e => e.SortiecaisseId).HasName("pk_meet_pret");

            entity.ToTable("meet_pret", "tontine_v14", tb => tb.HasComment("Meet_Pret"));

            entity.HasIndex(e => e.RefNo, "ak_alt_key_ref_number_meet_pre").IsUnique();

            entity.HasIndex(e => e.SeanceId, "association_11_fk");

            entity.HasIndex(e => e.Idinscrit, "association_19_fk");

            entity.HasIndex(e => e.SortiecaisseId, "meet_pret_pk").IsUnique();

            entity.Property(e => e.SortiecaisseId)
                .HasComment("Sortiecaisse_id")
                .HasColumnName("sortiecaisse_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Dateevts)
                .HasComment("Date effective a laquelle a lieu l'evenement")
                .HasColumnName("dateevts");
            entity.Property(e => e.DureeFinale)
                .HasComment("Duree_finale")
                .HasColumnName("duree_finale");
            entity.Property(e => e.DureeInitiale)
                .HasComment("Duree du pret en nombre de mois")
                .HasColumnName("duree_initiale");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.IsClosed)
                .HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)")
                .HasColumnName("is_closed");
            entity.Property(e => e.MontantInteret)
                .HasComment("Montant de l'interet")
                .HasColumnName("montant_interet");
            entity.Property(e => e.MontantPenalite)
                .HasComment("Montant applicable en cas de penalite sur les interets ou en cas d'absence de cotisation")
                .HasColumnName("montant_penalite");
            entity.Property(e => e.Montantpercu)
                .HasComment("Montant percu par le beneficiaire de l'evenement")
                .HasColumnName("montantpercu");
            entity.Property(e => e.Note)
                .HasMaxLength(1024)
                .HasComment("Observation generale concernant le deroulement de l'evenement")
                .HasColumnName("note");
            entity.Property(e => e.RefNo)
                .HasMaxLength(254)
                .HasComment("No de Reference permettant d'identifier le pret")
                .HasColumnName("ref_no");
            entity.Property(e => e.SeanceId)
                .HasComment("Seance_id")
                .HasColumnName("seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");
            entity.Property(e => e.Visarestants)
                .HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.")
                .HasColumnName("visarestants");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetPrets)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_ins");

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetPrets)
                .HasForeignKey(d => d.SeanceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_sea");
        });

        modelBuilder.Entity<MeetRubrique>(entity =>
        {
            entity.HasKey(e => e.RubriqueId).HasName("pk_meet_rubrique");

            entity.ToTable("meet_rubrique", "tontine_v14", tb => tb.HasComment("Represente la personnalisation de certaines valeurs appliquees aux types d'eveneents au cours d'une annee"));

            entity.HasIndex(e => e.TyperubId, "association_10_fk");

            entity.HasIndex(e => e.AnneeId, "association_9_fk");

            entity.HasIndex(e => e.RubriqueId, "meet_rubrique_pk").IsUnique();

            entity.Property(e => e.RubriqueId)
                .HasComment("Identifiant d'une configuration")
                .HasColumnName("rubrique_id");
            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.Commentaire)
                .HasComment("Commentaire")
                .HasColumnName("commentaire");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsOutcome)
                .HasComment("Indique si le type represente une sortie de caisse")
                .HasColumnName("is_outcome");
            entity.Property(e => e.Libelle)
                .HasMaxLength(128)
                .HasComment("Description de la rubrique (evenement)")
                .HasColumnName("libelle");
            entity.Property(e => e.MontantPerson)
                .HasComment("Montant total associe a l'evenement")
                .HasColumnName("montant_person");
            entity.Property(e => e.Montantroute)
                .HasComment("Montant du deplacement d'un membre mandate par l'association")
                .HasColumnName("montantroute");
            entity.Property(e => e.Nbmandataire)
                .HasComment("Nombre de membres representant l'asociation a l'evenement")
                .HasColumnName("nbmandataire");
            entity.Property(e => e.TyperubId)
                .HasComment("Identifiant du type d'evenement")
                .HasColumnName("typerub_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetRubriques)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_rub_associati_core_ann");

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetRubriques)
                .HasForeignKey(d => d.TyperubId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_rub_associati_meet_typ");
        });

        modelBuilder.Entity<MeetSeance>(entity =>
        {
            entity.HasKey(e => e.SeanceId).HasName("pk_meet_seance");

            entity.ToTable("meet_seance", "tontine_v14", tb => tb.HasComment("Meet_seance"));

            entity.HasIndex(e => new { e.AnneeId, e.DivisionId }, "association_54_fk");

            entity.HasIndex(e => new { e.EtabId, e.AntenneId }, "association_55_fk");

            entity.HasIndex(e => e.SeanceId, "meet_seance_pk").IsUnique();

            entity.HasIndex(e => new { e.AnneeId, e.DivisionId, e.EtabId, e.AntenneId }, "uniq_meeting_seance").IsUnique();

            entity.Property(e => e.SeanceId)
                .HasComment("Seance_id")
                .HasColumnName("seance_id");
            entity.Property(e => e.AnneeId)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("annee_id");
            entity.Property(e => e.AntenneId)
                .HasComment("Identifiant de l'antenne")
                .HasColumnName("antenne_id");
            entity.Property(e => e.Closedate)
                .HasComment("Date et heure de fermeture de la reunion")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("closedate");
            entity.Property(e => e.Compterendu)
                .HasComment("Compte rendu de la seance de reunion")
                .HasColumnName("compterendu");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Depensecollation)
                .HasComment("DepenseCollation")
                .HasColumnName("depensecollation");
            entity.Property(e => e.DivisionId)
                .HasComment("Identifiant de la division")
                .HasColumnName("division_id");
            entity.Property(e => e.EtabId)
                .HasComment("Etab_id")
                .HasColumnName("etab_id");
            entity.Property(e => e.Opendate)
                .HasComment("Date et heure d'ouverture de la reunion")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("opendate");
            entity.Property(e => e.Status)
                .HasComment("Le statut {CLOSED} indique que la reunion est cloturee et ses donnees ne sont plus modifiables")
                .HasColumnName("status");
            entity.Property(e => e.TotalEntrees)
                .HasComment("Total_entrees")
                .HasColumnName("total_entrees");
            entity.Property(e => e.TotalSorties)
                .HasComment("Total_Sorties")
                .HasColumnName("total_sorties");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.CoreSubdivision).WithMany(p => p.MeetSeances)
                .HasForeignKey(d => new { d.AnneeId, d.DivisionId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sea_associati_core_sub");

            entity.HasOne(d => d.MeetAntenne).WithMany(p => p.MeetSeances)
                .HasForeignKey(d => new { d.EtabId, d.AntenneId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sea_associati_meet_ant");
        });

        modelBuilder.Entity<MeetSortieCaisse>(entity =>
        {
            entity.HasKey(e => e.SortiecaisseId).HasName("pk_meet_sortie_caisse");

            entity.ToTable("meet_sortie_caisse", "tontine_v14", tb => tb.HasComment("Meet_Sortie_Caisse"));

            entity.HasIndex(e => e.SeanceId, "association_11_fk3");

            entity.HasIndex(e => e.EngagementId, "association_12_fk");

            entity.HasIndex(e => e.Idinscrit, "association_19_fk2");

            entity.HasIndex(e => e.SortiecaisseId, "meet_sortie_caisse_pk").IsUnique();

            entity.HasIndex(e => new { e.Idinscrit, e.SeanceId, e.EngagementId }, "uniq_sortie_caisse").IsUnique();

            entity.Property(e => e.SortiecaisseId)
                .HasComment("Sortiecaisse_id")
                .HasColumnName("sortiecaisse_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Dateevts)
                .HasComment("Date effective a laquelle a lieu l'evenement")
                .HasColumnName("dateevts");
            entity.Property(e => e.EngagementId)
                .HasComment("Engagement_id")
                .HasColumnName("engagement_id");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.IsClosed)
                .HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)")
                .HasColumnName("is_closed");
            entity.Property(e => e.ListeMandataires)
                .HasMaxLength(1024)
                .HasComment("Liste des membres designes pour le deplacement")
                .HasColumnName("liste_mandataires");
            entity.Property(e => e.MontantRoute)
                .HasComment("Montant dedie au deplacement des membres")
                .HasColumnName("montant_route");
            entity.Property(e => e.Montantpercu)
                .HasComment("Montant percu par le beneficiaire de l'evenement")
                .HasColumnName("montantpercu");
            entity.Property(e => e.Note)
                .HasMaxLength(1024)
                .HasComment("Observation generale concernant le deroulement de l'evenement")
                .HasColumnName("note");
            entity.Property(e => e.SeanceId)
                .HasComment("Seance_id")
                .HasColumnName("seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");
            entity.Property(e => e.Visarestants)
                .HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.")
                .HasColumnName("visarestants");

            entity.HasOne(d => d.Engagement).WithMany(p => p.MeetSortieCaisses)
                .HasForeignKey(d => d.EngagementId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_eng");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetSortieCaisses)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_ins");

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetSortieCaisses)
                .HasForeignKey(d => d.SeanceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_sea");
        });

        modelBuilder.Entity<MeetSuspensionMembre>(entity =>
        {
            entity.HasKey(e => e.SuspensionId).HasName("pk_meet_suspension_membre");

            entity.ToTable("meet_suspension_membre", "tontine_v14", tb => tb.HasComment("Meet_Suspension_Membre"));

            entity.HasIndex(e => e.PersonId, "association_56_fk");

            entity.HasIndex(e => e.SuspensionId, "meet_suspension_membre_pk").IsUnique();

            entity.Property(e => e.SuspensionId)
                .HasComment("Suspension_id")
                .HasColumnName("suspension_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.DateRetour)
                .HasComment("Date_retour")
                .HasColumnName("date_retour");
            entity.Property(e => e.DateSuspension)
                .HasComment("Date_suspension")
                .HasColumnName("date_suspension");
            entity.Property(e => e.IsActive)
                .HasComment("Is_active")
                .HasColumnName("is_active");
            entity.Property(e => e.PersonId)
                .HasComment("Person_id")
                .HasColumnName("person_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetSuspensionMembres)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sus_associati_core_per");
        });

        modelBuilder.Entity<MeetTypeRubrique>(entity =>
        {
            entity.HasKey(e => e.TyperubId).HasName("pk_meet_type_rubrique");

            entity.ToTable("meet_type_rubrique", "tontine_v14", tb => tb.HasComment("Represente un type d'evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc."));

            entity.HasIndex(e => e.Code, "ak_uniq_type_rubrique_meet_typ").IsUnique();

            entity.HasIndex(e => e.TyperubId, "meet_type_rubrique_pk").IsUnique();

            entity.Property(e => e.TyperubId)
                .HasComment("Identifiant du type d'evenement")
                .HasColumnName("typerub_id");
            entity.Property(e => e.AutoGenerated)
                .HasComment("Indique si le systeme cree automatiquement une rubrique correspondante quand sa valeur est TRUE")
                .HasColumnName("auto_generated");
            entity.Property(e => e.Candelete)
                .HasComment("Indique si l'utlisateur peut supprimer cette information")
                .HasColumnName("candelete");
            entity.Property(e => e.Code)
                .HasMaxLength(64)
                .HasComment("Les valeurs autorisees sont : {PRET, FONDENTRAIDE, COLLATION, EPARGNE, COTISATION, AIDE-NAISSANCE, AIDE-DECES, AIDE-MARIAGE, AIDE-DECES-CONJOINT, AIDE-DECES-FRERE, SECOURS, PENALITE-AIDES-DECES, PROJET}")
                .HasColumnName("code");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsActive)
                .HasComment("Lorsque sa valeur est a TRUE, le systeme peut proposser a l'utilisateur (ou automatiquement) la creation des rubrique associee a ce type.")
                .HasColumnName("is_active");
            entity.Property(e => e.IsOutcome)
                .HasComment("Indique si le type represente une sortie de caisse")
                .HasColumnName("is_outcome");
            entity.Property(e => e.Libelle)
                .HasComment("Libelle du type d'evenement")
                .HasColumnType("jsonb")
                .HasColumnName("libelle");
            entity.Property(e => e.Maxsignature)
                .HasComment("Nombre de signatures autorises pour signer un documents associe a ce type devenement")
                .HasColumnName("maxsignature");
            entity.Property(e => e.MontantPerson)
                .HasComment("Montant total associe a l'evenement")
                .HasColumnName("montant_person");
            entity.Property(e => e.Montantpenalite)
                .HasComment("Montant de la penalite applicable en cas d'absence aa l'evenement")
                .HasColumnName("montantpenalite");
            entity.Property(e => e.Montantroute)
                .HasComment("Montant du deplacement d'un membre mandate par l'association")
                .HasColumnName("montantroute");
            entity.Property(e => e.Nbmandataire)
                .HasComment("Nombre de membres representant l'asociation a l'evenement")
                .HasColumnName("nbmandataire");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasComment("Defini l'ordre dans lequel les rubriques de ce type peuevnt beneficier d'une repartition automatique du montant verse par un membre d'une reunion")
                .HasColumnName("numordre");
            entity.Property(e => e.Required)
                .HasComment("Indique que toutes les rubriques de ce type sont automatiquement cotisees par les membres d'une reunion")
                .HasColumnName("required");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<MeetVisa>(entity =>
        {
            entity.HasKey(e => e.VisaId).HasName("pk_meet_visas");

            entity.ToTable("meet_visas", "tontine_v14", tb => tb.HasComment("Meet_Visas"));

            entity.HasIndex(e => e.ConfigvisaId, "association_15_fk");

            entity.HasIndex(e => e.SortiecaisseId, "association_22_fk");

            entity.HasIndex(e => e.MeetOperation, "association_22_fk2");

            entity.HasIndex(e => e.Idinscrit, "association_26_fk");

            entity.HasIndex(e => e.VisaId, "meet_visas_pk").IsUnique();

            entity.HasIndex(e => new { e.Idinscrit, e.ConfigvisaId }, "uniq_visa").IsUnique();

            entity.Property(e => e.VisaId)
                .HasComment("Identiifant de la signature")
                .HasColumnName("visa_id");
            entity.Property(e => e.ConfigvisaId)
                .HasComment("Identifiant de la configuration de signature")
                .HasColumnName("configvisa_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasComment("create_uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.Datesign)
                .HasComment("Date de signature")
                .HasColumnName("datesign");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.MeetOperation)
                .HasComment("Meet_Operation")
                .HasColumnName("meet_operation");
            entity.Property(e => e.Receiver)
                .HasComment("Indique si le signataire est le beneficiare")
                .HasColumnName("receiver");
            entity.Property(e => e.SignByOrdre)
                .HasComment("Indique si le document est signe par ordre")
                .HasColumnName("sign_by_ordre");
            entity.Property(e => e.SortiecaisseId)
                .HasComment("Sortiecaisse_id")
                .HasColumnName("sortiecaisse_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasComment("update_uid")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Configvisa).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.ConfigvisaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_con");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_ins");

            entity.HasOne(d => d.MeetOperationNavigation).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.MeetOperation)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_pre");

            entity.HasOne(d => d.Sortiecaisse).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.SortiecaisseId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_sor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
