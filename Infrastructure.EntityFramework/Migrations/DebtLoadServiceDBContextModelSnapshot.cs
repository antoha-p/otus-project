using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EntityFramework.DebtLoadService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;



namespace Infrastructure.EntityFramework.Migrations
{

    [DbContext(typeof(DebtLoadDBContext))]

    partial class DebtLoadDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 120);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.DebtLoadService.DebtLoadUser", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");
                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                b.Property<int>("INN")
                    .HasColumnType("integer");


                b.Property<string>("PasportNo")
                    .HasColumnType("text");


                b.Property<int>("summ")
                    .HasColumnType("integer");

                b.Property<DateTime>("RequestDate")
                    .HasColumnType("timestamp with time zone");


                b.Property<DateTime>("ResponseDate")
                    .HasColumnType("timestamp with time zone");


                b.HasKey("Id");
                b.HasIndex("INN");
                b.HasIndex("PasportNo");
                b.ToTable("DebtLoadUsers");

            });

        }

    }
}
