﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ap1_main.Data;

#nullable disable

namespace ap1_main.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230524050647_InitialMigrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ap1_main.Domain.Cliente", b =>
                {
                    b.Property<int>("clienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("contaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("clienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ap1_main.Domain.Conta", b =>
                {
                    b.Property<int>("contaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("clienteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("numero")
                        .HasColumnType("INTEGER");

                    b.Property<double>("saldo")
                        .HasColumnType("REAL");

                    b.HasKey("contaId");

                    b.HasIndex("clienteId")
                        .IsUnique();

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("ap1_main.Domain.Transacao", b =>
                {
                    b.Property<int>("transacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("contaDestinocontaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("contaOrigemcontaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("transacaoId");

                    b.HasIndex("contaDestinocontaId");

                    b.HasIndex("contaOrigemcontaId");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("ap1_main.Domain.Conta", b =>
                {
                    b.HasOne("ap1_main.Domain.Cliente", "cliente")
                        .WithOne("conta")
                        .HasForeignKey("ap1_main.Domain.Conta", "clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("ap1_main.Domain.Transacao", b =>
                {
                    b.HasOne("ap1_main.Domain.Conta", "contaDestino")
                        .WithMany()
                        .HasForeignKey("contaDestinocontaId");

                    b.HasOne("ap1_main.Domain.Conta", "contaOrigem")
                        .WithMany()
                        .HasForeignKey("contaOrigemcontaId");

                    b.Navigation("contaDestino");

                    b.Navigation("contaOrigem");
                });

            modelBuilder.Entity("ap1_main.Domain.Cliente", b =>
                {
                    b.Navigation("conta");
                });
#pragma warning restore 612, 618
        }
    }
}
