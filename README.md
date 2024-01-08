# Sistema de Reservas de Salas

## Descrição

O Sistema de Reservas de Salas é uma aplicação web que permite aos usuários gerenciar salas e suas respectivas reservas. Ele foi desenvolvido utilizando a tecnologia Blazor, que é um framework da Microsoft para a construção de aplicações web interativas e ricas em recursos.

## Funcionalidades

- Listagem de salas disponíveis.
- Adição, edição e exclusão de salas.
- Visualização de reservas para cada sala.
- Controle de autenticação de usuários.
- Interface amigável e responsiva.

## Tecnologias Utilizadas

- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - Framework para construção de aplicações web com C#.
- [Bootstrap](https://getbootstrap.com/) - Framework front-end para design responsivo.
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Linguagem de programação principal.
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Mapeamento objeto-relacional para interagir com o banco de dados.
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) - Plataforma para a construção de aplicativos modernos e conectados à nuvem.

## Pré-requisitos

- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/download) (versão recomendada)
- Conexão com um banco de dados SQL Server (ou outro suportado pelo Entity Framework Core)

## Instalação

1. Clone o repositório para a sua máquina local.
   ```bash
   git clone https://github.com/seu-usuario/sistema-reservas-salas.git
   
2. Abra o projeto utilizando o Visual Studio ou Visual Studio Code.

3. Configure a conexão com o banco de dados no arquivo appsettings.json.

4. Abra o terminal e navegue até o diretório do projeto.
    ```
    cd sistema-reservas-salas

6. Execute as migrações para criar o banco de dados.
    ```
   dotnet ef database update
   
8. Inicie a aplicação.
   ```
   dotnet run

10. Acesse a aplicação no navegador: https://localhost:"PORT"

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
