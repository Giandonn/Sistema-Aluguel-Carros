Sistema Gerenciador de Aluguel de Carros
Descrição
Este sistema gerencia o aluguel de carros, garantindo que as validações necessárias sejam aplicadas e notificações por e-mail sejam enviadas aos clientes. O sistema possui as seguintes funcionalidades principais:

Cada aluguel dura apenas 1 dia.
O carro deve estar disponível na data especificada.
O cliente deve estar ativo para poder realizar o aluguel.
Notificação por e-mail é enviada ao cliente com o status da reserva, seja sucesso ou falha.
Requisitos
.NET 6.0 ou superior
SQL Server LocalDB
Endpoints
POST /carros/
/alugueis
Este endpoint cria um aluguel para o cliente especificado com o carro escolhido.

Parâmetros:

URL: ID do carro a ser alugado.
Corpo da requisição:
ClientId: ID do cliente que irá alugar.
DataHora: Data do aluguel.
Retorno: Um objeto representando o aluguel criado, ou uma mensagem de erro caso haja falha.

Como rodar o projeto
Crie um banco de dados local chamado RentsDB.

Atualize as migrations e rode o projeto:

bash
Copiar código
dotnet ef database update
dotnet run
O sistema estará disponível e pronto para receber requisições.

