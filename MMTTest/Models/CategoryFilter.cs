using System;

namespace MMTTest.API.Models
{
    public class CategoryFilter
    {
        public Guid Id { get; set; }
        public string Filter { get; set; }
        public Guid CategoryId { get; set; }
    }
}
