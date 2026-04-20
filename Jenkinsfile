pipeline {
    agent any

    environment {
        SONAR_PROJECT_KEY = "aeroxydhya_robot-controller-api"
        SONAR_ORG = "aeroxydhya"
        SONAR_TOKEN = "d51b4b52350e8dbee8f20c9e15f004081bc4e98c"
    }

    stages {

        stage('Build') {
            steps {
                dir('D:/hp laptop aradhya data/c#/SIT_331/4.3d/robot-controller-api') {
                    bat 'dotnet restore'
                    bat 'dotnet build robot-controller-api.sln'
                    bat 'docker build -t robot-api .'
                }
            }
        }

        stage('Test') {
            steps {
                dir('D:/hp laptop aradhya data/c#/SIT_331/4.3d/robot-controller-api') {
                    bat 'dotnet test'
                }
            }
        }

        stage('Code Quality') {
            steps {
                dir('D:/hp laptop aradhya data/c#/SIT_331/4.3d/robot-controller-api') {

                    bat """
                    C:\\WINDOWS\\system32\\config\\systemprofile\\.dotnet\\tools\\dotnet-sonarscanner begin ^
                    /k:"%SONAR_PROJECT_KEY%" ^
                    /o:"%SONAR_ORG%" ^
                    /d:sonar.token="%SONAR_TOKEN%"
                    """

                    bat 'dotnet build robot-controller-api.sln'

                    bat """
                    C:\\WINDOWS\\system32\\config\\systemprofile\\.dotnet\\tools\\dotnet-sonarscanner end ^
                    /d:sonar.token="%SONAR_TOKEN%"
                    """
                }
            }
        }

        stage('Security Scan') {
            steps {
                bat '"C:\\Users\\hp\\AppData\\Local\\Microsoft\\WinGet\\Packages\\AquaSecurity.Trivy_Microsoft.Winget.Source_8wekyb3d8bbwe\\trivy.exe" image robot-api'
            }
        }

        stage('Deploy') {
            steps {
                bat 'docker rm -f robot-container || exit 0'
                bat 'docker run -d -p 5001:80 --name robot-container robot-api'
            }
        }

        stage('Release') {
            steps {
                echo 'Release completed successfully'
            }
        }

        stage('Monitoring') {
            steps {
                echo 'Monitoring active - logs enabled'
            }
        }
    }
}