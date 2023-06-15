using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sqlite.Entities.Models;

public partial class TontineDbSqliteContext : DbContext
{
    public TontineDbSqliteContext()
    {
    }

    public TontineDbSqliteContext(DbContextOptions<TontineDbSqliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoreAnnee> CoreAnnees { get; set; }

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
        => optionsBuilder.UseSqlite("Data Source=tontine-db-sqlite.sqlite3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoreAnnee>(entity =>
        {
            entity.HasKey(e => e.AnneeId);

            entity.ToTable("core_annee");

            entity.HasIndex(e => new { e.Datedebut, e.Datefin }, "IX_core_annee_datedebut_datefin").IsUnique();

            entity.HasIndex(e => e.BureauId, "bureau_id_on_annee_fk");

            entity.HasIndex(e => e.AnneeId, "core_annee_pk").IsUnique();

            entity.HasIndex(e => e.FrequenceId, "freq_id_on_annee_fk");

            entity.Property(e => e.AnneeId).HasColumnName("annee_id");
            entity.Property(e => e.BureauId)
                .HasColumnType("INT")
                .HasColumnName("bureau_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Datedebut)
                .HasColumnType("date")
                .HasColumnName("datedebut");
            entity.Property(e => e.Datefin)
                .HasColumnType("date")
                .HasColumnName("datefin");
            entity.Property(e => e.FrequenceId)
                .HasColumnType("INT")
                .HasColumnName("frequence_id");
            entity.Property(e => e.IsClosed)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_closed");
            entity.Property(e => e.IsCurrent)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_current");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(128)")
                .HasColumnName("libelle");
            entity.Property(e => e.Nbdivision)
                .HasDefaultValueSql("12")
                .HasColumnType("INT")
                .HasColumnName("nbdivision");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bureau).WithMany(p => p.CoreAnnees)
                .HasForeignKey(d => d.BureauId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Frequence).WithMany(p => p.CoreAnnees)
                .HasForeignKey(d => d.FrequenceId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CoreAutorisation>(entity =>
        {
            entity.HasKey(e => e.ChoixId);

            entity.ToTable("core_autorisations");

            entity.HasIndex(e => e.Idcmde, "cmde_id_on_autorisations_fk");

            entity.HasIndex(e => e.ChoixId, "core_autorisations_pk").IsUnique();

            entity.HasIndex(e => e.ProfilId, "profil_id_on_autorisations_fk");

            entity.Property(e => e.ChoixId).HasColumnName("choix_id");
            entity.Property(e => e.Idcmde)
                .HasColumnType("INT")
                .HasColumnName("idcmde");
            entity.Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasColumnName("is_active");
            entity.Property(e => e.ProfilId)
                .HasColumnType("INT")
                .HasColumnName("profil_id");

            entity.HasOne(d => d.IdcmdeNavigation).WithMany(p => p.CoreAutorisations)
                .HasForeignKey(d => d.Idcmde)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Profil).WithMany(p => p.CoreAutorisations)
                .HasForeignKey(d => d.ProfilId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CoreBank>(entity =>
        {
            entity.HasKey(e => e.BankId);

            entity.ToTable("core_bank");

            entity.HasIndex(e => e.BankId, "core_bank_pk").IsUnique();

            entity.HasIndex(e => e.CountryId, "country_id_on_bank_fk");

            entity.Property(e => e.BankId).HasColumnName("bank_id");
            entity.Property(e => e.Adresse)
                .HasColumnType("varchar(1024)")
                .HasColumnName("adresse");
            entity.Property(e => e.Coderib)
                .HasColumnType("varchar(64)")
                .HasColumnName("coderib");
            entity.Property(e => e.CountryId)
                .HasColumnType("int8")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Email)
                .HasColumnType("varchar(64)")
                .HasColumnName("email");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(1024)")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CoreBanks)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CoreBankaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("core_bankaccount");

            entity.HasIndex(e => e.BankId, "bankid_on_bankaccount_fk");

            entity.HasIndex(e => e.AccountId, "core_bankaccount_pk").IsUnique();

            entity.HasIndex(e => e.EtabId, "etab_id_on_bankaccount_fk");

            entity.HasIndex(e => e.PersonId, "person_id_on_bankaccount_fk");

            entity.HasIndex(e => new { e.BankId, e.CompteNo }, "uniq_bank_account").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BankId)
                .HasColumnType("INT")
                .HasColumnName("bank_id");
            entity.Property(e => e.CompteNo)
                .HasColumnType("varchar(64)")
                .HasColumnName("compte_no");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.EtabId)
                .HasColumnType("INT")
                .HasColumnName("etab_id");
            entity.Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasColumnName("is_active");
            entity.Property(e => e.IsDefault)
                .HasDefaultValueSql("1")
                .HasColumnType("boolean")
                .HasColumnName("is_default");
            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.Solde)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("solde");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bank).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Etab).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Person).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CoreCommande>(entity =>
        {
            entity.HasKey(e => e.Idcmde);

            entity.ToTable("core_commandes");

            entity.HasIndex(e => e.Idcmde, "core_commandes_pk").IsUnique();

            entity.Property(e => e.Idcmde).HasColumnName("idcmde");
            entity.Property(e => e.Libelle).HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.ToTable("core_country");

            entity.HasIndex(e => e.CountryId, "core_country_pk").IsUnique();

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnType("int8")
                .HasColumnName("country_id");
            entity.Property(e => e.CodeIso2)
                .HasColumnType("varchar(8)")
                .HasColumnName("code_iso2");
            entity.Property(e => e.CodeIso3)
                .HasColumnType("varchar(8)")
                .HasColumnName("code_iso3");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Devise)
                .HasColumnType("varchar(128)")
                .HasColumnName("devise");
            entity.Property(e => e.Libelle).HasColumnName("libelle");
            entity.Property(e => e.PhoneCode)
                .HasColumnType("varchar(8)")
                .HasColumnName("phone_code");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<CoreEtablissement>(entity =>
        {
            entity.HasKey(e => e.EtabId);

            entity.ToTable("core_etablissement");

            entity.HasIndex(e => e.EtabId, "core_etablissement_pk").IsUnique();

            entity.HasIndex(e => e.CountryId, "country_id_on_etab_fk");

            entity.HasIndex(e => e.DeployedUrl, "uniq_deployed_url").IsUnique();

            entity.Property(e => e.EtabId).HasColumnName("etab_id");
            entity.Property(e => e.Adresse)
                .HasColumnType("varchar(1024)")
                .HasColumnName("adresse");
            entity.Property(e => e.ConnString)
                .HasColumnType("varchar(1024)")
                .HasColumnName("conn_string");
            entity.Property(e => e.CountryId)
                .HasColumnType("int8")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Creationdate)
                .HasColumnType("date")
                .HasColumnName("creationdate");
            entity.Property(e => e.DatabaseName)
                .HasColumnType("varchar(1024)")
                .HasColumnName("database_name");
            entity.Property(e => e.DeployedUrl)
                .HasColumnType("varchar(1024)")
                .HasColumnName("deployed_url");
            entity.Property(e => e.EnableMultiAntenne)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("enable_multi_antenne");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(256)")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CoreEtablissements)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CoreFrequenceDivision>(entity =>
        {
            entity.HasKey(e => e.FrequenceId);

            entity.ToTable("core_frequence_division");

            entity.HasIndex(e => e.NbDays, "IX_core_frequence_division_nb_days").IsUnique();

            entity.HasIndex(e => e.FrequenceId, "core_frequence_division_pk").IsUnique();

            entity.Property(e => e.FrequenceId).HasColumnName("frequence_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(128)")
                .HasColumnName("libelle");
            entity.Property(e => e.NbDays)
                .HasColumnType("INT")
                .HasColumnName("nb_days");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<CoreLangue>(entity =>
        {
            entity.HasKey(e => e.LangueId);

            entity.ToTable("core_langue");

            entity.HasIndex(e => e.LangueId, "core_langue_pk").IsUnique();

            entity.Property(e => e.LangueId).HasColumnName("langue_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_active");
            entity.Property(e => e.IsDefault)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_default");
            entity.Property(e => e.Isocode)
                .HasColumnType("varchar(8)")
                .HasColumnName("isocode");
            entity.Property(e => e.Libelle).HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreModepaie>(entity =>
        {
            entity.HasKey(e => e.ModepaieId);

            entity.ToTable("core_modepaie");

            entity.HasIndex(e => e.ModepaieId, "core_modepaie_pk").IsUnique();

            entity.Property(e => e.ModepaieId).HasColumnName("modepaie_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsCash)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_cash");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(128)")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<CorePerson>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.ToTable("core_person");

            entity.HasIndex(e => e.PersonId, "core_person_pk").IsUnique();

            entity.HasIndex(e => e.CountryId, "country_id_on_person_fk");

            entity.HasIndex(e => e.EtabId, "etab_id_on_person_fk");

            entity.HasIndex(e => e.Nocni, "uniq_cni_person").IsUnique();

            entity.HasIndex(e => new { e.Nom, e.Prenom, e.Datenais, e.Lieunais, e.Sexe }, "uniq_person").IsUnique();

            entity.HasIndex(e => e.Email, "unique_email_person").IsUnique();

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.AdhesionDate)
                .HasColumnType("date")
                .HasColumnName("adhesion_date");
            entity.Property(e => e.Adresse)
                .HasColumnType("varchar(1024)")
                .HasColumnName("adresse");
            entity.Property(e => e.AnneePromo)
                .HasColumnType("varchar(32)")
                .HasColumnName("annee_promo");
            entity.Property(e => e.CniExpireDate)
                .HasColumnType("date")
                .HasColumnName("cni_expire_date");
            entity.Property(e => e.CountryId)
                .HasColumnType("int8")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Datenais)
                .HasColumnType("date")
                .HasColumnName("datenais");
            entity.Property(e => e.Email)
                .HasColumnType("varchar(64)")
                .HasColumnName("email");
            entity.Property(e => e.EtabId)
                .HasColumnType("INT")
                .HasColumnName("etab_id");
            entity.Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasColumnName("is_active");
            entity.Property(e => e.IsVisible)
                .HasDefaultValueSql("1")
                .HasColumnType("boolean")
                .HasColumnName("is_visible");
            entity.Property(e => e.Lieunais)
                .HasColumnType("varchar(128)")
                .HasColumnName("lieunais");
            entity.Property(e => e.Nocni)
                .HasColumnType("varchar(32)")
                .HasColumnName("nocni");
            entity.Property(e => e.Nom)
                .HasColumnType("varchar(128)")
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasDefaultValueSql("''")
                .HasColumnType("varchar(128)")
                .HasColumnName("prenom");
            entity.Property(e => e.Sexe)
                .HasColumnType("varchar(16)")
                .HasColumnName("sexe");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Country).WithMany(p => p.CorePeople)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Etab).WithMany(p => p.CorePeople)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CorePhonenumber>(entity =>
        {
            entity.HasKey(e => e.PhoneId);

            entity.ToTable("core_phonenumber");

            entity.HasIndex(e => e.BankId, "bank_id_on_phonenumber_fk");

            entity.HasIndex(e => e.PhoneId, "core_phonenumber_pk").IsUnique();

            entity.HasIndex(e => e.CountryId, "country_id_on_phonenumber_fk2");

            entity.HasIndex(e => e.PersonId, "person_id_on_phonenumber_fk2");

            entity.Property(e => e.PhoneId)
                .ValueGeneratedNever()
                .HasColumnType("int8")
                .HasColumnName("phone_id");
            entity.Property(e => e.BankId)
                .HasColumnType("INT")
                .HasColumnName("bank_id");
            entity.Property(e => e.CountryId)
                .HasColumnType("int8")
                .HasColumnName("country_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsDefaut)
                .HasColumnType("boolean")
                .HasColumnName("is_defaut");
            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.PhoneNo)
                .HasColumnType("varchar(32)")
                .HasColumnName("phone_no");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bank).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Country).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Person).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CorePhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId);

            entity.ToTable("core_photos");

            entity.HasIndex(e => e.PhotoId, "core_photos_pk").IsUnique();

            entity.HasIndex(e => e.EtabId, "etab_id_on_photos_fk");

            entity.HasIndex(e => e.PersonId, "person_id_on_photos_fk2");

            entity.Property(e => e.PhotoId)
                .ValueGeneratedNever()
                .HasColumnType("int8")
                .HasColumnName("photo_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.EtabId)
                .HasColumnType("INT")
                .HasColumnName("etab_id");
            entity.Property(e => e.Fileext)
                .HasColumnType("varchar(32)")
                .HasColumnName("fileext");
            entity.Property(e => e.Filename)
                .HasColumnType("varchar(1024)")
                .HasColumnName("filename");
            entity.Property(e => e.Filepath)
                .HasColumnType("varchar(1024)")
                .HasColumnName("filepath");
            entity.Property(e => e.Image)
                .HasColumnType("varchar(254)")
                .HasColumnName("image");
            entity.Property(e => e.IsSignature)
                .HasColumnType("boolean")
                .HasColumnName("is_signature");
            entity.Property(e => e.MaxAllowLiens)
                .HasColumnType("INT")
                .HasColumnName("max_allow_liens");
            entity.Property(e => e.NbActualLiens)
                .HasColumnType("INT")
                .HasColumnName("nb_actual_liens");
            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.CorePhotos)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Person).WithMany(p => p.CorePhotos)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CoreProfil>(entity =>
        {
            entity.HasKey(e => e.ProfilId);

            entity.ToTable("core_profil");

            entity.HasIndex(e => e.ProfilId, "core_profil_pk").IsUnique();

            entity.Property(e => e.ProfilId).HasColumnName("profil_id");
            entity.Property(e => e.Candelete)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("candelete");
            entity.Property(e => e.Libelle).HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreSubdivision>(entity =>
        {
            entity.HasKey(e => e.DivisionId);

            entity.ToTable("core_subdivision");

            entity.HasIndex(e => e.MonthDate, "IX_core_subdivision_month_date").IsUnique();

            entity.HasIndex(e => e.AnneeId, "annee_on_subdivision_fk");

            entity.HasIndex(e => e.DivisionId, "core_subdivision_pk").IsUnique();

            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.AnneeId)
                .HasColumnType("INT")
                .HasColumnName("annee_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(128)")
                .HasColumnName("libelle");
            entity.Property(e => e.MonthDate)
                .HasColumnType("date")
                .HasColumnName("month_date");
            entity.Property(e => e.MonthDay)
                .HasColumnType("INT")
                .HasColumnName("month_day");
            entity.Property(e => e.Numordre)
                .HasColumnType("INT")
                .HasColumnName("numordre");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.CoreSubdivisions)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CoreUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("core_user");

            entity.HasIndex(e => e.UserId, "core_user_pk").IsUnique();

            entity.HasIndex(e => e.LangueId, "langue_id_on_user_fk");

            entity.HasIndex(e => e.ProfilId, "profil_id_on_user_fk");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("user_id");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("date")
                .HasColumnName("expiration_date");
            entity.Property(e => e.IsActif)
                .HasColumnType("boolean")
                .HasColumnName("is_actif");
            entity.Property(e => e.LangueId)
                .HasColumnType("INT")
                .HasColumnName("langue_id");
            entity.Property(e => e.LastConnexion)
                .HasColumnType("date")
                .HasColumnName("last_connexion");
            entity.Property(e => e.Passwd)
                .HasColumnType("varchar(254)")
                .HasColumnName("passwd");
            entity.Property(e => e.ProfilId)
                .HasColumnType("INT")
                .HasColumnName("profil_id");
            entity.Property(e => e.Username)
                .HasColumnType("varchar(128)")
                .HasColumnName("username");

            entity.HasOne(d => d.Langue).WithMany(p => p.CoreUsers)
                .HasForeignKey(d => d.LangueId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Profil).WithMany(p => p.CoreUsers)
                .HasForeignKey(d => d.ProfilId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetAntenne>(entity =>
        {
            entity.HasKey(e => e.AntenneId);

            entity.ToTable("meet_antenne");

            entity.HasIndex(e => e.EtabId, "etab_id_on_antenne_fk");

            entity.HasIndex(e => e.AntenneId, "meet_antenne_pk").IsUnique();

            entity.Property(e => e.AntenneId).HasColumnName("antenne_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Creationdate)
                .HasColumnType("date")
                .HasColumnName("creationdate");
            entity.Property(e => e.EtabId)
                .HasColumnType("INT")
                .HasColumnName("etab_id");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(128)")
                .HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.MeetAntennes)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetBureau>(entity =>
        {
            entity.HasKey(e => e.BureauId);

            entity.ToTable("meet_bureau");

            entity.HasIndex(e => e.EtabId, "etab_id_on_bureau_fk");

            entity.HasIndex(e => e.BureauId, "meet_bureau_pk").IsUnique();

            entity.HasIndex(e => new { e.EtabId, e.Debut, e.Fin }, "uniq_bureau").IsUnique();

            entity.Property(e => e.BureauId).HasColumnName("bureau_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Debut)
                .HasColumnType("date")
                .HasColumnName("debut");
            entity.Property(e => e.EtabId)
                .HasColumnType("INT")
                .HasColumnName("etab_id");
            entity.Property(e => e.Fin)
                .HasColumnType("date")
                .HasColumnName("fin");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(128)")
                .HasColumnName("libelle");
            entity.Property(e => e.Nbabstention)
                .HasColumnType("INT")
                .HasColumnName("nbabstention");
            entity.Property(e => e.Nbperson)
                .HasColumnType("INT")
                .HasColumnName("nbperson");
            entity.Property(e => e.Nbvotes)
                .HasColumnType("INT")
                .HasColumnName("nbvotes");
            entity.Property(e => e.Resumevote)
                .HasColumnType("clob")
                .HasColumnName("resumevote");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Etab).WithMany(p => p.MeetBureaus)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetConfigVisa>(entity =>
        {
            entity.HasKey(e => e.ConfigvisaId);

            entity.ToTable("meet_config_visas");

            entity.HasIndex(e => e.AnneeId, "annee_id_on_configvisa_fk");

            entity.HasIndex(e => e.ConfigvisaId, "meet_config_visas_pk").IsUnique();

            entity.HasIndex(e => e.PosteId, "poste_id_on_configvisa_fk");

            entity.HasIndex(e => e.TyperubId, "typerub_on_configvisa_fk2");

            entity.HasIndex(e => new { e.PosteId, e.AnneeId, e.TyperubId }, "uniq_config_visas").IsUnique();

            entity.Property(e => e.ConfigvisaId).HasColumnName("configvisa_id");
            entity.Property(e => e.AnneeId)
                .HasColumnType("INT")
                .HasColumnName("annee_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasColumnType("INT")
                .HasColumnName("numordre");
            entity.Property(e => e.PosteId)
                .HasColumnType("INT")
                .HasColumnName("poste_id");
            entity.Property(e => e.SignByOrdre)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("sign_by_ordre");
            entity.Property(e => e.TyperubId)
                .HasColumnType("INT")
                .HasColumnName("typerub_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetConfigVisas)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Poste).WithMany(p => p.MeetConfigVisas)
                .HasForeignKey(d => d.PosteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetConfigVisas)
                .HasForeignKey(d => d.TyperubId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetEngagement>(entity =>
        {
            entity.HasKey(e => e.EngagementId);

            entity.ToTable("meet_engagement");

            entity.HasIndex(e => e.EngagementId, "meet_engagement_pk").IsUnique();

            entity.HasIndex(e => e.PersonId, "person_id_on_engagement_fk");

            entity.HasIndex(e => e.RubriqueId, "rubrique_id_on_engagement_fk");

            entity.Property(e => e.EngagementId).HasColumnName("engagement_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Cumulverse)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("cumulverse");
            entity.Property(e => e.CustomAmount)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("custom_amount");
            entity.Property(e => e.EngagementDate)
                .HasColumnType("date")
                .HasColumnName("engagement_date");
            entity.Property(e => e.IsClosed)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_closed");
            entity.Property(e => e.IsOutcome)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_outcome");
            entity.Property(e => e.NbReqSeances)
                .HasDefaultValueSql("1")
                .HasColumnType("INT")
                .HasColumnName("nb_req_seances");
            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.RubriqueId)
                .HasColumnType("INT")
                .HasColumnName("rubrique_id");
            entity.Property(e => e.ToPay)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("to_pay");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetEngagements)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Rubrique).WithMany(p => p.MeetEngagements)
                .HasForeignKey(d => d.RubriqueId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetEntreeCaisse>(entity =>
        {
            entity.HasKey(e => e.OperationId);

            entity.ToTable("meet_entree_caisse");

            entity.HasIndex(e => e.EngagementId, "engagement_id_on_entreecaisse_f");

            entity.HasIndex(e => e.OperationId, "meet_entree_caisse_pk").IsUnique();

            entity.HasIndex(e => e.PresenceId, "presence_id_on_entreecaisse_fk");

            entity.HasIndex(e => new { e.PresenceId, e.EngagementId }, "uniq_versement").IsUnique();

            entity.Property(e => e.OperationId).HasColumnName("operation_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.EngagementId)
                .HasColumnType("INT")
                .HasColumnName("engagement_id");
            entity.Property(e => e.IsOutcome)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_outcome");
            entity.Property(e => e.Montantverse)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montantverse");
            entity.Property(e => e.PresenceId)
                .HasColumnType("INT")
                .HasColumnName("presence_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Engagement).WithMany(p => p.MeetEntreeCaisses)
                .HasForeignKey(d => d.EngagementId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Presence).WithMany(p => p.MeetEntreeCaisses)
                .HasForeignKey(d => d.PresenceId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetInscription>(entity =>
        {
            entity.HasKey(e => e.Idinscrit);

            entity.ToTable("meet_inscription");

            entity.HasIndex(e => e.AnneeId, "annee_id_on_inscription_fk");

            entity.HasIndex(e => e.AntenneId, "antenne_id_on_inscription_fk");

            entity.HasIndex(e => e.Idinscrit, "meet_inscription_pk").IsUnique();

            entity.HasIndex(e => e.PersonId, "person_id_on_inscription_fk");

            entity.HasIndex(e => new { e.AntenneId, e.PersonId, e.AnneeId }, "uniq_inscription").IsUnique();

            entity.Property(e => e.Idinscrit).HasColumnName("idinscrit");
            entity.Property(e => e.AnneeId)
                .HasColumnType("INT")
                .HasColumnName("annee_id");
            entity.Property(e => e.AntenneId)
                .HasColumnType("INT")
                .HasColumnName("antenne_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Cumuldettes)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("cumuldettes");
            entity.Property(e => e.Cumulpenalites)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("cumulpenalites");
            entity.Property(e => e.Dateinscrit)
                .HasColumnType("date")
                .HasColumnName("dateinscrit");
            entity.Property(e => e.Datesuspension)
                .HasColumnType("date")
                .HasColumnName("datesuspension");
            entity.Property(e => e.Endette)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("endette");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_active");
            entity.Property(e => e.Nocni)
                .HasColumnType("varchar(32)")
                .HasColumnName("nocni");
            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.ReportNouveau)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("report_nouveau");
            entity.Property(e => e.Soldedebut)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("soldedebut");
            entity.Property(e => e.Soldefin)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("soldefin");
            entity.Property(e => e.Tauxcotisation)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("tauxcotisation");
            entity.Property(e => e.TotalVerse)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("total_verse");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetInscriptions)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Antenne).WithMany(p => p.MeetInscriptions)
                .HasForeignKey(d => d.AntenneId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Person).WithMany(p => p.MeetInscriptions)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetMaxAllowSignature>(entity =>
        {
            entity.ToTable("meet_max_allow_signature");

            entity.HasIndex(e => e.AnneeId, "annee_id_on_max_allow_signature");

            entity.HasIndex(e => e.Id, "meet_max_allow_signature_pk").IsUnique();

            entity.HasIndex(e => e.TyperubId, "typerub_id_on_maxallowsignature");

            entity.HasIndex(e => new { e.AnneeId, e.TyperubId }, "uniq_max_allow_siganture").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnneeId)
                .HasColumnType("INT")
                .HasColumnName("annee_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.MaxSignature)
                .HasColumnType("INT")
                .HasColumnName("max_signature");
            entity.Property(e => e.TyperubId)
                .HasColumnType("INT")
                .HasColumnName("typerub_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetMaxAllowSignatures)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetMaxAllowSignatures)
                .HasForeignKey(d => d.TyperubId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetMembreBureau>(entity =>
        {
            entity.HasKey(e => e.BureaudetailsId);

            entity.ToTable("meet_membre_bureau");

            entity.HasIndex(e => e.BureauId, "bureau_id_on_membrebureau_fk");

            entity.HasIndex(e => e.Idinscrit, "inscrit_id_on_membrebureau_fk");

            entity.HasIndex(e => e.BureaudetailsId, "meet_membre_bureau_pk").IsUnique();

            entity.HasIndex(e => e.PosteId, "poste_id_on_membrebureau_fk");

            entity.HasIndex(e => new { e.Idinscrit, e.PosteId, e.BureauId }, "uniq_membre_bureau").IsUnique();

            entity.Property(e => e.BureaudetailsId).HasColumnName("bureaudetails_id");
            entity.Property(e => e.BureauId)
                .HasColumnType("INT")
                .HasColumnName("bureau_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Idinscrit)
                .HasColumnType("INT")
                .HasColumnName("idinscrit");
            entity.Property(e => e.PosteId)
                .HasColumnType("INT")
                .HasColumnName("poste_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Bureau).WithMany(p => p.MeetMembreBureaus)
                .HasForeignKey(d => d.BureauId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetMembreBureaus)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Poste).WithMany(p => p.MeetMembreBureaus)
                .HasForeignKey(d => d.PosteId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetOrdrePassage>(entity =>
        {
            entity.HasKey(e => e.PassageId);

            entity.ToTable("meet_ordre_passage");

            entity.HasIndex(e => e.DivisionId, "divisionn_id_on_ordrepassage_fk");

            entity.HasIndex(e => e.Idinscrit, "inscrit_id_on_ordrepassage_fk");

            entity.HasIndex(e => e.PassageId, "meet_ordre_passage_pk").IsUnique();

            entity.HasIndex(e => new { e.DivisionId, e.Idinscrit }, "uniq_ordre_passage").IsUnique();

            entity.Property(e => e.PassageId).HasColumnName("passage_id");
            entity.Property(e => e.Commentaire)
                .HasColumnType("clob")
                .HasColumnName("commentaire");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.DivisionId)
                .HasColumnType("INT")
                .HasColumnName("division_id");
            entity.Property(e => e.Heuredebut)
                .HasColumnType("date")
                .HasColumnName("heuredebut");
            entity.Property(e => e.Idinscrit)
                .HasColumnType("INT")
                .HasColumnName("idinscrit");
            entity.Property(e => e.Montantpercu)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montantpercu");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Division).WithMany(p => p.MeetOrdrePassages)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetOrdrePassages)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetPoste>(entity =>
        {
            entity.HasKey(e => e.PosteId);

            entity.ToTable("meet_poste");

            entity.HasIndex(e => e.Code, "IX_meet_poste_code").IsUnique();

            entity.HasIndex(e => e.PosteId, "meet_poste_pk").IsUnique();

            entity.Property(e => e.PosteId).HasColumnName("poste_id");
            entity.Property(e => e.Code)
                .HasColumnType("varchar(64)")
                .HasColumnName("code");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Libelle).HasColumnName("libelle");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<MeetPreference>(entity =>
        {
            entity.HasKey(e => e.SettingId);

            entity.ToTable("meet_preference");

            entity.HasIndex(e => e.SettingId, "meet_preference_pk").IsUnique();

            entity.Property(e => e.SettingId).HasColumnName("setting_id");
            entity.Property(e => e.AnneeId)
                .HasColumnType("INT")
                .HasColumnName("annee_id");
            entity.Property(e => e.DataFromPrevious)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("data_from_previous");
            entity.Property(e => e.EnableAutoDispatchIncome)
                .HasDefaultValueSql("1")
                .HasColumnType("boolean")
                .HasColumnName("enable_auto_dispatch_income");
            entity.Property(e => e.EnableAutoGenPresence)
                .HasDefaultValueSql("1")
                .HasColumnType("boolean")
                .HasColumnName("enable_auto_gen_presence");
            entity.Property(e => e.EnableFixedAmountFees)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("enable_fixed_amount_fees");
            entity.Property(e => e.EnableFixedFeesByAnten)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("enable_fixed_fees_by_anten");
            entity.Property(e => e.EnableMaxDelayPenalites)
                .HasDefaultValueSql("1")
                .HasColumnType("boolean")
                .HasColumnName("enable_max_delay_penalites");
            entity.Property(e => e.EnableSecoursInsurance)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("enable_secours_insurance");
            entity.Property(e => e.EnableSigningOutcome)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("enable_signing_outcome");
            entity.Property(e => e.EtabId)
                .HasColumnType("INT")
                .HasColumnName("etab_id");
            entity.Property(e => e.PreviousYear)
                .HasColumnType("INT")
                .HasColumnName("previous_year");
            entity.Property(e => e.TauxInteretMensuel)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("taux_interet_mensuel");
            entity.Property(e => e.TauxInteretPenalite)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("taux_interet_penalite");
            entity.Property(e => e.TauxPenaliteCotisation)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("taux_penalite_cotisation");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetPreferenceAnnees)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Etab).WithMany(p => p.MeetPreferences)
                .HasForeignKey(d => d.EtabId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.PreviousYearNavigation).WithMany(p => p.MeetPreferencePreviousYearNavigations)
                .HasForeignKey(d => d.PreviousYear)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetPresence>(entity =>
        {
            entity.HasKey(e => e.PresenceId);

            entity.ToTable("meet_presence");

            entity.HasIndex(e => e.Idinscrit, "inscrit_id_on_presence_fk");

            entity.HasIndex(e => e.PresenceId, "meet_presence_pk").IsUnique();

            entity.HasIndex(e => e.ModepaieId, "modepaie_id_on_presence_fk");

            entity.HasIndex(e => e.SeanceId, "seance_id_on_presence_fk");

            entity.HasIndex(e => e.NumBordero, "uniq_no_bordero").IsUnique();

            entity.HasIndex(e => new { e.SeanceId, e.Idinscrit }, "uniq_presence").IsUnique();

            entity.Property(e => e.PresenceId).HasColumnName("presence_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Dateop)
                .HasColumnType("date")
                .HasColumnName("dateop");
            entity.Property(e => e.Globalverse)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("globalverse");
            entity.Property(e => e.Idinscrit)
                .HasColumnType("INT")
                .HasColumnName("idinscrit");
            entity.Property(e => e.IsAbsent)
                .HasColumnType("boolean")
                .HasColumnName("is_absent");
            entity.Property(e => e.ModepaieId)
                .HasColumnType("INT")
                .HasColumnName("modepaie_id");
            entity.Property(e => e.NumBordero)
                .HasColumnType("varchar(128)")
                .HasColumnName("num_bordero");
            entity.Property(e => e.SeanceId)
                .HasColumnType("INT")
                .HasColumnName("seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
            entity.Property(e => e.VerseCash)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("verse_cash");
            entity.Property(e => e.VerseTransfert)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("verse_transfert");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetPresences)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Modepaie).WithMany(p => p.MeetPresences)
                .HasForeignKey(d => d.ModepaieId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetPresences)
                .HasForeignKey(d => d.SeanceId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetPret>(entity =>
        {
            entity.HasKey(e => e.SortiecaisseId);

            entity.ToTable("meet_pret");

            entity.HasIndex(e => e.RefNo, "IX_meet_pret_ref_no").IsUnique();

            entity.HasIndex(e => e.Idinscrit, "inscrit_id_on_pret_fk");

            entity.HasIndex(e => e.SortiecaisseId, "meet_pret_pk").IsUnique();

            entity.HasIndex(e => e.SeanceId, "seance_id_on_pret_fk");

            entity.Property(e => e.SortiecaisseId).HasColumnName("sortiecaisse_id");
            entity.Property(e => e.BenefPrincipal)
                .HasDefaultValueSql("1")
                .HasColumnType("boolean")
                .HasColumnName("benef_principal");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Dateevts)
                .HasColumnType("date")
                .HasColumnName("dateevts");
            entity.Property(e => e.DureeFinale)
                .HasColumnType("INT")
                .HasColumnName("duree_finale");
            entity.Property(e => e.DureeInitiale)
                .HasColumnType("INT")
                .HasColumnName("duree_initiale");
            entity.Property(e => e.Idinscrit)
                .HasColumnType("INT")
                .HasColumnName("idinscrit");
            entity.Property(e => e.IsClosed)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_closed");
            entity.Property(e => e.MontantInteret)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montant_interet");
            entity.Property(e => e.MontantPenalite)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montant_penalite");
            entity.Property(e => e.Montantpercu)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montantpercu");
            entity.Property(e => e.Note)
                .HasColumnType("varchar(1024)")
                .HasColumnName("note");
            entity.Property(e => e.RefNo)
                .HasColumnType("varchar(254)")
                .HasColumnName("ref_no");
            entity.Property(e => e.SeanceId)
                .HasColumnType("INT")
                .HasColumnName("seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
            entity.Property(e => e.Visarestants)
                .HasColumnType("INT")
                .HasColumnName("visarestants");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetPrets)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetPrets)
                .HasForeignKey(d => d.SeanceId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetRubrique>(entity =>
        {
            entity.HasKey(e => e.RubriqueId);

            entity.ToTable("meet_rubrique");

            entity.HasIndex(e => e.AnneeId, "annee_id_on_rubrique_fk");

            entity.HasIndex(e => e.RubriqueId, "meet_rubrique_pk").IsUnique();

            entity.HasIndex(e => e.TyperubId, "typerub_id_on_rubrique_fk");

            entity.Property(e => e.RubriqueId).HasColumnName("rubrique_id");
            entity.Property(e => e.AllowCustomAmount)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("allow_custom_amount");
            entity.Property(e => e.AnneeId)
                .HasColumnType("INT")
                .HasColumnName("annee_id");
            entity.Property(e => e.Commentaire)
                .HasColumnType("clob")
                .HasColumnName("commentaire");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsOutcome)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_outcome");
            entity.Property(e => e.Libelle)
                .HasColumnType("varchar(128)")
                .HasColumnName("libelle");
            entity.Property(e => e.MontantPerson)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montant_person");
            entity.Property(e => e.Montantroute)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montantroute");
            entity.Property(e => e.Nbmandataire)
                .HasColumnType("INT")
                .HasColumnName("nbmandataire");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasColumnType("INT")
                .HasColumnName("numordre");
            entity.Property(e => e.TopayEachPeriode)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("topay_each_periode");
            entity.Property(e => e.TyperubId)
                .HasColumnType("INT")
                .HasColumnName("typerub_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Annee).WithMany(p => p.MeetRubriques)
                .HasForeignKey(d => d.AnneeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Typerub).WithMany(p => p.MeetRubriques)
                .HasForeignKey(d => d.TyperubId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetSeance>(entity =>
        {
            entity.HasKey(e => e.SeanceId);

            entity.ToTable("meet_seance");

            entity.HasIndex(e => e.AntenneId, "antenne_id_on_seance_fk");

            entity.HasIndex(e => e.DivisionId, "division_id_on_seance_fk");

            entity.HasIndex(e => e.SeanceId, "meet_seance_pk").IsUnique();

            entity.HasIndex(e => new { e.DivisionId, e.AntenneId }, "uniq_meeting_seance").IsUnique();

            entity.Property(e => e.SeanceId).HasColumnName("seance_id");
            entity.Property(e => e.AntenneId)
                .HasColumnType("INT")
                .HasColumnName("antenne_id");
            entity.Property(e => e.Closedate)
                .HasColumnType("datetime")
                .HasColumnName("closedate");
            entity.Property(e => e.Compterendu)
                .HasColumnType("clob")
                .HasColumnName("compterendu");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Depensecollation)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("depensecollation");
            entity.Property(e => e.DivisionId)
                .HasColumnType("INT")
                .HasColumnName("division_id");
            entity.Property(e => e.Opendate)
                .HasColumnType("datetime")
                .HasColumnName("opendate");
            entity.Property(e => e.Status)
                .HasColumnType("INT")
                .HasColumnName("status");
            entity.Property(e => e.TotalEntrees)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("total_entrees");
            entity.Property(e => e.TotalSorties)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("total_sorties");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Antenne).WithMany(p => p.MeetSeances)
                .HasForeignKey(d => d.AntenneId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Division).WithMany(p => p.MeetSeances)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetSortieCaisse>(entity =>
        {
            entity.HasKey(e => e.SortiecaisseId);

            entity.ToTable("meet_sortie_caisse");

            entity.HasIndex(e => e.EngagementId, "engagement_id_on_sortiecaisse_f");

            entity.HasIndex(e => e.Idinscrit, "inscrit_id_on_sortiecaisse_fk2");

            entity.HasIndex(e => e.SortiecaisseId, "meet_sortie_caisse_pk").IsUnique();

            entity.HasIndex(e => e.SeanceId, "seance_id_on_sortiecaisse_fk3");

            entity.HasIndex(e => new { e.Idinscrit, e.SeanceId, e.EngagementId }, "uniq_sortie_caisse").IsUnique();

            entity.Property(e => e.SortiecaisseId).HasColumnName("sortiecaisse_id");
            entity.Property(e => e.BenefPrincipal)
                .HasDefaultValueSql("1")
                .HasColumnType("boolean")
                .HasColumnName("benef_principal");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Dateevts)
                .HasColumnType("date")
                .HasColumnName("dateevts");
            entity.Property(e => e.EngagementId)
                .HasColumnType("INT")
                .HasColumnName("engagement_id");
            entity.Property(e => e.Idinscrit)
                .HasColumnType("INT")
                .HasColumnName("idinscrit");
            entity.Property(e => e.IsClosed)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_closed");
            entity.Property(e => e.Montantpercu)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montantpercu");
            entity.Property(e => e.Note)
                .HasColumnType("varchar(1024)")
                .HasColumnName("note");
            entity.Property(e => e.RefNo)
                .HasColumnType("varchar(254)")
                .HasColumnName("ref_no");
            entity.Property(e => e.SeanceId)
                .HasColumnType("INT")
                .HasColumnName("seance_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
            entity.Property(e => e.Visarestants)
                .HasColumnType("INT")
                .HasColumnName("visarestants");

            entity.HasOne(d => d.Engagement).WithMany(p => p.MeetSortieCaisses)
                .HasForeignKey(d => d.EngagementId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetSortieCaisses)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Seance).WithMany(p => p.MeetSortieCaisses)
                .HasForeignKey(d => d.SeanceId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetSuspensionMembre>(entity =>
        {
            entity.HasKey(e => e.SuspensionId);

            entity.ToTable("meet_suspension_membre");

            entity.HasIndex(e => e.SuspensionId, "meet_suspension_membre_pk").IsUnique();

            entity.HasIndex(e => e.PersonId, "person_id_on_suspension_membre_");

            entity.Property(e => e.SuspensionId).HasColumnName("suspension_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.DateRetour)
                .HasColumnType("date")
                .HasColumnName("date_retour");
            entity.Property(e => e.DateSuspension)
                .HasColumnType("date")
                .HasColumnName("date_suspension");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_active");
            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Person).WithMany(p => p.MeetSuspensionMembres)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MeetTypeRubrique>(entity =>
        {
            entity.HasKey(e => e.TyperubId);

            entity.ToTable("meet_type_rubrique");

            entity.HasIndex(e => e.Code, "IX_meet_type_rubrique_code").IsUnique();

            entity.HasIndex(e => e.TyperubId, "meet_type_rubrique_pk").IsUnique();

            entity.Property(e => e.TyperubId).HasColumnName("typerub_id");
            entity.Property(e => e.AllowCustomAmount)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("allow_custom_amount");
            entity.Property(e => e.AutoGenerated)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("auto_generated");
            entity.Property(e => e.Candelete)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("candelete");
            entity.Property(e => e.Code)
                .HasColumnType("varchar(64)")
                .HasColumnName("code");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_active");
            entity.Property(e => e.IsOutcome)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("is_outcome");
            entity.Property(e => e.Libelle).HasColumnName("libelle");
            entity.Property(e => e.Maxsignature)
                .HasColumnType("INT")
                .HasColumnName("maxsignature");
            entity.Property(e => e.MontantPerson)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montant_person");
            entity.Property(e => e.Montantpenalite)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montantpenalite");
            entity.Property(e => e.Montantroute)
                .HasDefaultValueSql("0")
                .HasColumnType("numeric")
                .HasColumnName("montantroute");
            entity.Property(e => e.Nbmandataire)
                .HasColumnType("INT")
                .HasColumnName("nbmandataire");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasColumnType("INT")
                .HasColumnName("numordre");
            entity.Property(e => e.Required)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("required");
            entity.Property(e => e.TopayEachPeriode)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("topay_each_periode");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");
        });

        modelBuilder.Entity<MeetVisa>(entity =>
        {
            entity.HasKey(e => e.VisaId);

            entity.ToTable("meet_visas");

            entity.HasIndex(e => e.MeetOperation, "association_22_fk2");

            entity.HasIndex(e => e.ConfigvisaId, "configvisas_id_on_visa_fk");

            entity.HasIndex(e => e.Idinscrit, "inscrit_id_on_visas_fk");

            entity.HasIndex(e => e.VisaId, "meet_visas_pk").IsUnique();

            entity.HasIndex(e => e.SortiecaisseId, "sortiecaisse_id_on_visas_fk");

            entity.HasIndex(e => new { e.Idinscrit, e.ConfigvisaId }, "uniq_visa").IsUnique();

            entity.Property(e => e.VisaId).HasColumnName("visa_id");
            entity.Property(e => e.ConfigvisaId)
                .HasColumnType("INT")
                .HasColumnName("configvisa_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateUid)
                .HasColumnType("int8")
                .HasColumnName("create_uid");
            entity.Property(e => e.Datesign)
                .HasColumnType("date")
                .HasColumnName("datesign");
            entity.Property(e => e.Idinscrit)
                .HasColumnType("INT")
                .HasColumnName("idinscrit");
            entity.Property(e => e.MeetOperation)
                .HasColumnType("INT")
                .HasColumnName("meet_operation");
            entity.Property(e => e.Receiver)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("receiver");
            entity.Property(e => e.SignByOrdre)
                .HasDefaultValueSql("0")
                .HasColumnType("boolean")
                .HasColumnName("sign_by_ordre");
            entity.Property(e => e.SortiecaisseId)
                .HasColumnType("INT")
                .HasColumnName("sortiecaisse_id");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateUid)
                .HasColumnType("int8")
                .HasColumnName("update_uid");

            entity.HasOne(d => d.Configvisa).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.ConfigvisaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.MeetOperationNavigation).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.MeetOperation)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Sortiecaisse).WithMany(p => p.MeetVisas)
                .HasForeignKey(d => d.SortiecaisseId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
