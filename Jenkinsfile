node {

  stage('Checkout') {
    git url: 'https://github.com/CarlosTuiran/ProyectoDDP.git',branch: 'master'
  }
  //SignusFinanciero.sln
  stage ('Restore Nuget') {
    bat "dotnet restore ProyectoDDP.sln"
  }
  
  stage('Clean') {
    bat 'dotnet clean ProyectoDDP.sln'
  }
  
  stage('Build') {
    bat 'dotnet build ProyectoDDP.sln --configuration Release'
  }

  stage ('Test') {
    bat "dotnet test Aplication.Test/Aplication.Test.csproj --logger trx;LogFileName=unit_tests.trx"
    mstest testResultsFile:"**/*.trx", keepLongStdio: true
  }
    

  stage('Publish') {
    bat 'dotnet publish WebApiAngular/WebApiAngular.csproj -c Release -o C:/CempreDDP'
  } 
  
}