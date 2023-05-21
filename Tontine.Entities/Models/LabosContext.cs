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

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

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

    public virtual DbSet<DeviceCode> DeviceCodes { get; set; }

    public virtual DbSet<Entreecaisse> Entreecaisses { get; set; }

    public virtual DbSet<Inscription> Inscriptions { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<Modepaie> Modepaies { get; set; }

    public virtual DbSet<Monthlyseance> Monthlyseances { get; set; }

    public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

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

            entity.Property(e => e.Idevts)
                .ValueGeneratedNever()
                .HasComment("Idevts");
            entity.Property(e => e.Libelle).HasComment("Libelle de l'evenement");
            entity.Property(e => e.Lieu).HasComment("Lieu ou se deroule l'evenement");
            entity.Property(e => e.Listemandataires).HasComment("Liste des membres designes pour le deplacement");
            entity.Property(e => e.Montantroute).HasComment("Montant dedie au deplacement des membres");
            entity.Property(e => e.Montanttotalevt).HasComment("Montant statutaire prevu annuellement pourl'evenement");

            entity.HasOne(d => d.IdevtsNavigation).WithOne(p => p.Aide)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_aide_generalis_sortieca");
        });

        modelBuilder.Entity<Annualengagement>(entity =>
        {
            entity.HasKey(e => e.Idconfig).HasName("pk_annualengagements");

            entity.ToTable("annualengagements", "tontine", tb => tb.HasComment("Represente la personnalisation de certaines valeurs appliquees aux types d'eveneents au cours d'une annee"));

            entity.Property(e => e.Idconfig).HasComment("Identifiant d'une configuration");
            entity.Property(e => e.Categorie).HasComment("Numero determinant le type d'evenement/engagement");
            entity.Property(e => e.Commentaire).HasComment("Commentaire");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Idtype).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.Interetmensuel)
                .HasDefaultValueSql("0")
                .HasComment("Taux d'interet mensuel");
            entity.Property(e => e.Isactive)
                .HasDefaultValueSql("true")
                .HasComment("Isactive");
            entity.Property(e => e.Isaide).HasComment("IsAide");
            entity.Property(e => e.Iscotisation).HasComment("Indique si le type represente la cotisation");
            entity.Property(e => e.Isdepense).HasComment("Isdepense");
            entity.Property(e => e.Isfondentraide).HasComment("IsFondEntraide");
            entity.Property(e => e.Ispret)
                .HasDefaultValueSql("false")
                .HasComment("Indique si le type d'evenement est un pret");
            entity.Property(e => e.Montantevt).HasComment("Montant de l'evenement");
            entity.Property(e => e.Montantpenalite).HasComment("Montant de la penalite applicable en cas d'absence aa l'evenement");
            entity.Property(e => e.Montantroute).HasComment("Montant du deplacement d'un membre mandate par l'association");
            entity.Property(e => e.Montanttotal).HasComment("Montant total associe a l'evenement");
            entity.Property(e => e.Nbmandataire).HasComment("Nombre de membres representant l'asociation a l'evenement");
            entity.Property(e => e.Tauxpenalite)
                .HasDefaultValueSql("0")
                .HasComment("Taux d'interet applicable en cas de penalite");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Annualengagements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_annualen_associati_core_ann");

            entity.HasOne(d => d.IdtypeNavigation).WithMany(p => p.Annualengagements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_annualen_associati_rubrique");
        });

        modelBuilder.Entity<Antenne>(entity =>
        {
            entity.HasKey(e => e.Idantenne).HasName("pk_antenne");

            entity.ToTable("antenne", "tontine", tb => tb.HasComment("Represente ue antenne de l'association"));

            entity.Property(e => e.Idantenne).HasComment("Identifiant de l'antenne");
            entity.Property(e => e.Creationdate).HasComment("Date de creation de l'antenne");
            entity.Property(e => e.Libelle).HasComment("Libelle de l'antenne");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles", "tontine");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Bureau>(entity =>
        {
            entity.HasKey(e => e.Idbureau).HasName("pk_bureau");

            entity.ToTable("bureau", "tontine", tb => tb.HasComment("Bureau"));

            entity.Property(e => e.Idbureau).HasComment("Idbureau");
            entity.Property(e => e.Debut).HasComment("Debut");
            entity.Property(e => e.Fin).HasComment("Fin");
            entity.Property(e => e.Libelle).HasComment("Libelle");
            entity.Property(e => e.Nbabstention)
                .HasDefaultValueSql("0")
                .HasComment("NbAbstention");
            entity.Property(e => e.Nbperson)
                .HasDefaultValueSql("0")
                .HasComment("Nbperson");
            entity.Property(e => e.Nbvotes)
                .HasDefaultValueSql("0")
                .HasComment("Nbvotes");
        });

        modelBuilder.Entity<Configvisa>(entity =>
        {
            entity.HasKey(e => e.Idconfigvisa).HasName("pk_configvisas");

            entity.ToTable("configvisas", "tontine", tb => tb.HasComment("Represente l'ensemble des autorisatios de signature de documents au sein de l'association"));

            entity.Property(e => e.Idconfigvisa).HasComment("Identifiant de la configuration de signature");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Idposte).HasComment("Idposte");
            entity.Property(e => e.Idtype).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.Numordre)
                .HasDefaultValueSql("1")
                .HasComment("Numero d'ordre de la signature pour un type de document");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Configvisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_configvi_associati_core_ann");

            entity.HasOne(d => d.IdposteNavigation).WithMany(p => p.Configvisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_configvi_associati_poste");

            entity.HasOne(d => d.IdtypeNavigation).WithMany(p => p.Configvisas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_configvi_associati_rubrique");
        });

        modelBuilder.Entity<CoreAnnee>(entity =>
        {
            entity.HasKey(e => e.Idannee).HasName("pk_core_annee");

            entity.ToTable("core_annee", "tontine", tb => tb.HasComment("Represente une annee "));

            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Datedebut).HasComment("Date de debut de l'annee");
            entity.Property(e => e.Datefin).HasComment("Date de fin de l'annee");
            entity.Property(e => e.Idbureau).HasComment("Idbureau");
            entity.Property(e => e.Isclosed).HasComment("Indique que l'annee et cloturee et ses donnees ne sont plus modifiables");
            entity.Property(e => e.Iscurrent).HasComment("Indique l'annee de travail");
            entity.Property(e => e.Libelle).HasComment("Libelle de l'annee");
            entity.Property(e => e.Nbdivision)
                .HasDefaultValueSql("12")
                .HasComment("Nombre de divisions de l'annee");

            entity.HasOne(d => d.IdbureauNavigation).WithMany(p => p.CoreAnnees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_bureau");
        });

        modelBuilder.Entity<CoreAnnualetabparam>(entity =>
        {
            entity.HasKey(e => e.SchoolparamsId).HasName("pk_core_annualetabparams");

            entity.ToTable("core_annualetabparams", "tontine", tb => tb.HasComment("core_AnnualEtabParams"));

            entity.Property(e => e.SchoolparamsId)
                .ValueGeneratedNever()
                .HasComment("Identifiant de l'entite");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Idetab).HasComment("Idetab");
            entity.Property(e => e.MaxphotoallowLiens).HasComment("Nombre max de liens autorises pour la photo d'une personne");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.CoreAnnualetabparams)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");

            entity.HasOne(d => d.IdetabNavigation).WithMany(p => p.CoreAnnualetabparams)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_eta");
        });

        modelBuilder.Entity<CoreAutorisation>(entity =>
        {
            entity.HasKey(e => e.Idchoix).HasName("pk_core_autorisations");

            entity.ToTable("core_autorisations", "tontine", tb => tb.HasComment("core_Autorisations"));

            entity.Property(e => e.Idchoix).HasComment("Idchoix");
            entity.Property(e => e.Idcmde).HasComment("Idcmde");
            entity.Property(e => e.Idprofil).HasComment("Idprofil");
            entity.Property(e => e.Isactive).HasComment("Isactive");

            entity.HasOne(d => d.IdcmdeNavigation).WithMany(p => p.CoreAutorisations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_com");

            entity.HasOne(d => d.IdprofilNavigation).WithMany(p => p.CoreAutorisations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_pro");
        });

        modelBuilder.Entity<CoreBank>(entity =>
        {
            entity.HasKey(e => e.Idbank).HasName("pk_core_bank");

            entity.ToTable("core_bank", "tontine", tb => tb.HasComment("Etablissement financier"));

            entity.Property(e => e.Idbank).HasComment("Identifiant de la banque");
            entity.Property(e => e.Adresse).HasComment("Adresse postale de la banque");
            entity.Property(e => e.Coderib).HasComment("Numero de compte de l'association chez la baqnue");
            entity.Property(e => e.Email).HasComment("Contact telephonique de la banque No2");
            entity.Property(e => e.Libelle).HasComment("Libelle de la banque");
            entity.Property(e => e.PaysId).HasComment("Identifiant du pays");

            entity.HasOne(d => d.Pays).WithMany(p => p.CoreBanks)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_pay");
        });

        modelBuilder.Entity<CoreBankaccount>(entity =>
        {
            entity.HasKey(e => e.Idcompte).HasName("pk_core_bankaccount");

            entity.ToTable("core_bankaccount", "tontine", tb => tb.HasComment("core_Bankaccount"));

            entity.Property(e => e.Idcompte).HasComment("Idcompte");
            entity.Property(e => e.Idbank).HasComment("Identifiant de la banque");
            entity.Property(e => e.Idetab).HasComment("Idetab");
            entity.Property(e => e.Idperson).HasComment("Idperson");
            entity.Property(e => e.Isactive).HasComment("Isactive");
            entity.Property(e => e.Numcompte).HasComment("Numcompte");
            entity.Property(e => e.Solde).HasComment("solde");

            entity.HasOne(d => d.IdbankNavigation).WithMany(p => p.CoreBankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_ban");

            entity.HasOne(d => d.IdetabNavigation).WithMany(p => p.CoreBankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_eta");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.CoreBankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_per");
        });

        modelBuilder.Entity<CoreCommande>(entity =>
        {
            entity.HasKey(e => e.Idcmde).HasName("pk_core_commandes");

            entity.ToTable("core_commandes", "tontine", tb => tb.HasComment("core_Commandes"));

            entity.Property(e => e.Idcmde).HasComment("Idcmde");
            entity.Property(e => e.Libelle).HasComment("Libelle");
        });

        modelBuilder.Entity<CoreEtablissement>(entity =>
        {
            entity.HasKey(e => e.Idetab).HasName("pk_core_etablissement");

            entity.ToTable("core_etablissement", "tontine", tb => tb.HasComment("core_Etablissement"));

            entity.Property(e => e.Idetab).HasComment("Idetab");
            entity.Property(e => e.Agrement).HasComment("Agrement");
            entity.Property(e => e.Dossierfiscale).HasComment("Dossierfiscale");
            entity.Property(e => e.Libelle).HasComment("Libelle");
            entity.Property(e => e.PaysId).HasComment("Identifiant du pays");

            entity.HasOne(d => d.Pays).WithMany(p => p.CoreEtablissements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_eta_associati_core_pay");
        });

        modelBuilder.Entity<CoreLangue>(entity =>
        {
            entity.HasKey(e => e.LangueId).HasName("pk_core_langue");

            entity.ToTable("core_langue", "tontine", tb => tb.HasComment("core_Langue"));

            entity.Property(e => e.LangueId).HasComment("Identifiant de la langue");
            entity.Property(e => e.Isactive).HasComment("isactive");
            entity.Property(e => e.Isdefault).HasComment("Indique la langue par defaut");
            entity.Property(e => e.Isocode).HasComment("Code ISO de la langue");
            entity.Property(e => e.Libelle).HasComment("Libelle de la langue");
        });

        modelBuilder.Entity<CorePay>(entity =>
        {
            entity.HasKey(e => e.PaysId).HasName("pk_core_pays");

            entity.ToTable("core_pays", "tontine", tb => tb.HasComment("core_Pays"));

            entity.Property(e => e.PaysId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du pays");
            entity.Property(e => e.Code).HasComment("Code (2 caracteres) ISO du pays");
            entity.Property(e => e.Devisepays).HasComment("Devise du pays");
            entity.Property(e => e.Libelle).HasComment("Nom du pays");
            entity.Property(e => e.Phonecode).HasComment("Code telephoniquedu pays");
        });

        modelBuilder.Entity<CorePerson>(entity =>
        {
            entity.HasKey(e => e.Idperson).HasName("pk_core_person");

            entity.ToTable("core_person", "tontine", tb => tb.HasComment("Represente un membre de la reunion"));

            entity.Property(e => e.Idperson).HasComment("Idperson");
            entity.Property(e => e.Adresse).HasComment("Adresse");
            entity.Property(e => e.Anneepromo).HasComment("Anneepromo");
            entity.Property(e => e.Dateadhesion).HasComment("Dateadhesion");
            entity.Property(e => e.Datenais).HasComment("Datenais");
            entity.Property(e => e.Email).HasComment("Email");
            entity.Property(e => e.Isvisible).HasComment("Cette personne represente un utilisateur systeme");
            entity.Property(e => e.Lieunais).HasComment("lieunais");
            entity.Property(e => e.Nocni).HasComment("Nocni");
            entity.Property(e => e.Nom).HasComment("Nom");
            entity.Property(e => e.PaysId).HasComment("Identifiant du pays");
            entity.Property(e => e.Prenom)
                .HasDefaultValueSql("''::character varying")
                .HasComment("Prenom");
            entity.Property(e => e.Sexe).HasComment("Sexe");

            entity.HasOne(d => d.Pays).WithMany(p => p.CorePeople)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_pay");
        });

        modelBuilder.Entity<CorePhonenumber>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("pk_core_phonenumber");

            entity.ToTable("core_phonenumber", "tontine", tb => tb.HasComment("core_Phonenumber"));

            entity.Property(e => e.PhoneId)
                .ValueGeneratedNever()
                .HasComment("Identifiant du numero de telephone");
            entity.Property(e => e.Idbank).HasComment("Identifiant de la banque");
            entity.Property(e => e.Idperson).HasComment("Idperson");
            entity.Property(e => e.Isdefaut).HasComment("Represente le numero par defaut");
            entity.Property(e => e.Numphone).HasComment("Numero telephone");
            entity.Property(e => e.PaysId).HasComment("Identifiant du pays");

            entity.HasOne(d => d.IdbankNavigation).WithMany(p => p.CorePhonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_ban");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.CorePhonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");

            entity.HasOne(d => d.Pays).WithMany(p => p.CorePhonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_pay");
        });

        modelBuilder.Entity<CorePhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("pk_core_photos");

            entity.ToTable("core_photos", "tontine", tb => tb.HasComment("core_Photos"));

            entity.Property(e => e.PhotoId)
                .ValueGeneratedNever()
                .HasComment("Identifiant d'une photo");
            entity.Property(e => e.Fileext).HasComment("Extension du fichier");
            entity.Property(e => e.Filename).HasComment("Filename");
            entity.Property(e => e.Filepath).HasComment("Chemin d'acces au fichier");
            entity.Property(e => e.Idetab).HasComment("Idetab");
            entity.Property(e => e.Idperson).HasComment("Idperson");
            entity.Property(e => e.Image).HasComment("Image");
            entity.Property(e => e.Issignature).HasComment("Represente une signature");
            entity.Property(e => e.MaxallowLiens).HasComment("Nombre max de liens autorises");
            entity.Property(e => e.NbactualLiens).HasComment("Nombre de liens actuels");

            entity.HasOne(d => d.IdetabNavigation).WithMany(p => p.CorePhotos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_eta");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.CorePhotos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<CoreProfil>(entity =>
        {
            entity.HasKey(e => e.Idprofil).HasName("pk_core_profil");

            entity.ToTable("core_profil", "tontine", tb => tb.HasComment("core_Profil"));

            entity.Property(e => e.Idprofil).HasComment("Idprofil");
            entity.Property(e => e.Candelete).HasComment("Candelete");
            entity.Property(e => e.Libelle).HasComment("Libelle");
        });

        modelBuilder.Entity<CoreUser>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("pk_core_user");

            entity.ToTable("core_user", "tontine", tb => tb.HasComment("core_User"));

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasComment("UserId");
            entity.Property(e => e.Expirationdate).HasComment("Date d'expiration");
            entity.Property(e => e.Idprofil).HasComment("Idprofil");
            entity.Property(e => e.Isactif).HasComment("Compte actif");
            entity.Property(e => e.LangueId).HasComment("Identifiant de la langue");
            entity.Property(e => e.Lastconnexion).HasComment("Lastconnexion");
            entity.Property(e => e.Passwd).HasComment("Mot de passe");
            entity.Property(e => e.Username).HasComment("Nom d'utilisateur");

            entity.HasOne(d => d.IdprofilNavigation).WithMany(p => p.CoreUsers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_pro");

            entity.HasOne(d => d.Langue).WithMany(p => p.CoreUsers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_lan");
        });

        modelBuilder.Entity<Entreecaisse>(entity =>
        {
            entity.HasKey(e => e.Idoperation).HasName("pk_entreecaisse");

            entity.ToTable("entreecaisse", "tontine", tb => tb.HasComment("Entreecaisse"));

            entity.Property(e => e.Idoperation).HasComment("Idoperation");
            entity.Property(e => e.Cumulverse).HasComment("CumulVerse");
            entity.Property(e => e.Idconfig).HasComment("Identifiant d'une configuration");
            entity.Property(e => e.Idevts).HasComment("Idevts");
            entity.Property(e => e.Idpresence).HasComment("Identiifant de la signature");
            entity.Property(e => e.Montantverse).HasComment("MontantVerse");
            entity.Property(e => e.Reste).HasComment("Reste");

            entity.HasOne(d => d.IdconfigNavigation).WithMany(p => p.Entreecaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entreeca_associati_annualen");

            entity.HasOne(d => d.IdevtsNavigation).WithMany(p => p.Entreecaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entreeca_associati_sortieca");

            entity.HasOne(d => d.IdpresenceNavigation).WithMany(p => p.Entreecaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_entreeca_associati_presence");
        });

        modelBuilder.Entity<Inscription>(entity =>
        {
            entity.HasKey(e => e.Idinscrit).HasName("pk_inscription");

            entity.ToTable("inscription", "tontine", tb => tb.HasComment("Represente le renoouvellement de la presence d'un membre au sein de 'association au cours d'une annee"));

            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.Cumuldettes)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumulees applicable la nouvelle annee");
            entity.Property(e => e.Cumulpenalites)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumules de penelites applicable la nouvelle annee");
            entity.Property(e => e.Dateinscrit).HasComment("Date de l'inscription");
            entity.Property(e => e.Datesuspension).HasComment("Date de derniere suspension d'un membre");
            entity.Property(e => e.Endette).HasComment("Indique si le membre est endette");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Idantenne).HasComment("Identifiant de l'antenne");
            entity.Property(e => e.Idperson).HasComment("Idperson");
            entity.Property(e => e.Idposte).HasComment("Idposte");
            entity.Property(e => e.Isactive).HasComment("Statut actif ou non d'un membre");
            entity.Property(e => e.Nocni).HasComment("Nocni");
            entity.Property(e => e.Soldedebut).HasComment("SoldeDebut");
            entity.Property(e => e.Soldefin)
                .HasDefaultValueSql("0")
                .HasComment("SoldeFin");
            entity.Property(e => e.Tauxcotisation).HasComment("Report a nouveau du membre pour la nouvelle annee");
            entity.Property(e => e.Totalverse).HasComment("Totalverse");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Inscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_core_ann");

            entity.HasOne(d => d.IdantenneNavigation).WithMany(p => p.Inscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_antenne");

            entity.HasOne(d => d.IdpersonNavigation).WithMany(p => p.Inscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_core_per");

            entity.HasOne(d => d.IdposteNavigation).WithMany(p => p.Inscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inscript_associati_poste");
        });

        modelBuilder.Entity<Modepaie>(entity =>
        {
            entity.HasKey(e => e.Idmode).HasName("pk_modepaie");

            entity.ToTable("modepaie", "tontine", tb => tb.HasComment("Mode de paiement utilise par un membre"));

            entity.Property(e => e.Idmode).HasComment("Identifiant du mode de paiement");
            entity.Property(e => e.Iscash).HasComment("Indique si le mode represnte le CASH");
            entity.Property(e => e.Libelle).HasComment("Libelle du mode de paiement");
        });

        modelBuilder.Entity<Monthlyseance>(entity =>
        {
            entity.HasKey(e => new { e.Idannee, e.Iddivision }).HasName("pk_monthlyseance");

            entity.ToTable("monthlyseance", "tontine", tb => tb.HasComment("Represente le decoupage mensuel de l'annee"));

            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Iddivision)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de la division");
            entity.Property(e => e.Dateseance).HasComment("Date de debut de la division");
            entity.Property(e => e.Heuredebut).HasComment("HeureDebut");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.Libelle).HasComment("Libelle de la division");
            entity.Property(e => e.Montantpercu).HasComment("MontantPercu");
            entity.Property(e => e.Numordre).HasComment("Numero d'ordre de la division");
            entity.Property(e => e.Totalcotise).HasComment("TotalCotise");
            entity.Property(e => e.Totalsortie).HasComment("TotalSortie");
            entity.Property(e => e.Visarestants).HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Monthlyseances)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_monthlys_associati_core_ann");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Monthlyseances)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_monthlys_associati_inscript");
        });

        modelBuilder.Entity<Poste>(entity =>
        {
            entity.HasKey(e => e.Idposte).HasName("pk_poste");

            entity.ToTable("poste", "tontine", tb => tb.HasComment("Poste occupe par un membre de l'association"));

            entity.Property(e => e.Idposte).HasComment("Idposte");
            entity.Property(e => e.Iscc).HasComment("Iscc");
            entity.Property(e => e.Ismembre).HasComment("Ismembre");
            entity.Property(e => e.Ispresident).HasComment("Ispresident");
            entity.Property(e => e.Issg).HasComment("Issg");
            entity.Property(e => e.Issga).HasComment("Issga");
            entity.Property(e => e.Istresorier).HasComment("Istresorier");
            entity.Property(e => e.Libelle).HasComment("Libelle");
        });

        modelBuilder.Entity<Presence>(entity =>
        {
            entity.HasKey(e => e.Idpresence).HasName("pk_presence");

            entity.ToTable("presence", "tontine", tb => tb.HasComment("Represente l'etat des presences des membres a une seance de reunion et l'ensemble des signatures apposees par les membres (beneficiaire et bureau) de l'association sur un document"));

            entity.Property(e => e.Idpresence).HasComment("Identiifant de la signature");
            entity.Property(e => e.Codeop).HasComment("Indique le tupe d'operation (Entree ou Sortie de caisse)");
            entity.Property(e => e.Cumuldetteapres)
                .HasDefaultValueSql("0")
                .HasComment("CumulDetteApres");
            entity.Property(e => e.Dateop).HasComment("Dateop");
            entity.Property(e => e.Globalverse)
                .HasDefaultValueSql("0")
                .HasComment("globalverse");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Idcompte).HasComment("Idcompte");
            entity.Property(e => e.Iddivision).HasComment("Identifiant de la division");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.Idmode).HasComment("Identifiant du mode de paiement");
            entity.Property(e => e.Isabsent).HasComment("isabsent");
            entity.Property(e => e.Numbordero).HasComment("Numbordero");
            entity.Property(e => e.Soldedebut)
                .HasDefaultValueSql("0")
                .HasComment("Soldedebut");
            entity.Property(e => e.Soldefin)
                .HasDefaultValueSql("0")
                .HasComment("Soldefin");

            entity.HasOne(d => d.IdcompteNavigation).WithMany(p => p.Presences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_core_ban");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Presences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_inscript");

            entity.HasOne(d => d.IdmodeNavigation).WithMany(p => p.Presences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_modepaie");

            entity.HasOne(d => d.Id).WithMany(p => p.Presences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_presence_associati_monthlys");
        });

        modelBuilder.Entity<Pret>(entity =>
        {
            entity.HasKey(e => e.Idevts).HasName("pk_pret");

            entity.ToTable("pret", "tontine", tb => tb.HasComment("Pret"));

            entity.Property(e => e.Idevts)
                .ValueGeneratedNever()
                .HasComment("Idevts");
            entity.Property(e => e.Dureepret).HasComment("Duree du pret en nombre de mois");
            entity.Property(e => e.Ispret).HasComment("Indique si l'evenement est un pret");
            entity.Property(e => e.Montantinteret).HasComment("Montant de l'interet");
            entity.Property(e => e.Montantpenalite).HasComment("Montant applicable en cas de penalite sur les interets ou en cas d'absence de cotisation");

            entity.HasOne(d => d.IdevtsNavigation).WithOne(p => p.Pret)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_pret_generalis_sortieca");
        });

        modelBuilder.Entity<Rubrique>(entity =>
        {
            entity.HasKey(e => e.Idtype).HasName("pk_rubrique");

            entity.ToTable("rubrique", "tontine", tb => tb.HasComment("Represente un type d'evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc."));

            entity.Property(e => e.Idtype).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.Candelete).HasComment("CanDelete");
            entity.Property(e => e.Isaide).HasComment("IsAide");
            entity.Property(e => e.Iscotisation).HasComment("Indique si le type represente la cotisation");
            entity.Property(e => e.Isdepense).HasComment("Isdepense");
            entity.Property(e => e.Isfondentraide).HasComment("IsFondEntraide");
            entity.Property(e => e.Ispret)
                .HasDefaultValueSql("false")
                .HasComment("Indique si le type d'evenement est un pret");
            entity.Property(e => e.Libelle).HasComment("Libelle du type d'evenement");
            entity.Property(e => e.Maxsignature).HasComment("Nombre de signatures autorises pour signer un documents associe a ce type devenement");
        });

        modelBuilder.Entity<Sortiecaisse>(entity =>
        {
            entity.HasKey(e => e.Idevts).HasName("pk_sortiecaisse");

            entity.ToTable("sortiecaisse", "tontine", tb => tb.HasComment("SortieCaisse"));

            entity.Property(e => e.Idevts).HasComment("Idevts");
            entity.Property(e => e.Dateevts).HasComment("Date effective a laquelle a lieu l'evenement");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Idconfig).HasComment("Identifiant d'une configuration");
            entity.Property(e => e.Iddivision).HasComment("Identifiant de la division");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.Isclosed).HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)");
            entity.Property(e => e.Montantpercu)
                .HasDefaultValueSql("0")
                .HasComment("Montant percu par le beneficiaire de l'evenement");
            entity.Property(e => e.Note).HasComment("Observation generale concernant le deroulement de l'evenement");
            entity.Property(e => e.Visarestants).HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.");

            entity.HasOne(d => d.IdconfigNavigation).WithMany(p => p.Sortiecaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sortieca_associati_annualen");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Sortiecaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sortieca_associati_inscript");

            entity.HasOne(d => d.Id).WithMany(p => p.Sortiecaisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sortieca_associati_monthlys");
        });

        modelBuilder.Entity<Visa>(entity =>
        {
            entity.HasKey(e => e.Idvisa).HasName("pk_visas");

            entity.ToTable("visas", "tontine", tb => tb.HasComment("Visas"));

            entity.Property(e => e.Idvisa).HasComment("Identiifant de la signature");
            entity.Property(e => e.Datesign).HasComment("Date de signature");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Idconfigvisa).HasComment("Identifiant de la configuration de signature");
            entity.Property(e => e.Iddivision).HasComment("Identifiant de la division");
            entity.Property(e => e.Idevts).HasComment("Idevts");
            entity.Property(e => e.Idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.Parordre).HasComment("Indique si le document est signe par ordre");
            entity.Property(e => e.Receiver).HasComment("Indique si le signataire est le beneficiare");

            entity.HasOne(d => d.IdconfigvisaNavigation).WithMany(p => p.Visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_configvi");

            entity.HasOne(d => d.IdevtsNavigation).WithMany(p => p.Visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_sortieca");

            entity.HasOne(d => d.IdinscritNavigation).WithMany(p => p.Visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_inscript");

            entity.HasOne(d => d.Id).WithMany(p => p.Visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_visas_associati_monthlys");
        });

        modelBuilder.Entity<Yearlycopyoption>(entity =>
        {
            entity.HasKey(e => e.Idcopyoption).HasName("pk_yearlycopyoption");

            entity.ToTable("yearlycopyoption", "tontine", tb => tb.HasComment("yearlycopyoption"));

            entity.Property(e => e.Idcopyoption)
                .ValueGeneratedNever()
                .HasComment("Idcopyoption");
            entity.Property(e => e.Copyengagements).HasComment("CopyEngagements");
            entity.Property(e => e.Copymembers).HasComment("CopyMembers");
            entity.Property(e => e.Idannee).HasComment("Identifiant de l'annee");
            entity.Property(e => e.Previousyear).HasComment("Previousyear");

            entity.HasOne(d => d.IdanneeNavigation).WithMany(p => p.Yearlycopyoptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_yearlyco_associati_core_ann");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
