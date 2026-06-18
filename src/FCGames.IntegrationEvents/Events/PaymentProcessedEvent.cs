namespace FCGames.IntegrationEvents;

/// <summary>
/// Publicado por: PaymentsAPI após processar o pagamento.
/// Consumido por: CatalogAPI (Approved → biblioteca; Rejected → pedido rejeitado),
///               NotificationsAPI (log de confirmação ou rejeição).
/// Status: "Approved" | "Rejected"
/// </summary>
public record PaymentProcessedEvent(
    Guid OrderId,
    Guid UserId,
    Guid GameId,
    string GameName,
    decimal Price,
    string Status,
    string? Reason,
    DateTime ProcessedAtUtc,
    Guid CorrelationId
);
