# 🎮 FCG API — FIAP Cloud Games

## 📚 Sobre o Projeto

A **FIAP Cloud Games (FCG)** é uma API REST desenvolvida em **ASP.NET Core 8** para o **Tech Challenge — Fase 1 da FIAP**.

O projeto tem como objetivo criar a base de uma plataforma de jogos digitais, com **usuários, autenticação, jogos e biblioteca de jogos adquiridos**.

Nesta fase, a aplicação utiliza uma **arquitetura monolítica**, conforme solicitado no desafio.

## 🚀 Funcionalidades

- ✅ Cadastro de usuários
- ✅ Validação de e-mail e senha
- ✅ Autenticação com JWT
- ✅ Autorização por níveis de acesso
- ✅ Gerenciamento de usuários
- ✅ Cadastro e consulta de jogos
- ✅ Aquisição de jogos
- ✅ Biblioteca de jogos
- ✅ Swagger / OpenAPI
- ✅ Entity Framework Core + SQLite
- ✅ Migrations
- ✅ Middlewares para erros e logs
- ✅ Testes automatizados

### 👤 Usuário
Cadastro, login, consulta de jogos, aquisição e biblioteca.

### 👑 Administrador
Acesso aos recursos administrativos, como consulta de usuários e gerenciamento de jogos.

## 🏗️ Arquitetura

```text
Fcg.Api
Fcg.Application
Fcg.Domain
Fcg.Infrastructure
Fcg.Tests
```

🏛️ **Monólito com separação de responsabilidades entre as camadas.**

## ⚙️ Tecnologias

- 🟣 .NET 8
- 🌐 ASP.NET Core
- 🗄️ Entity Framework Core
- 💾 SQLite
- 🔐 JWT
- 📖 Swagger
- 🧪 xUnit

## 🛠️ Como Executar

### 📋 Pré-requisitos

- .NET 8 SDK
- Visual Studio 2022 ou Visual Studio Code

### ▶️ Executando o projeto

```bash
git clone URL_DO_REPOSITORIO
cd Fcg_FIAP
dotnet restore
dotnet ef database update
dotnet run --project Fcg.Api
```

📖 Depois, acesse o **Swagger** pela URL apresentada no terminal:

```text
http://localhost:PORTA/swagger
```

## 🔐 Administrador

Para testar os recursos administrativos:

```json
{
  "email": "admin@fcg.com",
  "senha": "Admin@123"
}
```

🔑 Após o login, utilize o token JWT no botão **Authorize** do Swagger.

## 🧪 Testes

Execute:

```bash
dotnet test
```

Ou utilize o **Test Explorer** do Visual Studio.

## 🧠 DDD

O projeto segue princípios de **Domain-Driven Design (DDD)** e possui documentação de **Event Storming** para os fluxos de criação de usuários e jogos.

## 🎓 Tech Challenge — Fase 1

Projeto desenvolvido para o **Tech Challenge da Fase 1 da FIAP**, aplicando conhecimentos de **API REST, persistência, autenticação, autorização, testes e DDD**.

---

❤️ Feito por **Milena**