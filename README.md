# ✅ Projeto Trilha .NET API – Entity Framework e Arquitetura em Camadas

## 📚 Sobre o Projeto

Este projeto foi desenvolvido como parte da **Trilha de aprendizado em .NET**, com foco em **API RESTful** estruturada em múltiplas camadas, utilizando o **Entity Framework** para persistência de dados e práticas modernas de desenvolvimento.

O principal objetivo foi criar uma API funcional e escalável para gerenciamento de **tarefas**, com recursos de cadastro, consulta e atualização, respeitando uma separação lógica entre responsabilidades.

---

## 🧱 Estrutura de Camadas da Solução

- `ConsoleApp`: responsável por interações via console (testes manuais e validação básica)
- `Model`: contém as entidades e classes de domínio (ex: Tarefa)
- `Data`: configuração do banco de dados e contexto do Entity Framework
- `Service`: regras de negócio e operações de manipulação dos dados
- `WebAPI`: camada de exposição de dados via endpoints HTTP

---

## 📝 Classe Principal: Tarefa

```csharp
public class Tarefa
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public string Status { get; set; }
}
```

## 🛠️ Tecnologias Utilizadas
* Visual Studio – versão 8.0

* .NET 8.0

* Entity Framework Core – ORM para abstração de dados

* PostgreSQL – Banco de dados relacional

* Swagger – Ferramenta de documentação e teste de endpoints

## 🚀 Como executar o projeto
1. Clone o repositório

2. Abra a solução no Visual Studio

3. Configure a string de conexão ao banco PostgreSQL no appsettings.json

4. Execute as migrações usando o Entity Framework

5. Execute o projeto WebAPI

6. Acesse o Swagger em: http://localhost:{porta}/swagger

## 📤 Finalização
Este projeto foi concluído com sucesso, seguindo as boas práticas de arquitetura em camadas, uso do EF Core, API documentada com Swagger e testes via console e WebAPI.

## 👤 Autora
[Daniela](https://github.com/Daniela2319)
  
