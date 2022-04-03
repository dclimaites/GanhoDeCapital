# GanhoDeCapital
#Pré-requisitos

  - Necessário instalação do runtime .Net 5.0
    - Linha de comando para instalação do repositório Microsoft
     ``` bash
      wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      sudo dpkg -i packages-microsoft-prod.deb
      rm packages-microsoft-prod.deb
      ```
      - Instalação do runtime
    
    ``` bash 
    sudo apt-get update; \
    sudo apt-get install -y apt-transport-https && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-6.0
    ```
  - Para executar o build do projeto manualmente: 
    ``` bash
    dotnet build "GanhoDeCapitalAPP.csproj" -c Release -o /app/build
    ```
  - Para executar o projeto manualmente: 
  ``` bash
  dotnet build "GanhoDeCapitalAPP.csproj" -c Release -o /app/build
  ```
