#!/bin/bash
echo "running docker_deploy.sh"
CURRENT_DIRECTORY=$(pwd)
SOLUTION_DIRECTORY=$1
SOLUTION_NAME=$2
PROJECT_DIRECTORY=$3
PROJECT_NAME=$4
DEPLOY_DIRECTORY=$PROJECT_DIRECTORY/Docker_Support/docker_deploy
PUBLISH_DIRECTORY=$DEPLOY_DIRECTORY/publish
STACK="jhipster_stack"

echo "CURRENT_DIRECTORY="$CURRENT_DIRECTORY
echo "SOLUTION_DIRECTORY="$SOLUTION_DIRECTORY
echo "SOLUTION_NAME="$SOLUTION_NAME
echo "PROJECT_DIRECTORY="$PROJECT_DIRECTORY
echo "PROJECT_NAME="$PROJECT_NAME
echo "DEPLOY_DIRECTORY="$DEPLOY_DIRECTORY
echo "PUBLISH_DIRECTORY="$PUBLISH_DIRECTORY
echo "STACK="$STACK
echo ""
echo "Deleting Publish Folder:"$PUBLISH_DIRECTORY
rm -rf $PUBLISH_DIRECTORY
echo ""
echo "Start Restore for solution:"$SOLUTION_DIRECTORY/$SOLUTION_NAME.sln
echo "dotnet restore $SOLUTION_DIRECTORY/$SOLUTION_NAME.sln"
echo ""
dotnet restore $SOLUTION_DIRECTORY/$SOLUTION_NAME.sln
echo ""
echo "Start Build"
echo "dotnet build $SOLUTION_DIRECTORY/$SOLUTION_NAME.sln"
echo ""


dotnet build $SOLUTION_DIRECTORY/$SOLUTION_NAME.sln
echo "End Build"
echo ""
echo "Start Publish"
echo "dotnet publish $SOLUTION_DIRECTORY/$SOLUTION_NAME.sln -c Release -o $PUBLISH_DIRECTORY"
echo ""
dotnet publish $SOLUTION_DIRECTORY/$SOLUTION_NAME.sln -c Release -o $PUBLISH_DIRECTORY
echo "End Publish"  
echo ""

cd $DEPLOY_DIRECTORY
echo "docker-compose -p $STACK up -d --build"
docker-compose -p $STACK up -d --build
echo ""
echo "Deleting Publish Folder:"$PUBLISH_DIRECTORY
rm -rf $PUBLISH_DIRECTORY
echo ""
echo ""
cd $CURRENT_DIRECTORY
echo $(pwd)
