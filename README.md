# Curso-EntityFrameworkCore
Estudos sobre o ORM entity framework core feito para C#.

Este projeto teve como base os cursos: *'Introdução ao Entity Framework Core'* e *'Dominando o Entity Framework Core'*.

# Introdução ao Entity Framework Core
Você poderá encontra-lo na plataforma **Desenvolvedor.io**: [Clique aqui](https://desenvolvedor.io/curso-online-introducao-entity-framework-core)

### Comando de geração de arquivos de migração
`dotnet ef migrations add PrimeiraMigracao -p .\Introducao\CursoEFCore.Aulas\CursoEFCore.Aulas.csproj`

### Comando de geração de arquivos contendo comandos sql com base nas migrações
`dotnet ef migrations script -p .\Introducao\CursoEFCore.Aulas\CursoEFCore.Aulas.csproj -o .\Introducao\CursoEFCore.Aulas\Scripts\Migracao.sql`

### Comando de aplicação das migrações no banco de dados
`dotnet ef database update -p .\Introducao\CursoEFCore.Aulas\CursoEFCore.Aulas.csproj -v`

### Comando de geração de arquivo contendo comandos sql 'idempotentes'
`dotnet ef migrations script -p .\Introducao\CursoEFCore.Aulas\CursoEFCore.Aulas.csproj -o .\Introducao\CursoEFCore.Aulas\Scripts\MigracaoIdempotente.sql -i`

### Comando de reversão (rollback) de migrações no banco de dados
`dotnet ef database update PrimeiraMigracao -p .\Introducao\CursoEFCore.Aulas\CursoEFCore.Aulas.csproj -v`

### Comando de remover último arquivo de migração gerado
`dotnet ef migrations remove -p .\Introducao\CursoEFCore.Aulas\CursoEFCore.Aulas.csproj`

# Dominando o Entity Framework Core
Você poderá encontra-lo na plataforma **Desenvolvedor.io**: [Clique aqui](https://desenvolvedor.io/curso-online-dominando-o-entity-framework-core)
