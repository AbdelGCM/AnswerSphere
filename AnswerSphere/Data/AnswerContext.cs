using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnswerSphere.Models;

namespace AnswerSphere.Data
{
    public class AnswerContext : DbContext
    {
        public AnswerContext (DbContextOptions<AnswerContext> options)
            : base(options)
        {
        }

        public DbSet<AnswerSphere.Models.Reponse> Reponse { get; set; } = default!;
        public DbSet<AnswerSphere.Models.Question> Question { get; set; } = default!;
        public DbSet<AnswerSphere.Models.Option> Option { get; set; } = default!;
    }
}
