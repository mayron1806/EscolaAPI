﻿// <auto-generated />
using System;
using EscolaAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EscolaAPI.Migrations
{
    [DbContext(typeof(EscolaContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EscolaAPI.Entities.Aluno", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EscolaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Presenca")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EscolaID");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("EscolaAPI.Entities.Escola", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Escolas");
                });

            modelBuilder.Entity("EscolaAPI.Entities.Nota", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("Bimestre")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AlunoID");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("EscolaAPI.Entities.Aluno", b =>
                {
                    b.HasOne("EscolaAPI.Entities.Escola", "Escola")
                        .WithMany("Alunos")
                        .HasForeignKey("EscolaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escola");
                });

            modelBuilder.Entity("EscolaAPI.Entities.Nota", b =>
                {
                    b.HasOne("EscolaAPI.Entities.Aluno", "Aluno")
                        .WithMany("Notas")
                        .HasForeignKey("AlunoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("EscolaAPI.Entities.Aluno", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("EscolaAPI.Entities.Escola", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
