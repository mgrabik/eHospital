::docker login -u mpleszkun

docker images

::docker tag zsutpwpatternswebservicerest:latest mpleszkun/application:visitrest

::docker rmi zsutpwpatternswebservicerest:latest

docker rmi mpleszkun/application:visitrest

docker build -f Visit.Rest2/Dockerfile -t mpleszkun/application:visitrest .

docker images

docker image ls --filter label=stage=visitrest_build

::docker image prune --filter label=stage=visitrest_build

::docker push mpleszkun/application:visitrest

::docker images

::docker logout

pause
