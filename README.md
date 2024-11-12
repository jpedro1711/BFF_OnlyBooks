# OnlyBooks API Documentation

## Routes - AWS API Gateway

### Empréstimos

- **GET**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Emprestimos`

- **POST (Async)**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Emprestimos`

- **GET BY ID**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Emprestimos/EmprestimosById/{id}`

- **PATCH**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Emprestimos/{id}/{status}`

- **DELETE**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Emprestimos/DeleteEmprestimo/{id}`

---

### Gênero do Livro

- **GET**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/GeneroLivro/listarGeneros`

- **GET BY ID**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/GeneroLivro/{id}`

- **PUT**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/GeneroLivro/{id}`

- **POST**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/GeneroLivro`

- **DELETE**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/GeneroLivro?id={id}`

---

### Reserva

- **GET**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Reserva/listarReservas`

- **GET BY ID**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Reserva/{id}`

- **GET BY USUARIO**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Reserva?userEmail={email}`

- **POST**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Reserva`

- **PATCH**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Reserva/atualizarStatus?id={id}&novoStatus={status}`

---

### Usuário

- **GET**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Usuario`

- **GET BY ID**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Usuario/{id}`

- **PUT**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Usuario/{id}`

- **POST**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Usuario`

- **DELETE**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Usuario/{id}`

---

### Livro

- **GET**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Livro/listarLivros`

- **GET BY ID**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Livro/{id}`

- **PUT**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Livro/{id}`

- **POST**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Livro`

- **DELETE**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Livro?id={id}`

- **PATCH (Status Update)**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Livro/atualizarStatus?id={id}&novoStatus={novoStatus}`

- **PATCH (Rating)**  
  `https://uljstw4930.execute-api.us-east-1.amazonaws.com/prod/Livro/avaliar?id={id}&novaNota={novaNota}`

---

## Swagger Links

- [Swagger do BFF](https://onlybooksbffcontainerapp.yellowocean-3bc779a1.northeurope.azurecontainerapps.io/swagger/index.html)
- [Swagger do micro-serviço](https://onlybookscontainerapp.yellowocean-3bc779a1.northeurope.azurecontainerapps.io/swagger/index.html)

---

## Evidências

- **Requisição no API Gateway**
  - **Request**: Detalhes da solicitação.
  - ![Req](https://evidenciaspjbl.blob.core.windows.net/evidencias/reqEvidencia.png)
  - **Response**: Mensagem enviada para o Service Bus e cadastro assíncrono.
  - ![Req](https://evidenciaspjbl.blob.core.windows.net/evidencias/resEvidencia.png)

- **Dado inserido com sucesso no banco MongoDB**
- ![Req](https://evidenciaspjbl.blob.core.windows.net/evidencias/dadoInserido.png)

---
## Canva
- ![Req](https://evidenciaspjbl.blob.core.windows.net/evidencias/Captura de tela 2024-11-11 205914.png)


## Repositórios GitHub

- **BFF**: [https://github.com/jpedro1711/BFF_OnlyBooks](https://github.com/jpedro1711/BFF_OnlyBooks)
- **Micro-serviço e arq**: [https://github.com/jpedro1711/OnlyBooksApiCleanArchitecture](https://github.com/jpedro1711/OnlyBooksApiCleanArchitecture)
- **Functions**: [https://github.com/jpedro1711/pjbl-arq-software-func-app](https://github.com/jpedro1711/pjbl-arq-software-func-app)

