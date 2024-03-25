# heimdall-midgard-valkyrie
WIP = WORK IN PROGRESS

## Building container images
Build container images with the following command: docker-compose build --build-arg GITHUB_TOKEN={GITHUB_PAT_WITH_PACKAGE_READ_SCOPE_ON_NOVO_NORDISK_OPENSOURCE_ORG}

## Bootstrapping solution

### Assign GITHUB_TOKEN environment variable

To ensure migrations can fetch packages assign your local github token to a shell: EXPORT GITHUB_TOKEN={GITHUB_PAT_WITH_PACKAGE_READ_SCOPE_ON_NOVO_NORDISK_OPENSOURCE_ORG}

### Start processes

To bootstrap the requires application processes run the following command: docker-compose up