﻿using Microsoft.EntityFrameworkCore;
using W9_assignment_template.Models;
using Microsoft.Extensions.Configuration;

namespace W9_assignment_template.Data;

public class GameContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Character> Characters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer("Server=bitsql.wctc.edu; Database=EFCoreIntro_SilasStowe; User Id=mstowe3; Password=000557664;");
        }

    // Seed Method
    public void Seed()
    {
        if (!Rooms.Any())
        {
            var room1 = new Room { Name = "Entrance Hall", Description = "The main entry." };
            var room2 = new Room { Name = "Treasure Room", Description = "A room filled with treasures." };

            var character1 = new Character { Name = "Knight", Level = 1, Room = room1 };
            var character2 = new Character { Name = "Wizard", Level = 2, Room = room2 };

            Rooms.AddRange(room1, room2);
            Characters.AddRange(character1, character2);

            SaveChanges();
        }
    }
}