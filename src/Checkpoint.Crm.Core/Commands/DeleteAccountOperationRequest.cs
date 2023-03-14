namespace Checkpoint.Crm.Core.Commands;

/// <summary>
/// Запрос на удаление (коррекцию) операции списания/начисления баллов
/// </summary>
public class DeleteAccountOperationRequest
{
    /// <summary>
    /// Идентификатор операции
    /// </summary>
    public string AccountOperationId { get; set; }
    
    /// <summary>
    /// Пользователь, иницировавший запрос
    /// </summary>
    public string? InitiatorUser { get; set; }
    
    /// <summary>
    /// Внешний идентификатор операции списания
    /// </summary>
    public string? ExternalId { get; set; }
}