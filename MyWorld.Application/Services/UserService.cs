
using MyWorld.Application.Interfaces;
using MyWorld.Domain.Repositories;
using Microsoft.Extensions.Logging;
using MyWorld.Application.Helper;

namespace MyWorld.Application.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IVocabularyRepository _vocabularyRepository;

    public UserService(
        IVocabularyRepository vocabularyRepository,
        ILogger<UserService> logger
    )
    {
        _vocabularyRepository = vocabularyRepository;
        _logger = logger;
    }

    public async Task<List<VocabularyEntity>> GetAllVocabulariesAsync()
    {
        return await _vocabularyRepository.GetAllAsync();
    }

    public async Task<VocabularyEntity?> GetVocabularyByIdAsync(int id)
    {
        return await _vocabularyRepository.GetByIdAsync(id);
    }

    public async Task<VocabularyEntity?> GetVocabularyByKeyAsync(string key)
    {
        return await _vocabularyRepository.GetByKeyAsync(key);
    }

    public async Task<BaseResponseView<bool>> AddVocabularyAsync(VocabularyDto vocabulary)
    {
        var vocabularyEntity = new VocabularyHelper(vocabulary).ToEntity();
        await _vocabularyRepository.AddAsync(vocabularyEntity);
        _logger.LogInformation("Vocabulary with key '{Key}' added successfully.", vocabulary.Key);
        return new SuccessResponseView<bool>();
    }

    public async Task UpdateVocabularyAsync(VocabularyEntity vocabulary)
    {
        await _vocabularyRepository.UpdateAsync(vocabulary);
    }

    public async Task DeleteVocabularyAsync(int id)
    {
        await _vocabularyRepository.DeleteAsync(id);
    }

}
