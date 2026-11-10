# FCGames.IntegrationEvents

Pacote NuGet com os contratos dos eventos trocados entre os serviços do FCGames. É a única fonte
desses records: os serviços referenciam o pacote, nunca copiam as classes.

## Eventos

Namespace `FCGames.IntegrationEvents` (o MassTransit roteia pelo namespace + nome do tipo).

| Evento | Campos | Publica | Consome |
|---|---|---|---|
| `UsuarioCriadoEvento` | `UsuarioId`, `Nome`, `Email`, `CriadoEmUtc`, `CorrelationId` | users | catalog, notificações |
| `PedidoRealizadoEvento` | `PedidoId`, `UsuarioId`, `JogoId`, `NomeJogo`, `Preco`, `RealizadoEmUtc`, `CorrelationId` | catalog | payments |
| `PagamentoProcessadoEvento` | `PedidoId`, `UsuarioId`, `JogoId`, `NomeJogo`, `Preco`, `Status` (`Aprovado` \| `Rejeitado`), `Motivo?`, `ProcessadoEmUtc`, `CorrelationId` | payments | catalog, notificações |

"Notificações" é a Lambda `fcg-notifications-lambda` na AWS e o worker `fcg-notifications-api` no
`docker-compose` local.

## Como consumir

1. Copie o `nuget.config` deste repositório para a raiz do serviço.
2. Defina `NUGET_AUTH_TOKEN` com um token do GitHub com permissão `read:packages`
   (localmente: `NUGET_AUTH_TOKEN=$(gh auth token)` depois de `gh auth refresh -s read:packages`).
3. Referencie a versão em uso hoje:

```xml
<PackageReference Include="FCGames.IntegrationEvents" Version="1.0.0-preview.2" />
```

## Versionamento

O workflow `publish.yml` publica no GitHub Packages da organização:

- push na `main` → `1.0.0-preview.<run_number>`
- tag `v*.*.*` (ex.: `v1.0.0`) → a versão da tag

Ainda não há versão estável: todos os serviços usam `1.0.0-preview.2`.

Adicionar campo opcional é compatível. Renomear ou remover campo quebra os consumidores: exige
nova versão maior e atualização de todos os serviços.
