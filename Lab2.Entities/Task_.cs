using Lab2.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    public class Task_ : BaseEntity
    {

        public DateTime BeginDateTime { get; set; }

        public DateTime DeadlineDateTime { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Requirements { get; set; } = string.Empty;

        public List<User> Users { get; set; } = new();
    }
}
