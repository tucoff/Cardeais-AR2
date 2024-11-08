Battle Card Game com Unity e Vuforia - Segunda Entrega

Este é um complemento ao projeto inicial, que busca aprimorar o sistema de batalhas e as ferramentas de suporte do jogo, mantendo o foco na experiência imersiva de realidade aumentada. A segunda entrega traz melhorias significativas para o desenvolvimento e a experiência de jogo.

Melhorias e Funcionalidades da Segunda Entrega

Esta atualização foca no sistema de batalhas e em ajustes visuais e funcionais para aprimorar a jogabilidade e a clareza do posicionamento das cartas:

Modelos 3D como Próprias Cartas: Nesta versão, os modelos tridimensionais são representações das próprias cartas, criando uma integração visual mais coesa e intuitiva.

Campo com Visualização Traseira: O campo de jogo agora exibe a parte de trás das cartas, o que facilita ao jogador identificar o local exato onde deve posicionar suas cartas durante a partida. Esse recurso adiciona uma camada de orientação visual para melhorar o entendimento espacial e a precisão no jogo.

![image](https://github.com/user-attachments/assets/04d782bf-ef60-42fd-903f-9240e2135f19)

Img4.: Demonstração campos mostrando o lado inverso. Além disso podemos ver nessa imagem a interface nova, onde os botões de suporte estão sendo representados por letras, as quais significam:

1) T: Randomizar turno, roda para selecionar quem será o primeiro a jogar,
   
2) R: Mostrar registro de todas as rodadas, é contabilizado uma rodada nova a cada turno que passa, mostra cartas que estão em cada posição do jogador do turno, se atacou alguém, quem foi esse jogador, o dano causado, habilidades usadas e a vida final de todos os campos nessa rodada.

3) A: Botão de atacar, seleciona quem que vai ser atacado, não podendo atacar a si mesmo. Obs.: O Counter é utilizado automaticamente caso ocorra, não necessitando de botões para controlar, esse movimento acontece quando alguma carta na posição de defesa é atacada e não morre.

4) F: Finalizar o turno, também passando a rodada, salvando tudo que aconteceu no registro. Além das batalhas e dos botões, foi adicionado uma função que mostra informações da carta assim que ela é detectada pelo Vuforia, essa função é importante pois algumas regras que estão escritas nas próprias cartas foram modificadas por questões de balanceamento e melhorias no jogo, então na versão digital após escanear, mostrará a habilidade atualizada. Outras questões tipo vida e dano também foram modificadas ou tem regras específicas que a versão digital corrige.

![image](https://github.com/user-attachments/assets/7210b01b-8515-4ac3-a4bd-4fe6396c291b)

Img5.: Tela de registro, mostrando tudo que aconteceu desde o primeiro round, a tela tem scroll então é possível deslizar para visualizar os registros mais antigos.

![image](https://github.com/user-attachments/assets/aada1f68-f484-4bc8-bea4-670dfe1785e1)

Img6.: Visualizador de informações da carta detectada, em branco o nome, em verde a vida, em vermelho o dano e em amarelo a habilidade especial da carta.

![image](https://github.com/user-attachments/assets/f341719f-3612-4a87-98ad-37d222ca61e5)

Img7 e Img8.: As duas imagens foram “printadas” no mesmo momento, sendo possível mostrar a comparação do que está acontecendo no mundo real e o que é visualizado no mundo digital, respectivamente.
