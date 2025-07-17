
# 🎉 MeuBuffet - Sistema de Gerenciamento de Buffet

![.NET Core](https://img.shields.io/badge/.NET-8.0-blueviolet)
![C#](https://img.shields.io/badge/C%23-Developer-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Status](https://img.shields.io/badge/status-Em%20Desenvolvimento-yellow)

## 🧠 Sobre o Projeto

O **MeuBuffet** é uma aplicação web desenvolvida com foco no gerenciamento completo de eventos de buffet, com suporte a:

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
MeuBuffet
├── MeuBuffet.API                 # Camada de apresentação (Web API)
├── MeuBuffet.Application        # Casos de uso / comandos e handlers
├── MeuBuffet.Domain             # Entidades, interfaces e regras de negócio
├── MeuBuffet.Infrastructure     # Persistência, serviços externos
├── MeuBuffet.Migrations         # Versões e scripts de banco de dados
└── MeuBuffet.Tests              # Testes unitários com cobertura realista
```

---

## 🚀 Como Executar

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/meubuffet.git
cd meubuffet

# Restaure os pacotes
dotnet restore

# Rode a aplicação
dotnet run --project MeuBuffet.API
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
