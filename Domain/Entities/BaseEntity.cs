namespace Domain.Entities;

/// <summary>
/// Базовый абстрактный класс сущности.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Дата изменения.
    /// </summary>
    public DateTime? ModifiedDate { get; set; }

    /// <summary>
    /// Переопределение метода для сравнения с другим объектом.
    /// </summary>
    /// <param name="obj">Объект сущности для сравнения.</param>
    /// <returns>bool</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        else if (obj is not BaseEntity entity)
            return false;
        else if (entity.Id != Id)
            return false;
        return true;
    }

    /// <summary>
    /// Переопределение метода для получения хэш-кода объекта.
    /// </summary>
    /// <returns>Хэш-код</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}