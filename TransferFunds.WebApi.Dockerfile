FROM microsoft/dotnet:2.2-sdk as builder
COPY . /
WORKDIR /src/TransferFunds/TransferFunds.WebApi
RUN dotnet restore --no-cache
RUN dotnet publish --output /app/ -c Release --no-restore

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /app .


ENV ASPNETCORE_ENVIRONMENT Development
ENV DOTNET_RUNNING_IN_CONTAINER true
ENV ASPNETCORE_URLS=http://*:80

EXPOSE 80
ENTRYPOINT ["dotnet", "TransferFunds.WebApi.dll"]