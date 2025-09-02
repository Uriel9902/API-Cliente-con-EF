# API Cliente con EF

Este proyecto es una **API RESTful** desarrollada en **.NET** utilizando **Entity Framework** para operaciones CRUD sobre la entidad Cliente.  

---

## 📁 Estructura del proyecto
API Cliente con EF
├─ Controllers
├─ Data
│ -> Models
│ -> AppDbContext.cs
├─ Middlewares
├─ Dtos
├─ Migrations

## 🛠️ Configuración

Clonar el repositorio:

```sh
git clone https://github.com/tu-usuario/API-Cliente-con-EF.git
cd "API Cliente con EF"
```
Antes de ejecutar la aplicación, debes configurar tus credenciales en el archivo appsettings.json:
```js
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=ClientesDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "ApiKey": "MiSuperSecretaApiKey123"
}
 ```

Ejecuta las migraciones de EF Core con :
```sh
Update-Database
```

Para consumirlo en Postman o Fetch usa Headers y agrega 'X-API-KEY':
```sh
Key	        Value
X-API-KEY	  MiSuperSecretaApiKey123
```
