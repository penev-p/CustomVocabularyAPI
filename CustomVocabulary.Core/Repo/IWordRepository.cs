using CustomVocabulary.Core.Models;
using System.Threading.Tasks;

namespace CustomVocabulary.Core.Repo
{
    //Repository interface for specific model database operations
    //empty for now, but can be helpful in the future
    public interface IWordRepository : IRepository<Word>
    {
        //Task<IEnumerable<Word>> GetAllWordsAsync();
        //Task<Word> GetWordByIdAsync(int wordId);
    }
}
