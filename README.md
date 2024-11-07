# API Dokumentation För Rika_AccountProvider

## Skapa User (`CreateUser`)

**Endpoint:** `/api/CreateUser`  
**Metod:** `POST`

### Request Body

```json
{
  "FirstName": "string",
  "LastName": "string",
  "Email": "string",
  "Password": "string"
}

````

## Hämta Alla Användare (`GetAllUsers`)

**Endpoint:** `/api/GetUsers`  
**Metod:** `GET`

### Request Body

```json
[
  {
    "UserId": "string",
    "FirstName": "string",
    "LastName": "string",
    "Email": "string",
    "PhoneNumber": "string",
    "ProfileImageUrl": "string",
    "Age": 0
  },
    {
    "UserId": "string",
    "FirstName": "string",
    "LastName": "string",
    "Email": "string",
    "PhoneNumber": "string",
    "ProfileImageUrl": "string",
    "Age": 0
  }
]

````
## Hämta En Användare (`GetOneUserAsync`)

**Endpoint:** `/api/GetOneUserAsync/{id}`  
**Metod:** `GET`

### Request Body

```json
{
  "UserId": "string",
  "FirstName": "string",
  "LastName": "string",
  "Email": "string",
  "PhoneNumber": "string",
  "ProfileImageUrl": "string",
  "Age": 0
}

````

## Uppdatera En Användare (`UpdateUser`)

**Endpoint:** `/api/UpdateUser`  
**Metod:** `PUT`

### Request Body

```json
{
  "UserId": "string",
  "FirstName": "string",
  "LastName": "string",
  "Email": "string",
  "PhoneNumber": "string",
  "ProfileImageUrl": "string",
  "Age": 0
}

````

## Ta Bort En Användare (`DeleteUser`)

**Endpoint:** `/api/DeleteUser`  
**Metod:** `DELETE`
