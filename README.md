# 📦 wash-back

Proyecto desarrollado con **ASP.NET Core Web API**, diseñado para administrar tanto los clientes como los ingresos de un lavadero, para así facilitar los pagos y facturación del mismo.

## 🧰 Tecnologías

- .NET Core 8.16
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / Swashbuckle
- AutoMapper
- JWT

## 🚀 Configuración del entorno
lo más importante al clonar el repositorio es generar el appsettings.json y agregarle la respectiva connection string y las variables de configuraicón de jwt, ejemplo:

    "Jwt":
    {
        "SecretKey": "llave secretisima",

        "Issuer": "MiApp",

        "Audience": "MiCliente"
    }

---
### Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)

### Clonar el repositorio

```bash
git clone https://github.com/Yeimss/wash-back
cd wash-back
