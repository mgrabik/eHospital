::docker login -u mpleszkun

docker-compose -f docker-composedoctor.yaml config

docker-compose -f docker-composedoctor.yaml ps

docker-compose -f docker-composedoctor.yaml images

docker-compose -f docker-composepatient.yaml config

docker-compose -f docker-composepatient.yaml ps

docker-compose -f docker-composepatient.yaml images

pause
