# 🔐 AuthenticationTest

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![Aspire](https://img.shields.io/badge/.NET%20Aspire-purple?style=for-the-badge&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-Authentication-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

> 🚀 Solución de autenticación JWT con .NET Aspire, Blazor Server y Clean Architecture

---

## 📋 Descripción

**AuthenticationTest** es una solución completa de autenticación basada en JWT (JSON Web Tokens) construida con las últimas tecnologías de Microsoft. Utiliza **.NET Aspire** para orquestación de servicios y **Blazor Server** para la interfaz de usuario.

---

## 🏗️ Arquitectura del Proyecto

```
📦 AuthenticationTest
├── 🎯 AuthenticationTest.AppHost                   # Orquestador .NET Aspire
├── 🌐 AuthenticationTest.Web                       # Frontend Blazor Server
├── 🔌 AuthenticationTest.Api                       # API de autenticación
├── ⚡ AuthenticationTest.ApiService                # Servicios API
├── 📚 AuthenticationTest.Application               # Capa de aplicación (lógica de negocio)
├── 🛠️ AuthenticationTest.ServiceDefaults           # Configuraciones compartidas de Aspire
├── 🧪 AuthenticationTest.Tests                     # Tests de integración
└── ✅ AuthenticationTest.Application.Tests.Unit    # Tests unitarios
```

---

## ✨ Características

- 🔑 **Autenticación JWT**    - Sistema seguro de tokens
- 🏢 **Clean Architecture**   - Separación clara de responsabilidades
- ☁️ **.NET Aspire**          - Orquestación y observabilidad cloud-native
- 🎨 **Blazor Server**        - UI interactiva con componentes Razor
- 🧪 **Testing**              - Tests unitarios e integración incluidos
- 📡 **Service Discovery**    - Descubrimiento automático de servicios
- 🔒 **Seguridad**            - Validación de tokens con múltiples parámetros

---

## 🚀 Comenzando

### 📋 Prerrequisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (opcional, para contenedores)

### ⚙️ Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/AuthenticationTest.git
   cd AuthenticationTest
   ```

2. **Restaurar dependencias**
   ```bash
   dotnet restore
   ```

3. **Ejecutar la aplicación**
   ```bash
   dotnet run --project AuthenticationTest.AppHost
   ```

4. **Abrir en el navegador** 🌐
   - Dashboard de Aspire: `https://localhost:15888`
   - Aplicación Web: `https://localhost:5001`

---

## 🔧 Configuración

### 🔐 JWT Settings

Configura los parámetros JWT en `appsettings.json`:

```json
{
  "Jwt": {
    "SecretKey": "tu-clave-secreta-super-segura-de-al-menos-32-caracteres",
    "Issuer": "AuthenticationTest",
    "Audience": "AuthenticationTest.Users"
  }
}
```

---

## 🧪 Ejecutar Tests

```bash
# Todos los tests
dotnet test

# Tests unitarios
dotnet test AuthenticationTest.Application.Tests.Unit

# Tests de integración
dotnet test AuthenticationTest.Tests
```

---

## 📁 Estructura de Capas

| Capa | Proyecto | Responsabilidad |
|------|----------|-----------------|
| 🎯 **Host** | AppHost | Orquestación con .NET Aspire |
| 🌐 **Presentación** | Web | UI con Blazor Server |
| 🔌 **API** | Api, ApiService | Endpoints REST |
| 📚 **Aplicación** | Application | Casos de uso y lógica |
| 🛠️ **Infraestructura** | ServiceDefaults | Configuraciones compartidas |

---

## 🛡️ Seguridad

- ✅ Validación de Issuer y Audience
- ✅ Validación de tiempo de vida del token
- ✅ Clave de firma simétrica
- ✅ ClockSkew configurado a cero
- ✅ Logging de fallos de autenticación

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

---

## 👨‍💻 Autor

Desarrollado con ❤️ usando las últimas tecnologías de Microsoft.

---

<p align="center">
  <img src="https://img.shields.io/badge/Made%20with-C%23-239120?style=flat-square&logo=c-sharp&logoColor=white" alt="Made with C#">
  <img src="https://img.shields.io/badge/Built%20with-.NET%20Aspire-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="Built with .NET Aspire">
</p>
