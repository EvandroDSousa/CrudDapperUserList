# CrudDapperUserList

## Descrição
CrudDapperUserList é uma Web API desenvolvida em **.NET 8**, utilizando **MySQL Server** como banco de dados. O projeto implementa operações **CRUD** (*Create, Read, Update, Delete*) com a biblioteca **Dapper** e segue o padrão **Repository Pattern** para organizar a camada de acesso a dados.

## 🚀 Tecnologias Utilizadas
- 🟣 **.NET 8**
- 🛢️ **MySQL Server**
- ⚡ **Dapper**
- 📂 **Repository Pattern**

## 📌 Importância dos Conceitos Utilizados
### 🔹 CRUD
CRUD é a base de qualquer aplicação que interage com bancos de dados, permitindo a **criação, leitura, atualização e remoção** de registros. Implementá-lo corretamente garante a funcionalidade essencial para manipulação dos dados de um sistema.

### 🔹 Dapper
**Dapper** é um **micro-ORM** que melhora o desempenho das consultas SQL em aplicações .NET. Ele fornece um acesso **rápido e eficiente** ao banco de dados, sendo uma excelente alternativa ao Entity Framework quando a performance é um fator crítico.

### 🔹 Repository Pattern
O **Repository Pattern** ajuda a manter uma estrutura organizada e modular, **separando a lógica de acesso a dados da lógica de negócio**. Isso torna o código mais **reutilizável, testável e fácil de manter**.

## ▶️ Como Executar o Projeto
1. **Clone o repositório:**
   ```sh
   git clone https://github.com/seu-usuario/CrudDapperUserList.git
   ```
2. **Configure a string de conexão** com o MySQL no arquivo `appsettings.json`.
3. **Execute as migrações** para criar as tabelas necessárias.
4. **Inicie a aplicação:**
   ```sh
   dotnet run
   ```

## 📡 Endpoints Disponíveis
- **GET** `/users` - Retorna a lista de usuários.
- **GET** `/users/{id}` - Retorna um usuário pelo ID.
- **POST** `/users` - Adiciona um novo usuário.
- **PUT** `/users/{id}` - Atualiza um usuário existente.
- **DELETE** `/users/{id}` - Remove um usuário.

## 🤝 Contribuição
Contribuições são bem-vindas! Fique à vontade para **abrir issues** e **enviar pull requests**.

## 📜 Créditos
Este projeto foi baseado no vídeo de [@CrislaineLuana](https://github.com/CrislaineLuana).

