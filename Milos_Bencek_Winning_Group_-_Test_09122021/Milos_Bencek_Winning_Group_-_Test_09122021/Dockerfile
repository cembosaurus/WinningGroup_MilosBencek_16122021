FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["Milos_Bencek_Winning_Group_-_Test_09122021.csproj", "./"]
RUN dotnet restore "Milos_Bencek_Winning_Group_-_Test_09122021.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Milos_Bencek_Winning_Group_-_Test_09122021.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Milos_Bencek_Winning_Group_-_Test_09122021.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Milos_Bencek_Winning_Group_-_Test_09122021.dll"]
