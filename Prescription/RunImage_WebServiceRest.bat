docker login -u mpleszkun

docker ps -a

docker start webservice

docker ps 

docker images

docker pull atomaszewski/application:webservicerest

docker run -d -p 8080:80 -p 44300:443 --name webservice atomaszewski/application:webservicerest

docker inspect webservice

curl -X GET "http://localhost:8080/Network/GetNodes?searchText=xxx" -H "accept: application/json"

docker stop webservice

docker rm webservice

pause
