## Camadas
- Controllers  -> entrada (HTTP)
- Services     -> regras de negócio
- Repositories -> acesso a dados
- Data         -> contexto do EF
- Domain       -> entidades
- Views        -> interface (MVC + Knockout)

---

##  Design Patterns utilizados

**Repository Pattern**  
Responsável por isolar o acesso ao banco de dados, desacoplando a camada de persistência das regras de negócio.

**Service Layer Pattern**  
Camada responsável por centralizar regras e validações da aplicação, evitando sobrecarga nos controllers.

**Dependency Injection**  
Utilizada para gerenciamento de dependências, evitando instanciamento manual e promovendo baixo acoplamento.

---

## Arquitetura MVC

- **Model** -> Domain/Person  
- **View** -> Views/Person/Index.cshtml  
- **Controller** -> PersonController  

---

##  Frontend com Knockout.js

Neste projeto utilizei o Knockout.js pela primeira vez. Até então, minha experiência no frontend era principalmente com jQuery, realizando manipulação direta dos elementos da tela.
Com o Knockout, tive contato com o conceito de data binding, o que facilitou a sincronização entre os dados e a interface.


A aplicação utiliza MVC no backend e MVVM no frontend com Knockout, além de Repository Pattern, Service Layer e Dependency Injection para organização e desacoplamento.

---

## Como funciona Migration

**Passo a passo, no cmd :** 

dotnet ef migrations add InitialCreate

dotnet ef database update 

***Quando for alterar a entidade*** 

Exemplo: 

adicionou campo

dotnet ef migrations add AddPhone

dotnet ef database update

**Decisões adotadas** 

Utilização de EF Core  para facilitar evolução do banco
Separação em camadas (Controller, Service, Repository) para manter organização e escalabilidade
uso de Knockout.js para aplicar padrão MVVM no front, validações implementadas no Service para centralizar regras de negócio, Uso de Dependency Injection nativa do ASP.NET Core.
