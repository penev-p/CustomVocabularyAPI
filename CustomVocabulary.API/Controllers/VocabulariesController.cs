using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.API.Controllers
{
    [ApiController]
    [Route("api/vocabularies")]
    public class VocabulariesController : ControllerBase
    {
        public IVocabularyService _vocabularyService;

        public VocabulariesController(IVocabularyService vocabularyService)
        {
            _vocabularyService = vocabularyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vocabulary>>> GetAllVocabularies()
        {
            var vocabularies = await _vocabularyService.GetAllVocabularies();
            
            return Ok(vocabularies);
        }
        
        [HttpGet, Route("{vocabularyId}")]
        public async Task<ActionResult<Vocabulary>> GetVocabularyWithWordsById(int vocabularyId)
        {
            var vocabulary = await _vocabularyService.GetVocabularyWithWordsById(vocabularyId);
           
            return Ok(vocabulary);
        }

        [HttpPost, Route("createvocabulary")]
        public async Task<ActionResult<Vocabulary>> CreateVocabulary([FromBody] Vocabulary vocabulary)
        {
            var newVocabulary = await _vocabularyService.CreateVocabulary(vocabulary);
            
            return Ok(newVocabulary);
        }

        [HttpPut, Route("{vocabularyId}")]
        public async Task<ActionResult<Vocabulary>> UpdateVocabulary(int vocabularyId, [FromBody] Vocabulary vocabulary)
        {
            var vocabularyToUpdate = await _vocabularyService.GetVocabularyById(vocabularyId);
            await _vocabularyService.UpdateVocabulary(vocabularyToUpdate, vocabulary);

            var updatedVocabulary = _vocabularyService.GetVocabularyById(vocabularyId);
            
            return Ok(updatedVocabulary);
        }

        [HttpDelete, Route("{vocabularyId}")]
        public async Task<ActionResult> DeleteVocabulary(int vocabularyId)
        {
            var vocabularyToDelete = await _vocabularyService.GetVocabularyById(vocabularyId);
            await _vocabularyService.DeleteVocabulary(vocabularyToDelete);
           
            return NoContent();
        }
    }
}
