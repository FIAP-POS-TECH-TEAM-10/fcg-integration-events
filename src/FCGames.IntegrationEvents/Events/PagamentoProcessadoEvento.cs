namespace FCGames.IntegrationEvents;

/// <summary>
/// Publicado por: PaymentsAPI após processar o pagamento.
/// Consumido por: CatalogAPI (Aprovado → biblioteca; Rejeitado → pedido rejeitado),
///               NotificationsAPI (log de confirmação ou rejeição).
/// Status: "Aprovado" | "Rejeitado"
/// </summary>
public record PagamentoProcessadoEvento(
    Guid PedidoId,
    Guid UsuarioId,
    Guid JogoId,
    string NomeJogo,
    decimal Preco,
    string Status,
    string? Motivo,
    DateTime ProcessadoEmUtc,
    Guid CorrelationId
);
