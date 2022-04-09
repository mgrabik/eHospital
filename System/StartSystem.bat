::docker login -u mpleszkun

docker network create -d bridge patient-network

docker-compose -f docker-composepatient.yaml config

docker-compose -f docker-composepatient.yaml ps

docker-compose -f docker-composepatient.yaml up --detach

docker network create -d bridge doctor-network

docker-compose -f docker-composedoctor.yaml config

docker-compose -f docker-composedoctor.yaml ps

::docker-compose -f docker-compose.yaml start

docker-compose -f docker-composedoctor.yaml up --detach

pause
