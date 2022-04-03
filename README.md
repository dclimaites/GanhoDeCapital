# GanhoDeCapital
#Pré-requisitos
1 - Necessário instalação do runtime .Net 5.0
  1.1 - Linha de comando instalação do repositório Microsoft
    wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    rm packages-microsoft-prod.deb
  1.2 - Instalação do runtime
    sudo apt-get update; \
    sudo apt-get install -y apt-transport-https && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-6.0
2 - Para executar o build do projeto manualmente: dotnet build "GanhoDeCapitalAPP.csproj" -c Release -o /app/build
3 - Para executar o projeto manualmente: dotnet build "GanhoDeCapitalAPP.csproj" -c Release -o /app/build
