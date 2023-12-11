pipeline {
    agent any
	
    stages {

	stage('Remove Containers') {
            steps {
                echo 'Remove Containers'
		if [ -n "$(docker ps -f "name=db" -f "status=running" -q )" ] ; then docker rm -f db
		fi
		sleep 2

		if [ -n "$(docker ps -f "name=web" -f "status=running" -q )" ] ; then docker rm -f web
		fi
		sleep 2
            }
        }
        stage('Build') {
            steps {
                
                echo "Building.."
                sh "docker compose build"
                }
            }
	
        stage('Test') {
            steps {
                echo "Testing.."
                sh "dotnet restore src/Server/Server.csproj"
                
            }
        }
	stage('Container Down') {
            steps {
                echo 'Docker container down'
                sh "docker compose down"
            }
        }
        stage('Container Up') {
            steps {
                echo 'Docker container up'
                sh "docker compose up -d"
            }
        }

    }
}
