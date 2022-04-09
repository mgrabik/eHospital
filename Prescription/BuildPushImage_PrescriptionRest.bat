docker login -u mpleszkun

docker images

::docker tag zsutpwpatternswebservicerest:latest mpleszkun/application:prescriptionrest

::docker rmi zsutpwpatternswebservicerest:latest

docker rmi mpleszkun/application:webservicerest

docker build -f Prescription.Rest/Dockerfile -t mpleszkun/application:prescriptionrest .

docker images

docker image ls --filter label=stage=prescriptionrest_build

::docker image prune --filter label=stage=prescriptionrest_build

docker push mpleszkun/application:prescriptionrest

::docker rmi mpleszkun/application:prescriptionrest

::docker images

::docker logout

pause
