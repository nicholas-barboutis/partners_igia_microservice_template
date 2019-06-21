#!/bin/bash
echo "running docker_jhipster.sh"
STACK=jhipster_stack
PROJECT_DIRECTORY=$1
DEPLOY_DIRECTORY=$PROJECT_DIRECTORY/Docker_Support/docker_deploy
echo PROJECT_DIRECTORY=$PROJECT_DIRECTORY
echo DEPLOY_DIRECTORY=$DEPLOY_DIRECTORY
cd $DEPLOY_DIRECTORY
echo CUR_DIR=$(pwd)

echo "docker-compose up -f ./docker-compose-jhipster.yml -d -p $STACK up"
docker-compose -f ./docker-compose-jhipster.yml -p $STACK up -d

