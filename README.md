----------------------------------------------------------------
Projeto IShopping- Abakos
----------------------------------------------------------------

Unidade Curricular: Desenvolvimento de Aplicações
Curso Técnico Superior Profissional de Programação de Sistemas
de Informação
Escola Superior de Tecnologia e Gestão - IPL Leiria
Ano letivo 2025/2026

----------------------------------------------------------------

1. ELEMENTOS DO GRUPO

- André Pedrosa Azenha - 2017127572
- Filipe Santos Cordeiro - 2025111969
- Mariana Gaspar Fragoso Lourenço Montez - 2025106693


----------------------------------------------------------------
2. DESCRIÇÃO


Aplicação WinForms em C# para gestão de compras domésticas.
Permite a vários utilizadores do agregado familiar:
- Gerir o orçamento familiar mensal
- Planear compras com itens previstos
- Registar itens não previstos durante a compra
- Fechar compras e ver estatísticas
- Exportar compras fechadas para CSV

A aplicação segue o padrão de arquitetura MVC e usa o
Entity Framework para persistência em SQL Server.


----------------------------------------------------------------
3. REQUISITOS


Software necessário:
- Windows 10 ou superior
- Visual Studio 2022 (Community ou superior)
  -> Carga de trabalho ".NET desktop development" instalada
- .NET Framework 4.8
- SQL Server LocalDB (vem com a instalação do Visual Studio)
- EntityFramework 6.5.2

----------------------------------------------------------------
4. INSTALAÇÃO


- Descompactar o ficheiro ZIP entregue.
- Abrir o Projeto:
    Abrir a pasta "iShopping-Abakos" -> selecionar o ficheiro
     "iShopping-Abakos.sln"
  
----------------------------------------------------------------
5. CONFIGURAÇÃO


A aplicação está pré-configurada para usar o SQL Server LocalDB
que vem com o Visual Studio. NÃO É NECESSÁRIA QUALQUER
CONFIGURAÇÃO ADICIONAL na primeira execução.

A base de dados é criada automaticamente quando a aplicação é
executada pela primeira vez, através do AppDbInitializer.

----------------------------------------------------------------
6. EXECUÇÃO


Dentro do Visual Studio:
- Clicar no botão Start

Na primeira execução, a base de dados é criada automaticamente
com dados iniciais (utilizadores e tipos de artigo pela seed).

----------------------------------------------------------------
7. UTILIZADORES PREDEFINIDOS


A aplicação tem três utilizadores criados automaticamente para
permitir o login imediato e testar:

   Username    Password
   --------    --------
   andre       1234
   filipe      1234
   mariana     1234

----------------------------------------------------------------

8. FUNCIONALIDADES PRINCIPAIS

- Login de utilizadores
- Gestão (CRUD) de Tipos de Artigo
- Gestão (CRUD) de Artigos (filtráveis por Tipo)
- Gestão de Orçamentos mensais
- Planeamento de Compras (criação, alteração, eliminação)
- Modo Compra (registo de itens previstos e não previstos)
- Fecho de Compras
- Exportação de Compras fechadas para ficheiro CSV
- Estatísticas:
  * Histórico de orçamentos vs total de compras
  * Percentagem de artigos previstos / não previstos
  * Sugestão de orçamento para o próximo mês

----------------------------------------------------------------
9. ESTRUTURA DO PROJETO


O projeto está organizado em três pastas, seguindo o padrão MVC:

   Model/      - Lógica de negócio, classes que representam as tabelas da BD,
                 contexto do EF (IShoppingContext) e
                 inicializador da BD (AppDbInitializer)

   View/       - Apresentação dos formulários WinForms (.cs e .Designer.cs) ao utilizador

   Controller/ - Lógica da aplicação que faz a ponte entre os
                 Forms (View) e a BD (Model)

----------------------------------------------------------------

10. NOTAS FINAIS


- A BD é recriada automaticamente sempre que os modelos
  sofrem alterações (DropCreateDatabaseIfModelChanges).
  Isto significa que dados de teste podem ser perdidos caso o Model seja alterado.

- Os utilizadores e os tipos de artigo do Seed são sempre criados de novo após
  qualquer alteração ao modelo.

- O ficheiro CSV gerado pela exportação é guardado no local
  escolhido pelo utilizador através da janela "Guardar como".
