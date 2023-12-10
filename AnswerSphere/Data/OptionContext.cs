using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnswerSphere.Models;

namespace AnswerSphere.Data
{
    public class OptionContext : DbContext
    {
        public OptionContext (DbContextOptions<OptionContext> options)
            : base(options)
        {
        }

        public DbSet<AnswerSphere.Models.Option> Option { get; set; } = default!;
    }
}
