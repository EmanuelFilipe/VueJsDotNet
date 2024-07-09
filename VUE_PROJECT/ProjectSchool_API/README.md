# formatar documento

ctrl + shift + p
format document

# criando projeto dotnet

dotnet new webapi -n nome

# root > dando build

dotnet build

# rodando com hot-reload

root > dotnet watch run

# Incluindo SqLite como DB

instalar o plugin: "Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0"

irá criar um banco de dados local

"ConnectionStrings": {
"DefaultConnection": "Data Source=ProjectSchool.db"
},

# add-migration

dotnet ef migrations add init

# remove-migration

dotnet ef migrations remove

# database-update

dotnet ef database update

# DB Browser SQ Lite

Open Database > selecionar o arquivo .db na pasta do projeto
