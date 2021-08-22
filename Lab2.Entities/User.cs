using Lab2.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Task_> Tasks { get; set; } = new();

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
