using System;
using GameStoreAPI.Models;
using GameStoreAPI.Models.Enuns;

namespace GameStoreAPI.Models
{
    public class Games
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public Categorys Category { get; set;}
        public Companys Company { get; set;}
        public double Rating { get; set;}
        public DateTime ReleaseDate { get; set;}
        public decimal Price { get; set;}
        public int Amount { get; set;}
    }
}