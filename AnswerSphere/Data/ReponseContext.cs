using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnswerSphere.Models;

namespace AnswerSphere.Data
{
    public class ReponseContext : DbContext
    {
        public ReponseContext (DbContextOptions<ReponseContext> options)
            : base(options)
        {
        }

        public DbSet<AnswerSphere.Models.Reponse> Reponse { get; set; } = default!;
    }
}
