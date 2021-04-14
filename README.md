# guidserver
Guid server provides lightweight REST API for generation of GUID

##How to use
To retreive one GUID from the system it is enought to call 
https://{host}/guid/

curl --location --request GET 'https://localhost:5001/guid

will provide you with following response

'''json
[
    "a59c6a83-1c8b-4bc1-a057-8a702e1c73c3"
]


To retreive more than one GUID from the system it is enought to call
https://{host}/guid/n

where n - it is a number of guids (limited with 100 but you can change it)

curl --location --request GET 'https://localhost:5001/guid/5

'''json
[
    "6c479edb-3a2c-4cdb-b745-738a82362093",
    "eb6197d9-1c14-455d-80bc-85c938544ac0"
    "e4387852-58c8-4d10-a6a1-d0649baeda75",
    "e42b64af-4f44-4d81-9c4d-1fac9d08c057",
    "6f7637ee-f169-41c3-88ea-d8c02dc2989d",
]

##Additional query parameters

upperCase=false - format GUID output with UPPER CASE
'''json
[
    "{514EF2A2-73F5-4851-A39D-0CAB68E090F1}"
]


base64Encode=false - encode each GUID into base64 string
'''json
[
    "ezE4MDFCNzYyLTYzRjQtNEMxMC1BMDZCLUQ4QTYyOTlBNUE5MX0",
    "ezcxQUY4MjlGLTJBMDYtNEU0MC1BQzYwLThFMjk2QzFCRjY0Mn0",
    "ezJFMjNDNDcxLUExRDAtNEJERi1BMTExLTYyOThFQkU0M0IxN30",
    "e0I0REFBRENBLTFCOTktNEY1MS04MjcwLTk0MjYxODE3QTUxQX0",
    "ezZDMDg4OUVCLTVFNUEtNENDMy04NTY5LTVEMDIyMkIyM0RDM30"
]

registryFormat=true - produces GUID in a registry form (wrapped with the {} brackets)
'''json
[
    "{514EF2A2-73F5-4851-A39D-0CAB68E090F1}"
]

curl --location --request GET 'https://localhost/guid/5?upperCase=true&base64Encode=true&registryFormat=true' \