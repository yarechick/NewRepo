
Donas es un CRUD sencillo basado en aplicación para Vue de [create-vue](https://github.com/vuejs/create-vue) y [sakai](https://sakai.primevue.org/documentation), y [create-vue]es forma recomendada de iniciar proyectos de Vue con tecnología Vite.



Características Principales
- **Autenticación de usuarios**: Inicio de sesión 
- **Panel de control interactivo**: Visualización de gráficos
- **Gestión de recursos**: CRUD simulando gestiòn de ventas
- **Diseño responsive**: Adaptable a dispositivos móviles y escritorio

Tecnologías Utilizadas
- **Frontend**: 
  ![Vue.js](https://img.shields.io/badge/Vue.js-3.3.4-42b883?logo=vue.js)
  ![Vue Router](https://img.shields.io/badge/Vue_Router-4.2.5-ea5358?logo=vue.js)
  ![Pinia](https://img.shields.io/badge/Pinia-2.1.7-ffe501?logo=vue.js)
  ![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-3.3.0-38bdf8?logo=tailwind-css)

- **Herramientas**: 
  ![Vite](https://img.shields.io/badge/Vite-4.4.5-646cff?logo=vite)
  ![Axios](https://img.shields.io/badge/Axios-1.4.0-5a29e4?logo=axios)

Instalación Local
Sigue estos pasos para configurar el proyecto:

1. Obtener el còdigo fuente:  
   - Recibirás los archivos del proyecto por correo electrónico
   - Descomprime el archivo ZIP en tu directorio de trabajo

    o en caso de que recibir informaciòn de repositorio git: 
   - git clone https://github.com/tu-usuario/tu-repositorio.git
   - cd tu-repositorio

2. Instalar dependencias:
   - cd nombre-del-proyecto
   - npm install
3. Configurar url del Api a consumir en el archivo config.json
  {
    "API_URL": "https://www.urlApi.com/"
||}

3. Ejecutar `npm run dev` para iniciar

4. Estructura del proyecto: 

src/
├── assets/           # Recursos estáticos
├── components/       # Componentes reutilizables
│   ├── dashboard/           # Componentes gràficos
│   └── ...
├── layout/           # Templete principal
│   ├── composables/  # Lógica reusable (hooks)
│   └── ...
├── router/           # Configuración de rutas
├── stores/           # Gestión de estado (Pinia)
├── service/         # Conexión con APIs/Backend
├── views/            # Componentes de página
├── App.vue           # Componente raíz
└── main.js           # Punto de entrada


Autor
Yareni Guadalupe Muñoz Galicia
