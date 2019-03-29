# Exemplo de operações em conta corrente

## TrasferFunds

    Microserviço responsável por fazer transações entre contas.

A operação de transfência entre contas é feita de modo assíncrono.

## Account

    Microserviço responsável por operar contas corrente

As operações disponíveis são:

* Consulta de conta
* Consulta de saldo
* Consulta de extrato

> O software `Account.PublicShared` seria um pacote Nuget que pode ser adicionado por quem gostaria de emitir algum evento de crédito

## Framework

    Conjunto de boillerplates contendo padrões de projetos.