FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["src/AssistenteFinanceiro.Api/AssistenteFinanceiro.Api.csproj", "src/AssistenteFinanceiro.Api/"]
COPY ["src/AssistenteFinanceiro.Application.Infra.Ioc/AssistenteFinanceiro.Application.Infra.Ioc.csproj", "src/AssistenteFinanceiro.Application.Infra.Ioc/"]
COPY ["src/AssistenteFinanceiro.Application/AssistenteFinanceiro.Application.csproj", "src/AssistenteFinanceiro.Application/"]
COPY ["src/AssistenteFinanceiro.Infra.SharedKernel/AssistenteFinanceiro.Infra.SharedKernel.csproj", "src/AssistenteFinanceiro.Infra.SharedKernel/"]
COPY ["src/AssistenteFinanceiro.Infra.Functional/AssistenteFinanceiro.Infra.Functional.csproj", "src/AssistenteFinanceiro.Infra.Functional/"]
COPY ["src/AssistenteFinanceiro.Domain/AssistenteFinanceiro.Domain.csproj", "src/AssistenteFinanceiro.Domain/"]
COPY ["src/AssistenteFinanceiro.Application.Infra.Repositories/AssistenteFinanceiro.Application.Infra.Repositories.csproj", "src/AssistenteFinanceiro.Application.Infra.Repositories/"]
COPY ["src/AssistenteFinanceiro.Infra.Database/AssistenteFinanceiro.Infra.Database.csproj", "src/AssistenteFinanceiro.Infra.Database/"]
RUN dotnet restore "src/AssistenteFinanceiro.Api/AssistenteFinanceiro.Api.csproj"
COPY . .
WORKDIR "/src/src/AssistenteFinanceiro.Api"
RUN dotnet build "AssistenteFinanceiro.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AssistenteFinanceiro.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AssistenteFinanceiro.Api.dll"]