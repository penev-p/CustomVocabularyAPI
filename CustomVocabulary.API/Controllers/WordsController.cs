using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomVocabulary.API.Controllers
{
    [ApiController]
    [Route("api/vocabularies")]
    public class WordsController : ControllerBase
    {
        public IWordService _wordService;
        public WordsController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet, Route("{vocabularyId}/{wordId}")]
        public async Task<ActionResult<Word>> GetWordById(int wordId)
        {
            var word = await _wordService.GetWordById(wordId);
           
            return Ok(word);
        }

        [HttpPost, Route("{vocabularyId}/createword")]
        public async Task<ActionResult<Word>> CreateWord([FromBody]Word word)
        {
            var newWord = await _wordService.CreateWord(word);
            
            return Ok(newWord);

        }

        [HttpPut, Route("{vocabularyId}/{wordId}")]
        public async Task<ActionResult<Word>> UpdateWord(int wordId, [FromBody]Word word)
        {
            var wordToUpdate = await _wordService.GetWordById(wordId);
            await _wordService.UpdateWord(wordToUpdate, word);

            var updatedWord = await _wordService.GetWordById(wordId);

            return Ok(updatedWord);
        }

        [HttpDelete, Route("{vocabularyId}/{wordId}")]
        public async Task<ActionResult<Word>> DeleteWord(int wordId)
        {
            var wordToDelete = await _wordService.GetWordById(wordId);
            await _wordService.DeleteWord(wordToDelete);

            return NoContent();
        }
    }
}
