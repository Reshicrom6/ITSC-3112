using Assignment5_2_1.Domain;

namespace Assignment5_2_1.Contracts;

/// <summary>
/// Defines in-memory CRUD operations for participation categories.
/// </summary>
public interface IParticipationCategoryRepository
{
    /// <summary>
    /// Adds one category while preserving identifier uniqueness.
    /// </summary>
    /// <param name="category">The valid category to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the category is null.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the identifier is already managed.
    /// </exception>
    void Add(ParticipationCategory category);

    /// <summary>
    /// Retrieves one category by identifier.
    /// </summary>
    /// <param name="id">The identifier to locate.</param>
    /// <returns>The matching category.</returns>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    ParticipationCategory GetById(Guid id);

    /// <summary>
    /// Gets a copy of all managed categories.
    /// </summary>
    /// <returns>A new list containing the managed categories.</returns>
    List<ParticipationCategory> GetAll();

    /// <summary>
    /// Changes the description of one managed category.
    /// </summary>
    /// <param name="id">The identifier of the category to update.</param>
    /// <param name="description">The replacement description.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    void UpdateDescription(Guid id, string description);

    /// <summary>
    /// Removes one managed category.
    /// </summary>
    /// <param name="id">The identifier of the category to remove.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when the identifier is not managed.
    /// </exception>
    void Delete(Guid id);
}
