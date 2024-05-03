# RRSolucoesAuth

Introdução
Esta documentação descreve a API de autenticação que utiliza tokens JWT para autenticar usuários. A aplicação é desenvolvida em .NET 8, utilizando o Identity para gerenciar usuários e roles, migrações do Entity Framework Core para o MySQL e segue os princípios da Clean Architecture para uma estrutura organizada e de fácil manutenção.

# Arquitetura
A arquitetura da aplicação segue o padrão Clean Architecture, dividida em quatro camadas principais: Presentation (API), Application, Domain e Infrastructure.

#### Presentation (API): Responsável por receber as requisições HTTP e enviar as respostas. Contém os controllers da API.
#### Application: Lida com as regras de negócio da aplicação, fazendo uso dos serviços disponíveis na camada de Infrastructure.
#### Domain: Contém as entidades de domínio e as interfaces dos repositórios que definem contratos para operações de persistência.
#### Infrastructure: Implementa as interfaces definidas na camada de Domain. Aqui é onde ocorrem as operações de acesso a dados, como consultas e atualizações no banco de dados e a injenção de dependencia no container DI.

# Configuração do Ambiente
Instale o .NET 8 SDK em sua máquina.
Configure o MySQL.

# Estrutura do Projeto
A estrutura do projeto segue a organização da Clean Architecture, com as soluções:

#### R&RSolucoesFinanceiraAuth.WebApi: Contém os controllers da API.
#### R&RSolucoesFinanceiraAuth.Application: Lógica de aplicação e serviços.
#### R&RSolucoesFinanceiraAuth.Domain: Entidades de domínio e interfaces.
#### R&RSolucoesFinanceiraAuth.Infra.Data: Implementações concretas das interfaces de persistência.
Os arquivos de migração do Entity Framework Core para o MySQL estão na pasta /Migrations.
#### R&RSolucoesFinanceiraAuth.Infra.IoC: Responsavel pela injeção de dependencia no container DI

# Endpoints da API
POST /api/User/register
Cria um novo usuário.
```json 
{
  "email": "user@example.com",
  "password": "string",
  "confirmPassword": "string"
}
```
Response: 200 OK

POST /api/User/login
Autentica o usuário e gera um token JWT.

```json
  { "email": "user@example.com", "password": "Numsei@2024" } 
```

Response: 200 OK + informações do token e do usuário:
```json 
{
  "message": "Mensagem de sucesso",
  "isAuthenticated": true,
  "email": "riverson@user.com",
  "roles": [
    "User",
    "Moderator",
    "Administrator"
  ],
  "token": "token ou refresh token",
  "refreshTokenExpiration": "tempo de expiração do refresh token"
}
```
Response: 200 OK + mensagem de sucesso.

POST /api/User/registerrole
registra perfil de usuário.
```json
{ "name": "string" }
```
Response: 200 OK + mensagem de sucesso.

POST /api/User/addusertorole
adiciona perfil ao usuario.
```json
{
  "email": "string",
  "password": "string",
  "role": "string"
}
```

# Fluxo de Autenticação
##### O usuário se registra na rota /api/User/register.
##### O usuário faz login na rota /api/User/login para obter um token JWT.
##### O token JWT é usado nas requisições subsequentes para acessar recursos protegidos.
