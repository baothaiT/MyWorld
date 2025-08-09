using MyWorld.Application.DTOs;
using MyWorld.Domain.Entities;
using System;

namespace MyWorld.Application.Helper;

public class VocabularyHelper
{
    private readonly VocabularyDto _vocabulary;
    private readonly VocabularyEntity _vocabularyEntity;
    public VocabularyHelper(VocabularyDto vocabularyDto)
    {
        _vocabulary = vocabularyDto ?? throw new ArgumentNullException(nameof(vocabularyDto));
    }
    public VocabularyHelper(VocabularyEntity vocabularyEntity)
    {
        _vocabularyEntity = vocabularyEntity ?? throw new ArgumentNullException(nameof(vocabularyEntity));
    }

    public VocabularyEntity ToEntity()
    {
        return new VocabularyEntity
        (
            key: _vocabulary.Key,
            value: _vocabulary.Value
        );
    }
    public VocabularyView ToView()
    {
        return new VocabularyView()
        {
            Key = _vocabularyEntity.Key,
            Value = _vocabularyEntity.Value
        };
    }
}
