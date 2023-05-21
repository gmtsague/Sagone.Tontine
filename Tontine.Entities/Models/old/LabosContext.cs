using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

public partial class LabosContext : DbContext
{
    public LabosContext()
    {
    }

    public LabosContext(DbContextOptions<LabosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aide> Aides { get; set; }

    public virtual DbSet<Annualengagement> Annualengagements { get; set; }

    public virtual DbSet<Antenne> Antennes { get; set; }

    public virtual DbSet<Bureau> Bureaus { get; set; }

    public virtual DbSet<Configvisa> Configvisas { get; set; }

    public virtual DbSet<CoreAnnee> CoreAnnees { get; set; }

    public virtual DbSet<CoreAnnualetabparam> CoreAnnualetabparams { get; set; }

    public virtual DbSet<CoreAutorisation> CoreAutorisations { get; set; }

    public virtual DbSet<CoreBank> CoreBanks { get; set; }

    public virtual DbSet<CoreBankaccount> CoreBankaccounts { get; set; }

    public virtual DbSet<CoreCommande> CoreCommandes { get; set; }

    public virtual DbSet<CoreEtablissement> CoreEtablissements { get; set; }

    public virtual DbSet<CoreLangue> CoreLangues { get; set; }

    public virtual DbSet<CorePay> CorePays { get; set; }

    public virtual DbSet<CorePerson> CorePeople { get; set; }

    public virtual DbSet<CorePhonenumber> CorePhonenumbers { get; set; }

    public virtual DbSet<CorePhoto> CorePhotos { get; set; }

    public virtual DbSet<CoreProfil> CoreProfils { get; set; }

    public virtual DbSet<CoreUser> CoreUsers { get; set; }

    public virtual DbSet<Entreecaisse> Entreecaisses { get; set; }

    public virtual DbSet<Inscription> Inscriptions { get; set; }

    public virtual DbSet<Modepaie> Modepaies { get; set; }

    public virtual DbSet<Monthlyseance> Monthlyseances { get; set; }

    public virtual DbSet<Poste> Postes { get; set; }

    public virtual DbSet<Presence> Presences { get; set; }

    public virtual DbSet<Pret> Prets { get; set; }

    public virtual DbSet<Rubrique> Rubriques { get; set; }

    public virtual DbSet<Sortiecaisse> Sortiecaisses { get; set; }

    public virtual DbSet<Visa> Visas { get; set; }

    public virtual DbSet<Yearlycopyoption> Yearlycopyoptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;port=5434;Database=labos;Username=laborentin;Password=Laborentin120");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aide>(entity =>
        {
            entity.HasKey(e => e.Idevts).HasName("pk_aide");

            entity.ToTable("aide", "tontine", tb => tb.HasComment("Aide"));

            entity.HasIndex(e => e.Idevts, "aide_pk").IsUnique();

            entity.Property(e => e.Idevts)
                .ValueGeneratedNever()
                .HasComment("Idevts")
                .HasColumnName("idevts");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle de l'evenement")
                .HasColumnName("libelle");
            entity.Property(e => e.Lieu)
                .HasMaxLength(254)
                .HasComment("Lieu ou se deroule l'evenement")
                .HasColumnName("lieu");
            entity.Property(e => e.Listemandataires)
                .HasMaxLength(254)
                .HasComment("Liste des membres designes pour le deplacement")
                .HasColumnName("listemandataires");
            entity.Property(e => e.Montantroute)
                .HasComment("Montant dedie au deplacement des membres")
                .HasColumnName("montantroute");
            entity.Property(e => e.Montanttotalevt)
                .HasComment("Montant statutaire prevu annuellement pourl'evenement")
                .HasColumnName("montanttotalevt");

            entity.HasOne(d => d.IdevtsNavigation).WithOne(p => p.Aide)
                .HasForeignKey<Aide>(d => d.Idevts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_aide_generalis_sortieca");
        });

        modelBuilder.Entity<Annualengagement>(entity =>
        {
            entity.HasKey(e => e.Idconfig).HasName("pk_annualengagements");

            entity.ToTable("annualengagements", "tontine", tb => tb.HasComment("Represente la personnalisation de certaines valeurs appliquees aux types d'eveneents au cours d'une annee"));

            entity.HasIndex(e => e.Idconfig, "annualengagements_pk").IsUnique();

            entity.HasIndex(e => e.Idtype, "association_10_fk");

            entity.HasIndex(e => e.Idannee, "association_9_fk");

            entity.Property(e => e.Idconfig)
                .HasComment("Identifiant d'une configuration")
                .HasColumnName("idconfig");
            entity.Property(e => e.Categorie)
                .HasComment("Numero determinant le type d'evenement/engagement")
                .HasColumnName("categorie");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(254)
                .HasComment("Commentaire")
                .HasColumnName("commentaire");
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Idtype)
                .HasComment("Identifiant du type d'evenement")
                .HasColumnName("idtype");
            entity.Property(e => e.Interetmensuel)
                .HasDefaultValueSql("0")
                .HasComment("Taux d'interet mensuel")
                .HasColumnName("interetmensuel");
            entity.Property(e => e.Isactive)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasComment("Isactive")
                .HasColumnName("isactive");
            entity.Property(e => e.Isaide)
                .HasComment("IsAide")
                .HasColumnName("isaide");
            entity.Property(e => e.Iscotisation)
                .HasComment("Indique si le type represente la cotisation")
                .HasColumnName("iscotisation");
            entity.Property(e => e.Isdepense)
                .HasComment("Isdepense")
                .HasColumnName("isdepense");
            entity.Property(e => e.Isfondentraide)
                .HasComment("IsFondEntraide")
                .HasColumnName("isfondentraide");
            entity.Property(e => e.Ispret)
                .HasDefaultValueSql("false")
                .HasComment("Indique si le type d'evenement est un pret")
                .HasColumnName("ispret");
            entity.Property(e => e.Montantevt)
                .HasComment("Montant de l'evenement")
                .HasColumnName("montantevt");
            entity.Property(e => e.Montantpenalite)
                .HasComment("Montant de la penalite applicable en cas d'absence aa l'evenement")
                .HasColumnName("montantpenalite");
            entity.Property(e => e.Montantroute)
                .HasComment("Montant du deplacement d'un membre mandate par l'association")
                .HasColumnName("montantroute");
            entity.Property(e => e.Montanttotal)
                .HasComment("Montant total associe a l'evenement")
                .HasColumnName("montanttotal");
            entity.Property(e => e.Nbmandataire)
                .HasComment("Nombre de membres representant l'asociation a l'evenement")
                .HasColumnName("nbmandataire");
            entity.Property(e => e.Tauxpenalite)
                .HasDefaultValueSql("0")
                .HasComment("Taux d'interet applicable en cas de penalite")
                .HasColumnName("tauxpenalite");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Annualengagements)
                .HasForeignKey(d => d.Idannee)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_annualen_associati_core_ann");

            entity.HasOne(d => d.IdtypeNavigation).WithMany(p => p.Annualengagements)
                .HasForeignKey(d => d.Idtype)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_annualen_associati_rubrique");
        });

        modelBuilder.Entity<Antenne>(entity =>
        {
            entity.HasKey(e => e.Idantenne).HasName("pk_antenne");

            entity.ToTable("antenne", "tontine", tb => tb.HasComment("Represente ue antenne de l'association"));

            entity.HasIndex(e => e.Idantenne, "antenne_pk").IsUnique();

            entity.Property(e => e.Idantenne)
                .HasComment("Identifiant de l'antenne")
                .HasColumnName("idantenne");
            entity.Property(e => e.Creationdate)
                .HasComment("Date de creation de l'antenne")
                .HasColumnName("creationdate");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle de l'antenne")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Bureau>(entity =>
        {
            entity.HasKey(e => e.Idbureau).HasName("pk_bureau");

            entity.ToTable("bureau", "tontine", tb => tb.HasComment("Bureau"));

            entity.HasIndex(e => e.Idbureau, "bureau_pk").IsUnique();

            entity.Property(e => e.Idbureau)
                .HasComment("Idbureau")
                .HasColumnName("idbureau");
            entity.Property(e => e.Debut)
                .HasComment("Debut")
                .HasColumnName("debut");
            entity.Property(e => e.Fin)
                .HasComment("Fin")
                .HasColumnName("fin");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle")
                .HasColumnName("libelle");
            entity.Property(e => e.Nbabstention)
                .HasDefaultValueSql("0")
                .HasComment("NbAbstention")
                .HasColumnName("nbabstention");
            entity.Property(e => e.Nbperson)
                .HasDefaultValueSql("0")
                .HasComment("Nbperson")
                .HasColumnName("nbperson");
            entity.Property(e => e.Nbvotes)
                .HasDefaultValueSql("0")
                .HasComment("Nbvotes")
                .HasColumnName("nbvotes");
        });

        modelBuilder.Entity<Configvisa>(entity =>
        {
            entity.HasKey(e => e.Idconfigvisa).HasName("pk_configvisas");

            entity.ToTable("configvisas", "tontine", tb => tb.HasComment("Represente l'ensemble des autorisatios de signature de documents au sein de l'association"));

            entity.HasIndex(e => e.Idannee, "association_6_fk");

            entity.HasIndex(e => e.Idposte, "association_7_fk");

            entity.HasIndex(e => e.Idtype, "association_8_fk2");

            entity.HasIndex(e => e.Idconfigvisa, "configvisas_pk").IsUnique();

            entity.Property(e => e.Idconfigvisa)
                .HasComment("Identifiant de la configuration de signature")
                .HasColumnName("idconfigvisa");
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Idposte)
                .HasComment("Idposte")
                .HasColumnName("idposte");
            entity.Property(e => e.Idtype)
                .HasComment("Identifiant du type d'evenement")
                .HasColumnName("idtype");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasComment("Numero d'ordre de la signature pour un type de document")
                .HasColumnName("numordre");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Configvisas)
                .HasForeignKey(d => d.Idannee)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_configvi_associati_core_ann");

            entity.HasOne(d => d.IdposteNavigation).WithMany(p => p.Configvisas)
                .HasForeignKey(d => d.Idposte)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_configvi_associati_poste");

            entity.HasOne(d => d.IdtypeNavigation).WithMany(p => p.Configvisas)
                .HasForeignKey(d => d.Idtype)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_configvi_associati_rubrique");
        });

        modelBuilder.Entity<CoreAnnee>(entity =>
        {
            entity.HasKey(e => e.Idannee).HasName("pk_core_annee");

            entity.ToTable("core_annee", "tontine", tb => tb.HasComment("Represente une annee "));

            entity.HasIndex(e => e.Idbureau, "association_24_fk");

            entity.HasIndex(e => e.Idannee, "core_annee_pk").IsUnique();

            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Datedebut)
                .HasComment("Date de debut de l'annee")
                .HasColumnName("datedebut");
            entity.Property(e => e.Datefin)
                .HasComment("Date de fin de l'annee")
                .HasColumnName("datefin");
            entity.Property(e => e.Idbureau)
                .HasComment("Idbureau")
                .HasColumnName("idbureau");
            entity.Property(e => e.Isclosed)
                .HasComment("Indique que l'annee et cloturee et ses donnees ne sont plus modifiables")
                .HasColumnName("isclosed");
            entity.Property(e => e.Iscurrent)
                .HasComment("Indique l'annee de travail")
                .HasColumnName("iscurrent");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle de l'annee")
                .HasColumnName("libelle");
            entity.Property(e => e.Nbdivision)
                .HasDefaultValueSql("12")
                .HasComment("Nombre de divisions de l'annee")
                .HasColumnName("nbdivision");

            entity.HasOne(d => d.IdbureauNavigation).WithMany(p => p.CoreAnnees)
                .HasForeignKey(d => d.Idbureau)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_bureau");
        });

        modelBuilder.Entity<CoreAnnualetabparam>(entity =>
        {
            entity.HasKey(e => e.SchoolparamsId).HasName("pk_core_annualetabparams");

            entity.ToTable("core_annualetabparams", "tontine", tb => tb.HasComment("core_AnnualEtabParams"));

            entity.HasIndex(e => e.Idetab, "association_40_fk");

            entity.HasIndex(e => e.Idannee, "association_41_fk");

            entity.HasIndex(e => e.SchoolparamsId, "core_annualetabparams_pk").IsUnique();

            entity.Property(e => e.SchoolparamsId)
                .ValueGeneratedNever()
                .HasComment("Identifiant de l'entite")
                .HasColumnName("schoolparams_id");
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Idetab)
                .HasComment("Idetab")
                .HasColumnName("idetab");
            entity.Property(e => e.MaxphotoallowLiens)
                .HasComment("Nombre max de liens autorises pour la photo d'une personne")
                .HasColumnName("maxphotoallow_liens");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.CoreAnnualetabparams)
                .HasForeignKey(d => d.Idannee)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");

            entity.HasOne(d => d.IdetabNavigation).WithMany(p => p.CoreAnnualetabparams)
                .HasForeignKey(d => d.Idetab)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_eta");
        });

        modelBuilder.Entity<CoreAutorisation>(entity =>
        {
            entity.HasKey(e => e.Idchoix).HasName("pk_core_autorisations");

            entity.ToTable("core_autorisations", "tontine", tb => tb.HasComment("core_Autorisations"));

            entity.HasIndex(e => e.Idprofil, "association_30_fk");

            entity.HasIndex(e => e.Idcmde, "association_31_fk");

            entity.HasIndex(e => e.Idchoix, "core_autorisations_pk").IsUnique();

            entity.Property(e => e.Idchoix)
                .HasComment("Idchoix")
                .HasColumnName("idchoix");
            entity.Property(e => e.Idcmde)
                .HasComment("Idcmde")
                .HasColumnName("idcmde");
            entity.Property(e => e.Idprofil)
                .HasComment("Idprofil")
                .HasColumnName("idprofil");
            entity.Property(e => e.Isactive)
                .HasComment("Isactive")
                .HasColumnName("isactive");

            entity.HasOne(d => d.IdcmdeNavigation).WithMany(p => p.CoreAutorisations)
                .HasForeignKey(d => d.Idcmde)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_com");

            entity.HasOne(d => d.IdprofilNavigation).WithMany(p => p.CoreAutorisations)
                .HasForeignKey(d => d.Idprofil)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_pro");
        });

        modelBuilder.Entity<CoreBank>(entity =>
        {
            entity.HasKey(e => e.Idbank).HasName("pk_core_bank");

            entity.ToTable("core_bank", "tontine", tb => tb.HasComment("Etablissement financier"));

            entity.HasIndex(e => e.PaysId, "association_43_fk");

            entity.HasIndex(e => e.Idbank, "core_bank_pk").IsUnique();

            entity.Property(e => e.Idbank)
                .HasComment("Identifiant de la banque")
                .HasColumnName("idbank");
            entity.Property(e => e.Adresse)
                .HasMaxLength(254)
                .HasComment("Adresse postale de la banque")
                .HasColumnName("adresse");
            entity.Property(e => e.Coderib)
                .HasMaxLength(254)
                .HasComment("Numero de compte de l'association chez la baqnue")
                .HasColumnName("coderib");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasComment("Contact telephonique de la banque No2")
                .HasColumnName("email");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle de la banque")
                .HasColumnName("libelle");
            entity.Property(e => e.PaysId)
                .HasComment("Identifiant du pays")
                .HasColumnName("pays_id");

            entity.HasOne(d => d.Pays).WithMany(p => p.CoreBanks)
                .HasForeignKey(d => d.PaysId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_pay");
        });

        modelBuilder.Entity<CoreBankaccount>(entity =>
        {
            entity.HasKey(e => e.Idcompte).HasName("pk_core_bankaccount");

            entity.ToTable("core_bankaccount", "tontine", tb => tb.HasComment("core_Bankaccount"));

            entity.HasIndex(e => e.Idbank, "association_17_fk");

            entity.HasIndex(e => e.Idperson, "association_27_fk");

            entity.HasIndex(e => e.Idetab, "association_28_fk");

            entity.HasIndex(e => e.Idcompte, "core_bankaccount_pk").IsUnique();

            entity.Property(e => e.Idcompte)
                .HasComment("Idcompte")
                .HasColumnName("idcompte");
            entity.Property(e => e.Idbank)
                .HasComment("Identifiant de la banque")
                .HasColumnName("idbank");
            entity.Property(e => e.Idetab)
                .HasComment("Idetab")
                .HasColumnName("idetab");
            entity.Property(e => e.Idperson)
                .HasComment("Idperson")
                .HasColumnName("idperson");
            entity.Property(e => e.Isactive)
                .HasComment("Isactive")
                .HasColumnName("isactive");
            entity.Property(e => e.Numcompte)
                .HasMaxLength(254)
                .HasComment("Numcompte")
                .HasColumnName("numcompte");
            entity.Property(e => e.Solde)
                .HasComment("solde")
                .HasColumnName("solde");

            entity.HasOne(d => d.IdbankNavigation).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.Idbank)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_ban");

            entity.HasOne(d => d.IdetabNavigation).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.Idetab)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_eta");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.CoreBankaccounts)
                .HasForeignKey(d => d.Idperson)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_per");
        });

        modelBuilder.Entity<CoreCommande>(entity =>
        {
            entity.HasKey(e => e.Idcmde).HasName("pk_core_commandes");

            entity.ToTable("core_commandes", "tontine", tb => tb.HasComment("core_Commandes"));

            entity.HasIndex(e => e.Idcmde, "core_commandes_pk").IsUnique();

            entity.Property(e => e.Idcmde)
                .HasComment("Idcmde")
                .HasColumnName("idcmde");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreEtablissement>(entity =>
        {
            entity.HasKey(e => e.Idetab).HasName("pk_core_etablissement");

            entity.ToTable("core_etablissement", "tontine", tb => tb.HasComment("core_Etablissement"));

            entity.HasIndex(e => e.PaysId, "association_42_fk");

            entity.HasIndex(e => e.Idetab, "core_etablissement_pk").IsUnique();

            entity.Property(e => e.Idetab)
                .HasComment("Idetab")
                .HasColumnName("idetab");
            entity.Property(e => e.Agrement)
                .HasMaxLength(254)
                .HasComment("Agrement")
                .HasColumnName("agrement");
            entity.Property(e => e.Dossierfiscale)
                .HasMaxLength(254)
                .HasComment("Dossierfiscale")
                .HasColumnName("dossierfiscale");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle")
                .HasColumnName("libelle");
            entity.Property(e => e.PaysId)
                .HasComment("Identifiant du pays")
                .HasColumnName("pays_id");

            entity.HasOne(d => d.Pays).WithMany(p => p.CoreEtablissements)
                .HasForeignKey(d => d.PaysId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_eta_associati_core_pay");
        });

        modelBuilder.Entity<CoreLangue>(entity =>
        {
            entity.HasKey(e => e.LangueId).HasName("pk_core_langue");

            entity.ToTable("core_langue", "tontine", tb => tb.HasComment("core_Langue"));

            entity.HasIndex(e => e.LangueId, "core_langue_pk").IsUnique();

            entity.Property(e => e.LangueId)
                .HasComment("Identifiant de la langue")
                .HasColumnName("langue_id");
            entity.Property(e => e.Isactive)
                .HasComment("isactive")
                .HasColumnName("isactive");
            entity.Property(e => e.Isdefault)
                .HasComment("Indique la langue par defaut")
                .HasColumnName("isdefault");
            entity.Property(e => e.Isocode)
                .HasMaxLength(254)
                .HasComment("Code ISO de la langue")
                .HasColumnName("isocode");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle de la langue")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<CorePay>(entity =>
        {
            entity.HasKey(e => e.PaysId).HasName("pk_core_pays");

            entity.ToTable("core_pays", "tontine", tb => tb.HasComment("core_Pays"));

            entity.HasIndex(e => e.PaysId, "core_pays_pk").IsUnique();

            entity.Property(e => e.PaysId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du pays")
                .HasColumnName("pays_id");
            entity.Property(e => e.Code)
                .HasMaxLength(254)
                .HasComment("Code (2 caracteres) ISO du pays")
                .HasColumnName("code");
            entity.Property(e => e.Devisepays)
                .HasMaxLength(254)
                .HasComment("Devise du pays")
                .HasColumnName("devisepays");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Nom du pays")
                .HasColumnName("libelle");
            entity.Property(e => e.Phonecode)
                .HasMaxLength(254)
                .HasComment("Code telephoniquedu pays")
                .HasColumnName("phonecode");
        });

        modelBuilder.Entity<CorePerson>(entity =>
        {
            entity.HasKey(e => e.Idperson).HasName("pk_core_person");

            entity.ToTable("core_person", "tontine", tb => tb.HasComment("Represente un membre de la reunion"));

            entity.HasIndex(e => e.PaysId, "association_8_fk");

            entity.HasIndex(e => e.Idperson, "core_person_pk").IsUnique();

            entity.Property(e => e.Idperson)
                .HasComment("Idperson")
                .HasColumnName("idperson");
            entity.Property(e => e.Adresse)
                .HasMaxLength(254)
                .HasComment("Adresse")
                .HasColumnName("adresse");
            entity.Property(e => e.Anneepromo)
                .HasMaxLength(254)
                .HasComment("Anneepromo")
                .HasColumnName("anneepromo");
            entity.Property(e => e.Dateadhesion)
                .HasComment("Dateadhesion")
                .HasColumnName("dateadhesion");
            entity.Property(e => e.Datenais)
                .HasComment("Datenais")
                .HasColumnName("datenais");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasComment("Email")
                .HasColumnName("email");
            entity.Property(e => e.Isvisible)
                .HasComment("Cette personne represente un utilisateur systeme")
                .HasColumnName("isvisible");
            entity.Property(e => e.Lieunais)
                .HasMaxLength(254)
                .HasComment("lieunais")
                .HasColumnName("lieunais");
            entity.Property(e => e.Nocni)
                .HasMaxLength(254)
                .HasComment("Nocni")
                .HasColumnName("nocni");
            entity.Property(e => e.Nom)
                .HasMaxLength(254)
                .HasComment("Nom")
                .HasColumnName("nom");
            entity.Property(e => e.PaysId)
                .HasComment("Identifiant du pays")
                .HasColumnName("pays_id");
            entity.Property(e => e.Prenom)
                .HasMaxLength(254)
                .HasDefaultValueSql("''::character varying")
                .HasComment("Prenom")
                .HasColumnName("prenom");
            entity.Property(e => e.Sexe)
                .HasMaxLength(254)
                .HasComment("Sexe")
                .HasColumnName("sexe");

            entity.HasOne(d => d.Pays).WithMany(p => p.CorePeople)
                .HasForeignKey(d => d.PaysId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_pay");
        });

        modelBuilder.Entity<CorePhonenumber>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("pk_core_phonenumber");

            entity.ToTable("core_phonenumber", "tontine", tb => tb.HasComment("core_Phonenumber"));

            entity.HasIndex(e => e.Idperson, "association_10_fk2");

            entity.HasIndex(e => e.Idbank, "association_44_fk");

            entity.HasIndex(e => e.PaysId, "association_5_fk2");

            entity.HasIndex(e => e.PhoneId, "core_phonenumber_pk").IsUnique();

            entity.Property(e => e.PhoneId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du numero de telephone")
                .HasColumnName("phone_id");
            entity.Property(e => e.Idbank)
                .HasComment("Identifiant de la banque")
                .HasColumnName("idbank");
            entity.Property(e => e.Idperson)
                .HasComment("Idperson")
                .HasColumnName("idperson");
            entity.Property(e => e.Isdefaut)
                .HasComment("Represente le numero par defaut")
                .HasColumnName("isdefaut");
            entity.Property(e => e.Numphone)
                .HasMaxLength(254)
                .HasComment("Numero telephone")
                .HasColumnName("numphone");
            entity.Property(e => e.PaysId)
                .HasComment("Identifiant du pays")
                .HasColumnName("pays_id");

            entity.HasOne(d => d.IdbankNavigation).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.Idbank)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_ban");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.Idperson)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");

            entity.HasOne(d => d.Pays).WithMany(p => p.CorePhonenumbers)
                .HasForeignKey(d => d.PaysId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_pay");
        });

        modelBuilder.Entity<CorePhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("pk_core_photos");

            entity.ToTable("core_photos", "tontine", tb => tb.HasComment("core_Photos"));

            entity.HasIndex(e => e.Idperson, "association_11_fk2");

            entity.HasIndex(e => e.Idetab, "association_39_fk");

            entity.HasIndex(e => e.PhotoId, "core_photos_pk").IsUnique();

            entity.Property(e => e.PhotoId)
                .ValueGeneratedNever()
                .HasComment("Identifiant d'une photo")
                .HasColumnName("photo_id");
            entity.Property(e => e.Fileext)
                .HasMaxLength(254)
                .HasComment("Extension du fichier")
                .HasColumnName("fileext");
            entity.Property(e => e.Filename)
                .HasMaxLength(254)
                .HasComment("Filename")
                .HasColumnName("filename");
            entity.Property(e => e.Filepath)
                .HasMaxLength(254)
                .HasComment("Chemin d'acces au fichier")
                .HasColumnName("filepath");
            entity.Property(e => e.Idetab)
                .HasComment("Idetab")
                .HasColumnName("idetab");
            entity.Property(e => e.Idperson)
                .HasComment("Idperson")
                .HasColumnName("idperson");
            entity.Property(e => e.Image)
                .HasMaxLength(254)
                .HasComment("Image")
                .HasColumnName("image");
            entity.Property(e => e.Issignature)
                .HasComment("Represente une signature")
                .HasColumnName("issignature");
            entity.Property(e => e.MaxallowLiens)
                .HasComment("Nombre max de liens autorises")
                .HasColumnName("maxallow_liens");
            entity.Property(e => e.NbactualLiens)
                .HasComment("Nombre de liens actuels")
                .HasColumnName("nbactual_liens");

            entity.HasOne(d => d.IdetabNavigation).WithMany(p => p.CorePhotos)
                .HasForeignKey(d => d.Idetab)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_eta");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.CorePhotos)
                .HasForeignKey(d => d.Idperson)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<CoreProfil>(entity =>
        {
            entity.HasKey(e => e.Idprofil).HasName("pk_core_profil");

            entity.ToTable("core_profil", "tontine", tb => tb.HasComment("core_Profil"));

            entity.HasIndex(e => e.Idprofil, "core_profil_pk").IsUnique();

            entity.Property(e => e.Idprofil)
                .HasComment("Idprofil")
                .HasColumnName("idprofil");
            entity.Property(e => e.Candelete)
                .HasComment("Candelete")
                .HasColumnName("candelete");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<CoreUser>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("pk_core_user");

            entity.ToTable("core_user", "tontine", tb => tb.HasComment("core_User"));

            entity.HasIndex(e => e.Idprofil, "association_32_fk");

            entity.HasIndex(e => e.LangueId, "association_38_fk");

            entity.HasIndex(e => e.Userid, "core_user_pk").IsUnique();

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasComment("UserId")
                .HasColumnName("userid");
            entity.Property(e => e.Expirationdate)
                .HasComment("Date d'expiration")
                .HasColumnName("expirationdate");
            entity.Property(e => e.Idprofil)
                .HasComment("Idprofil")
                .HasColumnName("idprofil");
            entity.Property(e => e.Isactif)
                .HasComment("Compte actif")
                .HasColumnName("isactif");
            entity.Property(e => e.LangueId)
                .HasComment("Identifiant de la langue")
                .HasColumnName("langue_id");
            entity.Property(e => e.Lastconnexion)
                .HasComment("Lastconnexion")
                .HasColumnName("lastconnexion");
            entity.Property(e => e.Passwd)
                .HasMaxLength(254)
                .HasComment("Mot de passe")
                .HasColumnName("passwd");
            entity.Property(e => e.Username)
                .HasMaxLength(254)
                .HasComment("Nom d'utilisateur")
                .HasColumnName("username");

            entity.HasOne(d => d.IdprofilNavigation).WithMany(p => p.CoreUsers)
                .HasForeignKey(d => d.Idprofil)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_pro");

            entity.HasOne(d => d.Langue).WithMany(p => p.CoreUsers)
                .HasForeignKey(d => d.LangueId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_lan");
        });

        modelBuilder.Entity<Entreecaisse>(entity =>
        {
            entity.HasKey(e => e.Idoperation).HasName("pk_entreecaisse");

            entity.ToTable("entreecaisse", "tontine", tb => tb.HasComment("Entreecaisse"));

            entity.HasIndex(e => e.Idpresence, "association_20_fk");

            entity.HasIndex(e => e.Idevts, "association_21_fk");

            entity.HasIndex(e => e.Idconfig, "association_2_fk");

            entity.HasIndex(e => e.Idoperation, "entreecaisse_pk").IsUnique();

            entity.Property(e => e.Idoperation)
                .HasComment("Idoperation")
                .HasColumnName("idoperation");
            entity.Property(e => e.Cumulverse)
                .HasComment("CumulVerse")
                .HasColumnName("cumulverse");
            entity.Property(e => e.Idconfig)
                .HasComment("Identifiant d'une configuration")
                .HasColumnName("idconfig");
            entity.Property(e => e.Idevts)
                .HasComment("Idevts")
                .HasColumnName("idevts");
            entity.Property(e => e.Idpresence)
                .HasComment("Identiifant de la signature")
                .HasColumnName("idpresence");
            entity.Property(e => e.Montantverse)
                .HasComment("MontantVerse")
                .HasColumnName("montantverse");
            entity.Property(e => e.Reste)
                .HasComment("Reste")
                .HasColumnName("reste");

            entity.HasOne(d => d.IdconfigNavigation).WithMany(p => p.Entreecaisses)
                .HasForeignKey(d => d.Idconfig)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entreeca_associati_annualen");

            entity.HasOne(d => d.IdevtsNavigation).WithMany(p => p.Entreecaisses)
                .HasForeignKey(d => d.Idevts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entreeca_associati_sortieca");

            entity.HasOne(d => d.IdpresenceNavigation).WithMany(p => p.Entreecaisses)
                .HasForeignKey(d => d.Idpresence)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entreeca_associati_presence");
        });

        modelBuilder.Entity<Inscription>(entity =>
        {
            entity.HasKey(e => e.Idinscrit).HasName("pk_inscription");

            entity.ToTable("inscription", "tontine", tb => tb.HasComment("Represente le renoouvellement de la presence d'un membre au sein de 'association au cours d'une annee"));

            entity.HasIndex(e => e.Idposte, "association_23_fk");

            entity.HasIndex(e => e.Idantenne, "association_3_fk");

            entity.HasIndex(e => e.Idperson, "association_4_fk");

            entity.HasIndex(e => e.Idannee, "association_5_fk");

            entity.HasIndex(e => e.Idinscrit, "inscription_pk").IsUnique();

            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
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
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Idantenne)
                .HasComment("Identifiant de l'antenne")
                .HasColumnName("idantenne");
            entity.Property(e => e.Idperson)
                .HasComment("Idperson")
                .HasColumnName("idperson");
            entity.Property(e => e.Idposte)
                .HasComment("Idposte")
                .HasColumnName("idposte");
            entity.Property(e => e.Isactive)
                .HasComment("Statut actif ou non d'un membre")
                .HasColumnName("isactive");
            entity.Property(e => e.Nocni)
                .HasMaxLength(254)
                .HasComment("Nocni")
                .HasColumnName("nocni");
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
            entity.Property(e => e.Totalverse)
                .HasComment("Totalverse")
                .HasColumnName("totalverse");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.Idannee)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_core_ann");

            entity.HasOne(d => d.IdantenneNavigation).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.Idantenne)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_antenne");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.Idperson)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_core_per");

            entity.HasOne(d => d.IdposteNavigation).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.Idposte)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_poste");
        });

        modelBuilder.Entity<Modepaie>(entity =>
        {
            entity.HasKey(e => e.Idmode).HasName("pk_modepaie");

            entity.ToTable("modepaie", "tontine", tb => tb.HasComment("Mode de paiement utilise par un membre"));

            entity.HasIndex(e => e.Idmode, "modepaie_pk").IsUnique();

            entity.Property(e => e.Idmode)
                .HasComment("Identifiant du mode de paiement")
                .HasColumnName("idmode");
            entity.Property(e => e.Iscash)
                .HasComment("Indique si le mode represnte le CASH")
                .HasColumnName("iscash");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle du mode de paiement")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Monthlyseance>(entity =>
        {
            entity.HasKey(e => new { e.Idannee, e.Iddivision }).HasName("pk_monthlyseance");

            entity.ToTable("monthlyseance", "tontine", tb => tb.HasComment("Represente le decoupage mensuel de l'annee"));

            entity.HasIndex(e => e.Idinscrit, "association_16_fk");

            entity.HasIndex(e => e.Idannee, "association_1_fk");

            entity.HasIndex(e => new { e.Idannee, e.Iddivision }, "monthlyseance_pk").IsUnique();

            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Iddivision)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de la division")
                .HasColumnName("iddivision");
            entity.Property(e => e.Dateseance)
                .HasComment("Date de debut de la division")
                .HasColumnName("dateseance");
            entity.Property(e => e.Heuredebut)
                .HasComment("HeureDebut")
                .HasColumnName("heuredebut");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle de la division")
                .HasColumnName("libelle");
            entity.Property(e => e.Montantpercu)
                .HasComment("MontantPercu")
                .HasColumnName("montantpercu");
            entity.Property(e => e.Numordre)
                .HasComment("Numero d'ordre de la division")
                .HasColumnName("numordre");
            entity.Property(e => e.Totalcotise)
                .HasComment("TotalCotise")
                .HasColumnName("totalcotise");
            entity.Property(e => e.Totalsortie)
                .HasComment("TotalSortie")
                .HasColumnName("totalsortie");
            entity.Property(e => e.Visarestants)
                .HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.")
                .HasColumnName("visarestants");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Monthlyseances)
                .HasForeignKey(d => d.Idannee)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_monthlys_associati_core_ann");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Monthlyseances)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_monthlys_associati_inscript");
        });

        modelBuilder.Entity<Poste>(entity =>
        {
            entity.HasKey(e => e.Idposte).HasName("pk_poste");

            entity.ToTable("poste", "tontine", tb => tb.HasComment("Poste occupe par un membre de l'association"));

            entity.HasIndex(e => e.Idposte, "poste_pk").IsUnique();

            entity.Property(e => e.Idposte)
                .HasComment("Idposte")
                .HasColumnName("idposte");
            entity.Property(e => e.Iscc)
                .HasComment("Iscc")
                .HasColumnName("iscc");
            entity.Property(e => e.Ismembre)
                .HasComment("Ismembre")
                .HasColumnName("ismembre");
            entity.Property(e => e.Ispresident)
                .HasComment("Ispresident")
                .HasColumnName("ispresident");
            entity.Property(e => e.Issg)
                .HasComment("Issg")
                .HasColumnName("issg");
            entity.Property(e => e.Issga)
                .HasComment("Issga")
                .HasColumnName("issga");
            entity.Property(e => e.Istresorier)
                .HasComment("Istresorier")
                .HasColumnName("istresorier");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle")
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Presence>(entity =>
        {
            entity.HasKey(e => e.Idpresence).HasName("pk_presence");

            entity.ToTable("presence", "tontine", tb => tb.HasComment("Represente l'etat des presences des membres a une seance de reunion et l'ensemble des signatures apposees par les membres (beneficiaire et bureau) de l'association sur un document"));

            entity.HasIndex(e => e.Idinscrit, "association_13_fk");

            entity.HasIndex(e => new { e.Idannee, e.Iddivision }, "association_14_fk");

            entity.HasIndex(e => e.Idmode, "association_18_fk");

            entity.HasIndex(e => e.Idcompte, "association_29_fk");

            entity.HasIndex(e => e.Idpresence, "presence_pk").IsUnique();

            entity.Property(e => e.Idpresence)
                .HasComment("Identiifant de la signature")
                .HasColumnName("idpresence");
            entity.Property(e => e.Codeop)
                .HasComment("Indique le tupe d'operation (Entree ou Sortie de caisse)")
                .HasColumnName("codeop");
            entity.Property(e => e.Cumuldetteapres)
                .HasDefaultValueSql("0")
                .HasComment("CumulDetteApres")
                .HasColumnName("cumuldetteapres");
            entity.Property(e => e.Dateop)
                .HasComment("Dateop")
                .HasColumnName("dateop");
            entity.Property(e => e.Globalverse)
                .HasDefaultValueSql("0")
                .HasComment("globalverse")
                .HasColumnName("globalverse");
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Idcompte)
                .HasComment("Idcompte")
                .HasColumnName("idcompte");
            entity.Property(e => e.Iddivision)
                .HasComment("Identifiant de la division")
                .HasColumnName("iddivision");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.Idmode)
                .HasComment("Identifiant du mode de paiement")
                .HasColumnName("idmode");
            entity.Property(e => e.Isabsent)
                .HasComment("isabsent")
                .HasColumnName("isabsent");
            entity.Property(e => e.Numbordero)
                .HasMaxLength(254)
                .HasComment("Numbordero")
                .HasColumnName("numbordero");
            entity.Property(e => e.Soldedebut)
                .HasDefaultValueSql("0")
                .HasComment("Soldedebut")
                .HasColumnName("soldedebut");
            entity.Property(e => e.Soldefin)
                .HasDefaultValueSql("0")
                .HasComment("Soldefin")
                .HasColumnName("soldefin");

            entity.HasOne(d => d.IdcompteNavigation).WithMany(p => p.Presences)
                .HasForeignKey(d => d.Idcompte)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_core_ban");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Presences)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_inscript");

            entity.HasOne(d => d.IdmodeNavigation).WithMany(p => p.Presences)
                .HasForeignKey(d => d.Idmode)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_modepaie");

            entity.HasOne(d => d.Id).WithMany(p => p.Presences)
                .HasForeignKey(d => new { d.Idannee, d.Iddivision })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_monthlys");
        });

        modelBuilder.Entity<Pret>(entity =>
        {
            entity.HasKey(e => e.Idevts).HasName("pk_pret");

            entity.ToTable("pret", "tontine", tb => tb.HasComment("Pret"));

            entity.HasIndex(e => e.Idevts, "pret_pk").IsUnique();

            entity.Property(e => e.Idevts)
                .ValueGeneratedNever()
                .HasComment("Idevts")
                .HasColumnName("idevts");
            entity.Property(e => e.Dureepret)
                .HasComment("Duree du pret en nombre de mois")
                .HasColumnName("dureepret");
            entity.Property(e => e.Ispret)
                .HasComment("Indique si l'evenement est un pret")
                .HasColumnName("ispret");
            entity.Property(e => e.Montantinteret)
                .HasComment("Montant de l'interet")
                .HasColumnName("montantinteret");
            entity.Property(e => e.Montantpenalite)
                .HasComment("Montant applicable en cas de penalite sur les interets ou en cas d'absence de cotisation")
                .HasColumnName("montantpenalite");

            entity.HasOne(d => d.IdevtsNavigation).WithOne(p => p.Pret)
                .HasForeignKey<Pret>(d => d.Idevts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_pret_generalis_sortieca");
        });

        modelBuilder.Entity<Rubrique>(entity =>
        {
            entity.HasKey(e => e.Idtype).HasName("pk_rubrique");

            entity.ToTable("rubrique", "tontine", tb => tb.HasComment("Represente un type d'evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc."));

            entity.HasIndex(e => e.Idtype, "rubrique_pk").IsUnique();

            entity.Property(e => e.Idtype)
                .HasComment("Identifiant du type d'evenement")
                .HasColumnName("idtype");
            entity.Property(e => e.Candelete)
                .HasComment("CanDelete")
                .HasColumnName("candelete");
            entity.Property(e => e.Isaide)
                .HasComment("IsAide")
                .HasColumnName("isaide");
            entity.Property(e => e.Iscotisation)
                .HasComment("Indique si le type represente la cotisation")
                .HasColumnName("iscotisation");
            entity.Property(e => e.Isdepense)
                .HasComment("Isdepense")
                .HasColumnName("isdepense");
            entity.Property(e => e.Isfondentraide)
                .HasComment("IsFondEntraide")
                .HasColumnName("isfondentraide");
            entity.Property(e => e.Ispret)
                .HasDefaultValueSql("false")
                .HasComment("Indique si le type d'evenement est un pret")
                .HasColumnName("ispret");
            entity.Property(e => e.Libelle)
                .HasMaxLength(254)
                .HasComment("Libelle du type d'evenement")
                .HasColumnName("libelle");
            entity.Property(e => e.Maxsignature)
                .HasComment("Nombre de signatures autorises pour signer un documents associe a ce type devenement")
                .HasColumnName("maxsignature");
        });

        modelBuilder.Entity<Sortiecaisse>(entity =>
        {
            entity.HasKey(e => e.Idevts).HasName("pk_sortiecaisse");

            entity.ToTable("sortiecaisse", "tontine", tb => tb.HasComment("SortieCaisse"));

            entity.HasIndex(e => new { e.Idannee, e.Iddivision }, "association_11_fk");

            entity.HasIndex(e => e.Idconfig, "association_12_fk");

            entity.HasIndex(e => e.Idinscrit, "association_19_fk");

            entity.HasIndex(e => e.Idevts, "sortiecaisse_pk").IsUnique();

            entity.Property(e => e.Idevts)
                .HasComment("Idevts")
                .HasColumnName("idevts");
            entity.Property(e => e.Dateevts)
                .HasComment("Date effective a laquelle a lieu l'evenement")
                .HasColumnName("dateevts");
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Idconfig)
                .HasComment("Identifiant d'une configuration")
                .HasColumnName("idconfig");
            entity.Property(e => e.Iddivision)
                .HasComment("Identifiant de la division")
                .HasColumnName("iddivision");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.Isclosed)
                .HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)")
                .HasColumnName("isclosed");
            entity.Property(e => e.Montantpercu)
                .HasDefaultValueSql("0")
                .HasComment("Montant percu par le beneficiaire de l'evenement")
                .HasColumnName("montantpercu");
            entity.Property(e => e.Note)
                .HasMaxLength(254)
                .HasComment("Observation generale concernant le deroulement de l'evenement")
                .HasColumnName("note");
            entity.Property(e => e.Visarestants)
                .HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.")
                .HasColumnName("visarestants");

            entity.HasOne(d => d.IdconfigNavigation).WithMany(p => p.Sortiecaisses)
                .HasForeignKey(d => d.Idconfig)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sortieca_associati_annualen");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Sortiecaisses)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sortieca_associati_inscript");

            entity.HasOne(d => d.Id).WithMany(p => p.Sortiecaisses)
                .HasForeignKey(d => new { d.Idannee, d.Iddivision })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sortieca_associati_monthlys");
        });

        modelBuilder.Entity<Visa>(entity =>
        {
            entity.HasKey(e => e.Idvisa).HasName("pk_visas");

            entity.ToTable("visas", "tontine", tb => tb.HasComment("Visas"));

            entity.HasIndex(e => e.Idconfigvisa, "association_15_fk");

            entity.HasIndex(e => e.Idevts, "association_22_fk");

            entity.HasIndex(e => new { e.Idannee, e.Iddivision }, "association_25_fk");

            entity.HasIndex(e => e.Idinscrit, "association_26_fk");

            entity.HasIndex(e => e.Idvisa, "visas_pk").IsUnique();

            entity.Property(e => e.Idvisa)
                .HasComment("Identiifant de la signature")
                .HasColumnName("idvisa");
            entity.Property(e => e.Datesign)
                .HasComment("Date de signature")
                .HasColumnName("datesign");
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Idconfigvisa)
                .HasComment("Identifiant de la configuration de signature")
                .HasColumnName("idconfigvisa");
            entity.Property(e => e.Iddivision)
                .HasComment("Identifiant de la division")
                .HasColumnName("iddivision");
            entity.Property(e => e.Idevts)
                .HasComment("Idevts")
                .HasColumnName("idevts");
            entity.Property(e => e.Idinscrit)
                .HasComment("Identifiant de l'inscription")
                .HasColumnName("idinscrit");
            entity.Property(e => e.Parordre)
                .HasComment("Indique si le document est signe par ordre")
                .HasColumnName("parordre");
            entity.Property(e => e.Receiver)
                .HasComment("Indique si le signataire est le beneficiare")
                .HasColumnName("receiver");

            entity.HasOne(d => d.IdconfigvisaNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.Idconfigvisa)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_configvi");

            entity.HasOne(d => d.IdevtsNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.Idevts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_sortieca");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.Idinscrit)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_inscript");

            entity.HasOne(d => d.Id).WithMany(p => p.Visas)
                .HasForeignKey(d => new { d.Idannee, d.Iddivision })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_monthlys");
        });

        modelBuilder.Entity<Yearlycopyoption>(entity =>
        {
            entity.HasKey(e => e.Idcopyoption).HasName("pk_yearlycopyoption");

            entity.ToTable("yearlycopyoption", "tontine", tb => tb.HasComment("yearlycopyoption"));

            entity.HasIndex(e => e.Idannee, "association_37_fk");

            entity.HasIndex(e => e.Idcopyoption, "yearlycopyoption_pk").IsUnique();

            entity.Property(e => e.Idcopyoption)
                .ValueGeneratedNever()
                .HasComment("Idcopyoption")
                .HasColumnName("idcopyoption");
            entity.Property(e => e.Copyengagements)
                .HasComment("CopyEngagements")
                .HasColumnName("copyengagements");
            entity.Property(e => e.Copymembers)
                .HasComment("CopyMembers")
                .HasColumnName("copymembers");
            entity.Property(e => e.Idannee)
                .HasComment("Identifiant de l'annee")
                .HasColumnName("idannee");
            entity.Property(e => e.Previousyear)
                .HasComment("Previousyear")
                .HasColumnName("previousyear");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Yearlycopyoptions)
                .HasForeignKey(d => d.Idannee)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_yearlyco_associati_core_ann");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
