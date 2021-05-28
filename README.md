# Ambiente de Desenvolvimento

Para o Desenvolvimento da Aplicação foi utilizado o sistema opercional Windows 10

##### IDE's:

* [JetBrains Rider 2021.1.2](https://www.jetbrains.com/pt-br/rider/)
* [WebStorm 2021.1.1](https://www.jetbrains.com/pt-br/webstorm/)

##### Banco de Dados:

* [Banco de Dados Relacional MySQL Community](https://dev.mysql.com/downloads/mysql/)

# Criação da Aplicação

A aplicação foi criada com o auxilio do __Rider__ selecionando a opção ASP.NET Core Web Application deixando selecionado
as opção defaut, selecionando o Angular como Front-End.

#### Dependencias

* Microsoft.AspNetCore.Mvc.NewtonsoftJson (para corrigir erros na serialização json)
* Microsoft.AspNetCore.SpaServices.Extensions (para levantamento da applicação Front-end com Angular)
* Microsoft.EntityFrameworkCore (para todo o gerenciamento dos dados entre applicação e banco de dados)
* Microsoft.EntityFrameworkCore.Tools (fornece ferramentas para a criação das migrations e atualização do banco de
  dados)
* MySql.EntityFrameworkCore (drive MySQL)
* Swashbuckle.AspNetCore (para a configuração do Swagger para a documentação e testes da API)

## Base da Aplicação

Foi criado uma base para as entidades do projeto com:

* IBaseEntity.cs - que estabelece um contrato para ser implementado pelas entidades do projeto, normalmente coloca-se
  nessa interface campos que se repetirão em todas as entidades do projeto, seguindo o principio "ISP — Interface
  Segregation Principle" do SOLID foi definido nessa classe a data de criação do objeto e a data de modificação.
* BaseEntity.cs - que consiste da implementação da IBaseEntity onde define as data corrente para os objetos no ató de
  sua criação.

Com isso o projeto está proto para começar a definir suas entidades.

User - Representa um usuário onde tem 4 campos:

* __Email__ do tipo string que será a primary key da tabela recebendo a notação [key] para o entity framework fazer o
  mapeamento no banco de dados.
* __Name__ do tipo string quer representa o nome do usuário.
* __Document__ do tipo string que representará no nosso sistema um documento de identificação do usuário. no Front-end
  será considerado um CPF.
* __Cards__ do tipo ICollection<Card\> que será onde os cartões do usuário serão armazenados.

Card - Representa um cartão de Credito contendo os atributos do mesmo

* __Id__ do tipo int, é a primary key do cartão
* __Number__ do tipo string, onde é armazenado o número aleatório após sua geração
* __Validate__ do tipo DateTime, onde se define a data de validade do cartão sendo essa estabelecida com 5 anos após a
  geração do cartão
* __SecurityCode__ do tipo int, código de segurança CVV com três digitos
* __UserEmail__ do tipo string, onde faz a amarração do usuário com o cartão, no mapeamento relacional também é
  utilizado a notação  [ForeignKey("User")] para que o entity framework consiga fazer essa ligação com o Usuário
* __User__ do tipo usuário, onde é utilizado no mapeamento do ORM.

####             * Criação do Contexto

Apos a criação do dominio foi definido o DbContext da aplicação que consiste dos dominios que o ORM ficará responsável
por gerenciar. Em seguida foi realizado a configuração do context no Startup da aplicação, para que o .NET gerencie o
contexto conectando-o no MySQL.

####             * MySQL Connector

Com as etapas anteriores concluídas foi adicionado a URI de conexão do MySQL no appsettings.Development.json para que a
aplicação consiga se comunicar com a base de dados.

####             * Criação das Migrations e Atualização do Banco de Dados

Após essas configurações utilizaremos o tools do Entity Framework no terminal para gerar as Migrations seguindo os
seguintes comandos:  
</br>
Add dotnet tools:

```console
dotnet new tool-manifest
```

Install dotnet tools:

```console
dotnet tool install dotnet-ef
```

Criar os scripts de Migração:

```console
dotnet ef migrations add Sample
```

Rodar os scripts para atualizar o banco de dados:

```console
dotnet ef database update
```

####             * Configuração documentação API com Swagger

Depois foi adicionado as configurações do Swagger no Startup.cs onde definisse URI de acesso pelo Browser.

####             * Repositories

Foi criado uma base de classes para abstrair as operações no banco de dados sendo elas compostas por

* __interface IRepository__ onde se define o contrado a ser adotado pela implementação.
* __abstract class RepositoryBase<TEntity, TContext>__ Utilizando de generics para ser extendida pelas classes
  especializadas, implementa-se o contrato com a IRepository.
* __Entidades Especializadas User e Card__ Com a base pronta cada classe deve criar sua interface para estipular os
  contratos especificos e uma classe que implementa esses contratos.

####             * Injeção de Dependências

Foi adicionado nos serviços do Startup as classes para que o Asp.Net Core gerencie as dependencias, sendo assim não
precisaremos instânciar manualmente nossas dependências, deixando a cardo da aplicação as injetar pelo construtor,
fascilitando a criação de testes unitários.

```c#
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<UserService>();
services.AddScoped<ICardRepository, CardRepository>();
services.AddScoped<CardService>();
```

## Regras de Negócio e Criação das API's

Foi adicionado uma camada Service a aplicação para realizar as operações com o banco de dados e implementar o algorítimo
de geração do número aleatório do cartão de crédito.   
Também foi adicionado uma camada Controller onde os endpoints estão armazenado, fazendo o gerenciamento das requisições
Http e devolvendo objetos Json respeitando a arquitetura REST.  
Nossa Api está no 2º nível do __modelo de maturidade de Richardson__ onde temos respostas perssonalizadas para cada tipo
de operação e também a utilização dos verbos HTTP (post, get, delete) para diferenciar o acesso aos endpoints.

####             * Camada de Serviço

Na camada de serviço foi criado um método para cada endpoint fazer a comunicação com o banco de dados, fazendo as
operações solicitadas pelas requisições nos controllers, no CardService.cs há um método com as regras de negócios para a
geração dos números aleatórios do cartão. Nesse método utiliza-se as biblioteca Random e também um StringBuilder para se
criar aleatóriamente os números selecionando aleatóriamente entre os caracteris de '0' a '9'.
<br>
<br>
Pensou-se também em utilizar o algoritmo de Luhn para que a solução se aproximasse da realidade, porém com pouco domínio
da técnologia .NET e com o curto prazo para entrega, cheguei a conclusão de que seria melhor aproveitado o tempo
estudando mais sobre o ambiente Asp.Net Core para conseguir uma solução.

####             * Camada de Controle

Na camada de controle foi desenvolvido 4 endpoints para o usuário, com os recursos:

* Criação de de usuário
* Busca por email, onde já trás do banco de dados todos os cartões cadastrados para o usuário
* Delete, para exclusão de usuário através do seu email.
* Listar todos os usuários
  <br>
  <br>
  Para o Catão foi criados os seguintes endpoints:
    * Criação de cartão, onde é passado uma string com o email do usuário que ficará vinculado ao cartão.
    * Exclusão de cartão passando o Id do cartão que deseja-se excluir.
      <br>
      <br>

####             * Testar a API

O Swagger nos fornece uma fantástica ferramenta com toda a documentação da nossa API, com recursos para fazer
requisições para teste, com isso para testar basta entrar no navegador e fazer a chamada para 
__URL_BASE/swagger/index.html__  


[https://localhost:44333/swagger/index.html](https://localhost:44333/swagger/index.html)

Essa é a tela do Swagger com os endpoints descritos acima.

![Tela Swagger](./Img/swagger.JPG)



