# Pregunta 1, parte 2: gimnasio

Rama local: `feat/Pregunta1-parte2`.

## Ejecutar en esta computadora

Abra PowerShell y ejecute:

```powershell
cd C:\Users\Ronald\Documents\ChatGPT\tareas\DSWI_T1_04
& "$env:USERPROFILE\.dotnet\dotnet.exe" run --launch-profile http
```

Abra http://localhost:5048/Gimnasio en el navegador. Detenga la aplicación con Ctrl+C en la terminal. Si ya está ejecutándose, abra directamente la dirección sin iniciar una segunda instancia.

El proyecto requiere el SDK de .NET 10. En esta computadora se instaló en `C:\Users\Ronald\.dotnet`; el comando anterior lo selecciona explícitamente porque el comando global `dotnet` todavía apunta a .NET 8. En otra computadora con .NET 10 disponible puede usar `dotnet run --launch-profile http`.

El cálculo del gimnasio no usa base de datos. Las pantallas de Clientes y Pedidos tienen su propia configuración de SQL Server.

## Casos para comprobar manualmente

| Edad | Meses | Tarifa mensual | Descuento | Total |
| --- | --- | --- | --- | --- |
| 17 | 3 | $20.00 | 5 % ($3.00) | $57.00 |
| 18 | 3 | $35.00 | 5 % ($5.25) | $99.75 |
| 59 | 6 | $35.00 | 10 % ($21.00) | $189.00 |
| 60 | 12 | $25.00 | 20 % ($60.00) | $240.00 |
| 30 | 4 | $35.00 | 0 % ($0.00) | $140.00 |

Compruebe también campos vacíos, edad negativa y meses iguales a cero: deben rechazarse. El botón Limpiar abre un formulario vacío.

La tarifa mensual depende de la edad. El subtotal es tarifa por meses; el descuento se aplica sobre ese subtotal. Los descuentos corresponden exactamente a 3, 6 o 12 meses; cualquier otra duración tiene 0 %.

## Organización del código

- `Dtos/GimnasioDto.cs`: edad y meses, con validación de entrada.
- `ViewModels/GimnasioViewModel.cs`: datos y resultados de la pantalla.
- `Services/GimnasioService.cs`: condiciones y fórmulas del cálculo.
- `Controllers/GimnasioController.cs`: GET del formulario y POST que valida y llama al servicio.
- `Views/Gimnasio/Index.cshtml`: formulario Razor y resultado con Bootstrap.
- `Program.cs`: registro del servicio mediante AddScoped.
- `Views/Shared/_Layout.cshtml`: enlace Gimnasio en el menú compartido.

## Verificación realizada

- Compilación con .NET 10: 0 errores y 0 advertencias.
- Solicitudes HTTP al controlador: 30 combinaciones de edades y duraciones, incluidas las edades 17, 18, 59 y 60.
- Ocho entradas inválidas rechazadas sin mostrar resultados.
- Importes adicionales enviados por el cliente no cambian el cálculo del servidor.
- POST sin token antifalsificación rechazado con HTTP 400.
- Formulario probado en navegador con edad 18 y 3 meses: total $99.75.

Esta verificación cubre el gimnasio. No verifica las operaciones de Clientes y Pedidos.
