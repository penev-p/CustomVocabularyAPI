using CustomVocabulary.Core.Models;
using System.Threading.Tasks;

namespace CustomVocabulary.Core.Services
{
    /// <summary>
    /// Services are going to link our API with the Data.
    /// This service interfaces purpose is to handle Model logic (Word)
    /// </summary>
    public interface IWordService
    {
        //Task<IEnumerable<Word>> GetAllWords();
        Task<Word> GetWordById(int wordId);
        Task<Word> CreateWord(Word newWord);
        Task UpdateWord(Word wordToUpdate, Word word);
        Task DeleteWord(Word word);
    }
}
