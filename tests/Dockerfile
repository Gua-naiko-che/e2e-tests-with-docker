FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime_webtests

# Install Google Chrome
ARG CHROME_VERSION="google-chrome-stable"
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list \
    && apt-get update -qqy \
    && apt-get -qqy install ${CHROME_VERSION} --no-install-recommends \
    && rm /etc/apt/sources.list.d/google-chrome.list \
    && rm -rf /var/lib/apt/lists/* /var/cache/apt/*

# Copy csproj and restore as distinct layers. This will allow us to leverage the Docker cache, 
# avoiding to execute this time-consuming step if there are no changes in the csproj, which is rare.
WORKDIR /tests
COPY tests.csproj ./
RUN dotnet restore

# Copy everything else
COPY . .

# Set entrypoint script
ENTRYPOINT ["dotnet", "test" ]