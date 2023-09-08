# Proyecto Monolegal - Gestión de Facturas
Este es un proyecto de ejemplo en .NETque utiliza MongoDB para gestionar facturas en una base de datos llamada "monolegal" con una colección llamada "factura".

## Requisitos Previos
Asegúrate de tener los siguientes requisitos previos instalados en tu sistema:

- .NET Core SDK 
- MongoDB 
# Configuración
Clona este repositorio en tu máquina local:
´´´
 git clone  https://github.com/Carlosabogal/Backend-Factura--MonoLegal
´´´
### SOLICITUDES PREVIAS
# Requisitos Previos
Asegúrate de tener los siguientes requisitos previos configurados antes de realizar las pruebas:

Postman - Asegúrate de tener Postman instalado en tu máquina.
Importar la Colección
Descarga la colección de solicitudes de Postman desde este enlace.

Abre Postman.

# Ejecutar las Solicitudes
Abre la colección "Facturas API" en Postman.

Dentro de la colección, encontrarás una solicitud llamada "Crear Factura".

Abre esta solicitud y asegúrate de que la URL esté configurada correctamente como "https://localhost:7053/api/factura".

En el cuerpo de la solicitud, utiliza los siguientes datos JSON como ejemplo:
<pre><code>

    {
        "Id": "22",
        "CodigoFactura": "P - 001",
        "Cliente": "Nombre del Cliente 1",
        "CorreoElectronico": "Carlosabogal1996@hotmail.com",
        "Ciudad": "Ciudad 1",
        "Desarrollo": "Nacional",
        "NumeroBogota": "123",
        "NIT": "345",
        "SubTotal": 80.00,
        "Iva": 20.50,
        "Retencion": "Retención 1",
        "RetencionValor": 5.00,
        "FechaCreacion": "2023-09-01T10:00:00",
        "Estado": "Pendiente",
        "Pagada": false
    }

</code></pre>

Envía la solicitud haciendo clic en el botón "Send", si colocas "Pagada como true"  se creara una fecha de actualizacion
<pre><code>
  {
        "id": "3",
        "codigoFactura": "3",
        "cliente": "421",
        "correoElectronico": "carlosabogal1996@hotmail.com",
        "ciudad": "calarca",
        "desarrollo": "3",
        "numeroBogota": "weq",
        "nit": "4124",
        "totalFactura": 10000,
        "subTotal": 10000,
        "iva": 100,
        "retencion": "1000",
        "retencionValor": 100,
        "fechaCreacion": "2023-09-07T05:00:00Z",
        "estado": "primerrecordatorio",
        "pagada": true,
        "fechaPago": "2023-09-08T13:37:29.436Z"
    }
</code></pre>
## Get All
Abre la colección "Facturas API" en Postman.
Dentro de la colección, encontrarás una solicitud llamada "Obtener Todas las Facturas".
Abre esta solicitud y asegúrate de que la URL esté configurada correctamente como "https://localhost:7053/api/factura".

Deja el cuerpo de la solicitud vacío ya que es una solicitud GET.
Envía la solicitud haciendo clic en el botón "Send".
Deberías recibir una respuesta del servidor con todos los datos de facturas existentes o cualquier otro resultado según la implementación del servidor.

## ENVIAR NOTIFICACIONES AL CLIENTE
## Ejecutar la Solicitud

1. Abre la colección "Facturas API" en Postman.

2. Dentro de la colección, encontrarás una solicitud llamada "Actualizar Estado de Factura".

3. Abre esta solicitud y asegúrate de que la URL esté configurada correctamente como "https://localhost:7053/api/factura/19?pago=true" para actualizar la factura con el ID 19.

4. En el cuerpo de la solicitud, utiliza el siguiente JSON para definir si la factura se debe marcar como pagada o no. Si `pago` es `true`, se marcará como pagada y se anexará la fecha actual; si es `false`, se enviará una notificación de recordatorio al correo.

   ```json
   {
       "pago": true
   }
Envía la solicitud haciendo clic en el botón "Send".

Deberías recibir una respuesta del servidor con los detalles actualizados de la factura o cualquier otro resultado según la implementación del servidor

