using CustomVocabulary.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.Core.Repo
{
    /// <summary>
    /// Repository interface for specific model (Vocabulary) database operations
    /// </summary>
    public interface IVocabularyRepository : IRepository<Vocabulary>
    {
        //Task<IEnumerable<Vocabulary>> GetAllVocabulariesAsync();
        Task<Vocabulary> GetVocabularyWithWordsById(int vocabularyId);
    }
}
