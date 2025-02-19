**Sistema de Controle de Gastos Residenciais**

## Objetivo:
    Desenvolver um sistema para controle de gastos residenciais com as seguintes funcionalidades:

    Cadastro de Transações: Registro de receitas e despesas.
    Cadastro de Pessoas: Gerenciamento de pessoas, permitindo criação, listagem e exclusão.
    Consulta de Totais: Visualização do saldo familiar total e do saldo individual.
    Verificação de Idade: Garantir que, para pessoas menores de 18 anos, apenas transações do tipo despesa sejam permitidas.



## Funcionalidades:
    Cadastro de Pessoas:
        Inclusão de novas pessoas.
        Exclusão de pessoas (ao excluir uma pessoa, todas as transações associadas também são removidas).
        Listagem de pessoas cadastradas.
    
    Cadastro de Transações:
        Registro de transações (receitas e despesas).
        Validação que impede transações do tipo receita para pessoas menores de 18 anos.

    Consulta de Saldo:
        Exibição do saldo familiar total (consolidação de receitas e despesas de todas as pessoas).
        Exibição do saldo individual de cada pessoa.

    Listagens:
        Visualização de todas as pessoas cadastradas.
        Visualização de todas as transações registradas.



## Tecnologias Utilizadas:
    Back-end
        Linguagem e Framework:
            C# e .NET

        Banco de Dados:
            SQL Server

        Acesso a Dados:
            Entity Framework (ORM) – utilizado para abstrair a manipulação do banco de dados

    Front-end
        Framework:
            Angular com TypeScript

        Biblioteca de Componentes:
            Angular Material



## Requisitos de Instalação:
    Para executar o projeto, é necessário ter instalados:

        .NET SDK:
            Versão compatível com o projeto (por exemplo, .NET 6 ou .NET 7)

        SQL Server:
            Uma instância local ou remota para o banco de dados

        Node.js e npm:
            Versão atualizada para gerenciar dependências e executar o Angular

        Angular CLI:
            Para criação e execução do projeto Angular

        Angular Material:
            Geralmente instalado via Angular CLI durante a configuração do projeto
        


## Configurações Iniciais:
    Back-end:
        Connection String:
            No arquivo back-end/appsettings.json, atualize a connectionString para apontar para a sua instância local do SQL Server.
       
       Swagger:
        O projeto utiliza Swagger para documentação e testes dos endpoints. Ao iniciar o back-end, acesse a interface do Swagger para visualizar os endpoints disponíveis.
    
    Front-end:
        Dependências:
            Certifique-se de que o projeto Angular possui todas as dependências necessárias (Angular, Angular Material, etc.).

        Iniciar a Aplicação:
            Utilize o comando ng serve --open para iniciar o front-end e visualizar a aplicação no navegador.



## Observações Adicionais:
    ORM (Entity Framework):
        O uso do ORM permite uma abstração eficiente do acesso ao banco de dados, facilitando operações de CRUD e manutenção.

    Validação de Idade:
        A validação para permitir apenas transações de despesa para pessoas menores de 18 anos foi implementada no front-end.

    Atenção: 
        Em um ambiente de produção, recomenda-se também validar essa regra no back-end para maior segurança.

    Documentação dos Endpoints:
        O back-end está configurado com Swagger, permitindo uma documentação interativa dos endpoints.



## Referências:
    Back-end:
        https://www.nuget.org/
    
    Front-end:
        https://v17.angular.io/start
        https://material.angular.io/components/categories
        https://consolelog.com.br/aprenda-o-basico-do-angular-em-alguns-minutos/
        https://www.youtube.com/playlist?list=PLTESsx8-vfPnQ-s4jM-jGrYQMOVg7t1u6
        https://youtu.be/uqkuoZfKxDI?si=tl9vdHx5HfmO63es
        https://youtu.be/rjrQpMYtTUw?si=oLFdNew2GVfdggjg



## Comentários Finais
**Back-end:** Desenvolvido 100% por mim, demonstrando domínio das tecnologias e conceitos necessários.
**Front-end:** Desenvolvido com base em pesquisas e principalmente referências.



*- Artur Morais Brasileiro*