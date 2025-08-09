using MyWorld.Domain.Entities;

namespace MyWorld.Domain.Repositories;

public interface IVocabularyRepository
{
    public Task<List<VocabularyEntity>> GetAllAsync();
    public Task<VocabularyEntity?> GetByIdAsync(int id);
    public Task<VocabularyEntity> GetByKeyAsync(string key);
    public Task AddAsync(VocabularyEntity vocabulary);
    public Task UpdateAsync(VocabularyEntity vocabulary);
    public Task DeleteAsync(int id);
}
