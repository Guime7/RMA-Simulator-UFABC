# RMA-Simulator
Simulador da disciplina de gradução Robôs Móveis Autônomos - RMA da UFABC.

A ideia da contribuição foi desenvolver um sensor de colisão/bumper que, quando acionado, gerasse um evento possibilitanto a execução de futuras tarefas, como paralisão do robô.

Para isso, foi incorporado um para-choques na carcaça do robô, com dois sensores expostos na dianteira, para detectar quaisquer contatos frontais. 

Após isso, foi delimitada a área sensível à colisão e adicionado um objeto cúbico no cenário para testar o funcionamento do sensor. 

O script nomeado “BumperSensor.cs” estabelece as regras necessárias para sua operação.