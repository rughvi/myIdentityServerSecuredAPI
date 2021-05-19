macOS:
1. remove all https dev-certs by running the below command:
    dotnet dev-certs https --clean
    
1. cd in the identityServer project folder.
2. the below commands

    dotnet dev-certs https -ep ${HOME}/.aspnet/https/identityServer.pfx -p crypticpassword
    dotnet dev-certs https --trust
    dotnet user-secrets -p ./identityServer.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword"
    docker build --pull -t myidentityserver_is .
    docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_ENVIRONMENT=Development -v ${HOME}/.microsoft/usersecrets/:/root/.microsoft/usersecrets -v ${HOME}/.aspnet/https:/root/.aspnet/https/ myidentityserver_is


docker pull mcr.microsoft.com/dotnet/core/samples:aspnetapp
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="password" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v %USERPROFILE%\.aspnet\https:/https/ mcr.microsoft.com/dotnet/core/samples:aspnetapp