# guidserver
Guid server provides lightweight REST API for generation of UUID (GUID)
https://en.wikipedia.org/wiki/Universally_unique_identifier

## How to use
To retreive one UUID from the system it is enought to call `https://{host}/guid/`

`curl -i -H "Accept: application/json" -H "Content-Type: application/json" -X GET https://guid-service.azurewebsites.net/guid`

will provide you response with one UUID

```json
[
    "a59c6a83-1c8b-4bc1-a057-8a702e1c73c3"
]
```

To retreive more than one GUID from the system it is enought to call `https://{host}/guid/n` where n - it is a number of UUID (limited with 100 but you can change it)

`curl -i -H "Accept: application/json" -H "Content-Type: application/json" -X GET https://guid-service.azurewebsites.net/guid/5`

will provide you response consists 5 UUID

```json
[
    "6c479edb-3a2c-4cdb-b745-738a82362093",
    "eb6197d9-1c14-455d-80bc-85c938544ac0"
    "e4387852-58c8-4d10-a6a1-d0649baeda75",
    "e42b64af-4f44-4d81-9c4d-1fac9d08c057",
    "6f7637ee-f169-41c3-88ea-d8c02dc2989d",
]
```

## Additional query parameters

`upperCase=false` - format UUID into UPPER CASE output
```json
[
    "514EF2A2-73F5-4851-A39D-0CAB68E090F1"
]
```

`base64Encode=false` - encode each UUID into base64 string
```json
[
    "ezE4MDFCNzYyLTYzRjQtNEMxMC1BMDZCLUQ4QTYyOTlBNUE5MX0"
]
```

`registryFormat=true` - produces UUID in a registry form (wrapped with the curly brackets)
```json
[
    "{514EF2A2-73F5-4851-A39D-0CAB68E090F1}"
]
```

## Live Demo

`curl -i -H "Accept: application/json" -H "Content-Type: application/json" -X GET https://guid-service.azurewebsites.net/guid/10/?upperCase=true&base64Encode=false&registryFormat=true`
