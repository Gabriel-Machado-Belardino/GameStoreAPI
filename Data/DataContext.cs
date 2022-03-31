using Microsoft.EntityFrameworkCore;
using GameStoreAPI.Models;
using GameStoreAPI.Models.Enuns;

namespace GameStoreAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {
            
        }

        public DbSet<Games> games { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>().HasData
            (
                new Games() { Id = 1, Name = "The Witcher 3: Wild Hunt", ReleaseDate = System.DateTime.Parse("18/05/2015"), Category = Categorys.Simulação ,Company = {Id = 1, Name = "CdProject"}, Price = 10.90M, Amount = 50, Rating = 4.9},
                new Games() { Id = 2, Name = "Grand Theft Auto V", ReleaseDate = System.DateTime.Parse("17/09/2013"), Category = Categorys.Simulação , Company =  {Id = 2, Name = "Rockstar Games"}, Price = 10.90M, Amount = 32, Rating = 4.7},
                new Games() { Id = 3, Name = "The Last of Us", ReleaseDate = System.DateTime.Parse("14/06/2013"), Category = Categorys.Aventura , Company =  {Id = 3, Name = "Sony"}, Price = 10.90M, Amount = 80, Rating = 4.9},
                new Games() { Id = 4, Name = "Super Smash Bros. Ultimate", ReleaseDate = System.DateTime.Parse("07/12/2018"), Category = Categorys.Luta , Company =  {Id = 4, Name = "Nintendo"}, Price = 10.90M, Amount = 1, Rating = 4.9},
                new Games() { Id = 5, Name = "God of War 4", ReleaseDate = System.DateTime.Parse("20/04/2018"), Category = Categorys.Aventura , Company =  {Id = 3, Name = "Sony"}, Price = 10.90M, Amount = 1, Rating = 4.8},
                new Games() { Id = 6, Name = "Portal 2", ReleaseDate = System.DateTime.Parse("18/04/2011"), Category = Categorys.Puzzle , Company =  {Id = 5, Name = "Valve"}, Price = 10.90M, Amount = 1, Rating = 4.9},
                new Games() { Id = 7, Name = "Red Dead Redemption", ReleaseDate = System.DateTime.Parse("18/05/2010"), Category = Categorys.Aventura , Company =  {Id = 2, Name = "Rockstar Games"}, Price = 10.90M, Amount = 1, Rating = 4.8},
                new Games() { Id = 8, Name = "Overwatch", ReleaseDate = System.DateTime.Parse("03/05/2016"), Category = Categorys.Ação , Company =  {Id = 6, Name = "Blizzard"}, Price = 10.90M, Amount = 1, Rating = 4.5},
                new Games() { Id = 9, Name = "Shadow of the Colossus", ReleaseDate = System.DateTime.Parse("18/10/2005"), Category = Categorys.Aventura , Company =  {Id = 3, Name = "Sony"}, Price = 10.90M, Amount = 1, Rating = 4.9},
                new Games() { Id = 10, Name = "Fallout 4", ReleaseDate = System.DateTime.Parse("10/11/2015"), Category = Categorys.RPG , Company =  {Id = 7, Name = "Bethesda Game Studios"}, Price = 10.90M, Amount = 1, Rating = 4.6}
                
            );
        }

    }
}