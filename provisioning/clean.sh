echo "Cleaning up..."

docker stack rm connector
docker stack rm pg-stack
docker stack rm swarmjobs

docker network rm connectors-overlay