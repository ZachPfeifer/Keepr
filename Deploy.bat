dotnet publish -c Release
docker build -t <IMAGENAME.tolower> ./bin/Release/netcoreapp<VERSION>/publish
docker tag <IMAGENAME.tolower> registry.heroku.com/<YOURHEROKUAPP>/web
docker push registry.heroku.com/<YOURHEROKUAPP>/web
heroku container:release web -a <YOURHEROKUAPP>