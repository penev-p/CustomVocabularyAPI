using AutoMapper;
using CustomVocabulary.API.DTOs;
using CustomVocabulary.API.Validators;
using CustomVocabulary.Core.Models;
using CustomVocabulary.Core.Services;
using FluentValidation.Results;
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
        public IMapper _mapper;

        public VocabulariesController(IVocabularyService vocabularyService, IMapper mapper)
        {
            _vocabularyService = vocabularyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vocabulary>>> GetAllVocabularies()
        {
            var vocabularies = await _vocabularyService.GetAllVocabularies();
            var vocabulariesDto = _mapper.Map<IEnumerable<Vocabulary>, IEnumerable<VocabularyDto>>(vocabularies);

            return Ok(vocabulariesDto);
   
        }
        
        [HttpGet, Route("{vocabularyId}")]
        public async Task<ActionResult<Vocabulary>> GetVocabularyWithWordsById(int vocabularyId)
        {
            var vocabulary = await _vocabularyService.GetVocabularyWithWordsById(vocabularyId);

            if (vocabulary == null)
                return NotFound();

            var vocabularyDto = _mapper.Map<Vocabulary, VocabularyDto>(vocabulary);

            return Ok(vocabularyDto);
 
        }

        [HttpPost, Route("createvocabulary")]
        public async Task<ActionResult<Vocabulary>> CreateVocabulary([FromBody] SaveVocabularyDto saveVocabularyDto)
        {
            var validator = new SaveVocabularyDtoValidator();
            var validationResult = await validator.ValidateAsync(saveVocabularyDto);

            if (!validationResult.IsValid)
            {
                foreach(ValidationFailure failure in validationResult.Errors)
                {
                    return BadRequest(failure.ErrorMessage);
                }
            }

            var vocabularyToCreate = _mapper.Map<SaveVocabularyDto, Vocabulary>(saveVocabularyDto);
            var newVocabulary = await _vocabularyService.CreateVocabulary(vocabularyToCreate);
            var vocabularyDto = _mapper.Map<Vocabulary, VocabularyDto>(newVocabulary);

            return Ok(vocabularyDto);

        }

        [HttpPut, Route("{vocabularyId}")]
        public async Task<ActionResult<Vocabulary>> UpdateVocabulary(int vocabularyId, [FromBody] SaveVocabularyDto saveVocabularyDto)
        {
            var validator = new SaveVocabularyDtoValidator();
            var validationResult = await validator.ValidateAsync(saveVocabularyDto);

            if (!validationResult.IsValid)
            {
                foreach(ValidationFailure failure in validationResult.Errors)
                {
                    return BadRequest(failure.ErrorMessage);
                }
            }

            var vocabularyToUpdate = await _vocabularyService.GetVocabularyById(vocabularyId);
            if (vocabularyToUpdate == null)
                return NotFound();

            var vocabulary = _mapper.Map<SaveVocabularyDto, Vocabulary>(saveVocabularyDto);
            await _vocabularyService.UpdateVocabulary(vocabularyToUpdate, vocabulary);

            var updatedVocabulary = await _vocabularyService.GetVocabularyById(vocabularyId);
            var updatedVocabularyDto = _mapper.Map<Vocabulary, VocabularyDto>(updatedVocabulary);

            return Ok(updatedVocabularyDto);

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
