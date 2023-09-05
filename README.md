# PsiUWeb - Programação II
Ciência da Computação. UNOESC. 4ª Fase

## Stack
* .NET Core 6. Model-View-Controller
* Entity Framework Core
* SQL Server
* Docker

## Escopo
Elaboração de projeto para desenvolvimento de um software WebApp para auxílio na SAÚDE MENTAL.
> Sugestão de nome: PSI-U.APP.BR

O sistema tem por objetivo fornecer conteúdos de áudio, imagens e textos, organizados categoricamente de modo
que os usuários cadastrados possam acessar e consumir o material com o objetivo de minimizar os impactos
psicológicos e emocionais causados pelo stress do cotidiano.

## Análise de requisitos
As especificações abaixo contemplam o que definimos como a composição de um escopo inicial para versão 1.0;

### Não funcionais
-|-
-|-
RNF.01 | App disponível via Web, acessível por qualquer dispositivo munido de um navegador de internet (celular, tablet, notebook, smart tv, etc.): interface responsiva;
RNF.02 | Servidor de hospedagem para aplicação, banco de dados e armazenagem de arquivos (imagens e áudios): Custo mensal de acordo com plano contratado;
RNF.03 | Registro de domínio (endereço web / url): Custo anual atual de R$ 40,00 sem contar mão de obra de gerenciamento;
RNF.04 | Elaboração de política de privacidade; Podemos sugerir modelo padrão que poderá ser revisado posteriormente;
RNF.05 | Elaboração de logomarca; 

### Funcionais
-|-
-|-
RF.01 | Cadastro e gerenciamento de Usuários: Inicialmente 3 categorias de usuários – Admin - Psico – Paciente;
RF.02 | Cadastro e gerenciamento de categorias de conteúdo: Possibilitar a organização das categorias em uma estrutura de dados em árvore; Apenas usuários Admin e Psico;
RF.03 | Cadastro e gerenciamento de conteúdo: Conteúdo deve possuir título, lead, imagem de capa, arquivo de áudio, texto livre em formato de hipertexto para formatação livre estilo blog palavras-chave para assuntos relacionados;
RF.04 | Acesso dos conteúdos; Visualizações devem ser contabilizadas para utilização de dados estatísticos futuros;
RF.05 | Página inicial de apresentação do projeto;

<details>
  <summary>Diagramas</summary>

## Classe
    
```mermaid
  classDiagram
    direction LR
    Enum <.. Papeis
    Papeis "1" *--> "*" PapeisUsuario
    PapeisUsuario "*" <--* "1" Usuario
    Usuario <|-- Psico
    Usuario <|-- Paciente
    Psico "1" *--> "*" Conteudo
    Paciente "1" *--> "0..*" PacienteConteudo
    Conteudo "1" *--> "0..*" PacienteConteudo
    Conteudo "1" *--> "1..*" ConteudoMidia
    Conteudo "1" *--> "1..*" ConteudoCategoria
    ConteudoCategoria "1..*" <--* "1" Categoria
    Categoria o--> Categoria
    ConteudoMidia "1..*" <--* "1" Midia

    class Enum{
        - Paciente: int
        - Admin: int
        - Psico: int
    }
    class Papeis{
        - PapeisID: int
        - Descricao: string
    }
    class PapeisUsuario{
        - Usuario: Usuario
        - Papeil: Papeis
    }
    class Usuario{
        - UsuarioID: int
        - Nome: string
        - Email: int?
        - EmailConfirmado: boolean
        - SenhaHash: string
        - SeloSeguranca: string
        - Bloqueio: boolean
        - BloqueioFim: DateTime
        - ContagemFalhasAcesso: int
        - DataCriacao: DateTime
    }
    class Psico{
        - PsicoID: int
        - Nome: string
        - CRP: string
        - Liberado: boolean
        - Usuario: Usuario
        - Endereco: Endereco
    }
    class Paciente{
        - PacienteID: int
        - Nome: string
        - DataNascimento: DateTime
        - Sexo: string
        - Peso: float
        - Altura: float
        - Cor: Cor_Raca
        - Endereco: Endereco
        - Usuario: Usuario
    }
    class PacienteConteudo{
        - PacienteConteudoID: Guid
        - ConteudoID: int
        - PacienteID: int
        - DataHora: DateTime
    }
    class Conteudo{
        - ConteudoID: int
        - Titulo: string
        - Resumo: string
        - HiperTexto: string
        - Autor_PsicoID: int
    }
    class ConteudoMidia{
        - ConteudoMidiaID: int
        - ConteudoID: int
        - MidiaID: int
    }
    class Midia{
        - MidiaID: int
        - URL: string
        - TipoMidia: string
    }
    class ConteudoCategoria{
        - ConteudoCategoriaID: int
        - CategoriaID: int
        - ConteudoID: int
    }
    class Categoria{
        - CategoriaID: int
        - Nome: string
        - CategoriaPaiId: int
    }
```

  ## Classe
  ![Diagrama de classe](https://i.ibb.co/Jxd7KBh/class.jpg)

  ## Caso de uso
  ![Diagrama de caso de uso](https://i.ibb.co/2vzsLt4/usecase.jpg)
</details>
