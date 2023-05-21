using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

public partial class labosContext : DbContext
{
    public labosContext(DbContextOptions<labosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<core_annee> core_annees { get; set; }

    public virtual DbSet<core_annual_setting> core_annual_settings { get; set; }

    public virtual DbSet<core_autorisation> core_autorisations { get; set; }

    public virtual DbSet<core_bank> core_banks { get; set; }

    public virtual DbSet<core_bankaccount> core_bankaccounts { get; set; }

    public virtual DbSet<core_commande> core_commandes { get; set; }

    public virtual DbSet<core_country> core_countries { get; set; }

    public virtual DbSet<core_etablissement> core_etablissements { get; set; }

    public virtual DbSet<core_frequence_division> core_frequence_divisions { get; set; }

    public virtual DbSet<core_langue> core_langues { get; set; }

    public virtual DbSet<core_modepaie> core_modepaies { get; set; }

    public virtual DbSet<core_person> core_people { get; set; }

    public virtual DbSet<core_phonenumber> core_phonenumbers { get; set; }

    public virtual DbSet<core_photo> core_photos { get; set; }

    public virtual DbSet<core_profil> core_profils { get; set; }

    public virtual DbSet<core_subdivision> core_subdivisions { get; set; }

    public virtual DbSet<core_user> core_users { get; set; }

    public virtual DbSet<meet_antenne> meet_antennes { get; set; }

    public virtual DbSet<meet_bureau> meet_bureaus { get; set; }

    public virtual DbSet<meet_config_visa> meet_config_visas { get; set; }

    public virtual DbSet<meet_engagement> meet_engagements { get; set; }

    public virtual DbSet<meet_entree_caisse> meet_entree_caisses { get; set; }

    public virtual DbSet<meet_inscription> meet_inscriptions { get; set; }

    public virtual DbSet<meet_max_allow_signature> meet_max_allow_signatures { get; set; }

    public virtual DbSet<meet_membre_bureau> meet_membre_bureaus { get; set; }

    public virtual DbSet<meet_ordre_passage> meet_ordre_passages { get; set; }

    public virtual DbSet<meet_poste> meet_postes { get; set; }

    public virtual DbSet<meet_preference> meet_preferences { get; set; }

    public virtual DbSet<meet_presence> meet_presences { get; set; }

    public virtual DbSet<meet_pret> meet_prets { get; set; }

    public virtual DbSet<meet_rubrique> meet_rubriques { get; set; }

    public virtual DbSet<meet_seance> meet_seances { get; set; }

    public virtual DbSet<meet_sortie_caisse> meet_sortie_caisses { get; set; }

    public virtual DbSet<meet_suspension_membre> meet_suspension_membres { get; set; }

    public virtual DbSet<meet_type_rubrique> meet_type_rubriques { get; set; }

    public virtual DbSet<meet_visa> meet_visas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<core_annee>(entity =>
        {
            entity.HasKey(e => e.annee_id).HasName("pk_core_annee");

            entity.ToTable("core_annee", "tontine_v14", tb => tb.HasComment("Represente une annee "));

            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.bureau_id).HasComment("Bureau_id");
            entity.Property(e => e.copy_data_from_previous).HasComment("Copy_data_from_previous");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.datedebut).HasComment("Date de debut de l'annee");
            entity.Property(e => e.datefin).HasComment("Date de fin de l'annee");
            entity.Property(e => e.frequence_id).HasComment("Frequence_id");
            entity.Property(e => e.is_closed).HasComment("Indique que l'annee et cloturee et ses donnees ne sont plus modifiables");
            entity.Property(e => e.is_current).HasComment("Indique l'annee de travail");
            entity.Property(e => e.libelle).HasComment("Libelle de l'annee");
            entity.Property(e => e.nbdivision)
                .HasDefaultValueSql("12")
                .HasComment("Nombre de divisions de l'annee");
            entity.Property(e => e.previous_year_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.bureau).WithMany(p => p.core_annees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_meet_bur");

            entity.HasOne(d => d.frequence).WithMany(p => p.core_annees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_fre");

            entity.HasOne(d => d.previous_year).WithMany(p => p.Inverseprevious_year)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");
        });

        modelBuilder.Entity<core_annual_setting>(entity =>
        {
            entity.HasKey(e => e.setting_id).HasName("pk_core_annual_setting");

            entity.ToTable("core_annual_setting", "tontine_v14", tb => tb.HasComment("core_Annual_setting"));

            entity.Property(e => e.setting_id).HasComment("Identifiant de l'entite");
            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.copyengagements).HasComment("CopyEngagements");
            entity.Property(e => e.copymembers).HasComment("CopyMembers");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.max_allow_photo_liens).HasComment("Nombre max de liens autorises pour la photo d'une personne");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.annee).WithMany(p => p.core_annual_settings)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_ann");

            entity.HasOne(d => d.etab).WithMany(p => p.core_annual_settings)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ann_associati_core_eta");
        });

        modelBuilder.Entity<core_autorisation>(entity =>
        {
            entity.HasKey(e => e.choix_id).HasName("pk_core_autorisations");

            entity.ToTable("core_autorisations", "tontine_v14", tb => tb.HasComment("core_Autorisations"));

            entity.Property(e => e.choix_id).HasComment("Choix_id");
            entity.Property(e => e.idcmde).HasComment("Idcmde");
            entity.Property(e => e.is_active).HasComment("Is_active");
            entity.Property(e => e.profil_id).HasComment("Profil_id");

            entity.HasOne(d => d.idcmdeNavigation).WithMany(p => p.core_autorisations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_com");

            entity.HasOne(d => d.profil).WithMany(p => p.core_autorisations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_aut_associati_core_pro");
        });

        modelBuilder.Entity<core_bank>(entity =>
        {
            entity.HasKey(e => e.bank_id).HasName("pk_core_bank");

            entity.ToTable("core_bank", "tontine_v14", tb => tb.HasComment("Etablissement financier"));

            entity.Property(e => e.bank_id).HasComment("Identifiant de la banque");
            entity.Property(e => e.adresse).HasComment("Adresse postale de la banque");
            entity.Property(e => e.coderib).HasComment("Numero de compte de l'association chez la baqnue");
            entity.Property(e => e.country_id).HasComment("Identifiant du pays");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.email).HasComment("Contact telephonique de la banque No2");
            entity.Property(e => e.libelle).HasComment("Libelle de la banque");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.country).WithMany(p => p.core_banks)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_cou");
        });

        modelBuilder.Entity<core_bankaccount>(entity =>
        {
            entity.HasKey(e => e.account_id).HasName("pk_core_bankaccount");

            entity.ToTable("core_bankaccount", "tontine_v14", tb => tb.HasComment("core_Bankaccount"));

            entity.Property(e => e.account_id).HasComment("Account_id");
            entity.Property(e => e.bank_id).HasComment("Identifiant de la banque");
            entity.Property(e => e.compte_no).HasComment("Compte_no");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.is_active).HasComment("Is_active");
            entity.Property(e => e.person_id).HasComment("Person_id");
            entity.Property(e => e.solde).HasComment("Solde");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.bank).WithMany(p => p.core_bankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_ban");

            entity.HasOne(d => d.etab).WithMany(p => p.core_bankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_eta");

            entity.HasOne(d => d.person).WithMany(p => p.core_bankaccounts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_ban_associati_core_per");
        });

        modelBuilder.Entity<core_commande>(entity =>
        {
            entity.HasKey(e => e.idcmde).HasName("pk_core_commandes");

            entity.ToTable("core_commandes", "tontine_v14", tb => tb.HasComment("core_Commandes"));

            entity.Property(e => e.idcmde).HasComment("Idcmde");
            entity.Property(e => e.libelle).HasComment("Libelle");
        });

        modelBuilder.Entity<core_country>(entity =>
        {
            entity.HasKey(e => e.country_id).HasName("pk_core_country");

            entity.ToTable("core_country", "tontine_v14", tb => tb.HasComment("core_country"));

            entity.Property(e => e.country_id)
                .ValueGeneratedNever()
                .HasComment("Identifiant du pays");
            entity.Property(e => e.code_iso2).HasComment("Code (2 caracteres) ISO du pays");
            entity.Property(e => e.code_iso3).HasComment("Code (3 caracteres) ISO du pays");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.devise).HasComment("Devise du pays");
            entity.Property(e => e.libelle).HasComment("Nom du pays");
            entity.Property(e => e.phone_code).HasComment("Code telephonique du pays");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");
        });

        modelBuilder.Entity<core_etablissement>(entity =>
        {
            entity.HasKey(e => e.etab_id).HasName("pk_core_etablissement");

            entity.ToTable("core_etablissement", "tontine_v14", tb => tb.HasComment("core_Etablissement"));

            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.adresse).HasComment("Adresse");
            entity.Property(e => e.conn_string).HasComment("Conn_string");
            entity.Property(e => e.country_id).HasComment("Identifiant du pays");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.creationdate).HasComment("Creationdate");
            entity.Property(e => e.database_name).HasComment("Database_name");
            entity.Property(e => e.deployed_url).HasComment("Deployed_Url");
            entity.Property(e => e.enable_multi_antenne).HasComment("Enable_multi_antenne");
            entity.Property(e => e.libelle).HasComment("Libelle");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.country).WithMany(p => p.core_etablissements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_eta_associati_core_cou");
        });

        modelBuilder.Entity<core_frequence_division>(entity =>
        {
            entity.HasKey(e => e.frequence_id).HasName("pk_core_frequence_division");

            entity.ToTable("core_frequence_division", "tontine_v14", tb => tb.HasComment("core_Frequence_Division"));

            entity.Property(e => e.frequence_id).HasComment("Frequence_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.libelle).HasComment("Libelle");
            entity.Property(e => e.nb_days).HasComment("Nb_Days");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");
        });

        modelBuilder.Entity<core_langue>(entity =>
        {
            entity.HasKey(e => e.langue_id).HasName("pk_core_langue");

            entity.ToTable("core_langue", "tontine_v14", tb => tb.HasComment("core_Langue"));

            entity.Property(e => e.langue_id).HasComment("Identifiant de la langue");
            entity.Property(e => e.is_active).HasComment("Isactive");
            entity.Property(e => e.is_default).HasComment("Indique la langue par defaut");
            entity.Property(e => e.isocode).HasComment("Code ISO de la langue");
            entity.Property(e => e.libelle).HasComment("Libelle de la langue");
        });

        modelBuilder.Entity<core_modepaie>(entity =>
        {
            entity.HasKey(e => e.modepaie_id).HasName("pk_core_modepaie");

            entity.ToTable("core_modepaie", "tontine_v14", tb => tb.HasComment("Mode de paiement utilise par un membre"));

            entity.Property(e => e.modepaie_id).HasComment("Identifiant du mode de paiement");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.is_cash).HasComment("Indique si le mode represnte le CASH");
            entity.Property(e => e.libelle).HasComment("Libelle du mode de paiement");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");
        });

        modelBuilder.Entity<core_person>(entity =>
        {
            entity.HasKey(e => e.person_id).HasName("pk_core_person");

            entity.ToTable("core_person", "tontine_v14", tb => tb.HasComment("Represente un membre de la reunion"));

            entity.Property(e => e.person_id).HasComment("Person_id");
            entity.Property(e => e.adhesion_date).HasComment("Adhesion_date");
            entity.Property(e => e.adresse).HasComment("Adresse");
            entity.Property(e => e.annee_promo).HasComment("Annee_promo");
            entity.Property(e => e.cni_expire_date).HasComment("CNI_Expire_date");
            entity.Property(e => e.country_id).HasComment("Identifiant du pays");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.datenais).HasComment("Datenais");
            entity.Property(e => e.email).HasComment("Email");
            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.is_active).HasComment("Indique si le membre est suspendu ou pas");
            entity.Property(e => e.is_visible)
                .HasDefaultValueSql("true")
                .HasComment("Cette personne represente un utilisateur systeme");
            entity.Property(e => e.lieunais).HasComment("lieunais");
            entity.Property(e => e.nocni).HasComment("Nocni");
            entity.Property(e => e.nom).HasComment("Nom");
            entity.Property(e => e.prenom)
                .HasDefaultValueSql("''::character varying")
                .HasComment("Prenom");
            entity.Property(e => e.sexe).HasComment("Sexe");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.country).WithMany(p => p.core_people)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_cou");

            entity.HasOne(d => d.etab).WithMany(p => p.core_people)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_per_associati_core_eta");
        });

        modelBuilder.Entity<core_phonenumber>(entity =>
        {
            entity.HasKey(e => e.phone_id).HasName("pk_core_phonenumber");

            entity.ToTable("core_phonenumber", "tontine_v14", tb => tb.HasComment("core_Phonenumber"));

            entity.Property(e => e.phone_id)
                .ValueGeneratedNever()
                .HasComment("Identifiant du numero de telephone");
            entity.Property(e => e.bank_id).HasComment("Identifiant de la banque");
            entity.Property(e => e.country_id).HasComment("Identifiant du pays");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.is_defaut).HasComment("Represente le numero par defaut");
            entity.Property(e => e.person_id).HasComment("Person_id");
            entity.Property(e => e.phone_no).HasComment("Numero telephone");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.bank).WithMany(p => p.core_phonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_ban");

            entity.HasOne(d => d.country).WithMany(p => p.core_phonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_cou");

            entity.HasOne(d => d.person).WithMany(p => p.core_phonenumbers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<core_photo>(entity =>
        {
            entity.HasKey(e => e.photo_id).HasName("pk_core_photos");

            entity.ToTable("core_photos", "tontine_v14", tb => tb.HasComment("core_Photos"));

            entity.Property(e => e.photo_id)
                .ValueGeneratedNever()
                .HasComment("Identifiant d'une photo");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.fileext).HasComment("Extension du fichier");
            entity.Property(e => e.filename).HasComment("Filename");
            entity.Property(e => e.filepath).HasComment("Chemin d'acces au fichier");
            entity.Property(e => e.image).HasComment("Image");
            entity.Property(e => e.is_signature).HasComment("Represente une signature");
            entity.Property(e => e.max_allow_liens).HasComment("Nombre max de liens autorises");
            entity.Property(e => e.nb_actual_liens).HasComment("Nombre de liens actuels");
            entity.Property(e => e.person_id).HasComment("Person_id");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.etab).WithMany(p => p.core_photos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_eta");

            entity.HasOne(d => d.person).WithMany(p => p.core_photos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_pho_associati_core_per");
        });

        modelBuilder.Entity<core_profil>(entity =>
        {
            entity.HasKey(e => e.profil_id).HasName("pk_core_profil");

            entity.ToTable("core_profil", "tontine_v14", tb => tb.HasComment("core_Profil"));

            entity.Property(e => e.profil_id).HasComment("Profil_id");
            entity.Property(e => e.candelete).HasComment("Candelete");
            entity.Property(e => e.libelle).HasComment("Libelle");
        });

        modelBuilder.Entity<core_subdivision>(entity =>
        {
            entity.HasKey(e => new { e.annee_id, e.division_id }).HasName("pk_core_subdivision");

            entity.ToTable("core_subdivision", "tontine_v14", tb => tb.HasComment("Represente le decoupage mensuel de l'annee"));

            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.division_id)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de la division");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.libelle).HasComment("Libelle de la division");
            entity.Property(e => e.month_date).HasComment("Date de debut de la division");
            entity.Property(e => e.month_day).HasComment("Jour du mois ou aura lieu la reunion");
            entity.Property(e => e.numordre).HasComment("Numero d'ordre de la division");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.annee).WithMany(p => p.core_subdivisions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_sub_associati_core_ann");
        });

        modelBuilder.Entity<core_user>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("pk_core_user");

            entity.ToTable("core_user", "tontine_v14", tb => tb.HasComment("core_User"));

            entity.Property(e => e.user_id)
                .ValueGeneratedNever()
                .HasComment("User_Id");
            entity.Property(e => e.expiration_date).HasComment("Date d'expiration");
            entity.Property(e => e.is_actif).HasComment("Compte actif");
            entity.Property(e => e.langue_id).HasComment("Identifiant de la langue");
            entity.Property(e => e.last_connexion).HasComment("Last_connexion");
            entity.Property(e => e.passwd).HasComment("Mot de passe");
            entity.Property(e => e.profil_id).HasComment("Profil_id");
            entity.Property(e => e.username).HasComment("Nom d'utilisateur");

            entity.HasOne(d => d.langue).WithMany(p => p.core_users)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_lan");

            entity.HasOne(d => d.profil).WithMany(p => p.core_users)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_core_use_associati_core_pro");
        });

        modelBuilder.Entity<meet_antenne>(entity =>
        {
            entity.HasKey(e => new { e.etab_id, e.antenne_id }).HasName("pk_meet_antenne");

            entity.ToTable("meet_antenne", "tontine_v14", tb => tb.HasComment("Represente ue antenne de l'association"));

            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.antenne_id)
                .ValueGeneratedOnAdd()
                .HasComment("Identifiant de l'antenne");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.creationdate).HasComment("Date de creation de l'antenne");
            entity.Property(e => e.libelle).HasComment("Libelle de l'antenne");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.etab).WithMany(p => p.meet_antennes)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ant_associati_core_eta");
        });

        modelBuilder.Entity<meet_bureau>(entity =>
        {
            entity.HasKey(e => e.bureau_id).HasName("pk_meet_bureau");

            entity.ToTable("meet_bureau", "tontine_v14", tb => tb.HasComment("Meet_Bureau"));

            entity.Property(e => e.bureau_id).HasComment("Bureau_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.debut).HasComment("Debut");
            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.fin).HasComment("Fin");
            entity.Property(e => e.libelle).HasComment("Libelle");
            entity.Property(e => e.nbabstention).HasComment("NbAbstention");
            entity.Property(e => e.nbperson).HasComment("Nbperson");
            entity.Property(e => e.nbvotes).HasComment("Nbvotes");
            entity.Property(e => e.resumevote).HasComment("Resumevote");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.etab).WithMany(p => p.meet_bureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_bur_associati_core_eta");
        });

        modelBuilder.Entity<meet_config_visa>(entity =>
        {
            entity.HasKey(e => e.configvisa_id).HasName("pk_meet_config_visas");

            entity.ToTable("meet_config_visas", "tontine_v14", tb => tb.HasComment("Represente l'ensemble des autorisatios de signature de documents au sein de l'association"));

            entity.Property(e => e.configvisa_id).HasComment("Identifiant de la configuration de signature");
            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.numordre)
                .HasDefaultValueSql("1")
                .HasComment("Numero d'ordre de la signature pour un type de document");
            entity.Property(e => e.poste_id).HasComment("Poste_id");
            entity.Property(e => e.sign_by_ordre).HasComment("Sign_by_ordre");
            entity.Property(e => e.typerub_id).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.annee).WithMany(p => p.meet_config_visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_core_ann");

            entity.HasOne(d => d.poste).WithMany(p => p.meet_config_visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_meet_pos");

            entity.HasOne(d => d.typerub).WithMany(p => p.meet_config_visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_con_associati_meet_typ");
        });

        modelBuilder.Entity<meet_engagement>(entity =>
        {
            entity.HasKey(e => e.engagement_id).HasName("pk_meet_engagement");

            entity.ToTable("meet_engagement", "tontine_v14", tb => tb.HasComment("Meet_Engagement"));

            entity.Property(e => e.engagement_id).HasComment("Engagement_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.cumulverse).HasComment("Cumul des versements sur une rubrique");
            entity.Property(e => e.engagement_date).HasComment("Engagement_Date");
            entity.Property(e => e.is_closed).HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)");
            entity.Property(e => e.is_outcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.person_id).HasComment("Person_id");
            entity.Property(e => e.rubrique_id).HasComment("Identifiant d'une configuration");
            entity.Property(e => e.solde).HasComment("Solde");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.person).WithMany(p => p.meet_engagements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_eng_associati_core_per");

            entity.HasOne(d => d.rubrique).WithMany(p => p.meet_engagements)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_eng_associati_meet_rub");
        });

        modelBuilder.Entity<meet_entree_caisse>(entity =>
        {
            entity.HasKey(e => e.operation_id).HasName("pk_meet_entree_caisse");

            entity.ToTable("meet_entree_caisse", "tontine_v14", tb => tb.HasComment("Meet_Entree_caisse"));

            entity.Property(e => e.operation_id).HasComment("Operation_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.engagement_id).HasComment("Engagement_id");
            entity.Property(e => e.is_outcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.modepaie_id).HasComment("Identifiant du mode de paiement");
            entity.Property(e => e.montantverse).HasComment("MontantVerse");
            entity.Property(e => e.presence_id).HasComment("Identiifant de la signature");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.engagement).WithMany(p => p.meet_entree_caisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_meet_eng");

            entity.HasOne(d => d.modepaie).WithMany(p => p.meet_entree_caisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_core_mod");

            entity.HasOne(d => d.presence).WithMany(p => p.meet_entree_caisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ent_associati_meet_pre");
        });

        modelBuilder.Entity<meet_inscription>(entity =>
        {
            entity.HasKey(e => e.idinscrit).HasName("pk_meet_inscription");

            entity.ToTable("meet_inscription", "tontine_v14", tb => tb.HasComment("Represente le renoouvellement de la presence d'un membre au sein de 'association au cours d'une annee"));

            entity.Property(e => e.idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.antenne_id).HasComment("Identifiant de l'antenne");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.cumuldettes)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumulees applicable la nouvelle annee");
            entity.Property(e => e.cumulpenalites)
                .HasDefaultValueSql("0")
                .HasComment("Dettes cumules de penelites applicable la nouvelle annee");
            entity.Property(e => e.dateinscrit).HasComment("Date de l'inscription");
            entity.Property(e => e.datesuspension).HasComment("Date de derniere suspension d'un membre");
            entity.Property(e => e.endette).HasComment("Indique si le membre est endette");
            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.is_active).HasComment("Statut actif ou non d'un membre");
            entity.Property(e => e.nocni).HasComment("Nocni");
            entity.Property(e => e.person_id).HasComment("Person_id");
            entity.Property(e => e.report_nouveau).HasComment("Report a nouveau indiquant les dettes d'un membre au terme d'un exercice precedent");
            entity.Property(e => e.soldedebut).HasComment("SoldeDebut");
            entity.Property(e => e.soldefin)
                .HasDefaultValueSql("0")
                .HasComment("SoldeFin");
            entity.Property(e => e.tauxcotisation).HasComment("Report a nouveau du membre pour la nouvelle annee");
            entity.Property(e => e.total_verse).HasComment("Total_verse");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.annee).WithMany(p => p.meet_inscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_core_ann");

            entity.HasOne(d => d.person).WithMany(p => p.meet_inscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_core_per");

            entity.HasOne(d => d.meet_antenne).WithMany(p => p.meet_inscriptions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ins_associati_meet_ant");
        });

        modelBuilder.Entity<meet_max_allow_signature>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_meet_max_allow_signature");

            entity.ToTable("meet_max_allow_signature", "tontine_v14", tb => tb.HasComment("Meet_Max_allow_signature"));

            entity.Property(e => e.id).HasComment("Id");
            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.max_signature).HasComment("La valeur de cet attribut a partir de la somme des lignes faisant reference a un type de rubrique pour une annee donnee");
            entity.Property(e => e.typerub_id).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.annee).WithMany(p => p.meet_max_allow_signatures)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_max_associati_core_ann");

            entity.HasOne(d => d.typerub).WithMany(p => p.meet_max_allow_signatures)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_max_associati_meet_typ");
        });

        modelBuilder.Entity<meet_membre_bureau>(entity =>
        {
            entity.HasKey(e => e.bureaudetails_id).HasName("pk_meet_membre_bureau");

            entity.ToTable("meet_membre_bureau", "tontine_v14", tb => tb.HasComment("Meet_Membre_Bureau"));

            entity.Property(e => e.bureaudetails_id).HasComment("bureaudetails_id");
            entity.Property(e => e.bureau_id).HasComment("Bureau_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.poste_id).HasComment("Poste_id");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.bureau).WithMany(p => p.meet_membre_bureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_bur");

            entity.HasOne(d => d.idinscritNavigation).WithMany(p => p.meet_membre_bureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_ins");

            entity.HasOne(d => d.poste).WithMany(p => p.meet_membre_bureaus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_mem_associati_meet_pos");
        });

        modelBuilder.Entity<meet_ordre_passage>(entity =>
        {
            entity.HasKey(e => e.passage_id).HasName("pk_meet_ordre_passage");

            entity.ToTable("meet_ordre_passage", "tontine_v14", tb => tb.HasComment("Meet_Ordre_Passage"));

            entity.Property(e => e.passage_id).HasComment("passage_id");
            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.commentaire).HasComment("Commentaire");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.division_id).HasComment("Identifiant de la division");
            entity.Property(e => e.heuredebut).HasComment("HeureDebut");
            entity.Property(e => e.idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.montantpercu).HasComment("MontantPercu");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.idinscritNavigation).WithMany(p => p.meet_ordre_passages)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ord_associati_meet_ins");

            entity.HasOne(d => d.core_subdivision).WithMany(p => p.meet_ordre_passages)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_ord_associati_core_sub");
        });

        modelBuilder.Entity<meet_poste>(entity =>
        {
            entity.HasKey(e => e.poste_id).HasName("pk_meet_poste");

            entity.ToTable("meet_poste", "tontine_v14", tb => tb.HasComment("Poste occupe par un membre de l'association"));

            entity.Property(e => e.poste_id).HasComment("Poste_id");
            entity.Property(e => e.code).HasComment("Les valeurs autorisees sont: {PRESIDENT, TRESORIER, SG, SGA, CC, CENSOR, MEMBER}");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.libelle).HasComment("Libelle");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");
        });

        modelBuilder.Entity<meet_preference>(entity =>
        {
            entity.HasKey(e => e.setting_id).HasName("pk_meet_preference");

            entity.ToTable("meet_preference", "tontine_v14", tb => tb.HasComment("Meet_Preference"));

            entity.Property(e => e.setting_id)
                .ValueGeneratedNever()
                .HasComment("Identifiant de l'entite");
            entity.Property(e => e.enable_auto_dispatch_income)
                .HasDefaultValueSql("true")
                .HasComment("Enable_auto_dispatch_income");
            entity.Property(e => e.enable_auto_gen_presence)
                .HasDefaultValueSql("true")
                .HasComment("Enable_auto_gen_presence");
            entity.Property(e => e.enable_fixed_amount_fees).HasComment("Enable_fixed_amount_fees");
            entity.Property(e => e.enable_fixed_fees_by_anten).HasComment("Enable_fixed_fees_by_anten");
            entity.Property(e => e.enable_max_delay_penalites)
                .HasDefaultValueSql("true")
                .HasComment("Enable_max_delay_penalites");
            entity.Property(e => e.enable_secours_insurance).HasComment("Enable_Secours_insurance");
            entity.Property(e => e.enable_signing_outcome).HasComment("Enable_signing_outcome");
            entity.Property(e => e.taux_interet_mensuel).HasComment("Taux d'interet mensuel pour un pret");
            entity.Property(e => e.taux_interet_penalite).HasComment("Taux d'interet applicable en cas de non respect de l'echeance d'un pret");
            entity.Property(e => e.taux_penalite_cotisation).HasComment("Taux d'interet applicable en cas de penalite pour echec a une cotiisation");

            entity.HasOne(d => d.setting).WithOne(p => p.meet_preference)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_generalis_core_ann");
        });

        modelBuilder.Entity<meet_presence>(entity =>
        {
            entity.HasKey(e => e.presence_id).HasName("pk_meet_presence");

            entity.ToTable("meet_presence", "tontine_v14", tb => tb.HasComment("Represente l'etat des presences des membres a une seance de reunion et l'ensemble des signatures apposees par les membres (beneficiaire et bureau) de l'association sur un document"));

            entity.Property(e => e.presence_id).HasComment("Identiifant de la signature");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.dateop).HasComment("Dateop");
            entity.Property(e => e.globalverse).HasComment("globalverse");
            entity.Property(e => e.idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.is_absent).HasComment("Is_absent");
            entity.Property(e => e.num_bordero).HasComment("Num_bordero");
            entity.Property(e => e.seance_id).HasComment("Seance_id");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.idinscritNavigation).WithMany(p => p.meet_presences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_ins");

            entity.HasOne(d => d.seance).WithMany(p => p.meet_presences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_sea");
        });

        modelBuilder.Entity<meet_pret>(entity =>
        {
            entity.HasKey(e => e.sortiecaisse_id).HasName("pk_meet_pret");

            entity.ToTable("meet_pret", "tontine_v14", tb => tb.HasComment("Meet_Pret"));

            entity.Property(e => e.sortiecaisse_id).HasComment("Sortiecaisse_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.dateevts).HasComment("Date effective a laquelle a lieu l'evenement");
            entity.Property(e => e.duree_finale).HasComment("Duree_finale");
            entity.Property(e => e.duree_initiale).HasComment("Duree du pret en nombre de mois");
            entity.Property(e => e.idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.is_closed).HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)");
            entity.Property(e => e.montant_interet).HasComment("Montant de l'interet");
            entity.Property(e => e.montant_penalite).HasComment("Montant applicable en cas de penalite sur les interets ou en cas d'absence de cotisation");
            entity.Property(e => e.montantpercu).HasComment("Montant percu par le beneficiaire de l'evenement");
            entity.Property(e => e.note).HasComment("Observation generale concernant le deroulement de l'evenement");
            entity.Property(e => e.ref_no).HasComment("No de Reference permettant d'identifier le pret");
            entity.Property(e => e.seance_id).HasComment("Seance_id");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");
            entity.Property(e => e.visarestants).HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.");

            entity.HasOne(d => d.idinscritNavigation).WithMany(p => p.meet_prets)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_ins");

            entity.HasOne(d => d.seance).WithMany(p => p.meet_prets)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_pre_associati_meet_sea");
        });

        modelBuilder.Entity<meet_rubrique>(entity =>
        {
            entity.HasKey(e => e.rubrique_id).HasName("pk_meet_rubrique");

            entity.ToTable("meet_rubrique", "tontine_v14", tb => tb.HasComment("Represente la personnalisation de certaines valeurs appliquees aux types d'eveneents au cours d'une annee"));

            entity.Property(e => e.rubrique_id).HasComment("Identifiant d'une configuration");
            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.commentaire).HasComment("Commentaire");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.is_outcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.libelle).HasComment("Description de la rubrique (evenement)");
            entity.Property(e => e.montant_person).HasComment("Montant total associe a l'evenement");
            entity.Property(e => e.montantroute).HasComment("Montant du deplacement d'un membre mandate par l'association");
            entity.Property(e => e.nbmandataire).HasComment("Nombre de membres representant l'asociation a l'evenement");
            entity.Property(e => e.typerub_id).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.annee).WithMany(p => p.meet_rubriques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_rub_associati_core_ann");

            entity.HasOne(d => d.typerub).WithMany(p => p.meet_rubriques)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_rub_associati_meet_typ");
        });

        modelBuilder.Entity<meet_seance>(entity =>
        {
            entity.HasKey(e => e.seance_id).HasName("pk_meet_seance");

            entity.ToTable("meet_seance", "tontine_v14", tb => tb.HasComment("Meet_seance"));

            entity.Property(e => e.seance_id).HasComment("Seance_id");
            entity.Property(e => e.annee_id).HasComment("Identifiant de l'annee");
            entity.Property(e => e.antenne_id).HasComment("Identifiant de l'antenne");
            entity.Property(e => e.closedate).HasComment("Date et heure de fermeture de la reunion");
            entity.Property(e => e.compterendu).HasComment("Compte rendu de la seance de reunion");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.depensecollation).HasComment("DepenseCollation");
            entity.Property(e => e.division_id).HasComment("Identifiant de la division");
            entity.Property(e => e.etab_id).HasComment("Etab_id");
            entity.Property(e => e.opendate).HasComment("Date et heure d'ouverture de la reunion");
            entity.Property(e => e.status).HasComment("Le statut {CLOSED} indique que la reunion est cloturee et ses donnees ne sont plus modifiables");
            entity.Property(e => e.total_entrees).HasComment("Total_entrees");
            entity.Property(e => e.total_sorties).HasComment("Total_Sorties");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.core_subdivision).WithMany(p => p.meet_seances)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sea_associati_core_sub");

            entity.HasOne(d => d.meet_antenne).WithMany(p => p.meet_seances)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sea_associati_meet_ant");
        });

        modelBuilder.Entity<meet_sortie_caisse>(entity =>
        {
            entity.HasKey(e => e.sortiecaisse_id).HasName("pk_meet_sortie_caisse");

            entity.ToTable("meet_sortie_caisse", "tontine_v14", tb => tb.HasComment("Meet_Sortie_Caisse"));

            entity.Property(e => e.sortiecaisse_id).HasComment("Sortiecaisse_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.dateevts).HasComment("Date effective a laquelle a lieu l'evenement");
            entity.Property(e => e.engagement_id).HasComment("Engagement_id");
            entity.Property(e => e.idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.is_closed).HasComment("Indique que l'evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)");
            entity.Property(e => e.liste_mandataires).HasComment("Liste des membres designes pour le deplacement");
            entity.Property(e => e.montant_route).HasComment("Montant dedie au deplacement des membres");
            entity.Property(e => e.montantpercu).HasComment("Montant percu par le beneficiaire de l'evenement");
            entity.Property(e => e.note).HasComment("Observation generale concernant le deroulement de l'evenement");
            entity.Property(e => e.seance_id).HasComment("Seance_id");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");
            entity.Property(e => e.visarestants).HasComment("Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.");

            entity.HasOne(d => d.engagement).WithMany(p => p.meet_sortie_caisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_eng");

            entity.HasOne(d => d.idinscritNavigation).WithMany(p => p.meet_sortie_caisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_ins");

            entity.HasOne(d => d.seance).WithMany(p => p.meet_sortie_caisses)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sor_associati_meet_sea");
        });

        modelBuilder.Entity<meet_suspension_membre>(entity =>
        {
            entity.HasKey(e => e.suspension_id).HasName("pk_meet_suspension_membre");

            entity.ToTable("meet_suspension_membre", "tontine_v14", tb => tb.HasComment("Meet_Suspension_Membre"));

            entity.Property(e => e.suspension_id).HasComment("Suspension_id");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.date_retour).HasComment("Date_retour");
            entity.Property(e => e.date_suspension).HasComment("Date_suspension");
            entity.Property(e => e.is_active).HasComment("Is_active");
            entity.Property(e => e.person_id).HasComment("Person_id");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.person).WithMany(p => p.meet_suspension_membres)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_sus_associati_core_per");
        });

        modelBuilder.Entity<meet_type_rubrique>(entity =>
        {
            entity.HasKey(e => e.typerub_id).HasName("pk_meet_type_rubrique");

            entity.ToTable("meet_type_rubrique", "tontine_v14", tb => tb.HasComment("Represente un type d'evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc."));

            entity.Property(e => e.typerub_id).HasComment("Identifiant du type d'evenement");
            entity.Property(e => e.auto_generated).HasComment("Indique si le systeme cree automatiquement une rubrique correspondante quand sa valeur est TRUE");
            entity.Property(e => e.candelete).HasComment("Indique si l'utlisateur peut supprimer cette information");
            entity.Property(e => e.code).HasComment("Les valeurs autorisees sont : {PRET, FONDENTRAIDE, COLLATION, EPARGNE, COTISATION, AIDE-NAISSANCE, AIDE-DECES, AIDE-MARIAGE, AIDE-DECES-CONJOINT, AIDE-DECES-FRERE, SECOURS, PENALITE-AIDES-DECES, PROJET}");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.is_active).HasComment("Lorsque sa valeur est a TRUE, le systeme peut proposser a l'utilisateur (ou automatiquement) la creation des rubrique associee a ce type.");
            entity.Property(e => e.is_outcome).HasComment("Indique si le type represente une sortie de caisse");
            entity.Property(e => e.libelle).HasComment("Libelle du type d'evenement");
            entity.Property(e => e.maxsignature).HasComment("Nombre de signatures autorises pour signer un documents associe a ce type devenement");
            entity.Property(e => e.montant_person).HasComment("Montant total associe a l'evenement");
            entity.Property(e => e.montantpenalite).HasComment("Montant de la penalite applicable en cas d'absence aa l'evenement");
            entity.Property(e => e.montantroute).HasComment("Montant du deplacement d'un membre mandate par l'association");
            entity.Property(e => e.nbmandataire).HasComment("Nombre de membres representant l'asociation a l'evenement");
            entity.Property(e => e.numordre)
                .HasDefaultValueSql("1")
                .HasComment("Defini l'ordre dans lequel les rubriques de ce type peuevnt beneficier d'une repartition automatique du montant verse par un membre d'une reunion");
            entity.Property(e => e.required).HasComment("Indique que toutes les rubriques de ce type sont automatiquement cotisees par les membres d'une reunion");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");
        });

        modelBuilder.Entity<meet_visa>(entity =>
        {
            entity.HasKey(e => e.visa_id).HasName("pk_meet_visas");

            entity.ToTable("meet_visas", "tontine_v14", tb => tb.HasComment("Meet_Visas"));

            entity.Property(e => e.visa_id).HasComment("Identiifant de la signature");
            entity.Property(e => e.configvisa_id).HasComment("Identifiant de la configuration de signature");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Create_at");
            entity.Property(e => e.create_uid).HasComment("create_uid");
            entity.Property(e => e.datesign).HasComment("Date de signature");
            entity.Property(e => e.idinscrit).HasComment("Identifiant de l'inscription");
            entity.Property(e => e.meet_operation).HasComment("Meet_Operation");
            entity.Property(e => e.receiver).HasComment("Indique si le signataire est le beneficiare");
            entity.Property(e => e.sign_by_ordre).HasComment("Indique si le document est signe par ordre");
            entity.Property(e => e.sortiecaisse_id).HasComment("Sortiecaisse_id");
            entity.Property(e => e.update_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Update_at");
            entity.Property(e => e.update_uid).HasComment("update_uid");

            entity.HasOne(d => d.configvisa).WithMany(p => p.meet_visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_con");

            entity.HasOne(d => d.idinscritNavigation).WithMany(p => p.meet_visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_ins");

            entity.HasOne(d => d.meet_operationNavigation).WithMany(p => p.meet_visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_pre");

            entity.HasOne(d => d.sortiecaisse).WithMany(p => p.meet_visas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_meet_vis_associati_meet_sor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
