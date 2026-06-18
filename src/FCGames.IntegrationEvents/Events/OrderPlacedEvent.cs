namespace FCGames.IntegrationEvents;

/// <summary>
/// Publicado por: CatalogAPI ao criar um pedido (após commit).
/// Consumido por: PaymentsAPI (processa o pagamento).
/// </summary>
public record OrderPlacedEvent(
    Guid OrderId,
    Guid UserId,
    Guid GameId,
    string GameName,
    decimal Price,
    DateTime PlacedAtUtc,
    Guid CorrelationId
);
