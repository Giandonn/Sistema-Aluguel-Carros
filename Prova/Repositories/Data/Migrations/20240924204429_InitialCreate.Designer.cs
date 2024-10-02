using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Prova.Repositories.Data;

namespace Prova.Repositories.Data {
	[DbContext(typeof(RentDbContext))]
	[Migration("20240924204429_InitialCreate")]
	partial class InitialCreate {
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder) {
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.8")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("Prova.Models.Car", b => {
				b.Property<string>("Id")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("Categoria")
					.IsRequired()
					.HasColumnType("nvarchar(max)");

				b.Property<string>("Modelo")
					.IsRequired()
					.HasColumnType("nvarchar(max)");

				b.HasKey("Id");

				b.ToTable("Cars");
			});

			modelBuilder.Entity("Prova.Models.Client", b => {
				b.Property<string>("Id")
					.HasColumnType("nvarchar(450)");

				b.Property<bool?>("Ativo")
					.HasColumnType("bit");

				b.Property<string>("Email")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("Name")
					.IsRequired()
					.HasColumnType("nvarchar(max)");

				b.HasKey("Id");

				b.ToTable("Clients");
			});

			modelBuilder.Entity("Prova.Models.Rent", b => {
				b.Property<string>("Id")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("CarroId")
					.IsRequired()
					.HasColumnType("nvarchar(450)");

				b.Property<string>("ClienteId")
					.IsRequired()
					.HasColumnType("nvarchar(450)");

				b.Property<DateTime>("DataHora")
					.HasColumnType("datetime2");

				b.HasKey("Id");

				b.HasIndex("CarroId");

				b.HasIndex("ClienteId");

				b.ToTable("Rents");
			});

			modelBuilder.Entity("Prova.Models.Rent", b => {
				b.HasOne("Prova.Models.Car", "Carro")
					.WithMany()
					.HasForeignKey("CarroId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Prova.Models.Client", "Cliente")
					.WithMany()
					.HasForeignKey("ClienteId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Carro");
				b.Navigation("Cliente");
			});
		}
	}
}
