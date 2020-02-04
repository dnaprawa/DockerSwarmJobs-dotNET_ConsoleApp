echo "Starting up..."

docker network create -d overlay connectors-overlay

docker stack deploy --compose-file=./docker-compose-postgres.yml pg-stack
docker stack deploy --compose-file=./docker-compose-swarmjobs.yml swarmjobs
docker stack deploy --compose-file=./docker-compose-connector.yml connector

exit 0
