using AutoMapper;
using CustomVocabulary.API.DTOs;
using CustomVocabulary.Core.Models;

namespace CustomVocabulary.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Resource
            CreateMap<Vocabulary, VocabularyDto>();
            CreateMap<Word, WordDto>();

            //Resource to Domain
            CreateMap<VocabularyDto, Vocabulary>();
            CreateMap<SaveVocabularyDto, Vocabulary>();

            CreateMap<WordDto, Word>();
            CreateMap<SaveWordDto, Word>();
        }
    }
}
