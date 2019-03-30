FROM microsoft/dotnet:2.2-sdk as builder
COPY . /
WORKDIR /src/Account/Account.Consumer.TransactionHandler
RUN dotnet restore --no-cache
RUN dotnet publish --output /app/ -c Release --no-restore

FROM microsoft/dotnet:2.2-runtime-alpine
WORKDIR /app
COPY --from=builder /app .

ENV DOTNET_RUNNING_IN_CONTAINER true

ENTRYPOINT ["dotnet", "Account.Consumer.TransactionHandler.dll"]