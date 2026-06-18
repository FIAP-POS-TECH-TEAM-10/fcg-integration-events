namespace FCGames.IntegrationEvents;

/// <summary>
/// Publicado por: UsersAPI após commit do cadastro.
/// Consumido por: CatalogAPI (cria biblioteca vazia), NotificationsAPI (log boas-vindas).
/// </summary>
public record UserCreatedEvent(
    Guid UserId,
    string Nome,
    string Email,
    DateTime CreatedAtUtc,
    Guid CorrelationId
);
