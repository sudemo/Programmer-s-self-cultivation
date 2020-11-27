dotnet build

cd src/ui/ng-alain
npm install && npm run-script build && del ..\..\colibri.kanban.Web\wwwroot\* /q && copy dist\* ..\..\colibri.kanban.Web\wwwroot\ && cd ..\..\colibri.kanban.Web && dotnet build -c Release && dotnet publish -c Release && cd ..\..\ && docker build -t colibri.kanban.web .
