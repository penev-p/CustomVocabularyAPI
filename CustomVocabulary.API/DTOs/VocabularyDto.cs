using System.Collections.Generic;

namespace CustomVocabulary.API.DTOs
{
    public class VocabularyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<WordDto> Words { get; set; }

    }
}
