# Bem-vindo a .Net Core API SupZezinho.

Trata-se de uma API desenvolvida com as tecnologias: C# e .Net Core SDK na versão 5.0.202, EntityFramework 5.0.5 SqlLite 5.0.5, AspNetCore.OData na versão 7.5.2. desenvolvido no vscode, mas procurei referencias as soluções para que seja possível abrir normalmente no Visual Studio.

****
**ABORDAGEM**

O Projeto está estruturado buscando utiliza bases e alguns conceitos de Domain Drivem Design (DDD), procurei manter as acamadas de apresentação, aplicação,dominio e estrutura o mais perceptivel possivel, embora não se aprofunde nas abordagem de S.O.L.I.D busca o máximo de singularidade entre os entidades. Para as validações, usei conceitos de  Data Annotations, algumas direto na propriedade da entidade. Para os filtros solicitados em **Listar Produtos** usei o protocolo ODATA podendo ser utilizados filtros conforme documentação abaixo

**Visão geral da linguagem OData** <br>
https://docs.microsoft.com/pt-br/azure/search/query-odata-filter-orderby-syntax


**EXECUÇÃO**

Basta clonar o repositório acessar O diretório src/SupZezinho.API na versão do 5.0.202 do .Net Core SDK. Mantive as referencias ao **Swagger** , nele já é possivel fazer alguns testes e conhecer a estrutura da API, as configurações, manitive no padrão abaixo, podendo ser alteradas no appsettings.json normamalmente.

****
https://localhost:5001/swagger/index.html <br>
http://localhost:5000/swagger/index.html

****
**E executar:**
## dotnet run 

Sugiro restaurar as dependências do Projeto com o comando:
## dotnet build   

**Banco de Dados**

Acompanha o Banco **SupZezinho.db** 

**Referências**

A versão o SDK utilizada no projeto, segue no link abaixo.
https://dotnet.microsoft.com/download/dotnet/5.0

