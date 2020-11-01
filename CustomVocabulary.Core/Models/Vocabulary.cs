using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CustomVocabulary.Core.Models
{
    public class Vocabulary
    {
        /// <summary>
        /// Creates collection of Words for every new Vocabulary
        /// </summary>
        public Vocabulary()
        {
            Words = new Collection<Word>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}
