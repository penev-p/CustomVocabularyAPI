using CustomVocabulary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomVocabulary.Data.Configurations
{
    /// <summary>
    /// This class defines models behavior (Vocabulary), it's constraints and relations with our second model (Word) 
    /// </summary>
    public class VocabularyConfiguration : IEntityTypeConfiguration<Vocabulary>
    {
        public void Configure(EntityTypeBuilder<Vocabulary> builder)
        {
            builder
                .HasKey(v => v.Id);
            builder
                .Property(v => v.Id)
                .UseIdentityColumn();
            builder
                .Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder
                .ToTable("Vocabularies");
        }
    }
}
