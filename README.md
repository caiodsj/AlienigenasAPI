## Grupo 3

### Autores:
- [Caio Diego](https://github.com/caiodsj)
- [Paulo Lisboa](https://github.com/paulolisboa38)
- [Raphael C. Teodoro](https://github.com/raphael-teodoro)
- [Raul Henrique Furtado](https://github.com/Raulbjj928)


# AlienigenasAPI 🛸
Sistema de Controle de Alienígenas.

## Descrição

AlienigenasAPI é uma API REST desenvolvida em .NET 7.0 para gerenciar informações sobre alienígenas, planetas, e os poderes que esses seres podem possuir.


## Tecnologias Utilizadas

- .NET 7.0
- Entity Framework Core
- SQL Server

## Como Rodar o Projeto com Visual Studio 2022

1. **Clone o repositório**

    ```sh
    git clone https://github.com/SeuUsuario/AlienigenasAPI.git
    ```

2. **Abra o projeto no Visual Studio**

    - Abra o Visual Studio 2022.
    - Vá para `File > Open > Project/Solution`.
    - Navegue até o diretório onde você clonou o projeto e selecione o arquivo `.sln`.

3. **Restaure os pacotes NuGet**

    - No Visual Studio, você verá uma notificação para restaurar os pacotes NuGet ou
    - Diretamente, você pode clicar com o botão direito do mouse no nome do projeto e selecionar `Restore NuGet Packages`.

4. **Configure o Banco de Dados**

    - Verifique se as configurações do banco de dados em `appsettings.json` estão corretas.

5. **Compile e Rode o Projeto**

    - Pressione `F5` para compilar e rodar o projeto.
    - O Visual Studio irá compilar o projeto e abrir o navegador, mostrando a API rodando.

6. **Comece a Usar a API**

    - Use a URL fornecida pelo navegador para começar a interagir com a API.
    

## Endpoints

### Alienígenas

- `GET /api/aliens`: Retorna todos os alienígenas.
- `GET /api/aliens/{id}`: Retorna o alienígena por um ID específico.
- `GET /api/aliens/{id}/poderes`: Retorna todos os poderes de um alienígena específico.
- `POST /api/aliens`: Adiciona um novo alienígena.
- `POST /api/aliens/{id}/poderes/{idPoder}`: Adiciona um poder específico a um alienígena específico.
- `PUT /api/aliens/{id}`: Atualiza um alienígena específico.
- `DELETE /api/aliens/{id}`: Remove um alienígena específico.
- `DELETE /api/aliens/{id}/poderes/{idPoder}`: Remove um poder específico de um alienígena específico.


### Planetas

- `GET /api/planetas`: Retorna todos os planetas existentes.
- `GET /api/planetas/{id}`: Retorna um planeta específico com base no ID.
- `GET /api/planetas/nome/{nome}`: Retorna todos os planetas com um nome específico.
- `POST /api/planetas`: Cria um novo planeta.
- `PUT /api/planetas/{id}`: Atualiza um planeta específico com base no ID.
- `DELETE /api/planetas/{id}`: Remove um planeta específico com base no ID.


### Poderes

- `GET /api/poderes`: Retorna todos os poderes disponíveis.
- `GET /api/poderes/{id}`: Retorna um poder específico com base no ID.
- `POST /api/poderes`: Cria um novo poder.
- `PUT /api/poderes`: Atualiza um poder existente com base no ID.
- `DELETE /api/poderes`: Remove um poder específico com base no ID.


### Terra

#### Aliens na Terra

- `GET /api/terra/BuscarAliens`: Retorna uma lista de todos os aliens que estão atualmente na Terra.
- `GET /api/terra/BuscarAlienPorId/{id}`: Retorna informações de um alien específico que está na Terra, baseado no seu ID.
- `GET /api/terra/BuscarAliensPorPlanetaId/{planetaId}`: Retorna uma lista de aliens que são originários de um planeta específico e estão atualmente na Terra.
- `GET /api/terra/BuscarAliensPorEspecie/{especie}`: Retorna uma lista de aliens que pertencem a uma espécie específica e estão atualmente na Terra.
- `GET /api/terra/BuscarAliensPorNome/{nome}`: Retorna uma lista de aliens que têm um nome específico e estão atualmente na Terra.

#### Controle de Entrada e Saída

- `PUT /api/terra/EntradaNaTerra/{id}`: Registra a entrada de um alien específico na Terra.
- `PUT /api/terra/SaidaDaTerra/{id}`: Registra a saída de um alien específico da Terra.


## Contribuindo

Sinta-se à vontade para abrir um problema ou enviar um pull request. Todas as contribuições são bem-vindas!

## Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.


