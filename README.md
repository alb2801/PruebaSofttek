# Prueba Técnica .NET Junior - Softtek

## Descripción

Este proyecto es una solución para la prueba técnica de desarrollador .NET (Backend Junior) solicitada por Softtek.  
Permite registrar y consultar autores y libros, cumpliendo reglas de negocio específicas y buenas prácticas de desarrollo en C# y .NET.

---

## Diagrama de Clases
> ![Diagrama de Clases](Docs/Prueba_Softtek.png)

---

## Estructura del Proyecto

```
PruebaSofttek/           # Backend (.NET API)
│
├── Controllers/         # Controladores de la API
├── Models/
│   ├── Entities/        # Entidades de dominio (Autor, Libro, etc.)
│   ├── DTOs/            # Data Transfer Objects
│   └── Enums/           # Enumeraciones (por ejemplo, Género)
├── Repositories/        # Interfaces y repositorios de datos
├── Services/            # Lógica de negocio e interfaces de servicios
└── Program.cs           # Configuración principal y DI

PruebaFront/             # Frontend (Blazor WebAssembly)
│
├── Pages/               # Páginas Blazor (RegistrarAutor, RegistrarLibro, AutoresYLibros, etc.)
├── Models/DTOs/         # DTOs usados en el frontend
├── Layout/              # Componentes de layout y menú
└── wwwroot/             # Archivos estáticos y recursos
```

---

## Ejecución del Proyecto

### Requisitos

- .NET 6 o superior
- SQL Server (local o remoto)
- Visual Studio 2022 o superior (opcional, pero recomendado)

### Pasos

1. **Clona el repositorio**
2. **Configura la cadena de conexión** en `appsettings.json` del backend.
3. **Restaura paquetes y compila la solución:**
   ```bash
   dotnet restore
   dotnet build
   ```
4. **Ejecuta el backend:**
   ```bash
   dotnet run --project PruebaSofttek/PruebaSofttek.csproj
   ```
5. **Ejecuta el frontend:**
   ```bash
   dotnet run --project PruebaFront/PruebaFront.csproj
   ```
6. **Accede a la aplicación Blazor** en tu navegador (por ejemplo, http://localhost:5000).

---

## Pruebas Realizadas en el Frontend

Se realizaron pruebas manuales para validar la funcionalidad y el manejo de errores:

- **Registro de autores:**  
  - Validación de campos obligatorios y formato de correo.
  - Restricción de longitud de campos.
  - Mensajes claros de éxito y error.

- **Registro de libros:**  
  - Validación de selección de género y autor.
  - Validación de año y número de páginas.
  - Mensajes de error si se supera el máximo de libros por autor o si el autor no existe.

- **Visualización:**  
  - Tablas de autores y libros con datos actualizados.
  - Mensajes informativos si no hay registros.

- **Manejo de errores:**  
  - Se muestran mensajes rojos para errores y verdes para éxitos.
  - Se validan reglas de negocio tanto en frontend como en backend.

---

## Reglas de Negocio Implementadas

- Todos los campos marcados con asterisco (*) son obligatorios.
- No se permite registrar un libro si se supera el máximo permitido por autor.
- No se permite registrar un libro si el autor no existe.
- Validaciones de integridad y formato en todos los campos.

---

## Notas Técnicas

- **Inyección de dependencias** en backend para servicios y repositorios.
- **DTOs** para separar entidades de dominio y datos expuestos.
- **Validaciones** en backend y frontend usando DataAnnotations y validación manual donde es necesario.
- **Manejo de excepciones** y mensajes claros para el usuario.
- **Estructura limpia y modular** siguiendo buenas prácticas de .NET.

---

## Contacto

Desarrollado por: _[Alberth Yecid Cifuentes Pulgarin]_  
Correo: _[alberthpulgarin@gmail.com]_  
Año: 2025

---