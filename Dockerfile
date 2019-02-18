FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ./ /src 
RUN dotnet restore "src/AssistenteFinanceiro.Api/AssistenteFinanceiro.Api.csproj"
COPY . .
WORKDIR "src/AssistenteFinanceiro.Api"
RUN dotnet build "AssistenteFinanceiro.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AssistenteFinanceiro.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AssistenteFinanceiro.Api.dll"]