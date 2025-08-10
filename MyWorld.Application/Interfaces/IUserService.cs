

namespace MyWorld.Application.Interfaces;

public interface IUserService
{
    public Task<List<VocabularyEntity>> GetAllVocabulariesAsync();
    public Task<VocabularyEntity?> GetVocabularyByKeyAsync(string key);
    public Task<BaseResponseView<bool>> AddVocabularyAsync(VocabularyDto vocabulary);
    public Task<VocabularyEntity?> GetVocabularyByIdAsync(Guid id);
    public Task DeleteVocabularyAsync(Guid id);
    public Task DeleteVocabularyAsync(string key);
}
