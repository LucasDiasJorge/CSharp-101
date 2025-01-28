# WeatherForecast API

Esta API � uma demonstra��o de uma aplica��o ASP.NET Core que utiliza Entity Framework Core para conectar-se a um banco de dados PostgreSQL e expor endpoints REST para opera��es CRUD na entidade `WeatherForecast`.

---

## Configura��o Inicial

### 1. Instalar ferramentas e pacotes necess�rios

Certifique-se de que voc� tenha o .NET SDK instalado. Para verificar:
```bash
dotnet --version
```

Instale a ferramenta `dotnet-ef` globalmente:
```bash
dotnet tool install --global dotnet-ef
```

Adicione os seguintes pacotes ao projeto:
```bash
dotnet add package Microsoft.EntityFrameworkCore
```
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```
```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

---

### 2. Configurar a string de conex�o no `appsettings.json`

No arquivo `appsettings.json`, adicione a seguinte configura��o:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=MyDatabase;Username=myuser;Password=mypassword"
  },
  "Jwt": {
    "Key": "supersecretkey12345",
    "Issuer": "MyAPI",
    "Audience": "MyAPIUsers"
  }
}
```

Substitua `myuser`, `mypassword`, e `MyDatabase` pelas credenciais do seu banco de dados PostgreSQL.

---

### 3. Criar o banco de dados e aplicar migra��es

1. Gere uma migra��o inicial:
   ```bash
   dotnet ef migrations add InitialCreate
   ```

2. Aplique as migra��es ao banco de dados:
   ```bash
   dotnet ef database update
   ```

---

## Popular o banco de dados

Execute o seguinte script SQL para inserir dados iniciais no banco de dados:

```sql
INSERT INTO "WeatherForecasts" ("Date", "TemperatureC")
VALUES
    ('2025-01-01', -5),
    ('2025-01-02', 5),
    ('2025-01-03', 15),
    ('2025-01-04', 25),
    ('2025-01-05', 35);
```

---

## Testando os Endpoints

### Listar todos os registros

**Endpoint:**
```http
GET /api/weather
```

**cURL:**
```bash
curl -X GET https://localhost:5001/api/weather \
     -H "Authorization: Bearer <SEU_TOKEN_JWT>"
```

---

### Testar conectividade

**Endpoint:**
```http
GET /api/weather/ping
```

**cURL:**
```bash
curl -X GET https://localhost:5001/api/weather/ping
```

---

## Estrutura do Projeto

- **Controllers**: Cont�m os endpoints da API, como o `WeatherForecastController`.
- **Models**: Define a entidade `WeatherForecast`.
- **Data**: Cont�m o contexto do banco de dados (`AppDbContext`).

---

## Configura��o Adicional

Caso queira usar um banco de dados diferente ou configurar autentica��o JWT, atualize os valores correspondentes no `appsettings.json`.

