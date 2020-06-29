FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime_webtests

# Copy csproj and restore as distinct layers. This will allow us to leverage the Docker cache, 
# avoiding to execute this time-consuming step if there are no changes in the csproj, which is rare.
WORKDIR /tests
COPY tests.csproj ./
RUN dotnet restore

# Copy everything else
COPY . .

# Set entrypoint script
ENTRYPOINT ["dotnet", "test" ]