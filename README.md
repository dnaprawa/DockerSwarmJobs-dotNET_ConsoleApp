# Docker Swarm Jobs Using .NET Console App

###### This is an example of Docker Swarm Jobs based on .NET Core console app connected to PostgreSQL and configured with CRON intervals. 
#

### Development 

##### Run with docker-compose
####
```sh
$ docker-compose -f docker-compose.dev.yml build
$ docker-compose -f docker-compose.dev.yml up
```

##### Run without docker-compose
####
###### Before start, make sure PostgreSQL is running.

```sh
$ docker image build -f Dockerfile.consoleapp -t connector:1 .
$ docker run -e DATABASE_USER=<DB_USER> -e DATABASE_PASSWORD=<DB_PASS> \ 
    -e DATABASE_HOST=<DB_HOST> -e DATABASE_PORT=<DB_PORT -e DATABASE_NAME=<DB_NAME> \
    connector:1
```


### Production

##### Initialize Docker Swarm
####
```sh
$ docker swarm init
$ ./provisioning/run.sh
```


##### Run everything
####
```sh
$ ./provisioning/run.sh
```


