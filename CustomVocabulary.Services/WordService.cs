using CustomVocabulary.Core;
using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Services;
using System.Threading.Tasks;

namespace CustomVocabulary.Services
{
    /// <summary>
    /// Business logic of the whole app. Controllers -> Services -> UnitOfWork -> DbContext, Repositories
    /// </summary>
    public class WordService : IWordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<Word>> GetAllWords()
        //{
        //    return await _unitOfWork.Words.GetAllAsync();
        //}

        //We implement IWordService with functionality provided by
        //main Repository and UnitOfWork
        public async Task<Word> GetWordById(int wordId)
        {
            return await _unitOfWork.Words.GetByIdAsync(wordId);
        }

        public async Task<Word> CreateWord(Word newWord)
        {
            await _unitOfWork.Words.AddAsync(newWord);
            
            await _unitOfWork.CommitAsync();

            return newWord;
        }

        public async Task UpdateWord(Word wordToUpdate, Word word)
        {
            wordToUpdate.Name = word.Name;
            wordToUpdate.Description = word.Description;

            await _unitOfWork.CommitAsync();
            
        }

        public async Task DeleteWord(Word word)
        {
            _unitOfWork.Words.Remove(word);
            
            await _unitOfWork.CommitAsync();

        }
    }
}
