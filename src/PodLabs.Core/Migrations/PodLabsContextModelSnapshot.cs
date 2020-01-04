﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PodLabs.Core;

namespace PodLabs.Core.Migrations
{
    [DbContext(typeof(PodLabsContext))]
    partial class PodLabsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("PodLabs.Core.Classes.Local.Tracker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<short>("IsAlliance")
                        .HasColumnName("IsAlliance")
                        .HasColumnType("bit");

                    b.Property<long>("TrackerId")
                        .HasColumnName("TrackerId");

                    b.HasKey("Id");

                    b.ToTable("Trackers");

                    b.HasData(
                        new { Id = 1L, IsAlliance = (short)0, TrackerId = 98614694L },
                        new { Id = 2L, IsAlliance = (short)1, TrackerId = 99007237L },
                        new { Id = 3L, IsAlliance = (short)1, TrackerId = 99003144L },
                        new { Id = 4L, IsAlliance = (short)1, TrackerId = 99009583L },
                        new { Id = 5L, IsAlliance = (short)1, TrackerId = 99006113L },
                        new { Id = 6L, IsAlliance = (short)1, TrackerId = 99006319L },
                        new { Id = 7L, IsAlliance = (short)1, TrackerId = 99007192L },
                        new { Id = 8L, IsAlliance = (short)1, TrackerId = 99006117L }
                    );
                });

            modelBuilder.Entity("PodLabs.Core.Classes.Swagger.Alliance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<long>("AllianceId")
                        .HasColumnName("AllianceId");

                    b.Property<long>("CreatorCorporationId")
                        .HasColumnName("CreatorCorporationId");

                    b.Property<long>("CreatorId")
                        .HasColumnName("CreatorId");

                    b.Property<DateTime>("DateFounded")
                        .HasColumnName("DateFounded");

                    b.Property<long?>("ExecutorCorporationId")
                        .HasColumnName("ExecutorCorporationId");

                    b.Property<long?>("FactionId")
                        .HasColumnName("FactionId");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.Property<string>("Ticker")
                        .HasColumnName("Ticker");

                    b.HasKey("Id");

                    b.ToTable("Alliances");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.Swagger.Corporation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<long?>("AllianceId")
                        .HasColumnName("AllianceId");

                    b.Property<long>("CeoId")
                        .HasColumnName("CeoId");

                    b.Property<long>("CorporationId")
                        .HasColumnName("CorporationId");

                    b.Property<long>("CreatorId")
                        .HasColumnName("CreatorId");

                    b.Property<DateTime?>("DateFounded")
                        .HasColumnName("DateFounded");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<long?>("FactionId")
                        .HasColumnName("FactionId");

                    b.Property<long?>("HomeStationId")
                        .HasColumnName("HomeStationId");

                    b.Property<long>("MemberCount")
                        .HasColumnName("MemberCount");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.Property<long?>("Shares")
                        .HasColumnName("Shares");

                    b.Property<double>("TaxRate")
                        .HasColumnName("TaxRate");

                    b.Property<string>("Ticker")
                        .HasColumnName("Ticker");

                    b.Property<string>("Url")
                        .HasColumnName("Url");

                    b.Property<short?>("WarEligible")
                        .HasColumnName("WarEligible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Corporations");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Attacker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<long>("AllianceId")
                        .HasColumnName("AllianceId");

                    b.Property<long>("CharacterId")
                        .HasColumnName("CharacterId");

                    b.Property<long>("CorporationId")
                        .HasColumnName("CorporationId");

                    b.Property<long>("DamageDone")
                        .HasColumnName("DamageDone");

                    b.Property<long>("FactionId")
                        .HasColumnName("FactionId");

                    b.Property<short>("FinalBlow")
                        .HasColumnName("FinalBlow")
                        .HasColumnType("bit");

                    b.Property<long?>("KillmailId");

                    b.Property<float>("SecurityStatus")
                        .HasColumnName("SecurityStatus");

                    b.Property<long>("ShipTypeId")
                        .HasColumnName("ShipTypeId");

                    b.Property<long>("WeaponTypeId")
                        .HasColumnName("WeaponTypeID");

                    b.HasKey("Id");

                    b.HasIndex("KillmailId");

                    b.ToTable("Attacker");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("Flag")
                        .HasColumnName("Flag");

                    b.Property<int>("ItemTypeId")
                        .HasColumnName("ItemTypeId");

                    b.Property<long?>("QuantityDestroyed")
                        .HasColumnName("QuantityDestroyed");

                    b.Property<long?>("QuantityDropped")
                        .HasColumnName("QuantityDropped");

                    b.Property<int>("Singleton")
                        .HasColumnName("Singleton");

                    b.Property<long?>("VictimId");

                    b.HasKey("Id");

                    b.HasIndex("VictimId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Killmail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<long>("KillmailId")
                        .HasColumnName("KillmailId");

                    b.Property<DateTime>("KillmailTime")
                        .HasColumnName("KillmailTime");

                    b.Property<long>("SolarSystemId")
                        .HasColumnName("SolarSystemId");

                    b.Property<long?>("VictimId");

                    b.Property<long?>("ZkbId");

                    b.HasKey("Id");

                    b.HasIndex("VictimId");

                    b.HasIndex("ZkbId");

                    b.ToTable("Killmails");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<float>("X")
                        .HasColumnName("X");

                    b.Property<float>("Y")
                        .HasColumnName("Y");

                    b.Property<float>("Z")
                        .HasColumnName("Z");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Victim", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<long>("AllianceId")
                        .HasColumnName("AllianceId");

                    b.Property<long>("CharacterId")
                        .HasColumnName("CharacterId");

                    b.Property<long>("CorporationId")
                        .HasColumnName("CorporationId");

                    b.Property<long>("DamageTaken")
                        .HasColumnName("DamageTaken");

                    b.Property<long?>("PositionId");

                    b.Property<long>("ShipTypeId")
                        .HasColumnName("ShipTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Victim");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Zkb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<short>("Awox")
                        .HasColumnName("Awox")
                        .HasColumnType("bit");

                    b.Property<string>("Esi")
                        .HasColumnName("Esi");

                    b.Property<double>("FittedValue")
                        .HasColumnName("FittedValue");

                    b.Property<string>("Hash")
                        .HasColumnName("Hash");

                    b.Property<long>("LocationId")
                        .HasColumnName("LocationId");

                    b.Property<short>("NPC")
                        .HasColumnName("NPC")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnName("Points");

                    b.Property<short>("Solo")
                        .HasColumnName("Solo")
                        .HasColumnType("bit");

                    b.Property<double>("TotalValue")
                        .HasColumnName("TotalValue");

                    b.Property<string>("Url")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.ToTable("Zkb");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Attacker", b =>
                {
                    b.HasOne("PodLabs.Core.Classes.zKillboard.Killmail")
                        .WithMany("Attackers")
                        .HasForeignKey("KillmailId");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Item", b =>
                {
                    b.HasOne("PodLabs.Core.Classes.zKillboard.Victim")
                        .WithMany("Items")
                        .HasForeignKey("VictimId");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Killmail", b =>
                {
                    b.HasOne("PodLabs.Core.Classes.zKillboard.Victim", "Victim")
                        .WithMany()
                        .HasForeignKey("VictimId");

                    b.HasOne("PodLabs.Core.Classes.zKillboard.Zkb", "Zkb")
                        .WithMany()
                        .HasForeignKey("ZkbId");
                });

            modelBuilder.Entity("PodLabs.Core.Classes.zKillboard.Victim", b =>
                {
                    b.HasOne("PodLabs.Core.Classes.zKillboard.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}
