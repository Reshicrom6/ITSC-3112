using Assignment5_2_1.Contracts;
using Assignment5_2_1.Domain;

namespace Assignment5_2_1.Service;

/// <summary>
/// Stores participation categories in memory and enforces unique collection membership.
/// </summary>
public class ParticipationCategoryRepository : IParticipationCategoryRepository
{
    private readonly List<ParticipationCategory> _categories = new();

    /// <inheritdoc />
    public void Add(ParticipationCategory category)
    {
        ArgumentNullException.ThrowIfNull(category);

        if (_categories.Any(existing => existing.Id == category.Id))
        {
            throw new InvalidOperationException($"Category {category.Id} is already managed.");
        }

        _categories.Add(category);
    }

    /// <inheritdoc />
    public ParticipationCategory GetById(Guid id)
    {
        return _categories.Find(category => category.Id == id)
            ?? throw new KeyNotFoundException($"Category {id} was not found.");
    }

    /// <inheritdoc />
    public List<ParticipationCategory> GetAll()
    {
        return new List<ParticipationCategory>(_categories);
    }

    /// <inheritdoc />
    public void UpdateDescription(Guid id, string description)
    {
        ParticipationCategory category = GetById(id);
        category.Description = description;
    }

    /// <inheritdoc />
    public void Delete(Guid id)
    {
        ParticipationCategory category = GetById(id);
        _categories.Remove(category);
    }
}
