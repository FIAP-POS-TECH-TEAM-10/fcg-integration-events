# FCGames.IntegrationEvents

Contratos de integração compartilhados entre os microsserviços FCGames.

## Eventos

| Evento | Publicado por | Consumido por |
|--------|--------------|---------------|
| `UsuarioCriadoEvento` | UsersAPI | CatalogAPI, NotificationsAPI |
| `PedidoRealizadoEvento` | CatalogAPI | PaymentsAPI |
| `PagamentoProcessadoEvento` | PaymentsAPI | CatalogAPI, NotificationsAPI |

## Como consumir

### 1. Adicionar `nuget.config` na raiz do seu repositório

Copie o arquivo `nuget.config` deste repo. Configure a variável de ambiente `NUGET_AUTH_TOKEN` com um PAT que tenha o scope `read:packages`.

### 2. Referenciar o pacote no `.csproj`

```xml
<PackageReference Include="FCGames.IntegrationEvents" Version="1.0.0" />
```

### 3. Usar nos consumers/publishers MassTransit

```csharp
using FCGames.IntegrationEvents;

// Publisher (ex: UsersAPI)
await _publishEndpoint.Publish(new UsuarioCriadoEvento(
    UsuarioId: usuario.Id,
    Nome: usuario.Nome,
    Email: usuario.Email,
    CriadoEmUtc: DateTime.UtcNow,
    CorrelationId: Guid.NewGuid()
));

// Consumer (ex: CatalogAPI)
public class UsuarioCriadoConsumer : IConsumer<UsuarioCriadoEvento>
{
    public async Task Consume(ConsumeContext<UsuarioCriadoEvento> context)
    {
        var evt = context.Message;
        // criar biblioteca vazia para evt.UsuarioId
    }
}

// Publisher (ex: CatalogAPI)
await _publishEndpoint.Publish(new PedidoRealizadoEvento(
    PedidoId: pedido.Id,
    UsuarioId: pedido.UsuarioId,
    JogoId: pedido.JogoId,
    NomeJogo: jogo.Nome,
    Preco: pedido.Preco,
    RealizadoEmUtc: DateTime.UtcNow,
    CorrelationId: correlationId
));

// Publisher (ex: PaymentsAPI)
await _publishEndpoint.Publish(new PagamentoProcessadoEvento(
    PedidoId: pagamento.PedidoId,
    UsuarioId: pagamento.UsuarioId,
    JogoId: pagamento.JogoId,
    NomeJogo: pagamento.NomeJogo,
    Preco: pagamento.Valor,
    Status: "Aprovado",   // ou "Rejeitado"
    Motivo: motivo,
    ProcessadoEmUtc: DateTime.UtcNow,
    CorrelationId: correlationId
));
```

## Versionamento

- Push na `main` → publica `1.0.0-preview.<run_number>` (snapshot de desenvolvimento)
- Tag `v1.0.0` → publica `1.0.0` (release estável)

## Regra de ouro

> Nunca altere um campo existente em um evento sem criar uma nova versão do pacote.
> Adicionar campos opcionais (`string? Campo`) é compatível com versões anteriores.
> Remover ou renomear campos é breaking change — bump de major version.
