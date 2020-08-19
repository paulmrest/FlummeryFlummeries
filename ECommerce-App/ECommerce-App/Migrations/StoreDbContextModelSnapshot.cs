﻿// <auto-generated />
using ECommerce_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce_App.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce_App.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cart");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = "63866547-918c-4c25-8d19-16c845d2fa2e"
                        },
                        new
                        {
                            Id = 2,
                            UserId = "cf1833eb-dbd6-42b1-ab9c-cf24382b9d07"
                        });
                });

            modelBuilder.Entity("ECommerce_App.Models.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            ProductId = 3,
                            Qty = 2
                        },
                        new
                        {
                            CartId = 1,
                            ProductId = 7,
                            Qty = 4
                        },
                        new
                        {
                            CartId = 2,
                            ProductId = 1,
                            Qty = 5
                        },
                        new
                        {
                            CartId = 2,
                            ProductId = 5,
                            Qty = 1
                        });
                });

            modelBuilder.Entity("ECommerce_App.Models.Flummery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<string>("Compliment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Flummery");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Calories = 1525,
                            Compliment = "I can't believe you managed to pull that off. Good job.",
                            Manufacturer = "Acme Baking",
                            Name = "Job Jelly",
                            Price = 9.99m,
                            Weight = 0.5m
                        },
                        new
                        {
                            Id = 2,
                            Calories = 1150,
                            Compliment = "That tie looks great on you! Is it new?",
                            Manufacturer = "Flum & Co",
                            Name = "Tied for First",
                            Price = 72.99m,
                            Weight = 0.6m
                        },
                        new
                        {
                            Id = 3,
                            Calories = 873,
                            Compliment = "Oh wow, you really tried your hardest on that!",
                            Manufacturer = "Flippery Flumstons",
                            Name = "Tryion",
                            Price = 46.33m,
                            Weight = 0.7m
                        },
                        new
                        {
                            Id = 4,
                            Calories = 912,
                            Compliment = "That chili would be pretty spicy to an infant.",
                            Manufacturer = "Acme Baking",
                            Name = "Baby Cowboy",
                            Price = 9.99m,
                            Weight = 0.5m
                        },
                        new
                        {
                            Id = 5,
                            Calories = 2100,
                            Compliment = "Stylish if your grandparents dressed you.",
                            Manufacturer = "Flippery Flumstons",
                            Name = "Polka",
                            Price = 9.99m,
                            Weight = 0.5m
                        },
                        new
                        {
                            Id = 6,
                            Calories = 1792,
                            Compliment = "What a nice sorting algorithm.",
                            Manufacturer = "Full On Flummery",
                            Name = "Lark on the Wing",
                            Price = 9.99m,
                            Weight = 0.5m
                        },
                        new
                        {
                            Id = 7,
                            Calories = 1135,
                            Compliment = "Yeah, that's a nice loaf of quarantine sourdough.",
                            Manufacturer = "Acme Baking",
                            Name = "Scarce Flour",
                            Price = 9.99m,
                            Weight = 0.5m
                        },
                        new
                        {
                            Id = 8,
                            Calories = 465,
                            Compliment = "What a nice painting! It's going right on the fridge.",
                            Manufacturer = "Flum For Kids",
                            Name = "Flum Jr.",
                            Price = 4.99m,
                            Weight = 0.2m
                        },
                        new
                        {
                            Id = 9,
                            Calories = 1325,
                            Compliment = "You all are the hardworking, salt of the earth type.",
                            Manufacturer = "Local Government",
                            Name = "Political HumFlummery",
                            Price = 52.99m,
                            Weight = 0.1m
                        },
                        new
                        {
                            Id = 10,
                            Calories = 1792,
                            Compliment = "You're so good at arguing, you should be a lawyer.",
                            Manufacturer = "Flumm Board for Ethical Flumming",
                            Name = "Flawmery",
                            Price = 9.99m,
                            Weight = 0.5m
                        });
                });

            modelBuilder.Entity("ECommerce_App.Models.CartItem", b =>
                {
                    b.HasOne("ECommerce_App.Models.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce_App.Models.Flummery", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
