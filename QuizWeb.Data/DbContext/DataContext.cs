using Microsoft.EntityFrameworkCore;
using QuizWeb.Data.Converters;
using QuizWeb.Data.Entities;

namespace QuizWeb.Data.DbContext
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Challenges { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<AnswerLog> AnswerLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<ExamVersion> ExamVersions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToIntConverter());
                    }
                }
            }
        }
    }
}