FROM nginx:alpine as final
EXPOSE 5017/tcp

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build

COPY ./Client/TodoApp.Client.csproj ./Client/TodoApp.Client.csproj
RUN dotnet restore "/Client/TodoApp.Client.csproj"
COPY ./Client/ ./Client/

COPY ./Shared/TodoApp.Shared.csproj ./Shared/TodoApp.Shared.csproj
RUN dotnet restore "/Shared/TodoApp.Shared.csproj"
COPY ./Shared/ ./Shared/

COPY ./Server/TodoApp.Server.csproj ./Server/TodoApp.Server.csproj
RUN dotnet restore "/Server/TodoApp.Server.csproj"
COPY ./Server/ ./Server/
RUN rm -rf appsettings.Development.json

RUN dotnet publish -c Release "/Server/TodoApp.Server.csproj" -o ./app/publish

FROM final
WORKDIR /app
COPY --from=build ./app/publish .
COPY ./Server/appsettings.json ./Server/appsettings.json

RUN apk add aspnetcore7-runtime

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

ENTRYPOINT ["dotnet", "TodoApp.Server.dll"]