using CustomVocabulary.Core;
using CustomVocabulary.Core.Repo;
using CustomVocabulary.Data.Repo;
using System.Threading.Tasks;

namespace CustomVocabulary.Data
{
    //Implementing UoW interface to wrap all repositories in one place
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomVocabularyDbContext _context;
        private VocabularyRepository _vocabularyRepository;
        private WordRepository _wordRepository;

        public UnitOfWork(CustomVocabularyDbContext context)
        {
            _context = context;
        }

        public IVocabularyRepository Vocabularies => _vocabularyRepository = _vocabularyRepository ?? new VocabularyRepository(_context);
        public IWordRepository Words => _wordRepository = _wordRepository ?? new WordRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
