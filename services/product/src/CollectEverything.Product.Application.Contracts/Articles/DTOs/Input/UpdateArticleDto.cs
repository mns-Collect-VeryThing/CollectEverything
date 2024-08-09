using System;

namespace CollectEverything.Product.Articles.DTOs.Input
{
    public class UpdateArticleDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public int Quantity { get; set; }
    }
}