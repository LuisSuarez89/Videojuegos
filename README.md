# Videojuegos (Unity)

Repositorio con varios proyectos de **Unity** usados para prácticas y prototipos de mecánicas (GUI, co-rutinas, roll-a-ball, parcial y proyecto de laberinto).

## Estructura del repositorio

Cada carpeta principal corresponde a un proyecto distinto:

- `Proyecto`
- `Taller GUI`
- `co-rutinas`
- `para parcial`
- `roll-a-ball`

> Nota: este repositorio está organizado principalmente por carpetas de `Assets/` y no siempre incluye configuración completa de Unity (`ProjectSettings`, `Packages`).

## Resumen de proyectos

| Proyecto | Escenas (`Assets/Scenes`) | Scripts propios (`Assets/Scripts`) | Enfoque |
|---|---:|---:|---|
| `Proyecto` | 2 | 5 | Laberinto por niveles, control de jugador, cámara y rotación de objetos. |
| `Taller GUI` | 2 | 1 | Taller básico de interfaz y escena 2D. |
| `co-rutinas` | 4 | 4 | Prácticas con co-rutinas y lógica de Roll-a-Ball. |
| `para parcial` | 3 | 3 | Versión para parcial con scripts base de control y cámara. |
| `roll-a-ball` | 6 | 16 | Proyecto más completo: combate, vida/resistencia, puntaje y enemigos. |

## Escenas por proyecto

### `Proyecto`
- `ProyectoLaberintoNivel1.unity`
- `ProyectoLaberintoNivel2.unity`

### `Taller GUI`
- `Escena2D.unity`
- `Taller GUI.unity`

### `co-rutinas`
- `Escena2.unity`
- `Escena2D.unity`
- `Roll-a-Ball.unity`
- `SampleScene.unity`

### `para parcial`
- `Parcial.unity`
- `Roll-a-Ball.unity`
- `SampleScene.unity`

### `roll-a-ball`
- `Escena2.unity`
- `Escena2D.unity`
- `Roll-a-Ball.unity`
- `SampleScene.unity`
- `proyectoFinal1.unity`
- `proyectoFinal2.unity`

## Scripts destacados

### `Proyecto/Assets/Scripts`
- `PlayerController.cs`
- `PlayerControllerNivel2.cs`
- `CameraController.cs`
- `Rotador.cs`
- `DuracionSonido.cs`

### `roll-a-ball/Assets/Scripts`
- `PlayerController.cs`
- `CameraController.cs`
- `ControlDisparo.cs`
- `ControlEnemigo.cs`
- `RecibeDisparo.cs`
- `Vida.cs`
- `Puntaje.cs`
- `Patulla.cs`

## Cómo abrir un proyecto en Unity

1. Abrí **Unity Hub**.
2. Seleccioná **Open** y elegí la carpeta del proyecto que quieras cargar (por ejemplo, `roll-a-ball`).
3. Si Unity pide actualizar assets, aceptá y esperá a que termine la importación.
4. Abrí una escena desde `Assets/Scenes` y ejecutá con **Play**.

## Recomendaciones

- Trabajá un proyecto por vez para evitar conflictos de meta files.
- Si vas a versionar cambios grandes, hacelo en ramas separadas por proyecto.
- Mantené los scripts de cada proyecto dentro de su `Assets/Scripts` correspondiente.

## Estado

Repositorio en crecimiento con material académico y experimental de desarrollo de videojuegos en Unity.
