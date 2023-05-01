# ApiConsultarVacinados
Api simples para demonstração de consulta.

O projeto integra com uma Api externa trazendo os resultados dos vacinados.
Existe apenas um único endpoint que faz uma chamada e retorna apenas os dados necessários, podendo até mesmo ser implementado, modificado e inserido atributos de segurança e outros tratamentos, 
este endpoint faz a chamada para uma api externa e atribui ao usuário (Nome e CPF) os dados do retorno em uma base de dados utilizando o orm entity framework e, caso o usuário 
faça uma nova consulta esta será buscada na base de dados pelo fato do usuário já existir, mas caso o usuário não exista um novo request a api externa será feito, a ideia é otimizar
a performance e reduzir o custo por request.
O projeto serve apenas como modelo e exemplo de como pode ser feito uma consulta externa ou criada uma api básica.


