using MyWorld.Application.DTOs;
using MyWorld.Application.Interfaces;

namespace MyWorld.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VocabularyController : ControllerBase
{

    public VocabularyController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetVocabulary(
        [FromServices] IUserService service
    )
    {
        var vocabularies = await service.GetAllVocabulariesAsync();
        return Ok(vocabularies);
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetVocabularyByKey(
        [FromRoute] string key,
        [FromServices] IUserService service
        )
    {
        var vocabulary = await service.GetVocabularyByKeyAsync(key);
        if (vocabulary == null)
            return NotFound($"Vocabulary with key '{key}' not found.");
        return Ok(vocabulary);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] VocabularyDto vocabulary,
        [FromServices] IUserService service
    )
        => Ok(await service.AddVocabularyAsync(vocabulary));

    [HttpPut("{vocabularyKey}")]
    public async Task<IActionResult> Update(
        [FromRoute] string vocabularyKey,
        [FromBody] VocabularyDto vocabulary,
        [FromServices] IUserService service
    )
    {
        vocabulary.Key = vocabularyKey;
        return Ok(await service.AddVocabularyAsync(vocabulary));
    }

    [HttpDelete("{key}:vocabularyKey")]
    public async Task<IActionResult> DeleteByKey(
        [FromRoute] string key,
        [FromServices] IUserService service
    )
    {
        await service.DeleteVocabularyAsync(key);
        return NoContent();
    }

    [HttpDelete("{id}:vocabularyId")]
    public async Task<IActionResult> DeleteById(
        [FromRoute] string key,
        [FromServices] IUserService service
    )
    {
        await service.DeleteVocabularyAsync(key);
        return NoContent();
    }
}

