::docker login -u mpleszkun

docker images

::docker tag zsutpwpatternswebservicerest:latest mpleszkun/application:connectpatientrest

::docker rmi zsutpwpatternswebservicerest:latest

docker rmi mpleszkun/application:connectpatientrest

docker build -f ConnectPatient.REST/Dockerfile -t mpleszkun/application:connectpatientrest .

docker images

docker image ls --filter label=stage=connectpatientrest_build

::docker image prune --filter label=stage=connectpatientrest_build

::docker push mpleszkun/application:connectpatientrest

::docker images

::docker logout

pause
