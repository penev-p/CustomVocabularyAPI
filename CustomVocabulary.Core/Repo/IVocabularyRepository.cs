using CustomVocabulary.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.Core.Repo
{
    //Repository interface for specific model database operations
    public interface IVocabularyRepository : IRepository<Vocabulary>
    {
        //Task<IEnumerable<Vocabulary>> GetAllVocabulariesAsync();
        Task<Vocabulary> GetVocabularyWithWordsById(int vocabularyId);
    }
}
