using CustomVocabulary.Core.Repo;
using System;
using System.Threading.Tasks;

namespace CustomVocabulary.Core
{
    /// <summary>
    /// Unit of work will keep track of the list of changes during transaction and commiting
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IVocabularyRepository Vocabularies { get; }
        IWordRepository Words { get; }
        Task<int> CommitAsync();
    }
}
