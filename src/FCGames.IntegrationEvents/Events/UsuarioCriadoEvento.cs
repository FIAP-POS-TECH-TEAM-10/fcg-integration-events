namespace FCGames.IntegrationEvents;

/// <summary>
/// Publicado por: UsersAPI após commit do cadastro.
/// Consumido por: CatalogAPI (cria biblioteca vazia), NotificationsAPI (log boas-vindas).
/// </summary>
public record UsuarioCriadoEvento(
    Guid UsuarioId,
    string Nome,
    string Email,
    DateTime CriadoEmUtc,
    Guid CorrelationId
);
