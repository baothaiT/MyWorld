

using System.Security.Cryptography.X509Certificates;

namespace MyWorld.Infra.Repositories;

public class VocabularyRepository : IVocabularyRepository
{
	private readonly AppDbContext _context;

	public VocabularyRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<List<VocabularyEntity>> GetAllAsync()
	{
		return await _context.Vocabularies.ToListAsync();
	}

	public async Task<VocabularyEntity?> GetByIdAsync(Guid id)
	{
		return await _context.Vocabularies.FindAsync(id);
	}

	public async Task<VocabularyEntity> GetByKeyAsync(string key)
	{
		return await _context.Vocabularies.FirstOrDefaultAsync(
			x => x.Key == key
		);
	}

	public async Task AddAsync(VocabularyEntity vocabulary)
	{
		_context.Vocabularies.Add(vocabulary);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(VocabularyEntity vocabulary)
	{
		_context.Vocabularies.Update(vocabulary);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid id)
	{
		var entity = await _context.Vocabularies.FindAsync(id);
		if (entity != null)
		{
			_context.Vocabularies.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
	
	public async Task DeleteAsync(string key)
	{
		var entity = await _context.Vocabularies.FirstOrDefaultAsync(x => x.Key == key);
		if (entity != null)
		{
			_context.Vocabularies.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
