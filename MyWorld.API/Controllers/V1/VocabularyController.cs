namespace MyWorld.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VocabularyController : ControllerBase
{
    private readonly AppDbContext _context;

    public VocabularyController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetVocabulary()
    {
        var vocabularies = await _context.Vocabularies.ToListAsync();
        return Ok(vocabularies);
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetVocabularyByKey(string key)
    {
        var vocabulary = await _context.Vocabularies
            .FirstOrDefaultAsync(v => v.Key == key);
        if (vocabulary == null)
            return NotFound($"Vocabulary with key '{key}' not found.");
        return Ok(vocabulary);
    }
}

