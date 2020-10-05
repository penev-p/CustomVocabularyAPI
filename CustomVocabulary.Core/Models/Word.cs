namespace CustomVocabulary.Core.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VocabularyId { get; set; }
        public virtual Vocabulary Vocabulary { get; set; }
    }
}
