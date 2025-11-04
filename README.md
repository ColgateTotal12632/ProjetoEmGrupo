# ProjetoDaora 🎯

## 🧩 Descrição

O **ProjetoDaora** é uma aplicação web desenvolvida em **ASP.NET Core MVC**, estruturada com o padrão **Model-View-Controller (MVC)** e integrada ao **Identity** para autenticação e gerenciamento de usuários.  
O objetivo do projeto é servir como base para sistemas web com autenticação, autorização e gerenciamento de dados, proporcionando um exemplo prático de arquitetura MVC moderna no .NET.

---

## 📚 Sumário
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [Instalação e Execução](#-instalação-e-execução)
- [Configuração do Banco de Dados](#-configuração-do-banco-de-dados)
- [Funcionalidades](#-funcionalidades)
- [Exemplo de Uso](#-exemplo-de-uso)
- [Contribuidores](#-contribuidores)
- [Licença](#-licença)

---

## 🛠️ Tecnologias Utilizadas

- **.NET 8+ / ASP.NET Core MVC**
- **Entity Framework Core**
- **Identity (Autenticação e Autorização)**
- **Razor Pages**
- **C#**
- **SQL Server (padrão, configurável via appsettings.json)**

---

## 🗂️ Estrutura do Projeto
ProjetoDaora/
│
├── ProjetoDaora.sln
├── ProjetoDaora/
│ ├── Program.cs
│ ├── appsettings.json
│ ├── appsettings.Development.json
│ ├── Areas/
│ │ └── Identity/
│ │ └── Pages/...
│ ├── Models/
│ ├── Controllers/
│ ├── Views/
│ └── wwwroot/

- **Models/** → Contém as classes de domínio e entidades do banco.  
- **Views/** → Define a camada de apresentação, com páginas Razor (`.cshtml`).  
- **Controllers/** → Controladores responsáveis pelas rotas e lógica de aplicação.  
- **Areas/Identity/** → Contém o sistema de autenticação e gerenciamento de contas.  
- **Program.cs** → Ponto de entrada da aplicação.  
- **appsettings.json** → Configurações gerais e de banco de dados.  

---

## ⚙️ Instalação e Execução

### Pré-requisitos
- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- Visual Studio ou VS Code com suporte a .NET

### Passos

1. **Clone o repositório**
   ```bash
   git clone https://github.com/ColgateTotal12632/ProjetoEmGrupo.git
   cd ProjetoDaora/ProjetoDaora

2. **Restaurar dependências**
   dotnet restore

3. **Configurar o banco de dados**
Edite o arquivo appsettings.json e configure a string de conexão:

"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=ProjetoDaoraDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

4. **Aplicar as migrations e criar o banco**
   dotnet ef database update

5. **Executar o projeto**
   dotnet run

O sistema estará disponível em:
👉 http://localhost:5000

---

### Funcionalidades

• ✅ Cadastro e login de usuários
• 🔐 Recuperação e redefinição de senha
• 🧱 Estrutura MVC modular e escalável
• ⚙️ Configuração simples via appsettings.json
• 🧾 Suporte a roles e políticas de autorização
• 📄 Interface Razor Pages moderna

---

### Exemplo de Uso

Após iniciar o projeto:
• Acesse a página inicial no navegador.
• Clique em Registrar para criar uma nova conta.
• Faça login e explore as seções disponíveis.
• O sistema pode ser estendido facilmente adicionando novos Models, Controllers e Views.

---

### Contribuidores

| Nome    | Função / Papel |
| ------- | -------------- |
| Matheus | Desenvolvedor  |
| Valdir  | Desenvolvedor  |
| Diogo   | Desenvolvedor  |
| Eduardo | Desenvolvedor  |
| Rian    | Desenvolvedor  |

---

### Licença

Este projeto não possui licença definida no momento.
Sinta-se à vontade para utilizá-lo como base para estudos ou desenvolvimento de aplicações similares.

---

### Observações

• O projeto segue boas práticas do padrão MVC e pode ser expandido com novas funcionalidades.
• Para deploy em produção, configure variáveis de ambiente e use HTTPS.
• Caso utilize outro banco de dados (ex: MySQL, PostgreSQL), ajuste o DbContext e a string de conexão.

---

### Desenvolvido com 💙 pela equipe ProjetoDaora
