# Sandbox
Ntier, C# & AspMvc

## How To
### Projet de démarrage
1 AspMvc
### BD
La base de données est un fichier mdf (/DAL/Database1.mdf)
Dans les fichiers app.config du projet "1 AspMvc" et DAL.
Configuration de chemin absolu à modifier : "c:\Ntier\Sandbox\DAL\Database1.mdf"
```
connectionStrings>
    <add name="modelEntities1" connectionString="metadata=res://*/Entities.Model1.csdl|res://*/Entities.Model1.ssdl|res://*/Entities.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=c:\Ntier\Sandbox\DAL\Database1.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
  ```


