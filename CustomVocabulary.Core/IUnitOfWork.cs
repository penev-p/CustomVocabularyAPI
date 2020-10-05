using CustomVocabulary.Core.Repo;
using System;
using System.Threading.Tasks;

namespace CustomVocabulary.Core
{
    //Unit of work will keep track of the list of changes during transaction and commiting
    public interface IUnitOfWork : IDisposable
    {
        IVocabularyRepository Vocabularies { get; }
        IWordRepository Words { get; }
        Task<int> CommitAsync();
    }
}
