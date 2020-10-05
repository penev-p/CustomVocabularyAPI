using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Repo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.Data.Repo
{
    public class WordRepository : Repository<Word>, IWordRepository
    {
        public WordRepository(CustomVocabularyDbContext context)
            : base(context)
        { }

        public CustomVocabularyDbContext CustomVocabularyDbContext { get { return _context as CustomVocabularyDbContext; } }

        //public async Task<Word> GetWordByIdAsync(int wordId)
        //{
        //    return await CustomVocabularyDbContext
        //        .Words
        //        .SingleOrDefaultAsync(w => w.Id == wordId);
        //}


        //This method is temorary
        //cause probably there will be no need to get all the words in one place
        public async Task<IEnumerable<Word>> GetAllWordsAsync()
        {
            return await CustomVocabularyDbContext
                .Words
                .ToListAsync();
        }
    }
}
