using CustomVocabulary.Core;
using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.Services
{

    /// <summary>
    /// Business logic of the whole app. Controllers -> Services -> UnitOfWork -> DbContext, Repositories
    /// </summary>
    public class VocabularyService : IVocabularyService
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public VocabularyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //We implement IVocabularyService with functionality provided by
        //main Repository, VocabularyRepository and UnitOfWork
        public async Task<IEnumerable<Vocabulary>> GetAllVocabularies()
        {
            return await _unitOfWork.Vocabularies.GetAllAsync();
        }

        public async Task<Vocabulary> GetVocabularyById(int vocabularyId)
        {
            return await _unitOfWork.Vocabularies.GetByIdAsync(vocabularyId);
        }

        //Using method provided by VocabularyRepository to get vocabulary with the list of words
        public async Task<Vocabulary> GetVocabularyWithWordsById(int vocabularyId)
        {
            return await _unitOfWork.Vocabularies.GetVocabularyWithWordsById(vocabularyId);
        }

        public async Task<Vocabulary> CreateVocabulary(Vocabulary newVocabulary)
        {
            await _unitOfWork.Vocabularies.AddAsync(newVocabulary);
            await _unitOfWork.CommitAsync();

            return newVocabulary;
        }

        public async Task UpdateVocabulary(Vocabulary vocabularyToUpdate, Vocabulary vocabulary)
        {
            vocabularyToUpdate.Name = vocabulary.Name;
            vocabularyToUpdate.Description = vocabulary.Description;

            await _unitOfWork.CommitAsync();
            
        }

        public async Task DeleteVocabulary(Vocabulary vocabulary)
        {
             _unitOfWork.Vocabularies.Remove(vocabulary);
            
            await _unitOfWork.CommitAsync();
        }
    }
}
