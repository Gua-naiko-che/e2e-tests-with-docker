FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime_webtests

# Install Google Chrome
# # USE THIS CODE TO INSTALL LATEST VERSION
# RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
#     && echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list \
#     && apt-get update -qqy \
#     && apt-get -qqy install google-chrome-stable --no-install-recommends \
#     && rm /etc/apt/sources.list.d/google-chrome.list \
#     && rm -rf /var/lib/apt/lists/* /var/cache/apt/*

# USE THIS CODE TO INSTALL A SPECIFC VERSION: Check available versions here: https://www.ubuntuupdates.org/package/google_chrome/stable/main/base/google-chrome-stable
ARG CHROME_VERSION="83.0.4103.116-1"
RUN wget --no-verbose -O /tmp/chrome.deb http://dl.google.com/linux/chrome/deb/pool/main/g/google-chrome-stable/google-chrome-stable_${CHROME_VERSION}_amd64.deb \
    && apt-get update -qqy \
    && apt install -y /tmp/chrome.deb \
    && rm /tmp/chrome.deb

# Copy csproj and restore as distinct layers. This will allow us to leverage the Docker cache, 
# avoiding to execute this time-consuming step if there are no changes in the csproj, which is rare.
WORKDIR /tests
COPY tests.csproj ./
RUN dotnet restore

# Copy everything else
COPY . .

# Set entrypoint script
ENTRYPOINT ["dotnet", "test" ]