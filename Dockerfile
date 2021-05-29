# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS Builder
WORKDIR /app

RUN apt-get update
RUN apt-get install -y make nodejs npm

# Copy csproj and restore as distinct layers
COPY ./src /app/src
COPY ./Makefile /app/
COPY ./package.json /app
COPY nuxt.config.js /app
RUN make restore
RUN make migrate
WORKDIR /app/src
RUN dotnet publish -c Release -o out

# EXPOSE 5000

ENV ASPNETCORE_URLS=http://0.0.0.0:5000
ENTRYPOINT ["/app/src/out/src"]

