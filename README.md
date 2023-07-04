# Projeto Final - Parte do Back-end! 📝



## ✅ Projeto Proposto:

Sistema Hoteleiro com o foco nas operações do Front Desk.

## ✅ Tecnologias Utilizadas:

- RestAPI
- Microsoft SQL Server 
- Entity Framework
- Consumo da API: Angular


## ✅ Realizado:

Project Hotel Management System 🔻

![Gerenciador](https://github.com/joojubba/Desafio2_Arquivo_WF/assets/89705012/ac18e775-8ad2-4540-9c9c-b4c887711ab4)

![Captura de tela 2023-07-04 163748](https://github.com/joojubba/Desafio2_Arquivo_WF/assets/89705012/13d8fe55-b69d-4c03-ad64-bc7ad6bb5740)

🔸Nesse projeto podemos realizar as operações de criação, leitura, atualização e exclusão (ou CRUD) em: 

- Hóspedes: com os atributos -> Id, Nome, Email, Telefone, Endereço, Data de Nascimento;

- Quartos: com os atributos -> Id, Número de quarto(UH), Capacidade pessoas, Tipo de quartom, Disponibilidade, Descrição e Status (Quarto: Vacant Clean, Blocked, Occupied Clean, Occupied Dirty, Vacant Dirty, No Show, Out of Order, Out of Service);

- Reservas: com os atributos -> Id, data de chegada, data de saída, Angência/Empresa, diárias, Número de pessoas, Total da reserva, Status da reserva ( Reserved, Cancelled, Checked In, CheckedOut, Due Out );

- Tarifas: com os atributos ->  Id, Código de tarifa, Valor da tarifa, descrição;
  
⚠️ Atenção:
- User: Foi possível implementar a autenticação e autorização com Bearer e JWT, porém não foi utilizada de fato, também já foi cadastrado dois perfis de usuário.
- Payment: Foi cadastrada a entidade com os atributos: Id, Valor de pagamento e tipo de pagamento, porém não foi utilizada nesse projeto.

🔸 Nas Controllers:
- Reservations:
No método POST é possível reservar com dados de hóspedes, de tarifas e quartos, onde é feito o cálculo do valor da tarifa pelo número de noites (diárias) do hóspede.

✨ Pontos de melhoria: para esse cálculo coloquei um metódo que usa o tipo da tarifa para calcular o valor total da tarifa (que deixei pré-definido na Context), mas não é muito viável em um projeto maior, tentei outras formas de calcular esse total de reserva, mas apresentou bastante erros. Então, decidi que seria uma melhor alternativa no momento aplicar dessa forma. Além disso, faltou implementar uma ação para impedir que sejam criadas tarifas e quartos toda vez que for reservar.

- Check-In:
É possível verificar as reservas que estão com status de check-in e realizar o procedimento de check-in no POST passando o número do Id da reserva e número do quarto.
- Check-Out:
É possível verificar as reservas que estão com com status de check-out e realizar o procedimento de check-out no POST passando o número do quarto.

✨ Pontos de melhoria: também em um projeto maior, seria mais interessente acrescentar outras formas de realizar esses procedimentos
de forma também funcional.

- Housekeeping:
É possível fazer verificar o status e fazer a alteração de status do quarto  pelo número dele, acredito que seja uma ação mais facilitadora para a governança e a recepção, por exemplo.

🔸 Context:
Gerencia a conexão com o banco de dados. Também deixei pré-definidos os usuários, os quartos e as tarifas para facilitar durante o desenvolvimento do projeto.


📚 Referências: 

- <a href="https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt">Autenticação e Autorização com Bearer e JWT</a>

- <a href="https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio">Tutorial: criar uma API Web com o ASP.NET Core</a>

- <a href="https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/workflows/new-database">Code First para um novo banco de dados</a>

