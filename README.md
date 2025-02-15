Projeto de classificação de operações financeiras

Esse aplicativo Console classifica uma ou mais operações informadas e retorna com o resultado do risco que aquela operação representa de acordo com os parâmetros de categorias cadastrados previamente.

- A classificação ocorre após o usuário informar as características para classificação (data de referência de classificação, quantidade de operrações que serão processadas, e a operação).
- A aplicação está preparada para receber uma a uma as operações e se houver necessidade de processamento em lote ela pode facilmente ser ajustada para leitura de uma arquivo em formato JSON ou outro.
- As regras de categorias existentes podem ser criadas através de um arquivo JSON (já existente na aplicação). Se houver necesidade de incluir ou alterar alguma categoria, basta realizar a alteração no arquivo JSON que a aplicação estará apta a utilizá-lo.

- Observação: com base nas regras iniciais estabelecidas para criação da aplicação não foi possível determinar o alcance das regras de categorias que devem ser utilizadas, mas, as alterações, se for o caso, também são simples de implementar no aplicativo com pequenas mudanças.
