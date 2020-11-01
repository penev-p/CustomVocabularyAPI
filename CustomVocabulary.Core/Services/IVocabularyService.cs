using CustomVocabulary.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.Core.Services
{
    /// <summary>
    /// Services are going to link our API with the Data. 
    /// This service interfaces purpose is to handle Model logic (Vocabulary)
    /// </summary>
    public interface IVocabularyService
    {
        Task<IEnumerable<Vocabulary>> GetAllVocabularies();
        Task<Vocabulary> GetVocabularyById(int vocabularyId);
        Task<Vocabulary> GetVocabularyWithWordsById(int vocabularyId);
        Task<Vocabulary> CreateVocabulary(Vocabulary newVocabulary);
        Task UpdateVocabulary(Vocabulary vocabularyToUpdate, Vocabulary vocabular);
        Task DeleteVocabulary(Vocabulary vocabulary);
    }
}
