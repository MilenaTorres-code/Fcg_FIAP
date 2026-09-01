# 🎮 FCG API — FIAP Cloud Games

API REST desenvolvida em **ASP.NET Core 8** para o projeto **FIAP Cloud Games (FCG)**.

O projeto tem como objetivo fornecer a base para uma plataforma de venda de jogos digitais e gerenciamento da biblioteca de jogos adquiridos pelos usuários.

A aplicação foi desenvolvida como um **monólito**, conforme solicitado no Tech Challenge da Fase 1, utilizando separação de responsabilidades entre as camadas do projeto.

---

# 📌 Sobre o projeto

A FCG API disponibiliza recursos para:

- Cadastro de usuários;
- Autenticação utilizando JWT;
- Autorização por níveis de acesso;
- Gerenciamento de usuários;
- Cadastro e consulta de jogos;
- Aquisição de jogos;
- Consulta da biblioteca de jogos adquiridos;
- Criação e consulta de promoções;
- Persistência de dados utilizando Entity Framework Core e SQLite.

A aplicação possui dois níveis de acesso:

### 👤 Usuário

O usuário pode:

- realizar cadastro;
- realizar login;
- consultar seu perfil;
- consultar jogos;
- adquirir jogos;
- consultar sua biblioteca;
- consultar promoções.

### 👑 Administrador

O administrador pode:

- consultar usuários;
- cadastrar jogos;
- consultar jogos;
- criar promoções;
- consultar promoções.

Os endpoints administrativos são protegidos utilizando autorização por Role.

---

# 🏗️ Arquitetura

O projeto utiliza uma arquitetura organizada em camadas:

```text
┌─────────────────────────────────┐
│            Fcg.Api              │
│ Controllers / DTOs / Swagger    │
│ HTTP / Autenticação              │
└───────────────┬─────────────────┘
                │
                ↓
┌─────────────────────────────────┐
│        Fcg.Application          │
│ Serviços e interfaces           │
└───────────────┬─────────────────┘
                │
                ↓
┌─────────────────────────────────┐
│           Fcg.Domain            │
│ Entidades / Enums / ValueObjects│
│ Regras de negócio               │
└─────────────────────────────────┘
                ↑
                │
┌───────────────┴─────────────────┐
│       Fcg.Infrastructure        │
│ EF Core / SQLite / Identity     │
│ JWT / Persistência              │
└─────────────────────────────────┘