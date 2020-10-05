using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Repo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.Data.Repo
{
    public class VocabularyRepository : Repository<Vocabulary>, IVocabularyRepository
    {
        public VocabularyRepository(CustomVocabularyDbContext context) 
            : base(context)
        { }

        private CustomVocabularyDbContext CustomVocabularyDbContext { get { return _context as CustomVocabularyDbContext; } }

        //public async Task<IEnumerable<Vocabulary>> GetAllVocabulariesAsync()
        //{
        //    return await CustomVocabularyDbContext
        //        .Vocabularies
        //        .ToListAsync();
        //}

        
        public async Task<Vocabulary> GetVocabularyWithWordsById(int vocabularyId)
        {
            return await CustomVocabularyDbContext
                .Vocabularies
                .Include(v => v.Words)
                .SingleOrDefaultAsync(v => v.Id == vocabularyId);
        }
    }
}
