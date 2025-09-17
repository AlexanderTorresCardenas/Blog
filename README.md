# Blog de programacion con IA
Proyecto para crear articulos basados en el desarrollo de software asistido por inteligencia artificial de OpenAI.

![](https://media.licdn.com/dms/image/v2/D4D12AQEWIT-9T6R3qA/article-cover_image-shrink_720_1280/article-cover_image-shrink_720_1280/0/1691146433815?e=2147483647&v=beta&t=ujew0Bq_W5qvIQ1ROLv4G0RREQtHla5hJRENKKWfxd4)

## Tecnologias usadas
- Desarrollado usando C# 9
- ASP.NET Core MVC
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft SQL Server 2022
	Developer Edition (64-bit) on Windows 10 Pro 10.0 <X64> (Build 26100: )
- OpenAI 2.10

------------

# BlogIA.md

![](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjk0A86MXNEP4bYXGeg2NeU8Ij0TVaZYS02rDj-d66Hy9-A0uTY3sTF76dAkP6dT5gjFU&usqp=CAU)

![](https://img.shields.io/github/stars/pandao/editor.md.svg) ![](https://img.shields.io/github/forks/pandao/editor.md.svg) ![](https://img.shields.io/github/tag/pandao/editor.md.svg) ![](https://img.shields.io/github/release/pandao/editor.md.svg)

![](https://github.com/AlexanderTorresCardenas/Blog/blob/main/Blog/wwwroot/img/gui-01.png)

------------

## AI de OpenAI usadas en el proyecto

### El generador de texto
Usando gpt-4o-mini de Open AI es una herramienta de inteligencia artificial de vanguardia que puede generar textos de alta calidad. Los textos generados por la IA que produce la tecnología se basan en un algoritmo de deep learning -aprendizaje profundo- que se entrena con un gran corpus de texto.
https://platform.openai.com/docs/guides/text

### DALL·E: creación de imágenes a partir de texto
Crea imágenes a partir de descripciones textuales para una amplia gama de conceptos expresables en lenguaje natural.
https://openai.com/es-ES/index/dall-e/

### API por lotes
Usando gpt-4o-mini de OpenAI, permite enviar solicitudes para el procesamiento por lotes asíncrono. Estas solicitudes en un plazo de 24 horas. Los detalles de cada solicitud se leerán desde un archivo precargado y las respuestas se escribirán en un archivo de salida. 
https://platform.openai.com/docs/api-reference/batch

------------

## Despligue de la aplicacion 
1. **Descargar la aplicacion del repositorio de GitHub** [descargar](https://github.com/AlexanderTorresCardenas/Blog "descargar")
2. ** Abra el projecto en el IDE Visual Studio 2022** [descargar](https://visualstudio.microsoft.com/es/vs/community/ "descargar")
3. ** Instalar los paquetes nuget**
	- Abre la Consola del Administrador de Paquetes: En el menú de Visual Studio, selecciona Herramientas > Administrador de paquetes NuGet > Consola del Administrador de Paquetes. 
	- Selecciona el proyecto: Asegúrate de que el proyecto o la solución en la que deseas actualizar la librería está seleccionada en la lista desplegable "Proyecto predeterminado" en la consola. 
	- Para actualizar todos los paquetes a la última versión: Escribe Update-Package y presiona Enter.
4. ** Crear base de datos en Microsoft SQL Server 2022** [descargar](https://www.microsoft.com/es-es/sql-server/sql-server-downloads "descargar")
	-  Modificar la cadena de conexion a la base de datos en el archivo appsettings.json
 `"ConnectionStrings": {
   "BlogConexion": "TU_CADENA_CONEXION",
 }`

	- Abre la Consola del Administrador de Paquetes: En Visual Studio, ve a Herramientas > Administrador de paquetes NuGet > Consola del Administrador de Paquetes. 
	Ejecuta el siguiente comando
```
Update-Database
```

5. **Crear archivo** secrets.json
Para esto debes dar clic derecho en en el proyecto y elegir la opcion Manage Users Secrets

```
{
  "ConfiguracionesIA": {
    "modeloTexto": "gpt-4o-mini",
    "modeloImagenes": "dall-e-3",
    "modeloSentimientos": "gpt-4o-mini",
    "llaveOpenAI": ">TU_KEY_OPENAI"
  }
}
```
