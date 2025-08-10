using MyWorld.Domain.Entities;

namespace MyWorld.Domain.Repositories;

public interface IVocabularyRepository
{
    public Task<List<VocabularyEntity>> GetAllAsync();
    public Task<VocabularyEntity?> GetByIdAsync(Guid id);
    public Task<VocabularyEntity> GetByKeyAsync(string key);
    public Task AddAsync(VocabularyEntity vocabulary);
    public Task UpdateAsync(VocabularyEntity vocabulary);
    public Task DeleteAsync(Guid id);
    public Task DeleteAsync(string key);
}
