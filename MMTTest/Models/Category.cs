using System;
using System.Collections.Generic;

namespace MMTTest.API.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CategoryFilter> Filters { get; set; }
    }
}
