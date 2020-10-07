using AutoMapper;
using CustomVocabulary.API.DTOs;
using CustomVocabulary.API.Validators;
using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomVocabulary.API.Controllers
{
    [ApiController]
    [Route("api/vocabularies")]
    public class WordsController : ControllerBase
    {
        public IWordService _wordService;
        public IMapper _mapper;
        public WordsController(IWordService wordService, IMapper mapper)
        {
            _wordService = wordService;
            _mapper = mapper;
        }

        [HttpGet, Route("{vocabularyId}/{wordId}")]
        public async Task<ActionResult<Word>> GetWordById(int wordId)
        {
            var word = await _wordService.GetWordById(wordId);

            if (word == null)
                return NotFound();

            var wordDto = _mapper.Map<Word, WordDto>(word);

            return Ok(wordDto);

        }

        [HttpPost, Route("{vocabularyId}/createword")]
        public async Task<ActionResult<Word>> CreateWord(int vocabularyId, [FromBody] SaveWordDto saveWordDto)
        {
            saveWordDto.VocabularyId = vocabularyId;

            var validator = new SaveWordDtoValidator();
            var validationResult = await validator.ValidateAsync(saveWordDto);

            if (!validationResult.IsValid)
            {
                foreach(ValidationFailure failure in validationResult.Errors)
                {
                    return BadRequest(failure.ErrorMessage);
                }
            }

            var wordToCreate = _mapper.Map<SaveWordDto, Word>(saveWordDto);
            var newWord = await _wordService.CreateWord(wordToCreate);
            var newWordDto = _mapper.Map<Word, WordDto>(newWord);

            return Ok(newWordDto);

        }

        [HttpPut, Route("{vocabularyId}/{wordId}")]
        public async Task<ActionResult<Word>> UpdateWord(int wordId, [FromBody]SaveWordDto saveWordDto)
        {
            var validator = new SaveWordDtoValidator();
            var validationResult = await validator.ValidateAsync(saveWordDto);

            if (!validationResult.IsValid)
            {
                foreach(ValidationFailure failure in validationResult.Errors)
                {
                    return BadRequest(failure.ErrorMessage);
                }
            }

            var wordToupdate = await _wordService.GetWordById(wordId);
            if (wordToupdate == null)
                return NotFound();

            var word = _mapper.Map<SaveWordDto, Word>(saveWordDto);

            await _wordService.UpdateWord(wordToupdate, word);

            var updatedWord = await _wordService.GetWordById(wordId);
            var updatedWordDto = _mapper.Map<Word, WordDto>(updatedWord);

            return Ok(updatedWordDto);
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
