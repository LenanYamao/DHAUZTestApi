# DHAUZTestApi

Utilizado um banco de dados do SQL Server local. 


Caso não seja possível testar com um banco de de dados local ou não queira, é possível testar descomentando a linha no program.cs:

  builder.Services.AddDbContext<MovieDbContext>(options => options.UseInMemoryDatabase("MoviesDb"));
  
E comentar a linha:
  
  builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesConnectionString")));
  
Fazer isso irá fazer com que os dados sejam salvos in memory, permitindo testar as chamadas da api mesmo sem um banco de dados local.


Endpoints criados:

- api/Movies/GetAll
  - Parametros: Nenhum
  - Funcionalidade: Busca todos os itens salvos no banco de dados

![image](https://user-images.githubusercontent.com/43767142/178120331-d72e67b6-0b63-4186-a386-973e3168f495.png)


- api/Movies/GetById
  - Parametros: int ID
  - Funcionalidade: Busca o item no banco de dados com o id passado
  
![image](https://user-images.githubusercontent.com/43767142/178120379-fc860595-dd15-4830-9e04-1ca7cf1b2095.png)


- api/Movies/GetByIdImdb
  - Parametros: string IDIMDB
  - Funcionalidade: Busca o item no banco de dados com o id do imdb passado

![image](https://user-images.githubusercontent.com/43767142/178120451-1ce73259-70c9-4136-8b7c-91fa56c1efc5.png)


- api/Movies/Post
  - Parametros: string IDIMDB
  - Funcionalidade: Busca um filme na base do IMDB e salva o filme no banco de dados local

![image](https://user-images.githubusercontent.com/43767142/178120499-1ec303d2-3501-4c95-9b16-7bf8c8039f38.png)


- api/Movies/Put
  - Parametros: 
    {
      int Id,
      string name,
      string description,
      string releaseDate,
      string genre,
      bool watched,
      string userScore
    }
  - Funcionalidade: Altera os dados de um filme no banco de dados local

![image](https://user-images.githubusercontent.com/43767142/178120655-664bbe80-a7cd-4c94-926e-2fc2c2d4e3ed.png)


- api/Movies/Delete
  - Parametros: int Id
  - Funcionalidade: Deleta um item da base de dados local a partir do id
  
![image](https://user-images.githubusercontent.com/43767142/178120887-3e1f9d71-1436-47bc-829b-b79b187eabad.png)

