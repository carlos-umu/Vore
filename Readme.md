# Vore

¡Bienvenido a **Vore**! Un videojuego clásico estilo arcade inspirado en las mecánicas de Pac-Man, desarrollado en **C#** con la biblioteca gráfica **Raylib-cs**.

El proyecto presenta una arquitectura modular con 10 niveles progresivos, IA de persecución y un sistema de renderizado optimizado para alta resolución.

---

## Galería de Assets

| Jugador | Enemigo | Muro | Comida |
| :---: | :---: | :---: | :---: |
| ![Jugador](Vore/Assets/ThirdPlayer.png) | ![Enemigo](Vore/Assets/EnemyPlayer.png) | ![Muro](Vore/Assets/Wall3.png) | ![Comida](Vore/Assets/BlueFood.png) |

---

## Características Técnicas

* **Arquitectura de Niveles:** 10 mapas cargados desde matrices de texto.

* **Sistema de Renderizado Pro:** Uso de `DrawTexturePro` para escalar sprites a 60x60 píxeles, garantizando que el diseño visual coincida con la lógica de colisiones.

* **Pantalla Completa Inteligente:** Detección automática de la resolución del monitor mediante `GetMonitorWidth` y `ToggleFullscreen`.

* **Gestión de Memoria:** Carga de texturas pre-inicializada para evitar *crashes* y saturación de la VRAM.

---

## Controles

* **Movimiento:** `W`, `A`, `S`, `D` o `Flechas de dirección`.

* **Pantalla Completa:** `F11`.

* **Salir:** Cerrar ventana o `ESC`.

---

## Instalación para Desarrolladores

1. **Requisitos:** .NET SDK 8.0+.
2. **Configuración de Assets:** Asegúrate de que el archivo `.csproj` tenga esta configuración para incluir los recursos en la compilación:

```xml
<ItemGroup>
  <Content Include="Assets\**">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </Content>
</ItemGroup>
