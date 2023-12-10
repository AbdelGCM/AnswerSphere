using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnswerSphere.Models;

namespace AnswerSphere.Data
{
    public class QuestionContext : DbContext
    {
        public QuestionContext (DbContextOptions<QuestionContext> options)
            : base(options)
        {
        }

        public DbSet<AnswerSphere.Models.Question> Question { get; set; } = default!;
    }
}
