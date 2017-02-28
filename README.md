# siaPOS

## Creating...

### simple content

-. The POS program was written as a Windows application and the DB used MS-SQL Server.

-. Database I / O was handled using stored procedures and triggers without inline coding.

-. Stored Procedure was created by creating CLR stored procedure in TSQL and C # and injecting dll file into DBMS.

-. WEB part is ASP, design is using css style sheet and PhotoShop.

-. The WEB part is responsible for querying and analyzing the data collected in the Windows application. The part that modifies or deletes the data in the database is treated as the stored procedure, and the part related to the query or operation is the LINQ technique.

-.Mobile is based on the Android platform, and can be used to retrieve sales-related data for the convenience of users.

-.When you invoke a method in Android Application using WSDL technology, you receive data in SOAP way use the ksoap2 library for parsing.


###※This program was created in 2011.
