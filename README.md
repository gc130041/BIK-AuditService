# BIK Audit Service

Microservicio desarrollado en **.NET 8** encargado de registrar de forma **inmutable** todas las transacciones y operaciones del **Banco Informático Kinal (BIK)**.  
Su objetivo es mantener un historial confiable de eventos financieros para fines de **auditoría, control y trazabilidad**.

---

## Configuración de Entorno

Las variables de entorno se inyectan a través del archivo de **orquestación general (`docker-compose.yml`)**, destacando principalmente la **cadena de conexión** hacia la base de datos **PostgreSQL**.

---

## Ejecución del Proyecto

Para iniciar este microservicio junto con el resto del ecosistema:

1. Sitúate en la **raíz del proyecto**.
2. Ejecuta el siguiente comando:

```bash
docker compose up -d --build
````

El servicio se iniciará y estará disponible en el puerto:

```
http://localhost:5001
```

---

## Uso de la Colección de Postman

1. Abre la **colección del proyecto en Postman**.
2. Verifica que la variable:

```
audit_base_url
```

tenga el valor:

```
http://localhost:5001
```

3. Dirígete a la carpeta correspondiente al **Servicio de Auditoría**.

Dentro encontrarás peticiones para:

* **Registrar logs de operaciones**
* **Consultar historiales de auditoría**

Estos endpoints funcionan **de manera independiente**, por lo que **no requieren autenticación previa desde el API Gateway**.
