FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/UniversityAutomate.csproj", "UniversityAutomate/"]
RUN dotnet restore "UniversityAutomate/UniversityAutomate.csproj"
COPY . .
WORKDIR "/src/UniversityAutomate"
RUN dotnet build "UniversityAutomate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UniversityAutomate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniversityAutomate.dll"]
