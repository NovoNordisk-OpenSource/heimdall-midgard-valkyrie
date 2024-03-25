# Setup build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Build arg to hold GITHUB_TOKEN for restoring packages
ARG GITHUB_TOKEN

# Set environment variables
ENV GITHUB_TOKEN=$GITHUB_TOKEN

# Copy files to container file system
COPY ./ ./build/

# Set workdir to /build
WORKDIR /build

# Install the nuget credential provider
RUN apt-get update && apt-get install -y locales curl && sed -i -e 's/# en_US.UTF-8 UTF-8/en_US.UTF-8 UTF-8/' /etc/locale.gen
RUN dpkg-reconfigure --frontend=noninteractive locales && update-locale LANG=en_US.UTF-8
RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash

# Set workdir to current project folder
WORKDIR /build/src/Heimdall.Midgard.Valkyrie.Host.Api

# Restore csproj packages.
RUN dotnet restore

# Compile source code using standard Release profile
RUN dotnet publish -c Release -o /build/out Heimdall.Midgard.Valkyrie.Host.Api.csproj

# Setup final container images.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Expose port 54323
EXPOSE 54323

# Set environment variables
ENV ASPNETCORE_URLS="http://*:54323"

# Copy binaries from publish container to final container
COPY --from=build-env /build/out .

# Setup liveness healthcheck
HEALTHCHECK CMD curl --fail http://localhost:54323/healthz/liveness || exit

# Run dotnet executable
ENTRYPOINT ["dotnet", "Heimdall.Midgard.Valkyrie.Host.Api.dll"]
