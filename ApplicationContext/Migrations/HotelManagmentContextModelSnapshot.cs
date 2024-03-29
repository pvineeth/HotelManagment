﻿// <auto-generated />
using System;
using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationContext.Migrations
{
    [DbContext(typeof(HotelManagmentContext))]
    partial class HotelManagmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Branch", b =>
                {
                    b.Property<string>("PkbranchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FkHostelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FkUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PkbranchId");

                    b.HasIndex("FkHostelId");

                    b.HasIndex("FkUserId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Models.Hostel", b =>
                {
                    b.Property<string>("PkhostelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HostelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PkhostelId");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("Models.Role", b =>
                {
                    b.Property<string>("PkRoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Models.UserProfile", b =>
                {
                    b.Property<string>("PkUserProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FkRoleID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNUmber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUserProfileId");

                    b.HasIndex("FkRoleID");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Models.Branch", b =>
                {
                    b.HasOne("Models.Hostel", "Hostel")
                        .WithMany("Branches")
                        .HasForeignKey("FkHostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.UserProfile", "UserProfile")
                        .WithMany("Branches")
                        .HasForeignKey("FkUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hostel");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Models.UserProfile", b =>
                {
                    b.HasOne("Models.Role", "Role")
                        .WithMany("UserProfiles")
                        .HasForeignKey("FkRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Models.Hostel", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("Models.Role", b =>
                {
                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("Models.UserProfile", b =>
                {
                    b.Navigation("Branches");
                });
#pragma warning restore 612, 618
        }
    }
}
