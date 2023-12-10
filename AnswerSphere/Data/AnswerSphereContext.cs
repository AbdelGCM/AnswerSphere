using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Answersphere.Models;

namespace AnswerSphere.Data
{
    public class AnswerSphereContext : DbContext
    {
        public AnswerSphereContext (DbContextOptions<AnswerSphereContext> options)
            : base(options)
        {
        }

        public DbSet<Answersphere.Models.Question> Question { get; set; } = default!;
        public DbSet<Answersphere.Models.Reponse> Reponse { get; set; } = default!;
        public DbSet<Answersphere.Models.Option> Option { get; set; } = default!;
    }
}
