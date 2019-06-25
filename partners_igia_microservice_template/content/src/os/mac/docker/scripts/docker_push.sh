#!/bin/bash
echo "Running docker_push.sh"
CURRENT_DIRECTORY=$(pwd)
PROJECT_NAME="microservice_template"
DOCKER_NAME="partners/"$PROJECT_NAME
DOCKER_REGISTY="docker-registry-ppm.partners.org"
VERSION=2.2.1.4

dotnet build 
echo "CURRENT_DIRECTORY="$CURRENT_DIRECTORY
echo "DOCKER_NAME="$DOCKER_NAME
echo "DOCKER_REGISTY="$DOCKER_REGISTY
echo "VERSION="$VERSION
echo ""


echo "docker login $DOCKER_REGISTY"
docker login $DOCKER_REGISTY


echo "Start Tag"
echo "docker tag $PROJECT_NAME $DOCKER_REGISTY/$DOCKER_NAME:latest"
echo "docker tag $PROJECT_NAME $DOCKER_REGISTY/$DOCKER_NAME:release-$VERSION"
docker tag $PROJECT_NAME $DOCKER_REGISTY/$DOCKER_NAME:latest
docker tag $PROJECT_NAME $DOCKER_REGISTY/$DOCKER_NAME:release-$VERSION
echo "End Tag"
echo ""
echo ""
echo "Start Push"
echo "docker push $DOCKER_REGISTY/$DOCKER_NAME:latest"
echo "docker push $DOCKER_REGISTY/$DOCKER_NAME:release-$VERSION"
echo "End Push"
docker push $DOCKER_REGISTY/$DOCKER_NAME:latest
docker push $DOCKER_REGISTY/$DOCKER_NAME:release-$VERSION
echo ""