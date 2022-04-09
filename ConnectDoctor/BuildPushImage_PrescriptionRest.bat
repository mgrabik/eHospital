::docker login -u mpleszkun

docker images

::docker tag zsutpwpatternswebservicerest:latest mpleszkun/application:connectdoctorrest

::docker rmi zsutpwpatternswebservicerest:latest

docker rmi mpleszkun/application:connectdoctorrest

docker build -f ConnectDoctor.Rest/Dockerfile -t mpleszkun/application:connectdoctorrest .

docker images

docker image ls --filter label=stage=connectdoctorrest_build

::docker image prune --filter label=stage=connectdoctorrest_build

::docker push mpleszkun/application:connectdoctorrest

::docker images

::docker logout

pause
