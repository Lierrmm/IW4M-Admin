﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SharedLibraryCore.Database.MigrationContext;

namespace SharedLibraryCore.Migrations.Postgresql
{
    [DbContext(typeof(PostgresqlDatabaseContext))]
    [Migration("20210124170956_UpdateEFMetaToSupportLinkedMeta")]
    partial class UpdateEFMetaToSupportLinkedMeta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFACSnapshot", b =>
                {
                    b.Property<int>("SnapshotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentSessionLength")
                        .HasColumnType("integer");

                    b.Property<double>("CurrentStrain")
                        .HasColumnType("double precision");

                    b.Property<int>("CurrentViewAngleId")
                        .HasColumnType("integer");

                    b.Property<int>("Deaths")
                        .HasColumnType("integer");

                    b.Property<double>("Distance")
                        .HasColumnType("double precision");

                    b.Property<double>("EloRating")
                        .HasColumnType("double precision");

                    b.Property<int>("HitDestinationId")
                        .HasColumnType("integer");

                    b.Property<int>("HitLocation")
                        .HasColumnType("integer");

                    b.Property<int>("HitOriginId")
                        .HasColumnType("integer");

                    b.Property<int>("HitType")
                        .HasColumnType("integer");

                    b.Property<int>("Hits")
                        .HasColumnType("integer");

                    b.Property<int>("Kills")
                        .HasColumnType("integer");

                    b.Property<int>("LastStrainAngleId")
                        .HasColumnType("integer");

                    b.Property<double>("RecoilOffset")
                        .HasColumnType("double precision");

                    b.Property<double>("SessionAngleOffset")
                        .HasColumnType("double precision");

                    b.Property<double>("SessionAverageSnapValue")
                        .HasColumnType("double precision");

                    b.Property<double>("SessionSPM")
                        .HasColumnType("double precision");

                    b.Property<int>("SessionScore")
                        .HasColumnType("integer");

                    b.Property<int>("SessionSnapHits")
                        .HasColumnType("integer");

                    b.Property<double>("StrainAngleBetween")
                        .HasColumnType("double precision");

                    b.Property<int>("TimeSinceLastEvent")
                        .HasColumnType("integer");

                    b.Property<int>("WeaponId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("When")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("SnapshotId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CurrentViewAngleId");

                    b.HasIndex("HitDestinationId");

                    b.HasIndex("HitOriginId");

                    b.HasIndex("LastStrainAngleId");

                    b.ToTable("EFACSnapshot");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFACSnapshotVector3", b =>
                {
                    b.Property<int>("ACSnapshotVector3Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("SnapshotId")
                        .HasColumnType("integer");

                    b.Property<int>("Vector3Id")
                        .HasColumnType("integer");

                    b.HasKey("ACSnapshotVector3Id");

                    b.HasIndex("SnapshotId");

                    b.HasIndex("Vector3Id");

                    b.ToTable("EFACSnapshotVector3");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientKill", b =>
                {
                    b.Property<long>("KillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("AttackerId")
                        .HasColumnType("integer");

                    b.Property<int>("Damage")
                        .HasColumnType("integer");

                    b.Property<int?>("DeathOriginVector3Id")
                        .HasColumnType("integer");

                    b.Property<int>("DeathType")
                        .HasColumnType("integer");

                    b.Property<double>("Fraction")
                        .HasColumnType("double precision");

                    b.Property<int>("HitLoc")
                        .HasColumnType("integer");

                    b.Property<bool>("IsKill")
                        .HasColumnType("boolean");

                    b.Property<int?>("KillOriginVector3Id")
                        .HasColumnType("integer");

                    b.Property<int>("Map")
                        .HasColumnType("integer");

                    b.Property<long>("ServerId")
                        .HasColumnType("bigint");

                    b.Property<int>("VictimId")
                        .HasColumnType("integer");

                    b.Property<int?>("ViewAnglesVector3Id")
                        .HasColumnType("integer");

                    b.Property<double>("VisibilityPercentage")
                        .HasColumnType("double precision");

                    b.Property<int>("Weapon")
                        .HasColumnType("integer");

                    b.Property<DateTime>("When")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("KillId");

                    b.HasIndex("AttackerId");

                    b.HasIndex("DeathOriginVector3Id");

                    b.HasIndex("KillOriginVector3Id");

                    b.HasIndex("ServerId");

                    b.HasIndex("VictimId");

                    b.HasIndex("ViewAnglesVector3Id");

                    b.ToTable("EFClientKills");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientMessage", b =>
                {
                    b.Property<long>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<bool>("SentIngame")
                        .HasColumnType("boolean");

                    b.Property<long>("ServerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TimeSent")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("MessageId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServerId");

                    b.HasIndex("TimeSent");

                    b.ToTable("EFClientMessages");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientRatingHistory", b =>
                {
                    b.Property<int>("RatingHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.HasKey("RatingHistoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("EFClientRatingHistory");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientStatistics", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<long>("ServerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<double>("AverageRecoilOffset")
                        .HasColumnType("double precision");

                    b.Property<double>("AverageSnapValue")
                        .HasColumnType("double precision");

                    b.Property<int>("Deaths")
                        .HasColumnType("integer");

                    b.Property<double>("EloRating")
                        .HasColumnType("double precision");

                    b.Property<int>("Kills")
                        .HasColumnType("integer");

                    b.Property<double>("MaxStrain")
                        .HasColumnType("double precision");

                    b.Property<double>("RollingWeightedKDR")
                        .HasColumnType("double precision");

                    b.Property<double>("SPM")
                        .HasColumnType("double precision");

                    b.Property<double>("Skill")
                        .HasColumnType("double precision");

                    b.Property<int>("SnapHitCount")
                        .HasColumnType("integer");

                    b.Property<int>("TimePlayed")
                        .HasColumnType("integer");

                    b.Property<double>("VisionAverage")
                        .HasColumnType("double precision");

                    b.HasKey("ClientId", "ServerId");

                    b.HasIndex("ServerId");

                    b.ToTable("EFClientStatistics");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFHitLocationCount", b =>
                {
                    b.Property<int>("HitLocationCountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("EFClientStatisticsClientId")
                        .HasColumnName("EFClientStatisticsClientId")
                        .HasColumnType("integer");

                    b.Property<long>("EFClientStatisticsServerId")
                        .HasColumnName("EFClientStatisticsServerId")
                        .HasColumnType("bigint");

                    b.Property<int>("HitCount")
                        .HasColumnType("integer");

                    b.Property<float>("HitOffsetAverage")
                        .HasColumnType("real");

                    b.Property<int>("Location")
                        .HasColumnType("integer");

                    b.Property<float>("MaxAngleDistance")
                        .HasColumnType("real");

                    b.HasKey("HitLocationCountId");

                    b.HasIndex("EFClientStatisticsServerId");

                    b.HasIndex("EFClientStatisticsClientId", "EFClientStatisticsServerId");

                    b.ToTable("EFHitLocationCounts");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFRating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("ActivityAmount")
                        .HasColumnType("integer");

                    b.Property<bool>("Newest")
                        .HasColumnType("boolean");

                    b.Property<double>("Performance")
                        .HasColumnType("double precision");

                    b.Property<int>("Ranking")
                        .HasColumnType("integer");

                    b.Property<int>("RatingHistoryId")
                        .HasColumnType("integer");

                    b.Property<long?>("ServerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("When")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("RatingId");

                    b.HasIndex("RatingHistoryId");

                    b.HasIndex("ServerId");

                    b.HasIndex("Performance", "Ranking", "When");

                    b.HasIndex("When", "ServerId", "Performance", "ActivityAmount");

                    b.ToTable("EFRating");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFServer", b =>
                {
                    b.Property<long>("ServerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("EndPoint")
                        .HasColumnType("text");

                    b.Property<int?>("GameName")
                        .HasColumnType("integer");

                    b.Property<string>("HostName")
                        .HasColumnType("text");

                    b.Property<bool>("IsPasswordProtected")
                        .HasColumnType("boolean");

                    b.Property<int>("Port")
                        .HasColumnType("integer");

                    b.HasKey("ServerId");

                    b.ToTable("EFServers");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFServerStatistics", b =>
                {
                    b.Property<int>("StatisticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<long>("ServerId")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalKills")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalPlayTime")
                        .HasColumnType("bigint");

                    b.HasKey("StatisticId");

                    b.HasIndex("ServerId");

                    b.ToTable("EFServerStatistics");
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFAlias", b =>
                {
                    b.Property<int>("AliasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IPAddress")
                        .HasColumnType("integer");

                    b.Property<int>("LinkId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.Property<string>("SearchableName")
                        .HasColumnType("character varying(24)")
                        .HasMaxLength(24);

                    b.HasKey("AliasId");

                    b.HasIndex("IPAddress");

                    b.HasIndex("LinkId");

                    b.HasIndex("Name");

                    b.HasIndex("SearchableName");

                    b.HasIndex("Name", "IPAddress")
                        .IsUnique();

                    b.ToTable("EFAlias");
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFAliasLink", b =>
                {
                    b.Property<int>("AliasLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.HasKey("AliasLinkId");

                    b.ToTable("EFAliasLinks");
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFChangeHistory", b =>
                {
                    b.Property<int>("ChangeHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Comment")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("CurrentValue")
                        .HasColumnType("text");

                    b.Property<int?>("ImpersonationEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("OriginEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("PreviousValue")
                        .HasColumnType("text");

                    b.Property<int>("TargetEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeChanged")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TypeOfChange")
                        .HasColumnType("integer");

                    b.HasKey("ChangeHistoryId");

                    b.ToTable("EFChangeHistory");
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFClient", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("AliasLinkId")
                        .HasColumnType("integer");

                    b.Property<int>("Connections")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentAliasId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FirstConnection")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastConnection")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<bool>("Masked")
                        .HasColumnType("boolean");

                    b.Property<long>("NetworkId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("text");

                    b.Property<int>("TotalConnectionTime")
                        .HasColumnType("integer");

                    b.HasKey("ClientId");

                    b.HasIndex("AliasLinkId");

                    b.HasIndex("CurrentAliasId");

                    b.HasIndex("NetworkId")
                        .IsUnique();

                    b.ToTable("EFClients");
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFMeta", b =>
                {
                    b.Property<int>("MetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Extra")
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<int?>("LinkedMetaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MetaId");

                    b.HasIndex("ClientId");

                    b.HasIndex("Key");

                    b.HasIndex("LinkedMetaId");

                    b.ToTable("EFMeta");
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFPenalty", b =>
                {
                    b.Property<int>("PenaltyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("AutomatedOffense")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Expires")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsEvadedOffense")
                        .HasColumnType("boolean");

                    b.Property<int>("LinkId")
                        .HasColumnType("integer");

                    b.Property<int>("OffenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Offense")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PunisherId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("When")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("PenaltyId");

                    b.HasIndex("LinkId");

                    b.HasIndex("OffenderId");

                    b.HasIndex("PunisherId");

                    b.ToTable("EFPenalties");
                });

            modelBuilder.Entity("SharedLibraryCore.Helpers.Vector3", b =>
                {
                    b.Property<int>("Vector3Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.Property<float>("Z")
                        .HasColumnType("real");

                    b.HasKey("Vector3Id");

                    b.ToTable("Vector3");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFACSnapshot", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "CurrentViewAngle")
                        .WithMany()
                        .HasForeignKey("CurrentViewAngleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "HitDestination")
                        .WithMany()
                        .HasForeignKey("HitDestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "HitOrigin")
                        .WithMany()
                        .HasForeignKey("HitOriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "LastStrainAngle")
                        .WithMany()
                        .HasForeignKey("LastStrainAngleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFACSnapshotVector3", b =>
                {
                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFACSnapshot", "Snapshot")
                        .WithMany("PredictedViewAngles")
                        .HasForeignKey("SnapshotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "Vector")
                        .WithMany()
                        .HasForeignKey("Vector3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientKill", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Attacker")
                        .WithMany()
                        .HasForeignKey("AttackerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "DeathOrigin")
                        .WithMany()
                        .HasForeignKey("DeathOriginVector3Id");

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "KillOrigin")
                        .WithMany()
                        .HasForeignKey("KillOriginVector3Id");

                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Victim")
                        .WithMany()
                        .HasForeignKey("VictimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Helpers.Vector3", "ViewAngles")
                        .WithMany()
                        .HasForeignKey("ViewAnglesVector3Id");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientMessage", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientRatingHistory", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFClientStatistics", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFHitLocationCount", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Client")
                        .WithMany()
                        .HasForeignKey("EFClientStatisticsClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("EFClientStatisticsServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFClientStatistics", null)
                        .WithMany("HitLocations")
                        .HasForeignKey("EFClientStatisticsClientId", "EFClientStatisticsServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFRating", b =>
                {
                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFClientRatingHistory", "RatingHistory")
                        .WithMany("Ratings")
                        .HasForeignKey("RatingHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId");
                });

            modelBuilder.Entity("IW4MAdmin.Plugins.Stats.Models.EFServerStatistics", b =>
                {
                    b.HasOne("IW4MAdmin.Plugins.Stats.Models.EFServer", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFAlias", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFAliasLink", "Link")
                        .WithMany("Children")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFClient", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFAliasLink", "AliasLink")
                        .WithMany()
                        .HasForeignKey("AliasLinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Database.Models.EFAlias", "CurrentAlias")
                        .WithMany()
                        .HasForeignKey("CurrentAliasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFMeta", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Client")
                        .WithMany("Meta")
                        .HasForeignKey("ClientId");

                    b.HasOne("SharedLibraryCore.Database.Models.EFMeta", "LinkedMeta")
                        .WithMany()
                        .HasForeignKey("LinkedMetaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("SharedLibraryCore.Database.Models.EFPenalty", b =>
                {
                    b.HasOne("SharedLibraryCore.Database.Models.EFAliasLink", "Link")
                        .WithMany("ReceivedPenalties")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Offender")
                        .WithMany("ReceivedPenalties")
                        .HasForeignKey("OffenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SharedLibraryCore.Database.Models.EFClient", "Punisher")
                        .WithMany("AdministeredPenalties")
                        .HasForeignKey("PunisherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
