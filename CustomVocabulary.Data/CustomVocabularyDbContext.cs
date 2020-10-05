using CustomVocabulary.Core.Models;
using CustomVocabulary.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CustomVocabulary.Data
{
    public class CustomVocabularyDbContext : DbContext
    {
        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<Word> Words { get; set; }

        public CustomVocabularyDbContext(DbContextOptions options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new VocabularyConfiguration());
            builder
                .ApplyConfiguration(new WordConfiguration());
        }
        
    }
}
