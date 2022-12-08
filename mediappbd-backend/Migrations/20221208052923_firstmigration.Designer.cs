﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using mediappbd_backend.Data;

#nullable disable

namespace mediappbdbackend.Migrations
{
    [DbContext(typeof(DatabaseConnection))]
    [Migration("20221208052923_firstmigration")]
    partial class firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("mediappbd_backend.Model.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("estado")
                        .HasColumnType("boolean");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("especialidad");
                });

            modelBuilder.Entity("mediappbd_backend.Model.Examen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("estado")
                        .HasColumnType("boolean");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("examen");
                });

            modelBuilder.Entity("mediappbd_backend.Model.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dui")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("estado")
                        .HasColumnType("boolean");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("photoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("medico");
                });

            modelBuilder.Entity("mediappbd_backend.Model.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dui")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("estado")
                        .HasColumnType("boolean");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
