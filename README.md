![N|Solid](https://aberto.com.br/wp-content/uploads/2018/01/aberto_logo_branco.png)

# Efetuando o combate 🥊🥊🥊

<details>
  <summary>Procedimentos</summary>
  Após o start da aplicação e o MongoDb devidamente conectado.
  Utiliza-se o Postman conforme as imagens:
  
<h3> Para cadastro do Herói 🥋 </h3> 
  
  ![cadastroHeroi](https://user-images.githubusercontent.com/72419533/154506935-6aa7f4af-2774-4ddd-b5cc-cb66a4da894c.PNG)
  
  <h3> Para cadastro do Vilão 🥋 </h3> 
   
  ![cadastroVilao](https://user-images.githubusercontent.com/72419533/154507028-863ed4b7-f3d3-4843-aa75-f8b083fe0048.PNG)
  
 <h3> Realização do combate 🤼‍♀️ </h3> 
  
![combate](https://user-images.githubusercontent.com/72419533/154507076-22ae017e-b374-48e8-824c-40effc7fd504.PNG)

  
</details>

# Teste de recrutamento back-end

<details>
  <summary>Heróis Vs Vilões</summary>
  
 ### Objetivo do teste: 
  - Analisar e compreender o funcionamento da aplicação existente; 
  - Checar se regras e critérios de aceites estão sendo atendidos; 
  - Aplicar boas práticas de desenvolvimento de software; 

 ### Cadastro do personagem: 
 Serão disponibilizados endpoints para o cadastro de heróis ou vilões dos universos Marvel ou DC. 
 
 Regras de negócio:

- O personagem deverá pertencer apenas a um dos universos (Marvel ou DC); 
- Validar se o personagem possui ao menos um poder; 
- O valor do poder do personagem deverá ser maior que zero; 
- Validar se o personagem possui ao menos um ponto fraco;  
- O valor do dano do ponto fraco deverá ser maior que zero; 
- A vida do personagem deve ser um valor maior que zero; 
- Os campos de textos não poderão ter mais que 100 caracteres; 
- Validar se os campos textos foram informados, não sendo possível informar apenas caracteres especiais ou espaços em branco; 

### Funcionamento de combate: 

No endpoint de combate, deverá ser informado os identificadores de dois personagens que irão combater entre si, sendo obrigatório informar um herói e um vilão. 

A batalha consiste em rodadas de ataques, onde em cada rodada um personagem causa um dano ao seu adversário, a batalha só termina quando um dos personagens ou ambos tenham o contador de vida zerado. 

O retorno do endpoint de combate deverá conter a quantidade de rodadas de ataques que aconteceram, a quantidade de vida que restou em cada personagem e se o personagem está vivo ou morto. 


Regras de negócio: 

- Personagens de universos diferentes não poderão batalhar entre si;
Exemplo: Spider-Man (Marvel) Vs Lex Luthor (DC) 
- Personagens que irão batalhar deverão estar previamente cadastrados; 
- A vida restante do personagem não pode ser menor que zero, quando este tiver o status de morto; 
    
</details>

## Onde e como desenvolver? 
Pode ser desenvolvido em qualquer IDE.

## Como realizar a entrega do problema? 

Para entregar a resolução do problema, basta subir em um repositório do seu github. Após isso nos envie o link de seu repósitorio. 

## Considerações finais
O teste será avaliado pelo nosso time e um feedback será enviado para o candidato.
