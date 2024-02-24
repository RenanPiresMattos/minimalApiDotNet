Estudo - Api Mínima com C#
-- Configuração --
dotnet new web -o ApiDotNet
cd ApiDotNet
code -r ../ApiDotNet

dotnet dev-certs https --trust

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite (Ou de preferência)
dotnet add package Microsoft.EntityFrameworkCore.Design

-- Migration --
dotnet ef migrations add Initial
dotnet ef database update