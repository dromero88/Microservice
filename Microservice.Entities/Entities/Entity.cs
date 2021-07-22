using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Domain.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
