::docker login -u mpleszkun

docker-compose -f docker-composedoctor.yaml stop

docker-compose -f docker-composedoctor.yaml ps

docker-compose -f docker-composedoctor.yaml down

docker-compose -f docker-composepatient.yaml stop

docker-compose -f docker-composepatient.yaml ps

docker-compose -f docker-composepatient.yaml down

pause
