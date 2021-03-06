﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_App.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Flummery> Flummery { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<OrderCart> OrderCart { get; set; }

        public DbSet<OrderCartItem> OrderCartItem { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Flummery>().HasData(
                new Flummery
                {
                    Id = 1,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Job%20Jelly.jpg",
                    Calories = 1525,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 2,
                    Name = "Tied for First",
                    Manufacturer = "Flum & Co",
                    Price = 72.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Tied%20for%20First.jpg",
                    Calories = 1150,
                    Weight = 0.6m,
                    Compliment = "That tie looks great on you! Is it new?"
                },
                new Flummery
                {
                    Id = 3,
                    Name = "Tryion",
                    Manufacturer = "Flippery Flumstons",
                    Price = 46.33m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Tryion.jpg",
                    Calories = 873,
                    Weight = 0.7m,
                    Compliment = "Oh wow, you really tried your hardest on that!"
                },
                new Flummery
                {
                    Id = 4,
                    Name = "Baby Cowboy",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Baby%20Cowboy.jpg",
                    Calories = 912,
                    Weight = 0.5m,
                    Compliment = "That chili would be pretty spicy to an infant."
                },
                new Flummery
                {
                    Id = 5,
                    Name = "Polka",
                    Manufacturer = "Flippery Flumstons",
                    Price = 9.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Polka.jpg",
                    Calories = 2100,
                    Weight = 0.5m,
                    Compliment = "Stylish if your grandparents dressed you."
                },
                new Flummery
                {
                    Id = 6,
                    Name = "Lark on the Wing",
                    Manufacturer = "Full On Flummery",
                    Price = 9.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Lark%20on%20the%20Wing.jpg",
                    Calories = 1792,
                    Weight = 0.5m,
                    Compliment = "What a nice sorting algorithm."
                },
                new Flummery
                {
                    Id = 7,
                    Name = "Scarce Flour",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Scarce%20Flour.jpg",
                    Calories = 1135,
                    Weight = 0.5m,
                    Compliment = "Yeah, that's a nice loaf of quarantine sourdough."
                },
                new Flummery
                {
                    Id = 8,
                    Name = "Flum Jr.",
                    Manufacturer = "Flum For Kids",
                    Price = 4.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Flum%20Jr..jpg",
                    Calories = 465,
                    Weight = 0.2m,
                    Compliment = "What a nice painting! It's going right on the fridge."
                },
                new Flummery
                {
                    Id = 9,
                    Name = "Political HumFlummery",
                    Manufacturer = "Local Government",
                    Price = 52.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Political%20HumFlummery.jpg",
                    Calories = 1325,
                    Weight = 0.1m,
                    Compliment = "You all are the hardworking, salt of the earth type."
                },
                new Flummery
                {
                    Id = 10,
                    Name = "Flawmery",
                    Manufacturer = "Flumm Board for Ethical Flumming",
                    Price = 9.99m,
                    ImageUrl = "https://ecommerceflum.blob.core.windows.net/ecommerceimages/Flawmery.jpg",
                    Calories = 1792,
                    Weight = 0.5m,
                    Compliment = "You're so good at arguing, you should be a lawyer."
                }
            );

            builder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 2,
                    UserId = "63866547-918c-4c25-8d19-16c845d2fa2e"
                },
                new Cart
                {
                    Id = 3,
                    UserId = "cf1833eb-dbd6-42b1-ab9c-cf24382b9d07"
                }
            );

            builder.Entity<CartItem>().HasKey(x => new { x.CartId, x.ProductId });

            builder.Entity<CartItem>().HasData(
                new CartItem
                {
                    CartId = 2,
                    ProductId = 3,
                    Qty = 2
                },
                new CartItem
                {
                    CartId = 2,
                    ProductId = 7,
                    Qty = 4
                },
                new CartItem
                {
                    CartId = 3,
                    ProductId = 1,
                    Qty = 5
                },
                new CartItem
                {
                    CartId = 3,
                    ProductId = 5,
                    Qty = 1
                }
            );

            builder.Entity<OrderCart>().HasData(
                new OrderCart
                { 
                    Id = 1,
                    UserId = "63866547-918c-4c25-8d19-16c845d2fa2e",
                    CartId = 100,
                    FirstName = "John",
                    LastName = "Dickinson",
                    BillingAddress = "1808 Forgotten Way",
                    BillingCity = "Wilmington",
                    BillingState = "DE",
                    BillingZip = "00001",
                    ShippingAddress = "1808 Forgotten Way",
                    ShippingCity = "Wilmington",
                    ShippingState = "DE",
                    ShippingZip = "00001"
                }
            );

            builder.Entity<OrderCartItem>().HasKey(x => new { x.OrderCartId, x.ProductId });

            builder.Entity<OrderCartItem>().HasData(
                new OrderCartItem
                {
                    OrderCartId = 1,
                    ProductId = 3,
                    Qty = 2
                },
                new OrderCartItem
                {
                    OrderCartId = 1,
                    ProductId = 8,
                    Qty = 5
                },
                new OrderCartItem
                {
                    OrderCartId = 1,
                    ProductId = 1,
                    Qty = 3
                }
            );
        }
    }
}
