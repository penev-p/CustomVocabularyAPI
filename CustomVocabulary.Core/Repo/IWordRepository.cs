using CustomVocabulary.Core.Models;
using System.Threading.Tasks;

namespace CustomVocabulary.Core.Repo
{
    /// <summary>
    /// Repository interface for specific model (Word) database operations empty for now, but will be used in the future
    /// </summary>
    public interface IWordRepository : IRepository<Word>
    {
        //Task<IEnumerable<Word>> GetAllWordsAsync();
        //Task<Word> GetWordByIdAsync(int wordId);
    }
}
