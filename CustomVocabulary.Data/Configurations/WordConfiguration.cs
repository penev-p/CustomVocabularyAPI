using CustomVocabulary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomVocabulary.Data.Configurations
{
    //This method defines models behavior, 
    //it's constraints and relations with our second model 
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder
                .HasKey(w => w.Id);
            builder
                .Property(w => w.Id)
                .UseIdentityColumn();
            builder
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(w => w.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder
                .HasOne(w => w.Vocabulary)
                .WithMany(v => v.Words)
                .HasForeignKey(w => w.VocabularyId);
            builder
                .ToTable("Words");
        }
    }
}
