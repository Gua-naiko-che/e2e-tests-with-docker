# This image should match the SDK version of your app, see https://hub.docker.com/_/microsoft-dotnet-core-sdk
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers. This will allow us to leverage the Docker cache, 
# avoiding to execute this time-consuming step if there are no changes in the csproj, which is rare.
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
# This image should match the SDK version of your app, see https://hub.docker.com/_/microsoft-dotnet-core-sdk
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "app.dll"]