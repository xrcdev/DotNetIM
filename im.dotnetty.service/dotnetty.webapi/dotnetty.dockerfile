FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
COPY .  /bin/Debug/net6.0/
WORKDIR /app
EXPOSE 8881 9990
ENTRYPOINT ["dotnet", "dotnetty.webapi.dll"]