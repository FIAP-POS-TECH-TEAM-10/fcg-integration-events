namespace FCGames.IntegrationEvents;

/// <summary>
/// Publicado por: CatalogAPI ao criar um pedido (após commit).
/// Consumido por: PaymentsAPI (processa o pagamento).
/// </summary>
public record PedidoRealizadoEvento(
    Guid PedidoId,
    Guid UsuarioId,
    Guid JogoId,
    string NomeJogo,
    decimal Preco,
    DateTime RealizadoEmUtc,
    Guid CorrelationId
);
