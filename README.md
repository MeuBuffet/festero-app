
# 🎉 FesteroApp - Sistema de Gerenciamento de Buffet

![.NET Core](https://img.shields.io/badge/.NET-8.0-blueviolet)
![C#](https://img.shields.io/badge/C%23-Developer-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Status](https://img.shields.io/badge/status-Em%20Desenvolvimento-yellow)

## 🧠 Sobre o Projeto

O **FesteroApp** é uma aplicação web desenvolvida com foco no gerenciamento completo de eventos de buffet, com suporte a:

- 🎯 Cadastro de clientes e eventos
- 📅 Controle de datas e reservas
- 🍽️ Escolha de cardápios e pacotes
- 🧾 Geração de relatórios e contratos
- 🔒 Autenticação segura com validação de senha forte e e-mail

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia         | Descrição                                 |
|--------------------|---------------------------------------------|
| 🧱 ASP.NET Core     | Backend RESTful moderno e robusto         |
| 🗃️ Entity Framework | ORM para acesso a dados                    |
| 💾 SQL Server       | Banco de dados relacional principal       |
| 🧪 NUnit + Moq      | Testes unitários e mocks                   |
| 🧰 FluentValidation | Validação declarativa de comandos         |
| 🔐 Identity         | Autenticação e controle de acesso         |

---

## 📁 Estrutura do Projeto

```
FesteroApp
├── FesteroApp.API                 # Camada de apresentação (Web API)
├── FesteroApp.Application        # Casos de uso / comandos e handlers
├── FesteroApp.Domain             # Entidades, interfaces e regras de negócio
├── FesteroApp.Infrastructure     # Persistência, serviços externos
├── FesteroApp.Migrations         # Versões e scripts de banco de dados
└── FesteroApp.Tests              # Testes unitários com cobertura realista
```

---

## 🚀 Como Executar

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/festero-app.git
cd festero-app

# Restaure os pacotes
dotnet restore

# Rode a aplicação
dotnet run --project FesteroApp.API
```

📍 Por padrão, a API estará disponível em: `https://localhost:5001`

---

## 🧪 Rodando os Testes

```bash
dotnet test
```

---

## 📷 Prints (Opcional)

> Inclua aqui prints da interface, Swagger, relatórios, etc.

---

## 🔐 Segurança

- Validação de e-mail e senha forte (`FluentValidation`)
- Tokens JWT para autenticação
- HTTPS habilitado por padrão

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---

## 💡 Observações

- Projeto seguindo princípios de **Clean Architecture** 🧼
- Código testado e versionado com **FluentMigrator** 🧬
